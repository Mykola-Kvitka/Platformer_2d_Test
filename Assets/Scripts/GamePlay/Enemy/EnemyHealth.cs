using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100;

    private float _health;

    private void Start()
    {

        _health = totalHealth;
        healthSlider.maxValue = _health;
        healthSlider.value = _health;

    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        healthSlider.value = _health;
        if (_health <= 0f)
        {
            Die();
        }
    
    }

    private void Die()
    {
        gameObject.SetActive(false);
    
    }
}
