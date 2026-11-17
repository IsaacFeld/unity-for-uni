using System;

using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 1000.0f;

    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject ExplosiveProjectile;
    
    [SerializeField] private Transform leftWeaponPosition;

    [SerializeField] private Transform rightWeaponPosition;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 amountToMove = Vector3.right  * Input.GetAxis("Horizontal") * speed *  0.01f;
        transform.Translate(Time.deltaTime * amountToMove, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Projectile, leftWeaponPosition.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(ExplosiveProjectile, rightWeaponPosition.position, Quaternion.identity);
        }
    }


    
}
