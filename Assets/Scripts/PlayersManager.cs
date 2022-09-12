using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersManager : MonoBehaviour // skrypt przypisany do playermanager
{
    public Text howToJoinTxt;

    [SerializeField]
    public static List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;

    private PlayerInputManager playerInputManager;
    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();

        //DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);

        if (players.Count > 0)
        {
            howToJoinTxt.gameObject.SetActive(false);
        }
        else
        {
            howToJoinTxt.gameObject.SetActive(true);
        }

        //Transform playerParent = player.transform.parent;
        //playerParent.position = startingPoints[players.Count - 1].position;
        player.transform.position = startingPoints[players.Count-1].position;

    }

    //public void StartGameButtonClicked() // przycisk zaczynaj¹cy grê 
    //{
    //    //tu trzeba bd zapisac players (public static List<PlayerInput> players = new List<PlayerInput>();) do pliku i odczytac ich na nast scenie 


    //    passwordTxt = passwordInput.text.Equals("") ? "secretpassword" : passwordInput.text;
    //  //  MenuInfo infoToSave = new MenuInfo(players, secretPassword);
    //   // SaveDataFromMenu.SaveMenuInfo(infoToSave);

    //   // SceneManager.LoadScene("Level");
    //}
}