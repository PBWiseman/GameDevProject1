using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    //If the player scene is not loaded then load it. This is on all scenes in case a scene is being started from the editor and not from the main menu
    void Awake()
    {
        //if player scene is not loaded then load it
        if (SceneManager.GetSceneByName("Player").isLoaded == false)
        {
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
    }
}
