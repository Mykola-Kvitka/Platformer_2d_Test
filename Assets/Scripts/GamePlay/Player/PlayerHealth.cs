using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : ZeroInvokerEvent
{
    [SerializeField] private Slider healthSlider;

    [SerializeField] private float totalHealth = 100;

    private float _health;
    private void Start()
    {
        unityEventsZ.Add(EventName.ReducePlayerHealthAnim, new ReducePlayerHealthAnimEvent());
        EventManager.AddZeroInvoker(EventName.ReducePlayerHealthAnim, this);
        
        unityEventsZ.Add(EventName.GameOver, new GameOverEvent());
        EventManager.AddZeroInvoker(EventName.GameOver, this);

        _health = totalHealth;
        healthSlider.maxValue = _health;
        healthSlider.value = _health;

    }
    public void ReduceHealth(float damage)
    {
        unityEventsZ[EventName.ReducePlayerHealthAnim].Invoke();

        _health -= damage;
        healthSlider.value = _health;
        if (_health <= 0f)
        {
            Die();
        }

    }

    private void Die()
    {
        unityEventsZ[EventName.GameOver].Invoke();

        gameObject.SetActive(false);

    }
}
