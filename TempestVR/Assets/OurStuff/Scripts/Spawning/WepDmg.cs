using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepDmg : MonoBehaviour {
	public float damage = 10f;
	public GameObject target = null;
	public bool hit = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//We can use trigger or Collision
	void OnTriggerEnter(Collider col)
	{
		if ((col.gameObject.tag == "hittable" || col.gameObject.tag == "hitspawn") && !hit) {
			Debug.Log ("hit object");
			target = col.gameObject;
			hit = true;
		}
	}

	//We can use trigger or Collision
	void OnTriggerExit(Collider col)
	{
		if (hit) {
			hit = false;
			if (target.tag == "hittable")
				target.GetComponent<HealthReduction> ().reduceHealth (damage);
			else if (target.tag == "hitspawn")
				target.GetComponent<GuidedSpawner> ().reduceHealth (damage);
			target = null;
		}
	}

}
