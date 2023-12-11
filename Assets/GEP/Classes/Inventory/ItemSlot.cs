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

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        if (transform.childCount == 4)
        {
            inventory.isFull[i] = false;
        }
    }
}
