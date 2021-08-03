using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : FloatInvokerEvent
{
    [SerializeField]private float damage = 20.0f;

    private PlayerAttack _playerAttack;
    private void Start()
    {
        _playerAttack = transform.root.GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null && _playerAttack.IsAttack)
        {
            enemyHealth.ReduceHealth(damage);
        }
    }
}
