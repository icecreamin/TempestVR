using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReduction : MonoBehaviour {
	public float maxhealth;
	private float health;
	public GameObject smaller;
	public int spawns;
	private float factor;
	private float tored; //when to spawn
	public int minspeed = 5;
	public float scalefac = 0.1f;
	public float minsize = 0.1f;
	public bool colDmg = true;

	// Use this for initialization
	void Start () {
		transform.localScale -= new Vector3 (scalefac, scalefac, scalefac);
		if (maxhealth < 1 ||(transform.localScale.x < minsize && transform.localScale.y < minsize && transform.localScale.z < minsize ))
			this.gameObject.SetActive (false);
		health = maxhealth;
		factor = maxhealth / spawns;
		tored = maxhealth - factor;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (health);
		while (health <= tored) {
			Vector3 tps = transform.position;
			tps += new Vector3 (0, 1f, 0);
			Instantiate (smaller, tps, Quaternion.identity);
			Debug.Log ("Spawned object");
			tored -= factor;
		}
		if (health < 0) {
			Debug.Log ("Deleted Object");
			this.gameObject.SetActive (false);
		}
	}

	public void reduceHealth(float dmg) {
		health -= dmg;
		Debug.Log ("took damage");
	}

	void OnCollisionEnter(Collision collision)
	{
		if (colDmg) {
			if (collision.relativeVelocity.magnitude > minspeed)
				health -= collision.relativeVelocity.magnitude;
		}
	}

}
