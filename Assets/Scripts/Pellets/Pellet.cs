using System;
using UnityEngine;

public class Pellet : MonoBehaviour, IEdible {

    public static event EventHandler OnAnyPelletEaten;

    private bool isEaten;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStaticData() {
        OnAnyPelletEaten = null;
    }

    public void Eat() {
        if (isEaten) return;
        isEaten = true;
        
        OnAnyPelletEaten?.Invoke(this,EventArgs.Empty);
        Destroy(gameObject);
    }
}
