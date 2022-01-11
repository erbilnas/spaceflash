using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Laser")) {
            gameManager.StartGame();
        }
    }
}
