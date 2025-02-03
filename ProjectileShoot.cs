using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    //Declare projectile as an object
    public GameObject projectilePrefab;
    //Initialize shooting to allow fireing normal and with powerups
    private int shooting;

    void Start()
    {
        //Declare what the starting shot type is
        shooting = 1;
    }


    private void Update()
    {
        //Starts the shooting loop
        Shooting();
    }
    void Shooting()
    {
        //Shoots with LMB
        if (Input.GetButtonDown("Fire1"))
        {
            switch (shooting)
            {
                //Normal shots
                case 1:
                    Instantiate(projectilePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    break;
                //Double-shots
                case 2:
                    Instantiate(projectilePrefab, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                    Instantiate(projectilePrefab, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                    break;
            }
        }
    }
    //Wait a few seconds before lose powerup
    IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(4f);
        shooting = 1;
    }
    //Pickup powerup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            shooting = 2;
            StartCoroutine(PowerDown());
            Destroy(collision.gameObject);
        }
    }
}
