using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CarController CarController;
    [SerializeField] private Slider nitroSlider;
    [SerializeField] private ParticleSystem p1, p2;
    [SerializeField] private PushPlayer pushp;
    [SerializeField] private GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        nitroSlider.value = CarController.nitroHave / 100;
    }

    public void MadeAGoal1()
    {
        p1.Play();
        pushp.Push1();
        Invoke("Won", 2f);
        Invoke("ReloadScene", 5f);
    }

    public void MadeAGoal2()
    {
        p2.Play();
        pushp.Push2();
        Invoke("Won", 2f);
        Invoke("ReloadScene", 5f);
    }

    private void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void Won()
    {
        winPanel.SetActive(true);
    }
}
