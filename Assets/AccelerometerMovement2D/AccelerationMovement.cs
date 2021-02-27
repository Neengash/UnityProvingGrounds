using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationMovement : MonoBehaviour
{
    private Vector3 acceleration;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float forceMultiplication;
    private float previousDirection;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        acceleration = Input.acceleration;
        // Si acaba de canviar sa direcció, reset de les velocitats;
        if (previousDirection * acceleration.x < 0) {
            rb.velocity = new Vector3();
        }
        rb.AddForce(new Vector3(acceleration.x * forceMultiplication, 0, 0));
        previousDirection = acceleration.x;
    }

}
