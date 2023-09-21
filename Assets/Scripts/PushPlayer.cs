using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [SerializeField] private GameObject porteria1, porteria2;
    private Rigidbody rb1, rb2, rb;

    private void Start()
    {
        rb1 = porteria1.GetComponent<Rigidbody>();
        rb2 = porteria2.GetComponent<Rigidbody>();
        rb = this.GetComponent<Rigidbody>();
    }

    public void Push1()
    {
        Vector3 direccion = rb1.transform.position - transform.position;
        direccion.Normalize();

        rb.AddForce(direccion * pushForce, ForceMode.Impulse);
    }

    public void Push2()
    {
        Vector3 direccion = rb2.transform.position - transform.position;
        direccion.Normalize();

        rb.AddForce(direccion * pushForce, ForceMode.Impulse);
    }
}
