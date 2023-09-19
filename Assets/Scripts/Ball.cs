using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portería 1"))
        {
            uiManager.MadeAGoal1();
        }

        if (other.gameObject.CompareTag("Portería 2"))
        {
            uiManager.MadeAGoal2();
        }
    }
}
