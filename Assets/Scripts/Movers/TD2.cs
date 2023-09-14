using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD2 : MonoBehaviour
{
    private float moveSpeed;

    private void Start()
    {
        StartCoroutine(BehaviorRoutine());
        moveSpeed = 20f;
    }

    IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            float additionalPosition = moveSpeed * Time.deltaTime;

            while (transform.position.y < 10f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + additionalPosition, transform.position.z);
                yield return null;
            }

            while (transform.position.y > -4.41f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - additionalPosition, transform.position.z);
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }
}
