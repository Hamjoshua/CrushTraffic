using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Lifes = 3;
    public float Speed = 3f;
    public float JumpForse = 60f;

    private Vector3 _movement;
    private bool _inAir = false;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Debug.Log(Input.GetAxis("Jump"));

        if(Input.GetAxis("Jump") != 0f && !_inAir)
        {
            _rb.AddForce(Vector3.up * JumpForse * Time.deltaTime, ForceMode.Impulse);
            _inAir = true;
        }

        _movement = new Vector3(xMove * Speed, 0f, zMove * Speed);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Car")
        {
            Lifes -= 1;
        }
    }
}
