using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody rb;
    private GameObject player;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        player = GameObject.Find("Player_Sphere");
    }

    private void Update()
    {
        Vector3 lookdirection = (player.transform.position - transform.position).normalized;
        rb.AddForce( lookdirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
