using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class DynamicObject : MonoBehaviour
{
    public UnityEvent ActionsOnCameraExit;
    public UnityEvent ActionsOnBottomTouch;
    public float Speed;

    [SerializeField]
    private float _globalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _globalSpeed = Speed;
    }

    protected void PlaySound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveDown();
        _globalSpeed = Speed + GameManager.Instance.GlobalSpeed;
    }

    private void MoveDown()
    {
        transform.Translate(_globalSpeed * Vector3.forward * -1 * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Trigger")
        {
            ActionsOnBottomTouch.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Trigger")
        {
            ActionsOnCameraExit.Invoke();
            Die();
        }        
    }
}
