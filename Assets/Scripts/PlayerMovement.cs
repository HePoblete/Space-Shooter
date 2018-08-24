using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	//Update is called once per frame
	void Update () {

        // ROTATE the ship
        //Get rotation quaternion
        Quaternion rot = transform.rotation;

        //Get the Z euler angle
        float z = rot.eulerAngles.z;

        //Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        //Feed the quaternion into existing rotation
        transform.rotation = rot;

        // MOVE the ship
        Vector3 pos = transform.position;
        
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        //Restrict player to boundaries

        //Vertical boundary
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        
        //Calculate orthagraphic width based on screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //Horizontal boundary
        if (pos.x + shipBoundaryRadius > widthOrtho) {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho) {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        //Update position
        transform.position = pos;
      
	}
}
