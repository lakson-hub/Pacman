using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour {

    private static readonly int IS_WALKING = Animator.StringToHash("IsWalking");

    [SerializeField] private Player player;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        player.OnWalkingChanged += Player_OnWalkingChanged;
        
        animator.SetBool(IS_WALKING, player.GetPlayerIsWalking());
    }
    
    private void OnDisable() {
        player.OnWalkingChanged -= Player_OnWalkingChanged;
    }

    private void Player_OnWalkingChanged(object sender, EventArgs e) {
        animator.SetBool(IS_WALKING, player.GetPlayerIsWalking());
    }
}
