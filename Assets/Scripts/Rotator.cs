using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rotation = 45.0f;
        transform.Rotate(rotation * Time.deltaTime, 0, 0);
	}
}
