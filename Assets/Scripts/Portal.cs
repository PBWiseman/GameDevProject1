using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool inDungeon;
    private bool inRange;
    private bool used;
    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            PortalUse();
        }
    }

    //When the player interacts with the portal, check if they are in the town or the dungeon and load the other scene
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

    //If the player is in the dungeon and interacts with the portal, load town
    private void GoToTown()
    {
        //TODO: Add animation
        SceneManager.UnloadSceneAsync("Dungeon1");
        SceneManager.LoadScene("Town", LoadSceneMode.Additive);
    }

    //If the player is in the town and interacts with the portal, load dungeon
    //At the moment this is hardcoded to dungeon1 but when there are more dungeons it will give an option
    private void GoToDungeon()
    {
        //TODO: Add animation
        SceneManager.UnloadSceneAsync("Town");
        SceneManager.LoadScene("Dungeon1", LoadSceneMode.Additive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
