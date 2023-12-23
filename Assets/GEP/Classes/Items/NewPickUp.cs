using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPickUp : MonoBehaviour
{
    private Inventory inventory;
    private GameObject itemButton;
    private string itemName;

    public Cube cube;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        itemName = cube.item_name;
        itemButton = cube.item_button;

        GetComponent<Renderer>().material = cube.item_material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true)
                {
                    if (inventory.slots[i].transform.GetComponent<ItemSlot>().amount < 2)
                    {
                        if (itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName)
                        {
                            Destroy(gameObject);
                            inventory.slots[i].GetComponent<ItemSlot>().amount += 1;
                            break;
                        }
                    }
                }
                else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<ItemSlot>().amount += 1;
                    inventory.slots[i].GetComponent<ItemSlot>().item_name = itemName;
                    inventory.slots[i].GetComponent<ItemSlot>().description = cube.description;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
