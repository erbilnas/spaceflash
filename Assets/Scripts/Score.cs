using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private void OnEnable() {
        GameManager.OnAsteroidDestroyed += DisplayScore;
    }

    private void OnDisable() {
        GameManager.OnAsteroidDestroyed -= DisplayScore;
    }

    private void DisplayScore(){
        GetComponent<TextMeshProUGUI>().text = "Score: " + GameManager.playerScore.ToString();
    }
}
