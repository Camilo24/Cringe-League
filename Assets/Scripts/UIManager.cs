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

    void Start()
    {
        
    }

    void Update()
    {
        nitroSlider.value = CarController.nitroHave / 100;
    }

    public void MadeAGoal1()
    {
        p1.Play();
        Invoke("ReloadScene", 5f);
    }

    public void MadeAGoal2()
    {
        p2.Play();
        Invoke("ReloadScene", 5f);
    }

    private void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
