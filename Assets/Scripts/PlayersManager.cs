using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour
{
    public Camera startCamera;
    [SerializeField]
    private List<PlayerInput> players = new List<PlayerInput>();
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
        }
        else
        {
            startCamera.gameObject.SetActive(true);
        }

        Transform playerParent = player.transform.parent;
        playerParent.position = startingPoints[players.Count - 1].position;
        //player.transform.position = startingPoints[players.Count-1].position;
    }
}