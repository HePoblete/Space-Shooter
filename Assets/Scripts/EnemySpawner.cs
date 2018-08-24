using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy1Prefab;

    float spawnDistance = 15f;

    float enemyRate = 5;
    float nextEnemy = 1;


	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0) {
            nextEnemy = enemyRate;
            enemyRate *= 0.95f;
            if (enemyRate < 2) {
                enemyRate = 2;
            }

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemy1Prefab, transform.position +offset, Quaternion.identity);

        }

		
	}
}
