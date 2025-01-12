using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public void PlayLevel6()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainManu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
