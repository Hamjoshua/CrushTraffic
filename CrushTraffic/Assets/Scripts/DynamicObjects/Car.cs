using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : DynamicObject
{
    public float CollisionImpact = 20f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaySound();
            Rigidbody _rb = GetComponent<Rigidbody>();
            _rb.AddForce(Vector3.forward * 1 * CollisionImpact, ForceMode.Impulse);
        }
    }
}
