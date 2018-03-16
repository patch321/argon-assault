using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on Player")][SerializeField] GameObject deathFx;

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        deathFx.SetActive(true);
        SendMessage("DisableMovement");
        Invoke("ReloadGame", levelLoadDelay);
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
}
