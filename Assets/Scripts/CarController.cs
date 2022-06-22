using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    //public enum ControlMode
    //{
    //    Keyboard,
    //    Buttons
    //};

    public enum Axle
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
      //  public GameObject wheelEffectObj;
       // public ParticleSystem smokeParticle;
        public Axle axle;
    }

   // public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;
    public float maxSpeed = 200.0f;
    public float speed = 0.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;
    //private CarLights carLights;

    public Text speedTxt;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

       // carLights = GetComponent<CarLights>();
    }

    private Vector2 movementInput = Vector2.zero;
    public void OnMove(InputAction.CallbackContext context) //potrzebne do unity inputsystem 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private bool braking = false;
    private float brakingValue = 0;
    public void OnBreak(InputAction.CallbackContext context)
    {
        braking = context.action.triggered;
        brakingValue = context.ReadValue<float>();
        //Debug.Log(brakingValue);
    }
    private float acceleratingInputValue = 0;
    private float accelerating = 600;
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        acceleratingInputValue = context.ReadValue<float>();
    }

    void Update()
    {
        GetInputs();
        AnimateWheels();
        //   WheelEffects();
        WriteSpeed();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }


    void GetInputs()
    {
        // if (control == ControlMode.Keyboard) //wersja ze starym input system
        // { 
        //  moveInput = -Input.GetAxis("Vertical");   
        //  steerInput = Input.GetAxis("Horizontal");
        //  }
        moveInput = -movementInput.y;
        steerInput = movementInput.x;
    }

    void Move()
    {
        speed = (int)Math.Round(carRb.velocity.magnitude * 3.6);

        if(speed > maxSpeed)
        {
            acceleratingInputValue = 0;
        }
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = -accelerating * acceleratingInputValue * maxAcceleration * Time.deltaTime; //* moveInput mozna usunac POZNIEJ ZEBY STEROWAC TYLKO TRIGGERAMI moveInput  * 
        }

    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axle == Axle.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f); 
            }
        }
    }

    void Brake()
    {
        if (braking)    //to do jechania do tylu wciskajac hamulec , jedynie co to trzeba wprowadzic kontrole predkosci np stala dla kazdego auta 30 kmh 
        {
            if (speed > maxSpeed)
            {
                brakingValue = 0;
            }
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.motorTorque = accelerating * brakingValue * brakeAcceleration * Time.deltaTime;
            }
        }
        //else if

        // if (Input.GetKey(KeyCode.Space) || moveInput == 0) // wersja ze starym input system
        //if (braking || moveInput == 0)
        //{
        //    foreach (var wheel in wheels)
        //    {
        //        wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime *brakingValue;
        //    }
          
        //    // carLights.isBackLightOn = true;
        //    //  carLights.OperateBackLights();
        //}
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }

         //   carLights.isBackLightOn = false;
        //    carLights.OperateBackLights();
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
           // wheel.wheelModel.transform.rotation = rot;

            //Debug.Log(steerInput);
            // wheel.wheelModel.transform.eulerAngles = new Vector3(0, 90 + rot.y + steerInput * maxSteerAngle, 0);   // OBRACANIE KOL DO POPRAWY
            
            


        }
    }

    void WriteSpeed()
    {
        speedTxt.text = speed.ToString();
    }

    //void WheelEffects()
    //{
    //    foreach (var wheel in wheels)
    //    {
    //        //var dirtParticleMainSettings = wheel.smokeParticle.main;

    //        if (Input.GetKey(KeyCode.Space) && wheel.axle == Axle.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
    //        {
    //            wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
    //            wheel.smokeParticle.Emit(1);
    //        }
    //        else
    //        {
    //            wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
    //        }
    //    }
    //}
}