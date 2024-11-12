using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierArea : MonoBehaviour
{
    public Timer timerScript;
    public GameObject timer;
    private bool hasTimerStarted = false;

    public GameObject barrier;
    private bool isTaskCompleted = false;

    private void Start()
    {
        timer.SetActive(false);
        barrier.SetActive(false);
    }

    private void Update()
    {
        if (hasTimerStarted && timerScript.IsTimerExpired())
        {
            EndTask();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTimerStarted && !isTaskCompleted)
        {
            timer.SetActive(true);
            barrier.SetActive(true);
            Debug.Log("Barrier Activated");
            timerScript.StartTimer();
            hasTimerStarted = true;
        }

    }

    public void CompleteHealing()
    {
        isTaskCompleted = true;
        EndTask();
    }

    private void EndTask()
    {
        barrier.SetActive(false);
        timer.SetActive(false);
        hasTimerStarted = false;
    }
}
