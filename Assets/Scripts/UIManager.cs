using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CarController CarController;
    [SerializeField] private Slider nitroSlider;
    [SerializeField] private ParticleSystem p1, p2;
    [SerializeField] private PushPlayer pushp;
    [SerializeField] private GameObject winPanel, pausePanel;
    [SerializeField] private TextMeshProUGUI time, winTimer;
    private float currentTime;
    private int roundedTime;
    private bool paused;

    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        time.text = "Time: " + 00;
    }

    void Update()
    {
        nitroSlider.value = CarController.nitroHave / 100;
        Pause();
        Timer();
        GoToMenu();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
                pausePanel.SetActive(true);
                paused = true;
                Time.timeScale = 0f;
            }

            else
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                paused = false;
            }
        }
    }

    void Timer()
    {
        currentTime += Time.deltaTime;
        roundedTime = Mathf.RoundToInt(currentTime);
        time.text = "Time: " + roundedTime;
    }

    public void MadeAGoal1()
    {
        p1.Play();
        pushp.Push1();
        Invoke("Won", 2f);
        Invoke("ReloadScene", 3f);
    }

    public void MadeAGoal2()
    {
        p2.Play();
        pushp.Push2();
        Invoke("Won", 2f);
        Invoke("ReloadScene", 3f);
    }

    private void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void Won()
    {
        winTimer.text = "Time: " + roundedTime;
        winPanel.SetActive(true);
    }

    void GoToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
