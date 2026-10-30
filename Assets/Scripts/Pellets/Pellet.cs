using System;
using UnityEngine;

public class Pellet : MonoBehaviour, IEdible {

    public static event EventHandler<OnAnyPelletEatenEventArgs> OnAnyPelletEaten;
    public sealed class OnAnyPelletEatenEventArgs : EventArgs {
        private readonly PelletSO pelletSO;

        public OnAnyPelletEatenEventArgs(PelletSO pelletSO) {
            this.pelletSO = pelletSO;
        }

        public PelletSO GetPelletSO() {
            return pelletSO;
        }
    }

    [SerializeField] private PelletSO pelletSO;

    private bool isEaten;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStaticData() {
        OnAnyPelletEaten = null;
    }

    public void Eat() {
        if (isEaten) return;
        isEaten = true;
        
        Destroy(gameObject);
        OnAnyPelletEaten?.Invoke(this, new OnAnyPelletEatenEventArgs(pelletSO));
    }
}
