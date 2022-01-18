using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform grabHolder;
    public float rayDist;

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if(grabCheck.collider !=null && grabCheck.collider.tag == "DiamondChest")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = grabHolder;
                grabCheck.collider.gameObject.transform.position = grabHolder.position;
                Destroy(GameObject.FindWithTag("DiamondChest"));
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
            }
        }
    }
}
