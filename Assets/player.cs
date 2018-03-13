using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [SerializeField][Tooltip("In meters/second")] float xSpeed = 4f;
    [SerializeField] [Tooltip("In meters")] float xRange = 5f;
    float startingXPostition;

	// Use this for initialization
	void Start () {
        this.startingXPostition = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
