using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronCollision : MonoBehaviour {
    Dictionary<string, int> ingDict = new Dictionary<string, int>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.tag == "Ingredient")
        {
            Debug.Log("Ingredient added");

            if (ingDict.ContainsKey(collision.gameObject.name))
            {
                ingDict[collision.gameObject.name]++;
            }
            else
            {
                ingDict.Add(collision.gameObject.name, 1);
            }
            Destroy(collision.gameObject);

            //print the dictionary to the console
            foreach(var item in ingDict)
            {
                Debug.Log(item.Key + ": " + item.Value);
            }
        }
        
    }
}
