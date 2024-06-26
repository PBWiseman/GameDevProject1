/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 7, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to load the player scene if it is not loaded
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    //If the player scene is not loaded then load it. This is on all scenes in case a scene is being started from the editor and not from the main menu
    void Start()
    {
        //If player scene is not loaded then load it
        if (SceneManager.GetSceneByName("Player").isLoaded == false)
        {
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
    }
}
