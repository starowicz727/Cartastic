using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarModifier : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] cars;
    private int currentModel;
    private int currentColor;

    private bool changingModel = false;

    void Start()
    {
        currentModel = 0;
        currentColor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnModelChange(InputAction.CallbackContext context)
    {
        changingModel = context.action.triggered;
    }

    void ChangeModel()
    {
        if (changingModel)
        {
            cars[currentModel].gameObject.SetActive(false);
            currentModel++;
            if (currentModel >= cars.Length) //gdy ju¿ przejrzelismy ka¿dy samochód w tablicy i chcemy cofn¹æ siê na pocz¹tek
            {
                currentModel = 0;
            }
            cars[currentModel].gameObject.SetActive(true);
        }
    }
}
