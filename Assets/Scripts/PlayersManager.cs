using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour
{
    public Camera startCamera;
    public GameObject panel;
    public GameObject panelLid; //przykrywka tajemniczej czwartej kamery po prawej od do³u ekranu jak jest 3 graczy
    public Button readyToStartButton;


    [SerializeField]
    public static List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;

    private PlayerInputManager playerInputManager;
    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
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
            startCamera.gameObject.SetActive(false);
            panel.SetActive(false);
            readyToStartButton.gameObject.SetActive(true);
            if (players.Count == 3)
            {
                panelLid.SetActive(true);
            }
            else
            {
                panelLid.SetActive(false);
            }
        }
        else
        {
            startCamera.gameObject.SetActive(true);
            panel.SetActive(true);
            readyToStartButton.gameObject.SetActive(false);
        }

        //Transform playerParent = player.transform.parent;
        //playerParent.position = startingPoints[players.Count - 1].position;
        player.transform.position = startingPoints[players.Count-1].position;

    }

    public void StartGameButtonClicked()
    {
        //tu trzeba bd zapisac players do pliku i odczytac ich na nast scenie 
    }
}