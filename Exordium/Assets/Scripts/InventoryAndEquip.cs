using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAndEquip : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject InventoryButton;

    public GameObject EquipPanel;
    public GameObject EquipButton;

    private bool _inventoryPanelActive;
    private bool _equipPanelActive;

    void Start()
    {
        InventoryPanel.SetActive(false);
        EquipPanel.SetActive(false);
    }

    void Update()
    {
        if(EquipPanel.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryOnOff();
            }
        }
        if (InventoryPanel.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EquipOnOff();
            }
        }
    }

    public void InventoryOnOff()
    {
        _inventoryPanelActive = !_inventoryPanelActive;

        if (_inventoryPanelActive)
        {
            InventoryPanel.SetActive(true);
            InventoryButton.SetActive(false);
            EquipButton.SetActive(false);
            PauseGame();
        }
        else if (_inventoryPanelActive == false)
        {
            InventoryPanel.SetActive(false);
            InventoryButton.SetActive(true);
            EquipButton.SetActive(true);
            ResumeGame();
        }
    }

    public void EquipOnOff()
    {
        _equipPanelActive = !_equipPanelActive;

        if (_equipPanelActive)
        {
            EquipPanel.SetActive(true);
            EquipButton.SetActive(false);
            InventoryButton.SetActive(false);
            PauseGame();
        }
        else if (_equipPanelActive == false)
        {
            EquipPanel.SetActive(false);
            EquipButton.SetActive(true);
            InventoryButton.SetActive(true);
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
