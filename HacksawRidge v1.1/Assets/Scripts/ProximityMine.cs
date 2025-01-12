using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximityMine : MonoBehaviour
{
    public GameObject deathScreen;
    private float restartDelay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Invoke(nameof(RestartScene), restartDelay);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
