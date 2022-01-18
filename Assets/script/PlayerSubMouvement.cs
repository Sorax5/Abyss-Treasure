using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubMouvement : MonoBehaviour
{
    public float moveSpeed;
    public float moveBoost;
    public float rotationSpeed;
    public bool isFacingLeft = true;
    public bool canBoost = true;
    public bool GrapActive = false;

    public Rigidbody2D rb;
    public Transform trs;
    private Vector3 velocity = Vector3.zero;

    public Animator SousMarinsAnimator;
    public Animator heliceAnimator;

    IEnumerator RotationWaiting()
    {
        yield return new WaitForSeconds(1);
        trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
    }

    IEnumerator BoostWaiting()
    {
        yield return new WaitForSeconds(8);
        canBoost = true;
    }

    IEnumerator Boosting()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveBoost * Time.deltaTime * 2;
        float verticalMovement = Input.GetAxis("Vertical") * moveBoost * Time.deltaTime * 2;

        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        yield return new WaitForSeconds((float)0.7);
        canBoost = false;
    }

    IEnumerator Grap()
    {
        GrapActive = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds((float)1.5);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GrapActive = false;
    }

    void Update()
    {

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        if (GrapActive == false)
        {
            MovePlayer(horizontalMovement, verticalMovement);
            Boost();
        }

        SousMarinsAnimator.SetBool("GrapActive", GrapActive);
        grappin();

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        heliceAnimator.SetFloat("speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (!isFacingLeft)
            {
                trs.transform.localScale = new Vector3(2, trs.transform.localScale.y, trs.transform.localScale.z);
                isFacingLeft = true;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, -45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
                StartCoroutine(RotationWaiting());
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, 45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
                StartCoroutine(RotationWaiting());
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (isFacingLeft)
            {
                trs.transform.localScale = new Vector3(-2, trs.transform.localScale.y, trs.transform.localScale.z);
                isFacingLeft = false;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, 45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
                StartCoroutine(RotationWaiting());
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, targetVelocity - trs.position);
                desiredRotation = Quaternion.Euler(0, 0, -45);
                trs.transform.rotation = Quaternion.RotateTowards(trs.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
                StartCoroutine(RotationWaiting());
            }
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (canBoost)
            {
                StartCoroutine(Boosting());
                StartCoroutine(BoostWaiting());
            }

        }
    }

    void grappin()
    {
        if (Input.GetKeyDown(KeyCode.E) && GrapActive == false)
        {
            StartCoroutine(Grap());
        }
    }
}
