using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public float speed = 50.0f;

     void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

     void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(Vector3.forward * forwardInput *speed );
    }

}
