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
        ChangeModel();
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
            Transform positionToPutNewCar = cars[currentModel].gameObject.transform;
            currentModel++;
            if (currentModel >= cars.Length) //gdy ju� przejrzelismy ka�dy samoch�d w tablicy i chcemy cofn�� si� na pocz�tek
            {
                currentModel = 0;
            }

            cars[currentModel].gameObject.gameObject.transform.position = new Vector3(positionToPutNewCar.position.x, positionToPutNewCar.position.y, positionToPutNewCar.position.z); //ustaw nowy w miejscu starego
            mainCamera.gameObject.GetComponent<CameraFollow>().CarTarget = cars[currentModel].gameObject.transform; // ustaw kamer� na �ledzenie nowego modelu
            cars[currentModel].gameObject.gameObject.SetActive(true); // zr�b nowy widzialnym 
            
        }
    }
}
