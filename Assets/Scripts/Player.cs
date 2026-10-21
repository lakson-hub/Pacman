using System;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player Instance { get; private set; }
    
    private static readonly Vector2 BOX_SIZE = new Vector2(.8f, .8f);

    public event EventHandler OnWalkingChanged;

    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private LayerMask obstaclesLayerMask;

    private Vector2 currentDirection;
    private Vector2 queuedDirection;
    private bool isWalking;

    private void Awake() {
        Instance = this;
    }

    private void Update() { 
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 movementDirection = playerInput.GetMovementVectorNormalized();

        if (movementDirection != Vector2.zero) {
            queuedDirection = movementDirection;
        }

        float movementDistance = movementSpeed * Time.deltaTime;

        if (queuedDirection != Vector2.zero && CanMove(queuedDirection, movementDistance)) {
            currentDirection = queuedDirection;
        }

        bool hasMoved = false;

        if (currentDirection != Vector2.zero && CanMove(currentDirection, movementDistance)) {
            transform.position += (Vector3)(currentDirection * movementDistance);
            hasMoved = true;
        }
        
        SetWalking(hasMoved);
    }

    private void SetWalking(bool isWalking) {
        if (this.isWalking == isWalking) return;

        this.isWalking = isWalking;
        OnWalkingChanged?.Invoke(this,EventArgs.Empty);
    }

    private bool CanMove(Vector2 direction, float distance) {
        return !Physics2D.BoxCast(transform.position, BOX_SIZE, 0f, direction, distance,
            obstaclesLayerMask);
    }

    public bool GetPlayerIsWalking() {
        return isWalking;
    }
}