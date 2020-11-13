using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField]float coolDown;
    bool IsCoolDown;

    void Update()
    {
        if (IsCoolDown == false)
        {
            coolDown = 5f;
            IsCoolDown = true;
        }
        else
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
