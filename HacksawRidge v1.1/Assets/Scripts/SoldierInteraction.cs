using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierInteraction : MonoBehaviour
{
    public GameObject pressE;
    public GameObject healing;

    private PlayerMovement playerMovement;
    public SoldierArea soldierArea;

    private bool isPlayerInRange = false;

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
        pressE.SetActive(false);
        healing.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenHealing();
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseHealing();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            pressE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            pressE.SetActive(false);
        }
    }

    private void OpenHealing()
    {
        healing.SetActive(true);
        playerMovement.enabled = false;
    }

    private void CloseHealing()
    {
        healing.SetActive(false);
        playerMovement.enabled = true;

        soldierArea.CompleteHealing(); // not gonna be here later
    }
}
