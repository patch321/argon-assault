using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [SerializeField][Tooltip("In meters/second")] float speed = 15f;
    [SerializeField] [Tooltip("In meters")] float xRange = 5f;
    [SerializeField] [Tooltip("In meters")] float yRange = 3f;
    float startingXPostition;
    float startingYPostition;

    // Use this for initialization
    void Start () {
        this.startingXPostition = this.transform.position.x;
        this.startingYPostition = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float newyPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, newyPos, transform.localPosition.z);
    }
}
