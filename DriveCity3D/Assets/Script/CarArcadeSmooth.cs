using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarArcadeSmooth : MonoBehaviour
{
    public float acceleration = 10f;       // força de acelerar
    public float deceleration = 12f;       // força de desacelerar
    public float reverseAcceleration = 8f; // aceleração da ré
    public float turnSpeed = 100f;         // velocidade de virar
    public float maxSpeed = 25f;           // velocidade máxima
    public float reverseMaxSpeed = 12f;    // velocidade máxima de ré

    private float currentSpeed = 0f;       // velocidade atual
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical");   // W / S
        float steer = Input.GetAxis("Horizontal"); // A / D

        // ➤ ACELERAÇÃO PARA FRENTE (gradual)
        if (input > 0)
        {
            currentSpeed += acceleration * input * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }

        // ➤ RÉ (gradual)
        else if (input < 0)
        {
            currentSpeed += reverseAcceleration * input * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseMaxSpeed, 0);
        }

        // ➤ DESACELERAÇÃO NATURAL (quando jogador solta o W/S)
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                if (currentSpeed < 0) currentSpeed = 0;
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.deltaTime;
                if (currentSpeed > 0) currentSpeed = 0;
            }
        }

        // ➤ MOVIMENTO DO CARRO
        rb.velocity = transform.forward * currentSpeed;

        // ➤ VIRAR (só se estiver em movimento)
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            transform.Rotate(Vector3.up * steer * turnSpeed * Time.deltaTime);
        }
    }
}

