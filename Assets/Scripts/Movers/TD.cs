using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD : MonoBehaviour
{
    private float moveSpeed;
    private float initialPosition;
    private bool movingUp = true;

    void Start()
    {
        Time.timeScale = 1f;
        initialPosition = transform.position.y;
        moveSpeed = 7f;
    }

    void Update()
    {
        float additionalPosition = moveSpeed * Time.deltaTime;

        if (movingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + additionalPosition, transform.position.z);

            if (transform.position.y > initialPosition + 4f)
            {
                movingUp = false;
            }
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - additionalPosition, transform.position.z);

            if (transform.position.y < initialPosition)
            {
                movingUp = true;
            }
        }
    }
}
