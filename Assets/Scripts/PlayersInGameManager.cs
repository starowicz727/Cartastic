using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInGameManager : MonoBehaviour
{
    // tu bedzie wczytywanie graczy z sceny menu zapisanych przez metode z playersmanager 
    private PlayerInputManager playersInGameInputManager;
    private void Awake()
    {
        playersInGameInputManager = FindObjectOfType<PlayerInputManager>();

        MenuInfo readMenuInfo = SaveDataFromMenu.LoadMenuInfo();

     //   playersInGameInputManager.playerJoinedEvent
    }
}
