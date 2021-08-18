using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItem : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Item Item;

    private bool _canAddToInventory;

    public GameObject InventoryFullText;

    void Start()
    {
        SpriteRenderer.sprite = Item.Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _canAddToInventory = InventoryManager.Instance.Add(this);
            if (_canAddToInventory)
            {
                Debug.Log("Picked up " + Item.ItemName);
                this.gameObject.SetActive(false);
            }
            else
            {
                Instantiate(InventoryFullText, transform.position, Quaternion.identity);
            }
        }
    }

    public void DropItem()
    {
        InventoryManager.Instance.DropItem(this);
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = InventoryManager.Instance.Player.position + new Vector3(0,-1, 0);
        Debug.Log(Item.ItemName + " dropped!");
    }

    public void Use()
    {
        InventoryManager.Instance.Use(this);
    }
}
