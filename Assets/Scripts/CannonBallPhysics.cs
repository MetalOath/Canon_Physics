using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CannonBallPhysics : MonoBehaviour
{
    private GameManager gameManager;

    private int velocity = 0, angle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if(int.TryParse(gameManager.velocityField.text, out int x))
            velocity = x;
        
        Debug.Log(velocity);

        //angle = int.Parse(gameManager.angleField.text);
    }

    // Update is called once per frame
    void Update()
    {
        // velocity = distance / time
        // acceleration = velocity / time
        
        transform.Translate(Vector3.up * -9.81f / (Time.deltaTime * Time.deltaTime));
        
        transform.Translate(Vector3.right * 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
