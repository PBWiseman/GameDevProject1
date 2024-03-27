using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    //If the player scene is not loaded then load it. This is on all scenes in case a scene is being started from the editor and not from the main menu
    void Start()
    {
        //if player scene is not loaded then load it
        // int count = SceneManager.sceneCount;
        // Debug.Log(count);
        // for (int i = 0; i < count; i++)
        // {
        //     Scene scene = SceneManager.GetSceneAt(i);
        //     Debug.Log(scene.name);
        //     if (scene.name == "Player")
        //     {
        //         return;
        //     }
        // }
        

        // if (SceneManager.GetSceneByName("Player").isLoaded == false)
        // {
        //     SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        // }
    }
}
