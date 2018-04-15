using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    [SerializeField] int shieldHealth = 5;
    [SerializeField] GameObject hitFX;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(hitFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        shieldHealth--;
        if (shieldHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}
