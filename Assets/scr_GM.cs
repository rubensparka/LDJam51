using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GM : MonoBehaviour
{
    public float TheTimer = 0f;
    public bool TimerSwitch = false;

    // Update is called once per frame
    void Update()
    {
        //10 Second Timer
        if (TheTimer >= 10f)
        {
            TheTimer = 0f;
            TimerSwitch = !TimerSwitch;
        }
        TheTimer += Time.deltaTime;
    }
}