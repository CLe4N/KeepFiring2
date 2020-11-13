using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMedKit : MonoBehaviour
{
    Hp_con hp;
    AudioSource healSFX;
    private void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Hp_con>();
        healSFX = GameObject.Find("HealSFX").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hp.hp += 1;
            healSFX.Play();
            Destroy(this.gameObject);
        }
    }
}
