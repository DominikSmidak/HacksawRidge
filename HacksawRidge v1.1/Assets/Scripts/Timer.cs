using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float time;
    private float remainingTime;
    private bool isCountingDown = false;
    //private float customTime = 0f;

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
                // Custom functionality when timer ends
            }

            UpdateTimerUI();
        }
    }

    public void StartTimerWithTime(float customTime)
    {
        time = customTime;
        remainingTime = customTime;
        isCountingDown = true;

        Debug.Log($"Timer started with custom time: {time} seconds");
    }

    public void SetTimerText(TextMeshProUGUI textComponent)
    {
        timerText = textComponent;
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public bool IsTimerExpired()
    {
        return !isCountingDown && remainingTime <= 0;
    }
}
