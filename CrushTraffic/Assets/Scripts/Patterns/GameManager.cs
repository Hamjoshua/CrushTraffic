using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Global Speed")]
    [SerializeField]
    private float _increasingStep = 0.1f;
    [SerializeField]
    private float _timeForIncreaseSpeed = 1.0f;
    public float GlobalSpeed = 0.0f;

    public AudioSource Music;
    public UnityEvent OnDefeat;

    [Header("Player")]
    public float JumpIncrease = 0.2f;
    public float Jumps;
    public int Lifes;

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
