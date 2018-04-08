using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 2.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        respondToHorizontalInput();
        respondToVerticalInput();
        processRotate();
    }

    private void processRotate()
    {
        throw new NotImplementedException();
    }

    private void respondToVerticalInput()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = Speed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampYPos, transform.localPosition.z);
    } 

    private void respondToHorizontalInput()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffset = Speed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
