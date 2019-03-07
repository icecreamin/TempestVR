using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawnCube : MonoBehaviour {
	
	
	public SteamVR_Input_Sources handType; // 1
	public SteamVR_Action_Boolean spawnCubeAction;
	public SteamVR_Behaviour_Pose controllerPose;
	
	public GameObject cubePrefab; // 1
	private GameObject cube; // 2
	private Transform cubeTransform; // 3
	
	public Vector3 cubeOffset;
	
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		// 1
		cube = Instantiate(cubePrefab);
		// 2
		cubeTransform = cube.transform;
		
		cube.SetActive(true);
		
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetSpawnCube())
		{
			print("cube spawned");
			
			object clone;
			clone = Instantiate(cubePrefab, controllerPose.transform.position, controllerPose.transform.rotation);
			//cubeTransform.position = controllerPose.transform.position + cubeOffset;
			//clone.rigidbody = controllerPose.GetVelocity();
			
			//I want to make the cube spawn with velocity forward like a cube gun
			
		}
		rb.velocity = new Vector3(0, 1000, 0);
		
	}
	
	public bool GetSpawnCube() // 1
	{
		return spawnCubeAction.GetStateDown(handType);
	}
}
