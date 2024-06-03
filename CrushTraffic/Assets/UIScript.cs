using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LifesText;
    public GameObject DefeatWindow;
    public GameObject StartButton;

    public TextMeshProUGUI JumpsText;
    public Slider JumpsSlider;
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        GameManager.Instance.Music.Play();
        Time.timeScale = 1.0f;
        StartButton.SetActive(false);
    }

    private void Update()
    {
        RenderScore();
        RenderLifes();
        RenderJumps();
    }

    public void RenderJumps()
    {
        float jumps = GameManager.Instance.Jumps;
        string[] floatAsString = jumps.ToString().Split(",");

        float lowerPart = (float)Convert.ToDouble("0," + floatAsString[1]);
        int upperPart = Convert.ToInt32(floatAsString[0]);

        JumpsSlider.value = lowerPart;
        JumpsText.text = upperPart.ToString();
    }

    public void RenderLifes()
    {
        int lifes = GameManager.Instance.Lifes;
        LifesText.text = lifes.ToString();
    }
    public void RenderScore()
    {
        float score = GameManager.Instance.GlobalSpeed;
        ScoreText.text = $"{score:,00}";
    }
    public void ShowDefeatWindow()
    {
        DefeatWindow.SetActive(true);
        GameManager.Instance.Music.Stop();
        Time.timeScale = 0.0f;
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
