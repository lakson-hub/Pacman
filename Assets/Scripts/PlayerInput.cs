using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    
    public static PlayerInput Instance { get; private set; }
    
    public enum Binding {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
    }

    private PlayerInputActions playerInputActions;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void OnDestroy() {
        playerInputActions.Dispose();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}