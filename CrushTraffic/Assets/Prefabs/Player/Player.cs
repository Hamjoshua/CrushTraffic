using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float Speed = 3f;
    public float JumpForse = 60f;

    private Vector3 _movement;
    private Rigidbody _rb;
    private bool _onGround = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.Lifes > 0)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            _movement = new Vector3(xMove * Speed, 0f, zMove * Speed);

            if (Input.GetKeyDown(KeyCode.Space) &&
                GameManager.Instance.Jumps >= 1f && 
                _onGround)
            {
                GameManager.Instance.Jumps -= 1f;
                _onGround = false;
                _rb.AddForce(Vector3.up * JumpForse, ForceMode.Impulse);
            }

            _rb.AddForce(_movement, ForceMode.Force);
        }
        else
        {
            GameManager.Instance.OnDefeat.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            Debug.Log("Jump ready");
            GameManager.Instance.Jumps += 0.2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onGround = true;

        if (collision.transform.tag == "Car")
        {
            Debug.Log("Minus Life");

            GameManager.Instance.Lifes -= 1;
        }
    }
}
