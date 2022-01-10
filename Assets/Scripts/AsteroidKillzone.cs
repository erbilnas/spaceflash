using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillzone : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }
    }
}
