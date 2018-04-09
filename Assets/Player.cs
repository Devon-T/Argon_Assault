using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 11f;
    [Tooltip("In m")] [SerializeField] float xRange = 6f;
    [Tooltip("In m")] [SerializeField] float yRange = 4.5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -30f;

    float yThrow, xThrow;

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
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlPitchFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void respondToVerticalInput()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = Speed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampYPos, transform.localPosition.z);
    } 

    private void respondToHorizontalInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffset = Speed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
