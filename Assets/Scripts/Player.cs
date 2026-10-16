using System;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player Instance { get; private set; }

    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private LayerMask obstaclesLayerMask;

    private void Awake() {
        Instance = this;
    }

    private void Update() { 
        HandleMovement();   
    }

    private void HandleMovement() {
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
        Vector2 movementDirection = new Vector2(inputVector.x, inputVector.y);
        float movementDistance = movementSpeed * Time.deltaTime;

        float playerRadius = .5f;
        bool canMove = !Physics2D.CircleCast(transform.position, playerRadius, movementDirection, movementDistance, obstaclesLayerMask);

        if (canMove) {
            transform.position += (Vector3)(movementDirection * movementDistance);
        }
    }
}