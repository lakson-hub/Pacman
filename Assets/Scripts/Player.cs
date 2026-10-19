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
        Vector2 movementDirection = playerInput.GetMovementVectorNormalized();
        
        if (movementDirection == Vector2.zero) return;
        
        float movementDistance = movementSpeed * Time.deltaTime;

        float playerRadius = .4f;
        bool canMove = !Physics2D.CircleCast(transform.position, playerRadius, movementDirection, movementDistance, obstaclesLayerMask);

        if (canMove) {
            transform.position += (Vector3)(movementDirection * movementDistance);
        }
    }
}