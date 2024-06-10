using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    public float speed = 5.0f;
    public bool hasPowerup;

     void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

     void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(focalPoint.transform.forward * forwardInput *speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Debug.Log("Destroy");
            Destroy(other.gameObject);
        }
    }
}
