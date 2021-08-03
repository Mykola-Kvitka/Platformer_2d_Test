using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : ZeroInvokerEvent
{

    private bool _isAttack = false;

    public bool IsAttack {get => _isAttack;}

    public void FinishAttack()
    {
        _isAttack = false;
    }
    private void Start()
    {
        unityEventsZ.Add(EventName.PlayerAttackAnim, new PlayerAttackAnimEvent());
        EventManager.AddZeroInvoker(EventName.PlayerAttackAnim, this);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            unityEventsZ[EventName.PlayerAttackAnim].Invoke();
            _isAttack = true;
        }
    }
}
