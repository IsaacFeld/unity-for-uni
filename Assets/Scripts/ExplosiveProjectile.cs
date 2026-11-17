using System;
using System.Collections;
using UnityEngine;


public class ExplosiveProjectile : MonoBehaviour
{


    [SerializeField] private GameObject Projectile;

    private bool exploded;
    
    public float speed = 1000.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exploded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = 0.01f * speed;
        transform.Translate(Vector3.up * amountToMove * Time.deltaTime, Space.Self);
        if (transform.position.y > 5 && !exploded)
        {
            explode();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Asteroid")
        {
            explode();
        }

    }

    private void explode()
    {
        if (!exploded)
        {
            
            Destroy(gameObject);
            /* Spawn other Projectiles */
            Instantiate(Projectile, transform.position, Quaternion.identity);
            exploded = true;
        }
        
            
    }
}