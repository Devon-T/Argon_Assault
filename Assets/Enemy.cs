using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] int standardEnemyHealth = 5;
    [SerializeField] Transform parent;

	// Use this for initialization
	void Start () {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnParticleCollision(GameObject other)
    {
        standardEnemyHealth--;
        if (standardEnemyHealth < 1)
        {
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
        }
    }

}
