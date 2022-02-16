using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    public Transform cam;
    public float shakeMagnitude;
    public float shakeDuration;
    public float dampingSpeed;
    Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = cam.localPosition;
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            cam.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;


        }
        else
        {
            shakeDuration = 0f;
            cam.localPosition = new Vector3(0, 0, -10);
        }
    }
}
