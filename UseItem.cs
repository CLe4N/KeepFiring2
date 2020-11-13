using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject ActiveItem;
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    public void CreateActiveItem()
    {
        Instantiate(ActiveItem, Player.position, Quaternion.identity);
    }
}
