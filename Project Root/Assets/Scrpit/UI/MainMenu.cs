using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;// so can use the scene management in unity
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Level 1"); // to load the level 1 scene 
        }
    }

    public void Level1() // the level 1 function 
    {
        SceneManager.LoadScene("Level 1"); // to load the level 1 scene 

        

    }
}
