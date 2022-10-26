using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CannonBallPhysics : MonoBehaviour
{
    private GameManager _gameManager;
    
    private Vector3 _velocity;

    private float v, a;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Debug.Log(_gameManager.velocityField.text);
        Debug.Log(_gameManager.angleField.text);

        if (float.TryParse(_gameManager.velocityField.text, out float vf))
        {
            v = vf;
        }
        else
        {
            Debug.Log("Parsing failed");
        }
        
        if (float.TryParse(_gameManager.angleField.text, out float af))
        {
            a = af;
        }
        else
        {
            Debug.Log("Parsing failed");
        }
        
        _velocity += Vector3.up * Mathf.Sin(Mathf.Deg2Rad * a) * v;
        _velocity += Vector3.right * Mathf.Cos(Mathf.Deg2Rad * a) * v;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateVelocity()
    {
        _velocity += Physics.gravity * Time.deltaTime;
    }
 
    private void UpdatePosition()
    {
        transform.position += _velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
