using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public TextMeshProUGUI amountText;
    public int amount;
    public TextMeshProUGUI nameText;
    public string item_name;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();
        nameText.text = item_name.ToString();

        if (amount < 1)
        {
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (item_name == "Empty")
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (transform.childCount == 3)
        {
            inventory.isFull[i] = false;
        }
    }

    public void Drop()
    {
        if (amount > 0)
        {
            amount--;
            transform.GetComponentInChildren<Spawn>().SpawnItem();

            if (amount == 0)
            {
                item_name = "Empty";
                GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
            }
        }
    }
}
