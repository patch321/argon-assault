using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        int numMusicPLayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPLayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
