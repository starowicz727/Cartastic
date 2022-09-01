using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class MenuInfo
{
    public List<PlayerInput> playersInp;
    public string secretPassword;

    public MenuInfo(List<PlayerInput> playersInp, string secretPassword)
    {
        this.playersInp = playersInp;
        this.secretPassword = secretPassword;
    }
}
