using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Intro,
        Playing,
        GameOver
    }

    public static GameState gameStatus;
    public delegate void AsteroidHandler();
    public static event AsteroidHandler OnAsteroidDestroyed;

    public UnityEvent onStartActivated;
    public UnityEvent onGameOver;
    public UnityEvent onGameReset;

    [Header("The Time Slider Component")]
    public Image sliderImage;
    public float gameDuration;
    private float sliderCurrentFillAmount = 1f;
    public static int playerScore = 0;

    private void Start() {
        gameStatus = GameState.Intro;
    }

    private void Update() {
        if (gameStatus == GameState.Playing) {
            sliderImage.fillAmount = (sliderCurrentFillAmount - (Time.deltaTime / gameDuration));

            sliderCurrentFillAmount = sliderImage.fillAmount;

            if (sliderCurrentFillAmount <= 0) {
                GameOver();
            }
        }
    }

	private void GameOver()
	{
        gameStatus = GameState.GameOver;
        onGameOver.Invoke();
	}

	public static void AsteroidHit() {
        if (gameStatus == GameState.Playing) {
            playerScore += 100;
            OnAsteroidDestroyed();
        }
    }

    public void StartGame() {
        gameStatus = GameState.Playing;
        onStartActivated.Invoke();
    }

    public void ResetGame() {
        onGameReset.Invoke();
        playerScore = 0;
        sliderCurrentFillAmount = 1f;
    }
}
