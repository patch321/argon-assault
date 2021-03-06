﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [SerializeField][Tooltip("In meters/second")] float controlSpeed = 15f;
    [SerializeField] [Tooltip("In meters")] float xRange = 5f;
    [SerializeField] [Tooltip("In meters")] float yRange = 3f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -3f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -3f;

    float startingXPostition;
    float startingYPostition;
    float xThrow, yThrow;
    bool movementEnabled = true;

    // Use this for initialization
    void Start () {
        this.startingXPostition = this.transform.position.x;
        this.startingYPostition = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(movementEnabled == true)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }        
    }

    private void ProcessRotation()
    {
        float pitchDueToPostion = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow + pitchDueToPostion;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float newYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void DisableMovement()
    {
        movementEnabled = false;
    }
}
