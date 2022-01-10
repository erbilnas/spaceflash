using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserGun : MonoBehaviour
{
    public Animator gunAnimator;
    public GameObject laserBeamModel;
    public Transform laserBeamSpawnPoint;
	public Transform laserParent;
	public void FireGun () {
		gunAnimator.SetTrigger("Fire");

        GetComponent<AudioSource>().Play();

        GameObject generatedLaserBeam = Instantiate(laserBeamModel, laserBeamSpawnPoint.position, laserBeamSpawnPoint.rotation);

        generatedLaserBeam.transform.SetParent(laserParent);

		Debug.Log("Laserbeam!");
    }
}
