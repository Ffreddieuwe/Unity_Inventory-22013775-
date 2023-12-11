using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public string itemName;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<ItemSlot>().amount > 2)
                {
                    if (itemName == inventory.slots[i].transform.GetComponent<Spawn>().itemName)
                    {
                        Destroy(gameObject);
                        inventory.slots[i].GetComponent<ItemSlot>().amount += 1;
                        break;
                    }
                }
                else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<ItemSlot>().amount += 1;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
