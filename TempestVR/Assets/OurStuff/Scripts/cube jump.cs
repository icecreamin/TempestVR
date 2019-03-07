using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class cubejump : MonoBehaviour {//make the already existing cube jump into the air when I press a button to learn velocity and eventually make a cube gun

	public Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>()
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
