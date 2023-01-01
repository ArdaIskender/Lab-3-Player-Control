using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float maxSpeed = 6f;
    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            moveSpeed = 1.5f;
            playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput);
            playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput);
        }
        else
        {
            moveSpeed = 2f;
            playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput);
            playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput);
        }  
    }
}
