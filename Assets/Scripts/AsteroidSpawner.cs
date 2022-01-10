using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Size of the Spawn Area")]
	public Vector3 size;

    [Header("Rate of Asteroid Spawning")]
    public float spawnRate = 1f;

    [Header("Asteroid Prefab")]
	public GameObject asteroidModel;

    [Header("Asteroid Parent")]
    public Transform asteroidParent;
	private float nextSpawnTime = 0;

	private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }

    private void Update() {
        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + spawnRate;

            SpawnAsteroid();
        }
    }

	private void SpawnAsteroid() {
		Vector3 spawnPoint = transform.position + new Vector3(
            Random.Range(-size.x / 2, size.x / 2), 
            Random.Range(-size.y / 2, size.y / 2), 
            Random.Range(-size.z / 2, size.z / 2)
            );

        // Quaternion asteroidRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        GameObject asteroid = Instantiate(asteroidModel, spawnPoint, transform.rotation);

        asteroid.transform.SetParent(asteroidParent);
	}
}
