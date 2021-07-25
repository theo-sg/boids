# boids in Unity3D
### What is a boid?
Boids (short for birdoid) are an [emergent phenomenon](https://en.wikipedia.org/wiki/Emergence) that can be found in nature. The first boid program was developed by Craig Reynolds in 1986 to simulate birds flocking. In essence, to create a boid simulation, each individual must follow three rules.

#### Alignment
![Boid alignment](https://upload.wikimedia.org/wikipedia/commons/e/e1/Rule_alignment.gif)
* Each individual must align itself to travel in the average direction of its neighbours.


#### Cohesion
![Boid cohesion](https://upload.wikimedia.org/wikipedia/commons/2/2b/Rule_cohesion.gif)
* Each individual must travel towards the centre of any nearby boids.


#### Cohesion
![Boid separation](https://upload.wikimedia.org/wikipedia/commons/e/e1/Rule_separation.gif)
* Each individual must steer to avoid collisions.
