using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour
{
    private bool isActiveted = false;

    void Start()
    {
        EventManager.AddZeroListener(EventName.Finish, Finish);
        EventManager.AddZeroListener(EventName.Set_Active, Set_Active);
    }

    private void Finish()
    {
       if(isActiveted)
        gameObject.SetActive(false);
    }
    private void Set_Active()
    {
        isActiveted = true;
    }
}
