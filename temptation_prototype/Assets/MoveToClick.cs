using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    public float speed = 2f;
    private float distance;
    Vector3 mousePos, transPos, targetPos;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - targetPos.x;
        if (Input.GetMouseButtonDown(0))
        {
            GetTargetPos();
        }
        MoveToTarget();
        if(distance != 0)
        {
            if(distance > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(distance < 0)
            {
                spriteRenderer.flipX = false;
            }
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void GetTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, -2.02f, 0);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
    }
}
