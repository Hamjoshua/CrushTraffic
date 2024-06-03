using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float Speed = 3.0f;
    public float JumpForse = 60.0f;
    public float AirMultiplier = 0.4f;

    private Vector3 _movement;
    private Rigidbody _rigidBody;
    private bool _onGround = true;

    public AudioSource JumpAddedSFX;
    public AudioSource MakeJumpSFX;
    public AudioSource NewJumpIsReadySFX;
    public AudioSource JumpIsNotReadySFX;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.Lifes > 0)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            _movement = new Vector3(xMove * Speed, 0.0f, zMove * Speed);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameManager.Instance.Jumps >= 1.0f
                    && _onGround)
                {
                    GameManager.Instance.Jumps -= 1.0f;
                    _onGround = false;
                    MakeJumpSFX.Play();
                    _rigidBody.AddForce(Vector3.up * JumpForse, ForceMode.Impulse);

                }
                else
                {
                    JumpIsNotReadySFX.Play();
                }
            }

            if (_onGround)
            {
                _rigidBody.AddForce(_movement, ForceMode.Force);
            }
            else
            {
                _rigidBody.AddForce(_movement * AirMultiplier, ForceMode.Force);
            }
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
            JumpAddedSFX.Play();
            GameManager.Instance.Jumps += GameManager.Instance.JumpIncrease;
            if (IsNewJumpReady())
            {
                NewJumpIsReadySFX.Play();
            }
        }
    }

    bool IsNewJumpReady()
    {
        string lastLetter = GameManager.Instance.Jumps.ToString().Split(',')[0];

        return lastLetter == "0";
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
