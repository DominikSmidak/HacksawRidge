using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float time;
    private float remainingTime;
    private bool isCountingDown = false;

    void Start()
    {
        remainingTime = time;
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                Debug.Log("Timer has finished!");
                isCountingDown = false;
                remainingTime = 0;
                //funkcia
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }

    public void StartTimer()
    {
        Debug.Log("Timer started!");
        isCountingDown = true;
        remainingTime = time;
    }

    public bool IsTimerExpired()
    {
        return !isCountingDown && remainingTime <= 0;
    }
}
