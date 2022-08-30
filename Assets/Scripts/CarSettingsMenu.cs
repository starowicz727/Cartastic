using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSettingsMenu : MonoBehaviour // skrypt przypisany do carsettingscanvas
{
    public GameObject look;
    private GameObject carBody;
    public GameObject[] models;
    public Material[] materials;
    private int currentModel;
    private int currentColor;
    private int numberOfColors;
    private const int numberOfModels = 6;  //6 modeli 

    private void Start()
    {
        currentModel = 0;
        currentColor = 0;
        // carBody = GetChildWithName(look, "Car 3");
        Instantiate(models[currentModel], look.transform);
        carBody = GetChildWithName(look, models[currentModel].name + "(Clone)");

        numberOfColors = materials.Length;
    }
    public void ColorChange() // metoda przypisana do przycisku zmiany koloru aut
    {
        currentColor++;
        if (currentColor >= numberOfColors)
        {
            currentColor = 0;
        }

        carBody.GetComponent<MeshRenderer>().material = materials[currentColor];
    }

    public void ModelChange() //metoda przypisana do przycisku zmiany modeli aut
    {
        currentModel++;
        if (currentModel >= numberOfModels)
        {
            currentModel = 0;
        }

        Destroy(carBody);
        Instantiate(models[currentModel], look.transform);
        carBody = GetChildWithName(look, models[currentModel].name+"(Clone)");

        currentColor--;
        ColorChange();
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
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
// 8 czarny

