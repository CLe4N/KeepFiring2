using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ZombiePrefab;
    AudioSource zombieRoar;
    int spawnNum;
    bool IsRespawn;
    float coolDown;

    float spawnCD;
    float SpawnTime = 2.5f;
    bool Is_CD;

    private void Start()
    {
        zombieRoar = GameObject.Find("ZombieRoar").transform.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (SpawnTime > 0.99)
        {
            if (Is_CD == false)
            {
                spawnCD = 10;
                Is_CD = true;
            }
            else
            {
                if (spawnCD > 0)
                {
                    spawnCD -= Time.deltaTime;
                }
                else
                {
                    Is_CD = false;
                    spawnCD = 0;
                    SpawnTime -= 0.2f;
                }
            }
        }
        Respawn(SpawnTime);
    }

    void Respawn(float RespawmCD)
    {
        if (IsRespawn == false)
        {
            spawnNum = Random.Range(1, 6);
            if (spawnNum >= 5)
            {
                Instantiate(ZombiePrefab[1], new Vector2(Random.Range(-6, 6), transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(ZombiePrefab[0], new Vector2(Random.Range(-6, 6), transform.position.y), Quaternion.identity);
            }
            zombieRoar.Play();
            IsRespawn = true;
            coolDown = RespawmCD;
        }
        if(IsRespawn == true)
        {
            if(coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                IsRespawn = false;
            }
        }
    }
}
