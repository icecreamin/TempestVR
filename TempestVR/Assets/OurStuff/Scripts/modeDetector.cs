using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class modeDetector : MonoBehaviour {
    public GameObject vrPlayer;
    public GameObject fpsPlayer;
    private void Awake()
    {
        if (XRDevice.isPresent)
        {
            Debug.Log("VR device detected, loading VR mode");
            vrPlayer.SetActive(true);
        }
        else
        {
            Debug.Log("No VR device detected, loading Desktop mode");
            fpsPlayer.SetActive(true);
        }
        
    }
    
}
