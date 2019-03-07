using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


//code found at https://answers.unity.com/questions/1268357/pick-upthrow-object.html
public class HoldItems : MonoBehaviour {
	//speed at which things are thrown when dropped
	public float speed = 0;
	public bool canHold = true;
	//the object to hold. start as empty
	//any object intended to be held should be tagged "holdable"
	public GameObject ball;
	//make an empty GameObject and set that as the guide
	//this is where the held object will be held
	public Transform guide;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (!canHold) //already holding
				throw_drop();
			else
				Pickup();
		}//if left-click

		if (!canHold && ball)
			ball.transform.position = guide.position;

	}//update

	//We can use trigger or Collision
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "holdable")
		if (!ball) // if we don't have anything holding
			ball = col.gameObject;
	}

	//We can use trigger or Collision
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "holdable")
		{
			if (canHold)
				ball = null;
		}
	}


	private void Pickup()
	{
		if (!ball)
			return;

		//We set the object parent to our guide empty object.
		ball.transform.SetParent(guide);

		//Set gravity to false while holding it
		ball.GetComponent<Rigidbody>().useGravity = false;

		//we apply the same rotation our main object (Camera) has.
		ball.transform.localRotation = transform.rotation;
		//We re-position the ball on our guide object 
		ball.transform.position = guide.position;

		canHold = false;
	}

	private void throw_drop()
	{
		if (!ball)
			return;

		//Set our Gravity to true again.
		ball.GetComponent<Rigidbody>().useGravity = true;
		// we don't have anything to do with our ball field anymore
		ball = null; 
		//Apply velocity on throwing
		guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

		//Unparent our ball
		guide.GetChild(0).parent = null;
		canHold = true;
	}
}//class
