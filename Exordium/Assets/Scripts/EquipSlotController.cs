using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlotController : MonoBehaviour
{
    public LoadItem LoadItem;

    private void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        Text DisplayText = transform.Find("Text").GetComponent<Text>();
        Image DisplayImage = transform.Find("Image").GetComponent<Image>();

        if (LoadItem)
        {
            DisplayText.text = LoadItem.Item.ItemName;
            DisplayImage.sprite = LoadItem.Item.Icon;
            DisplayImage.color = Color.white;
        }
        else
        {
            DisplayText.text = "";
            DisplayImage.sprite = null;
            DisplayImage.color = Color.clear;
        }
    }
}
