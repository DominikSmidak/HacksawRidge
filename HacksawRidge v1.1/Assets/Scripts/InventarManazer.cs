using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarManazer : MonoBehaviour
{
    public GameObject InventarMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;


    void start()
        {

        }

    void Update()
        {
            if (Input.GetButtonDown("Inventar") && menuActivated)
            {
                InventarMenu.SetActive(false);
                menuActivated = false;
        }

            else if (Input.GetButtonDown("Inventar") && !menuActivated)
            {
                InventarMenu.SetActive(true);
                menuActivated = true;
            }
        }

}
