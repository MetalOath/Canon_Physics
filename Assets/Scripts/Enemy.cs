using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 0.1f);
    }
}
