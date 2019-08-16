using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        //create entry into console
        Debug.Log("Playgame was pressed");

        //loads game when button is pressed
        SceneManager.LoadScene("Game");
    }

  
}
