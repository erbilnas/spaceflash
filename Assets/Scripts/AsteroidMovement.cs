using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
	public float maxSpeed, minSpeed;
	public Vector3 movementDirection;

    public float rotationSpeedMin, rotationSpeedMax;
    private float rotationSpeed, xAngle, yAngle, zAngle;

	private float _asteroidSpeed = 10f;
	// Start is called before the first frame update
	void Start()
    {
        _asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.GetChild(0).transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * _asteroidSpeed);
        transform.GetChild(0).transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
