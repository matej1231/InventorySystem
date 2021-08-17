using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<LoadItem> List = new List<LoadItem>();

    public GameObject InventoryPanel;
    public GameObject InventoryFullText;

    private int _listLength = 32;

    public Transform Player;
    public static InventoryManager Instance;

    void Start()
    {
        Player = GameObject.Find("Character").transform;
        Instance = this;
        UpdatePanelSlots();
    }

    public void UpdatePanelSlots()
    {
        int _index = 0;
        foreach (Transform child in InventoryPanel.transform)
        {
            InventorySlotController Slot = child.GetComponent<InventorySlotController>();

            if(_index < List.Count)
            {
                Slot.LoadItem = List[_index];
            }
            else
            {
                Slot.LoadItem = null;
            }

            Slot.UpdateInfo();
            _index++;
        }
    }

    public bool Add(LoadItem LoadItem)
    {
        if (List.Count < _listLength) {
            List.Add(LoadItem);
            UpdatePanelSlots();
            return true;
        }
        else
        {
            Debug.Log("Inventory full!");
            return false;
        }
    }

    public void DropItem(LoadItem LoadItem)
    {
        List.Remove(LoadItem);
        UpdatePanelSlots();
    }

    public void Use(LoadItem LoadItem)
    {
        if(LoadItem != null)
        {
            DropItem(LoadItem);
            EquipManager.Instance.EquipItem(LoadItem);
        }
    }
}
