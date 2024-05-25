using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Global Speed")]
    [SerializeField]
    private float _increasingStep = 0.1f;
    [SerializeField]
    private float _timeForIncreaseSpeed = 1f;
    public float GlobalSpeed = 0f;

    [Space(5)]
    private bool _isOver;

    public void Start()
    {
        if(Instance == null)
        {
            Instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        }
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (!_isOver)
        {
            yield return new WaitForSeconds(_timeForIncreaseSpeed);
            GlobalSpeed += _increasingStep;
        }        
    }
}
