using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;

    private float powerUpStrength = 15.0f;
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

        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Debug.Log("Destroy");
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup ) 
        { 
            Rigidbody enemyrigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyrigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with : " +  collision.gameObject.name + "With PowerUp set to " + hasPowerup);
        }

    }
}
