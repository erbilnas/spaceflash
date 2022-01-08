using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamMove : MonoBehaviour
{
	public float thrust = 10f;
	private Rigidbody rb;
	// Start is called before the first frame update
	private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * thrust;

        Destroy(gameObject, 2f);
    }
}
