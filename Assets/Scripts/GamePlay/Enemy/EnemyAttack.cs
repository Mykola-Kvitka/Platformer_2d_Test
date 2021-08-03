using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ZeroInvokerEvent
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private float timeToDamage = 1f;

    private float _damagetime;

    private bool _isDamage = true;

    private void Start()
    {
        _damagetime = timeToDamage;
        unityEventsZ.Add(EventName.ReducePlayerHealthAnim, new PlayerAttackAnimEvent());
        EventManager.AddZeroInvoker(EventName.ReducePlayerHealthAnim, this);
    }
    private void Update()
    {
        if(!_isDamage)
        {
            _damagetime -= Time.deltaTime;
            if(_damagetime <=0f)
            {
                _isDamage = true;
                _damagetime = timeToDamage;

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null && _isDamage)
        {
            unityEventsZ[EventName.ReducePlayerHealthAnim].Invoke();
            _isDamage = false;
            playerHealth.ReduceHealth(damage);
        }
    }
}
