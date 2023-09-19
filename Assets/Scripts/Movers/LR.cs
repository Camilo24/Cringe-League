using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR : MonoBehaviour
{
    private float moveSpeed1;
    private float initialPosition1;

    void Start()
    {
        moveSpeed1 = 7f;
        initialPosition1 = transform.position.x;
    }

    void Update()
    {
        float additionalPosition = moveSpeed1 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + additionalPosition, transform.position.y, transform.position.z);

        if (transform.position.x > initialPosition1 + 3f)
        {
            moveSpeed1 = -7f;
        }

        if (transform.position.x < initialPosition1 - 3f)
        {
            moveSpeed1 = 7f;
        }
    }
}
