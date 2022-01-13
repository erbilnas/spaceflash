using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollison : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);

            Instantiate(asteroidExplosion, collision.transform.position, collision.transform.rotation);

            GameManager.AsteroidHit();

            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
