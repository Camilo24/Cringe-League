using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private bool touched;
    [SerializeField] private GameObject based;

    void Start()
    {
        
    }

    void Update()
    {
        if (touched)
        {
            based.SetActive(false);
            touched = false;
            Invoke("Respawn", 5f);
        }
    }

    public void GetTouch()
    {
        touched = true;
    }

    private void Respawn()
    {
        based.SetActive(true);
    }
}
