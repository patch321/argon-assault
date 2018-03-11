using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadNextScene", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(1);
    }
}
