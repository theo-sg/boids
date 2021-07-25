using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoidBehaviour))]
public class BoidAvoidanceBehaviour : MonoBehaviour
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
            if (offset.magnitude < BoidManager.Instance.repulsionRadius )
            {
                average += offset;
                inRange++;
            }
        }

        //apply repulsion
        //each boid will rotate slightly away from its neighbours
        if (inRange > 0)
        {
            average = average / inRange;
            boid.velocity -= Vector3.Lerp(boid.velocity, average, Time.fixedDeltaTime) * BoidManager.Instance.repulsionForce;
            boid.velocity += BoidManager.Instance.RandomVector3();
        }
    }
}

