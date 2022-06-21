using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

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

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;

    //private CarLights carLights;

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
    public void OnBreak(InputAction.CallbackContext context)
    {
        braking = context.action.triggered;
    }

    void Update()
    {
        GetInputs();
        AnimateWheels();
     //   WheelEffects();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    //public void MoveInput(float input)
    //{
    //    moveInput = input;
    //}

    //public void SteerInput(float input)
    //{
    //    steerInput = input;
    //}

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
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
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
        // if (Input.GetKey(KeyCode.Space) || moveInput == 0) // wersja ze starym input system
        if (braking || moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }

           // carLights.isBackLightOn = true;
          //  carLights.OperateBackLights();
        }
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