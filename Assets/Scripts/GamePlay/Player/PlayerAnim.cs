using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float horizontal;
    private void Start()
    {
        EventManager.AddZeroListener(EventName.MovePlayer, PlayMovementAnim);
        EventManager.AddZeroListener(EventName.PlayerAttackAnim, PlayAttackAnim);
        EventManager.AddZeroListener(EventName.ReducePlayerHealthAnim, ReducePlayerHealthAnim);
    }

    private void PlayMovementAnim()
    {
        horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("MoveSpeed", Mathf.Abs(horizontal));
    }
    private void PlayAttackAnim()
    {
        animator.SetTrigger("attack");
    }
    private void ReducePlayerHealthAnim()
    {
        animator.SetTrigger("takeDamage");
    }
}
