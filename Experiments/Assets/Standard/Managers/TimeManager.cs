using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    private float slowDownLength;
    public bool needed = false;

    private void Update()
    {
        if(needed)
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.timeScale += (1 / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        
    }

    public void TimeConfig(float slowDownFactor, float slowDownLength)
    {
        needed = true;
        this.slowDownLength = slowDownLength;
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }

    public void TimeConfig(float slowDownFactor)
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }
}
