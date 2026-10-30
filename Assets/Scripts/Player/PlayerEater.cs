using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerEater : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.TryGetComponent(out IEdible edible)) {
            edible.Eat();
        }
    }
}
