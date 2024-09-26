using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Rigidbody2D playerRB;
    private Vector2 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                targetPosition = touchPosition;
                isMoving = true;

                Debug.Log("Posición del touchh: " + touchPosition);
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {

            Vector2 newPosition = Vector2.MoveTowards(playerRB.position, targetPosition, speed * Time.fixedDeltaTime);
            playerRB.MovePosition(newPosition);

            if (Vector2.Distance(playerRB.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
