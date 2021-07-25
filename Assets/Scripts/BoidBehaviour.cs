using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    //the current velocity
    public Vector3 velocity = new Vector3();

    void FixedUpdate()
    {
        if (velocity.magnitude > BoidManager.Instance.max)
            velocity = velocity.normalized * BoidManager.Instance.max;
        //move and rotate boid
        transform.position += velocity * Time.fixedDeltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
    }
}
