using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockbackscript : MonoBehaviour
{
    public string Tag;
    public Rigidbody reggiebody;
    public float knockbackForce;
    public float screenShakeIntensity;
    public UnityEngine.Events.UnityEvent OnKnockBack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Vector2 touchDirection = this.transform.position - other.transform.position;

            
        }
    }
}
