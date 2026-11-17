using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ExplosiveProjectiles : MonoBehaviour
{
    [SerializeField] private GameObject TopLeft;
    [SerializeField] private GameObject TopRight;
    [SerializeField] private GameObject TopMiddle;
    
    [SerializeField] private GameObject BottomLeft;
    [SerializeField] private GameObject BottomRight;
    [SerializeField] private GameObject BottomMiddle;

    [SerializeField] private GameObject MiddleLeft;
    [SerializeField] private GameObject MiddleRight;
    
    public float speed = 1000.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = 0.01f * speed;
        TopMiddle.transform.Translate(Vector3.up * amountToMove * Time.deltaTime, Space.World);
        TopLeft.transform.Translate(Vector3.Normalize((Vector3.up + Vector3.left)) * amountToMove * Time.deltaTime, Space.World);
        TopRight.transform.Translate(Vector3.Normalize((Vector3.up + Vector3.right)) * amountToMove * Time.deltaTime, Space.World);
        
        BottomMiddle.transform.Translate(Vector3.down * amountToMove * Time.deltaTime, Space.World);
        BottomLeft.transform.Translate(Vector3.Normalize((Vector3.down + Vector3.left)) * amountToMove * Time.deltaTime, Space.World);
        BottomRight.transform.Translate(Vector3.Normalize((Vector3.down + Vector3.right)) * amountToMove * Time.deltaTime, Space.World);

        MiddleLeft.transform.Translate(Vector3.left * amountToMove * Time.deltaTime, Space.World);
        MiddleRight.transform.Translate(Vector3.right * amountToMove * Time.deltaTime, Space.World);
        
        if (TopMiddle.transform.position.y > 20)
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
