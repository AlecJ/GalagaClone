using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallPlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Debug.Log("start");
    }

    // Handles player movement
    // this just gets the current X and Y position of the player
    // actual movement updates are handled below in FixedUpdate()
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        // store X and Y vector components
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update before physics are applied
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // Handles contact with any triggers
    // For the player object, this only will handle:
    // - PickUp objects - coins that the player runs into and collects
    private void OnTriggerEnter(Collider other) {
        // if other is a pick up object (tag == PickUp)
        // deactivate the pick up object and increment the player's score
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
        }
    }
}
