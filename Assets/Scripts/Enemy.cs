using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;
    public float speed = 800.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {

        float amountToMove = 0.01f * speed;
        transform.Translate(-1 * Vector3.up * amountToMove * Time.deltaTime, Space.World);

        if (transform.position.y < -3)
        {
            Reset();
        }
        
    }

    public void Reset()
    {
        transform.position = new Vector3( Random.Range(-5, 5), 15, transform.position.z );
       
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {++score}";
    }

    

    
}
