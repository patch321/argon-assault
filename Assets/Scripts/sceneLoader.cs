using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        Invoke("LoadNextScene", 3f);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
