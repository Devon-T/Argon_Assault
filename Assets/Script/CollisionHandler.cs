using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 2;
    [Tooltip("FX Prefab on player")] [SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider Other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        //deathParticle.Play();
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("RestartGame", levelLoadDelay);
    }

    private void RestartGame()
    {
        deathFX.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
