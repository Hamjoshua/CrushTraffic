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
            Rigidbody _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.AddForce(Vector3.forward * CollisionImpact, ForceMode.Impulse);
        }
    }
}
