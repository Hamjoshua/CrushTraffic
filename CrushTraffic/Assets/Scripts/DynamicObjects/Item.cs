using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : DynamicObject
{
    public UnityEvent EventOnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventOnCollision.Invoke();
            Destroy(gameObject);
        }
    }

    public void KillEmAll()
    {
        Debug.Log("--ENEMIES");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Car");
        foreach(var enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void HealPlayer()
    {
        Debug.Log("++LIFE");
        GameManager.Instance.Lifes += 1;
    }

    public void GiveOneJump()
    {
        Debug.Log("++JUMP");
        GameManager.Instance.Jumps += 1;
    }
}
