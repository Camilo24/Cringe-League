using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle;
    private Rigidbody rigidBody;
    private float currentbreakForce;
    private bool isBreaking, canNitro, inNitro;
    [SerializeField] private float motorForce, breakForce, maxSteerAngle, jumpForce;
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;
    [SerializeField] private float nitro; 
    public float nitroHave;
    [SerializeField] ParticleSystem rearLeftParticle, rearRightParticle, rearLeftNitroParticle, rearRightNitroParticle;
    private GameObject[] sun;

    private void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        nitroHave = 100f;
        inNitro = false;
        sun = GameObject.FindGameObjectsWithTag("NitroBase");
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        FixAll();
        Jump();
        Nitro();
        ParticleManager();
    }

    private void ParticleManager()
    {
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            if (!rearLeftParticle.isPlaying)
            {
                rearLeftParticle.Play();
            }
        }

        else
        {
            if (rearLeftParticle.isPlaying)
            {
                rearLeftParticle.Stop();
            }
        }

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            if (!rearRightParticle.isPlaying)
            {
                rearRightParticle.Play();
            }
        }

        else
        {
            if (rearRightParticle.isPlaying)
            {
                rearRightParticle.Stop();
            }
        }

        if (inNitro)
        {
            rearLeftNitroParticle.Play();
            rearRightNitroParticle.Play();
        }

        if (!inNitro)
        {
            rearLeftNitroParticle.Stop();
            rearRightNitroParticle.Stop();
        }
    }

    private void Nitro()
    {
        if (nitroHave > 0)
        {
            canNitro = true;
        }

        if (nitroHave <= 0)
        {
            canNitro = false;
        }

        if (nitroHave > 0 && canNitro)
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = nitro;
                nitroHave = nitroHave - 0.2f;
                inNitro = true;
            }

            else
            {
                inNitro = false; 
            }
        }

        else
        {
            inNitro = false; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            inNitro = false;
        }
    }

    private void FixAll()
    {
        if (Input.GetMouseButton(1))
        {
            rigidBody.rotation = Quaternion.identity;
        }

        if (transform.position.y > 200f)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = 0f;
            transform.position = newPosition;
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.E);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NitroBase"))
        {
            other.gameObject.SetActive(false);
            canNitro = true;
            nitroHave = 100;
            Invoke("Respawn", 5f);
        }
    }

    private void Respawn()
    {
        for (int i = 0; i < sun.Length; i++)
        {
            sun[i].SetActive(true);
        }
    }

    /* To-Do
     * Timer - Ganar
     * Pausa
     * Postprocesado
     * Audio
     * Menu
     * */
}