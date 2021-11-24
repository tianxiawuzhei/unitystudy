using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    private float speed = 5.0f;
    private float awayPower = 15.0f;

    public bool hasPowerup;
    
        // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*forwardInput*speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
            powerupIndicator.SetActive(true);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Vector3 awayDir = other.gameObject.transform.position - transform.position;
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce(awayDir*awayPower, ForceMode.Impulse);
            //Debug.Log("Collision with:" + other.gameObject.name + "hasPowerup value:" + hasPowerup);
        }
    }
}
