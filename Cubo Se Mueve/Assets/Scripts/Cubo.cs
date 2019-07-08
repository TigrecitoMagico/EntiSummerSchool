using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {
    float prueba;
	// Use this for initialization
	void Start () {
        prueba = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        prueba += 0.01f;
        Debug.Log(prueba);
	}
}
