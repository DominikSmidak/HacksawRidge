using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //======ITEM DATA======//
    public string itemName;
    public int pocet;
    public Sprite itemSprite;
    public bool isFull;

    //======ITEM SLOT======//
    [SerializeField]
    private TMP_Text PocetText;

    [SerializeField]
    private Image ItemImage;

public void AddItem(string itemName, int pocet, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.pocet = pocet;
        this.itemSprite = itemSprite;
        isFull = true;

        PocetText.text = pocet.ToString();
        PocetText.enabled = true;
        ItemImage.sprite = itemSprite;
    }
  
}
