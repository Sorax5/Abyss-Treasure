using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    bool timerActive = true;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true) 
        {
            currentTime = currentTime - Time.deltaTime;
        }
        currentTimeText.text = currentTime.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public float getTimer()
    {
        return this.currentTime;
    }
}
