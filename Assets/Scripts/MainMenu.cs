using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour //skrypt przypisany do MenuCanvas
{
    void Start()
    {
       // GameState.LoadMyGameState();
        Cursor.visible = true;
    }
    public void StartPlaying()
    {
        SceneManager.LoadScene("Level");
    } 
    public void Quit()
    {
        Application.Quit();
    }
}
