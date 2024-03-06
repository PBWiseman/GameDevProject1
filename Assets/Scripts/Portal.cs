using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool inDungeon;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Town")
        {
            inDungeon = true;
        }
        else
        {
            inDungeon = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PortalUse();
        }
    }

    //When the player interacts with the portal, check if they are in the town or the dungeon and load the other scene
    public void PortalUse()
    {
        Debug.Log("Portal used");
        if (inDungeon)
        {
            GoToTown();
        }
        else
        {
            GoToDungeon();
        }
    }

    //If the player is in the dungeon and interacts with the portal, load town
    private void GoToTown()
    {
        //TODO: Add animation
        SceneManager.LoadScene("Town");
        SceneManager.UnloadSceneAsync("Dungeon1");
    }

    //If the player is in the town and interacts with the portal, load dungeon
    //At the moment this is hardcoded to dungeon1 but when there are more dungeons it will give an option
    private void GoToDungeon()
    {
        //TODO: Add animation
        SceneManager.LoadScene("Dungeon1");
        SceneManager.UnloadSceneAsync("Town");
    }
}
