using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMouvement : MonoBehaviour
{
    public float moveSpeed;
    public float moveBoost;
    public float rotationSpeed;
    public bool wait = true;
    public bool isFacingLeft = true;

    public Rigidbody2D rb;
    public Transform trs;
    private Vector3 velocity = Vector3.zero;

    public Animator heliceAnimator;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement, verticalMovement);

        Boost();

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        heliceAnimator.SetFloat("speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isFacingLeft)
            {
                trs.transform.localScale = new Vector3(2, trs.transform.localScale.y, trs.transform.localScale.z);
                isFacingLeft = true;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, -45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, 45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (isFacingLeft)
            {
                trs.transform.localScale = new Vector3(-2, trs.transform.localScale.y, trs.transform.localScale.z);
                isFacingLeft = false;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, 45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, -45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * moveBoost * Time.deltaTime*2;
            float verticalMovement = Input.GetAxis("Vertical") * moveBoost * Time.deltaTime*2;

            Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        }

    }
}
