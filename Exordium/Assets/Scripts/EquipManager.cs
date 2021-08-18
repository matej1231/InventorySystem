using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public List<LoadItem> EquipItems = new List<LoadItem>();

    private int _listLength = 4;

    public static EquipManager Instance;

    public GameObject EquipPanel;

    private void Start()
    {
        Instance = this;
        UpdatePanelSlots();
    }
    public void UpdatePanelSlots()
    {
        int _index = 0;
        foreach (Transform child in EquipPanel.transform)
        {
            EquipSlotController Slot = child.GetComponent<EquipSlotController>();

            if (_index < EquipItems.Count)
            {
                Slot.LoadItem = EquipItems[_index];
            }
            else
            {
                Slot.LoadItem = null;
            }

            Slot.UpdateInfo();
            _index++;
        }
    }

    public void EquipItem(LoadItem LoadItem)
    {
        if (LoadItem.Item.Equipment)
        {
            if (EquipItems.Count < _listLength)
            {
                InventoryManager.Instance.DropItem(LoadItem);
                EquipItems.Add(LoadItem);
                UpdatePanelSlots();
            }
            else
            {
                Debug.Log("Equipment full!");
            }
        }
        else
        {
            Debug.Log("Cannot equip " + LoadItem.Item.ItemName);
        }
    }
}
