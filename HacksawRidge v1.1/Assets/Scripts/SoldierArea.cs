using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierArea : MonoBehaviour
{
    public Timer timerScript;
    public GameObject timer;
    private bool hasTimerStarted = false;

    private void Start()
    {
        timer.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTimerStarted)
        {
            timer.SetActive(true);
            timerScript.StartTimer();
            hasTimerStarted = true;
        }

    }
}
