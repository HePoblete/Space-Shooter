﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour {

	public void doquit()
    {
        Debug.Log("has quit");
        Application.Quit();
    }
}
