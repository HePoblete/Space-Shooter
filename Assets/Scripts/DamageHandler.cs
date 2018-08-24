using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    public float timer = 0;
    public int pointValue = 100;

    SpriteRenderer spriteRend;

    void Start() {
        correctLayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null) {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null) {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D() {
        Debug.Log("Trigger!");

        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
    }
    void Update() {
      
        if (invulnTimer > 0) {
            invulnTimer -= Time.deltaTime;
            if (invulnTimer <= 0) {
                gameObject.layer = correctLayer;
                if (spriteRend != null) {
                    spriteRend.enabled = true;
                }
            }
            else {
                if (spriteRend != null) {
                    if (timer > 0) {
                        timer--;
                    }
                    if (timer <= 0) {
                        spriteRend.enabled = !spriteRend.enabled;
                        timer = 10;
                        
                    }
                }
            }
        }

        if (health <= 0){
            Die();
        }

    }
    void Die() {
        Destroy(gameObject);
        GameObject.Find("PlayerSpawnSpot").GetComponent<PlayerSpawner>().AddPoint(pointValue);
    }
    
}   
