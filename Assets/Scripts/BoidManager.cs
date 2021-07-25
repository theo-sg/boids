using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    //### singleton ###
    public static BoidManager Instance;
    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    //boids in the scene
    public BoidBehaviour[] boids;
    //radius of detection
    [Range(1, 10f)] public float radius = 5f;
    //the maximum speed
    [Range(0f, 50f)] public float max = 10f;
    //radius of repulsion
    [Range(0f, 10f)] public float repulsionRadius = 3f;
    //force of repulsion
    [Range(0f, 20f)] public float repulsionForce = 5f;
    //random magnitude
    public float randomness = 0.02f;
    [Space(20)]
    public GameObject boidPrefab;

    //get every boid
    public void OnEnable()
    {
        for (int i = 0; i < 45; i++)
        {
            GameObject.Instantiate(boidPrefab, Random.insideUnitCircle * 10, Random.rotation);
        }
        boids = FindObjectsOfType<BoidBehaviour>();
    }

    public Vector3 RandomVector3()
    {
        return Random.insideUnitSphere * randomness;
    }
}
