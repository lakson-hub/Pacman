using UnityEngine;

[CreateAssetMenu(fileName = "PelletSO", menuName = "Pacman/PelletSO")]
public class PelletSO : ScriptableObject {
    
    [SerializeField, Min(0)] private int points;
    
    public int GetPoints() {
        return points;
    }
}
