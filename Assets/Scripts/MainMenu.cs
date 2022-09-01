using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour //skrypt przypisany do MenuCanvas
{
    public GameObject menuCanvas;
    void Start()
    {
       // GameState.LoadMyGameState();
        Cursor.visible = true;
    }
    public void StartPlaying()
    {
        Cursor.visible = false;
        menuCanvas.gameObject.SetActive(false);
    } 
    public void Quit()
    {
        Application.Quit();
    }
}
