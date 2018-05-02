using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerKill = 10;
    [SerializeField] int EnemyHealth = 5;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnParticleCollision(GameObject other)
    {
        EnemyHealth--;
        if (EnemyHealth < 1 && EnemyHealth > -1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        scoreBoard.ScoreHit(scorePerKill);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
