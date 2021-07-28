using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("start");
    }

    // Handles player movement
    // this gets the intended movement from the input system
    // actual movement updates are handled below in FixedUpdate()
    private void OnMove(InputValue movementValue)
    {
        Debug.Log("input");
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        // store X and Y vector components
        movementX = movementVector.x;
        movementY = movementVector.y;

        Debug.Log("(Input) X: " + movementX + " Y: " + movementY);
    }

    // Update before physics are applied
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // // Handles contact with any triggers
    // private void OnTriggerEnter(Collider other) {

    // }
}
