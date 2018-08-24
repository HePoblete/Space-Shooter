using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject laserRedPrefab;

    public float fireDelay = 0.5f;
    float cooldownTimer = 0;

    Transform player;

    // Update is called once per frame
    void Update() {

        if (player == null) {
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null) {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        if ( cooldownTimer <= 0 && player !=null && Vector3.Distance(transform.position, player.position) < 4) {
            //Shoot
            //Debug.Log("Enemy PEW!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);

            Instantiate(laserRedPrefab, transform.position + offset, transform.rotation);
        }
    }
}
