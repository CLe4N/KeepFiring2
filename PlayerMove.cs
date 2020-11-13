using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public TutorailUi Tutorail_Stat;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Tutorail_Stat.ReadyToPlay == true)
        {
            float axisX = Input.GetAxisRaw("Horizontal");
            float axisY = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(axisX * speed, axisY * speed);
        }
    }
}
