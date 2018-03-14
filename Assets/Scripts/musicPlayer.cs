using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
