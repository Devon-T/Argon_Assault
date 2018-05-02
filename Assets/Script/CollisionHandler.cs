using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 2;
    [Tooltip("FX Prefab on player")] [SerializeField] GameObject deathFX;
    [SerializeField] bool collisionDisabled = false;

    void OnTriggerEnter(Collider Other)
    {
        if (collisionDisabled) { return; }
        else {StartDeathSequence();}
    }

    private void StartDeathSequence()
    {
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("RestartGame", levelLoadDelay);
    }

    private void RestartGame()
    {
        deathFX.SetActive(false);
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            debugControls();
        }
    }

    private void debugControls()
    {
        if (Input.GetKeyDown(KeyCode.C) || CrossPlatformInputManager.GetButton("Jump")) // todo figure out why not always responding to input
        {
            collisionDisabled = !collisionDisabled;
        }
    }
}
