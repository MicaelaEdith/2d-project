using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Rigidbody2D playerRB;
    private Vector2 targetPosition;
    private bool isMoving = false;
    public int selectedObject { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField]
    private LayerMask structure;
    private int lastSelectedObject = -1;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
}


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    targetPosition = touchPosition;
                    isMoving = true;
                }
            }
            else
            {
                SelectObjectFromUI(touch.position);
            }
        }

        /*RaycastHit2D rcStructureL = Physics2D.Raycast(transform.position + new Vector3(-1, 0.5f), Vector2.up, 0.5f, structure);
        RaycastHit2D rcStructureR = Physics2D.Raycast(transform.position + new Vector3(1, 0.5f), Vector2.up, 0.5f, structure);

        if (rcStructureL && !rcStructureR)
        {
            transform.position += new Vector3(0.5f, 0);
            Debug.Log("move R");
        }
        if (rcStructureR && !rcStructureL)
        {
            transform.position -= new Vector3(0.5f, 0);
            Debug.Log("move L");
        }*/

        animator.SetBool("isRunning", isMoving);
        Flip();
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

    private void SelectObjectFromUI(Vector2 touchPosition)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = touchPosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            GridItem gridItem = result.gameObject.GetComponent<GridItem>();

            if(FindObject(gridItem)) break;
            
        }
    }
    private bool FindObject(GridItem gridItem)
    {
        if (gridItem != null)
        {   
            ////////////////////
            if (gridItem.key == lastSelectedObject)
            {
                Debug.Log("else");
                selectedObject = -1;
                lastSelectedObject = selectedObject;
                gridItem.selectedImg.SetActive(false);
            }
            else
            {
                Debug.Log("if");
                selectedObject = gridItem.key;
                lastSelectedObject = selectedObject;
                gridItem.selectedImg.SetActive(true);
                foreach (var no in gridItem.noSelected)
                {
                    no.SetActive(false);
                }
            }

             return true; /////////////////////
        }
        return false;

    }

    private void Flip()
    {
        if (transform.position.x < targetPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x > targetPosition.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}
