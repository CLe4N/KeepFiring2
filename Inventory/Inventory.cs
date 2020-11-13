using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slot;
    public UseItem[] Item;

    private void Update()
    {
        if (slot[0].transform.childCount > 1)
        {
            Item[0] = slot[0].transform.GetChild(1).GetComponent<UseItem>();
        }
        if (slot[1].transform.childCount > 1)
        {
            Item[1] = slot[1].transform.GetChild(1).GetComponent<UseItem>();
        }

        ItemKey();
    }

    void ItemKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (slot[0].transform.childCount > 1)
            {
                Item[0].CreateActiveItem();
                Destroy(slot[0].transform.GetChild(1).gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (slot[1].transform.childCount > 1)
            {
                Item[1].CreateActiveItem();
                Destroy(slot[1].transform.GetChild(1).gameObject);
            }
        }
    }
}

