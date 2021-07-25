using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoidBehaviour))]
public class BoidAlignmentBehaviour : MonoBehaviour
{

    BoidBehaviour boid;

    void Start() => boid = GetComponent<BoidBehaviour>();

    void FixedUpdate()
    {
        //iterate through every boid
        Vector3 average = Vector3.zero;
        int inRange = 0;
        foreach (BoidBehaviour boid in BoidManager.Instance.boids.Where(x => x != boid))
        {
            Vector3 offset = boid.transform.position - transform.position;
            if (offset.magnitude < BoidManager.Instance.radius)
            {
                average += boid.velocity;
                inRange++;
            }
        }

        //align with nearby boids
        //interpolate to the average velocity direction
        if (inRange > 0)
        {
            average = average / inRange;
            boid.velocity += Vector3.Lerp(boid.velocity, average.normalized, Time.fixedDeltaTime);
            boid.velocity += BoidManager.Instance.RandomVector3();
        }
    }
}

