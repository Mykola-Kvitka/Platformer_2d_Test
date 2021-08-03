using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : ZeroInvokerEvent
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        unityEventsZ.Add(EventName.LeverArm, new LeverArmEvent());
        EventManager.AddZeroInvoker(EventName.LeverArm, this);

        EventManager.AddZeroListener(EventName.LeverArmActive, Activate_Animator);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            unityEventsZ[EventName.LeverArm].Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            unityEventsZ[EventName.LeverArm].Invoke();

        }
    }
    private void Activate_Animator()
    {
        _animator.SetTrigger("activate");
    }
}
