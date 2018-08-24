using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

    public GameObject PlayerShipPrefab;
    GameObject playerInstance;

    public double numLives = 4;
    public Transform canvas;
    float respawnTimer;

    int score = 0;
   // public Text curScore;
    //public Text highScore;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        SpawnPlayer();

        //highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
		
	}
    void SpawnPlayer() {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(PlayerShipPrefab, transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if(playerInstance == null && numLives > 0) {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0 ) {
                SpawnPlayer();
            }
        }
        if(playerInstance == null && numLives == 0) {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

	}
    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null) {
            GUI.Label(new Rect(0, 0, 150, 50), "Remaining Lives: " + numLives);
        }
        else{
            GUI.Label(new Rect(Screen.width / 2 - 40, 50, 100, 50), "GAME OVER");
            
        }
        GUI.Label(new Rect(0, 25, 150, 50), "Score: " + score);

    }
    public void AddPoint(int v)
    {
        score += v;
        //curScore.text = score.ToString();

        //PlayerPrefs.SetInt("HighScore", score);
    }
}
