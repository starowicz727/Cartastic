using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSettingsMenu : MonoBehaviour
{
    public GameObject carBody;
    public Button colorButton;
    public GameObject[] models;
    public Material[] materials;
    private int currentModel;
    private int currentColor;             
    private const int numberOfColors = 8;

    private void Start()
    {
        currentModel = 0;
        currentColor = 0;
    }
    public void ColorChange()
    {
        currentColor++;
        if (currentColor >= numberOfColors)
        {
            currentColor = 0;
        }

        carBody.GetComponent<MeshRenderer>().material = materials[currentColor];
    }
}

// 0 turkus  53FDC8       
// 1 pomarancz F8B476
// 2 niebieski  4ED6FF
// 3 zielony 6BFF7F
// 4 fiolet A400FF
// 5 czerwien FF0084
// 6 szary 727272
// 7 zolty FFFC26

