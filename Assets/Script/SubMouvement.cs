using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMouvement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Animator heliceAnimator;

    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        heliceAnimator.SetFloat("speed",characterVelocity);
    }

    void MovePlayer (float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
