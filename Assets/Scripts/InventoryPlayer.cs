using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPlayer : MonoBehaviour
{
    public GameObject Slots;
    public GameObject[] inventorySlot = new GameObject[28];

    void Start()
    {
        for (int i = 0; i < inventorySlot.Length; i++)
        {
            for (int k = 0; k <= i; k++)
            {
                inventorySlot[i] = Slots.transform.GetChild(k).gameObject;
            }
        }
    }
}
