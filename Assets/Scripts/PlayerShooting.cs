using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject laserBluePrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;

        if ( Input.GetButton("Fire1") && cooldownTimer <= 0 ) {
            //Shoot
            //Debug.Log("PEW!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);

            Instantiate(laserBluePrefab, transform.position + offset, transform.rotation);
        }
	}
}
