using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour {
    
    public static PlayerInput Instance { get; private set; }
    
    [SerializeField, Range(0.01f, 0.3f)] private float swipeThresholdPercent = 0.06f;
    
    private readonly SwipeDetector swipeDetector = new SwipeDetector();

    private PlayerInputActions playerInputActions;
    private Vector2 lastDirection;
    private Vector2 swipeDirection;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update() {
        HandleSwipe();
    }

    private void LateUpdate() {
        swipeDirection = Vector2.zero;
    }

    private void OnDestroy() {
        playerInputActions.Player.Disable();
        playerInputActions.Dispose();
    }

    private void HandleSwipe() {
        var touchPress = playerInputActions.Player.TouchPress;
        var touchPosition = playerInputActions.Player.TouchPosition;

        if (touchPress.WasPressedThisFrame()) {
            swipeDetector.Begin(touchPosition.ReadValue<Vector2>());
        }

        if (touchPress.IsPressed() && swipeDetector.TryToDetectSwipe(touchPosition.ReadValue<Vector2>(),
                GetSwipeThresholdPixels(), out Vector2 detectedDirection)) {
            swipeDirection = detectedDirection;
        }

        if (touchPress.WasReleasedThisFrame()) {
            swipeDetector.End();
        }
    }

    private float GetSwipeThresholdPixels() {
        return Mathf.Min(Screen.width, Screen.height) * swipeThresholdPercent;
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        if (inputVector.x != 0f && inputVector.y != 0f) {
            if (lastDirection.x != 0f) {
                inputVector.y = 0f;
            } else {
                inputVector.x = 0f;
            }
        }
        
        if (inputVector == Vector2.zero) {
            inputVector = swipeDirection;
        }
        
        inputVector = inputVector.normalized;
        lastDirection = inputVector;

        return inputVector;
    }
}