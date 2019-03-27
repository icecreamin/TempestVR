using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuidedSpawner : MonoBehaviour {
	public float maxhealth = 100; //spawns whenever this hits 0
	private float health;
	public GameObject spawned;
	public bool startfill = false; //starts filled up

	private bool[] guides;
	private int n; //total number of guides
	private int f; //guides being used

	// Use this for initialization
	void Start () {
		health = maxhealth;
		n = this.transform.childCount;
		guides = new bool[n];
		f = 0;
		if (startfill)
			refill ();
	}
	
	// Update is called once per frame
	void Update () {
		check ();
		while (health <= 0) {
			health += maxhealth;
			if (f == 0) {
				refill ();
			}
			else 
				drop ();
		}
	}

	private void check() {
		f = 0;
		for (int i = 0; i < n; i++) {
			if (this.transform.GetChild (i).childCount == 0) {
				guides [i] = false;
			}
			else {
				f++;
				guides[i] = true;
				this.transform.GetChild(i).GetChild(0).localPosition = new Vector3 (0, 0, 0);
			}
		}
	}

	private void refill() {
		System.Random r = new System.Random();
		int rand = r.Next (n / 2, n + 1);
		for (int i = 0; i < rand; i++) {
			int p = r.Next (0, n);
			refill (p);
		}
	}

	private void refill(int p) {
		if (guides [p])
			return;
		Debug.Log (p);
		Transform c = this.transform.GetChild(p);
		GameObject x = Instantiate(spawned);
		x.SetActive (true);
		x.GetComponent<Rigidbody> ().useGravity = false;
		x.transform.SetParent (c);
		x.transform.localPosition = new Vector3 (0, 0, 0);
		guides [p] = true;
	}

	private void drop() {
		System.Random r = new System.Random();
		int ran = r.Next (0, n);
		while (!guides [ran])
			ran = r.Next (0, n);
		Transform x = this.transform.GetChild (ran).GetChild (0);
		x.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		x.SetParent (null);
		f--;
		Debug.Log ("dropped");
	}

	public void reduceHealth(float dmg) {
		health -= dmg;
		Debug.Log ("took damage");
	}
		
}
