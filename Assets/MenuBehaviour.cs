using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuBehaviour : MonoBehaviour
{
    public void UseMouse()
    {
        CompleteProject.PlayerMovement.useMouse = true;
    
    }

    public void UseController()
    {
        CompleteProject.PlayerMovement.useMouse = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("_Complete-Game");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Select()
    
    {
        //Start.Select(); 
    }


}
