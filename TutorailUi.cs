using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailUi : MonoBehaviour
{
    public GameObject PlayerUi;
    public GameObject ScoreUi;
    public GameObject[] Spawner;
    public bool ReadyToPlay;

    private void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            Time.timeScale = 1;
            PlayerUi.SetActive(true);
            ScoreUi.SetActive(true);
            Spawner[0].SetActive(true);
            Spawner[1].SetActive(true);
            ReadyToPlay = true;
            Destroy(this.gameObject);
        }
    }
}
