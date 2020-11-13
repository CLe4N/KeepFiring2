using UnityEngine;

public class ActiveRocket : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 direction;
    public GameObject BoomEffect;
    AudioSource RocketSFX;
    AudioSource ExplosionSFX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2d
        RocketSFX = GameObject.Find("RocketSFX").GetComponent<AudioSource>(); // Find "RocketSFX" and get AudioSource
        ExplosionSFX = GameObject.Find("ExplosionSFX").GetComponent<AudioSource>(); // Find "ExplosionSFX" and get AudioSource
        Vector3 mousePos = Input.mousePosition; //Get mouse position 
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); // calculate mouse position form main camera screen to world point

        direction = new Vector2 // Calculate this gameobject position and "main-cam view mouse position" to find direction 
            (mousePos.x - transform.position.x,
             mousePos.y - transform.position.y);

        transform.up = direction; //rotate to "direction"'s direction 
        rb.velocity = transform.up * 10f; // this object has 10 velocity facing front of this object
        RocketSFX.Play(); // Play "RocketSFX"

    }

    private void OnTriggerEnter2D(Collider2D collision)// Do this method on Trigger collider is enter;
    {
        if (collision.tag != "Player") // in other collider is don't has tag "Player"
        {
            Instantiate(BoomEffect, transform.position, Quaternion.identity); // create "BoomEffect" object
            ExplosionSFX.Play(); // Play "ExplosionSFX"
            Destroy(this.gameObject); // Destroy this object
        }
    }

}
