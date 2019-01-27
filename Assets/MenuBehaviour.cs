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
        SceneManager.LoadSceneAsync("Master", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Level2", LoadSceneMode.Additive);
    }

    public void CloseGame()
    {
        Application.Quit();
    }


}
