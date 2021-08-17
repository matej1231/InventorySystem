using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour, IPointerClickHandler
{
    Button Button;
    public LoadItem LoadItem;

    private void Awake()
    {
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (LoadItem)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Button.onClick.AddListener(() =>
                {
                    LoadItem.DropItem();
                    Button.onClick.RemoveAllListeners();
                });
            }
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Button.onClick.AddListener(() =>
                {
                    LoadItem.Use();
                    if (LoadItem)
                    {
                        LoadItem.Destroy();
                    }
                    Button.onClick.RemoveAllListeners();
                });
            }
        }
    }
}
