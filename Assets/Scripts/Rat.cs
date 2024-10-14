using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float speed = 4f;
    private Vector2 targetPosition;
    private bool movingToPointB = true;

    private void Start()
    {
        targetPosition = pointB.position;
    }

    private void Update()
    {
        MoveRat();
        FlipRat();
    }

    private void MoveRat()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) <= 0.5f)
        {
            if (movingToPointB)
            {
                Debug.Log("puntoB");
                targetPosition = pointA.position;
                movingToPointB = false;
            }
            else
            {
                Debug.Log("puntoA");
                targetPosition = pointB.position;
                movingToPointB = true;
            }
        }
    }

    private void FlipRat()
    {
        if (transform.position.x < targetPosition.x)
        {
            transform.localScale = new Vector3(.21f, .21f, .21f);
        }
        else if (transform.position.x > targetPosition.x)
        {
            transform.localScale = new Vector3(-.21f, .21f, .21f);
        }
    }
}
