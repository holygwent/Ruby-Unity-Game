using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndRestorePosition : MonoBehaviour
{
    private Health health;
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        health = GetComponent<Health>();
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (!health.dead)
        {
            SavedPositionManager.savedPositions[sceneIndex] = transform.position;
        }
        else
        {
            transform.position = new Vector3(-3.5f, -3.5f, 0);
        }
    }
}