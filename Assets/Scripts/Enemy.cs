using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int maxHits = 10;

    Scoreboard scoreboard;

	// Use this for initialization
	void Start () {
        AddBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (maxHits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        maxHits -= 1;
    }

    private void KillEnemy()
    {
        scoreboard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
