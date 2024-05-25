using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : DynamicObject
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            // TODO отнимать здоровье
        }
    }
}
