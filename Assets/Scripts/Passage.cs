using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Passage : MonoBehaviour {
    
    [SerializeField] private Transform exitPoint;
    [SerializeField] private Player player;

    private Vector2 exitPosition;

    private void OnTriggerEnter2D(Collider2D collider2D) {
        player.TeleportTo(exitPoint.position);
    }
}
