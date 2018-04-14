using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] float enemyDeathDelay = 0.2f;
    int enemyHealth = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth < 1)
        {
            deathFX.SetActive(true);
            Invoke("KillEnemy", enemyDeathDelay);
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
    }
}
