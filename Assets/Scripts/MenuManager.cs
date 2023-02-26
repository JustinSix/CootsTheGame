using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public CatController catController;
    public GameObject menuObject;
    public GameObject gameUIObject;

    public GameObject menuCamera;
    public GameObject gameCamera;
    public void PlayTheVideoGame()
    {
        catController.enabled = true;
        menuCamera.SetActive(false);
        gameCamera.SetActive(true);
        menuObject.SetActive(false);
        gameUIObject.SetActive(true); 

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false; 
    }
}
