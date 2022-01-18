using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FischPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    private Transform target;
    private bool sens = true;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {

            if(sens)
            {
                destPoint += 1;
                graphics.flipX = false;
            }
            else
            {
                destPoint -= 1;
                graphics.flipX = true;
            }

            target = waypoints[destPoint];
            

            if(destPoint == waypoints.Length-1)
            {
                sens = false;
            }
            else if(destPoint == 0)
            {
                sens = true;
            }
        }
        
    }
}
