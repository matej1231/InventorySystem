using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    Button Button, EquipButton;
    public LoadItem LoadItem;

    GameObject Child;

    private void Awake()
    {
        EquipButton = GetComponentInChildren<Button>();
        Child = transform.GetChild(2).gameObject;
        EquipButton = Child.gameObject.GetComponent<Button>();
        Button = GetComponent<Button>();
    }
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
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(() =>
            {
                LoadItem.DropItem();
                Button.onClick.RemoveAllListeners();
            });

            EquipButton.onClick.RemoveAllListeners();
            EquipButton.onClick.AddListener(() =>
            {
                LoadItem.Use();
                EquipButton.onClick.RemoveAllListeners();
            });

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
