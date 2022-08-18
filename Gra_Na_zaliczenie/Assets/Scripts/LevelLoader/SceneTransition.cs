using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerVectorStorage;
    private bool colliding;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerVectorStorage.initialValue = playerPosition;
            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliding = false;
        }
    }

    private void Update()
    {
        if (colliding == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
