using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1000.0f;

    public bool resetting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = 0.01f * speed;
        transform.Translate(Vector3.up * amountToMove * Time.deltaTime, Space.Self);
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Asteroid")
        {
            other.gameObject.GetComponent<Enemy>().UpdateScore();
            other.gameObject.GetComponent<Enemy>().Reset();
        }
    }
}
