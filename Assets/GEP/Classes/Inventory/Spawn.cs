using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject itemPrefab;
    private Transform playerTransform;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem()
    {
        Vector3 playerPos = new Vector3(playerTransform.position.x, playerTransform.position.y + 1, playerTransform.position.z + 3);
        Instantiate(itemPrefab, playerPos, Quaternion.identity);
    }
}
