using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    public float speed = 5.0f;

     void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

     void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(focalPoint.transform.forward * forwardInput *speed );
    }

}
