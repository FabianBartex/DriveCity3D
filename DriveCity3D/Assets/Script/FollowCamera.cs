using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;   // carro
    public Vector3 offset = new Vector3(0, 5, -8); // posição atrás e acima
    public float smoothSpeed = 0.15f;

    void LateUpdate()
    {
        if (target == null) return;

        // posição desejada
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // suavizar movimento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // olhar para o carro
        transform.LookAt(target);
    }
}

