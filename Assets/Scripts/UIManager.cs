using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CarController CarController;
    [SerializeField] private Slider nitroSlider;

    void Start()
    {
        
    }

    void Update()
    {
        nitroSlider.value = CarController.nitroHave / 100;
    }
}
