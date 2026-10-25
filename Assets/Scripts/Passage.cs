using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Passage : MonoBehaviour {
    
    [SerializeField] private Transform exitPoint;

    private Vector2 exitPosition;

    private void OnTriggerEnter2D(Collider2D collider2D) {
        collider2D.GetComponent<ITeleportable>().TeleportTo(exitPoint.position);
    }
}
