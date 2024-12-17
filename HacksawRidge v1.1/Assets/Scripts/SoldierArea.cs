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

    private float customTime;

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

    public void SetTimerDuration(float time)
    {
        customTime = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTimerStarted && !isTaskCompleted)
        {
            timer.SetActive(true);
            barrier.SetActive(true);
            Debug.Log("Barrier Activated");
            timerScript.StartTimerWithTime(customTime);
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

        //docasne riesienie, kym nebude hotovy system liecenia
        Debug.Log("Soldier task ended. Destroying soldier.");
        Destroy(transform.parent.gameObject);
    }
}
