/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 7, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to control the portal that allows the player to move between the town and the dungeon
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //Boolean for if the player is in the dungeon
    public bool inDungeon;
    //Boolean for if the player is in range of the portal
    private bool inRange;
    //Boolean for if the portal has been used
    private bool used;
    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range of the portal and presses E, use the portal
        //This uses the old input system as the new one was not working
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            PortalUse();
        }
    }

    /// <summary> 
    ///When the player interacts with the portal, check if they are in the town or the dungeon and load the other scene
    /// </summary>
    public void PortalUse()
    {
        if(!used)
        {
            used = true;
            if (inDungeon)
            {
                GoToTown();
            }
            else
            {
                GoToDungeon();
            }
        }
    }

    /// <summary>
    /// If the player is in the dungeon and interacts with the portal, load town
    /// </summary>
    private void GoToTown()
    {
        SceneManager.UnloadSceneAsync("Dungeon1");
        SceneManager.LoadScene("Town", LoadSceneMode.Additive);
    }
    /// <summary>
    /// If the player is in the town and interacts with the portal, load dungeon
    /// At the moment this is hardcoded to dungeon1 but when there are more dungeons it will give an option
    /// </summary>
    private void GoToDungeon()
    {
        SceneManager.UnloadSceneAsync("Town");
        SceneManager.LoadScene("Dungeon1", LoadSceneMode.Additive);
    }
    
    /// <summary>
    /// When the player enters the trigger, set inRange to true
    /// </summary>
    /// <param name="collision">Collider entered</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    /// <summary>
    /// When the player exits the trigger, set inRange to false
    /// </summary>
    /// <param name="collision">Collider entered</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
