using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectController : MonoBehaviour
{
    private Animator animator;
    public bool isDragable;
    public bool isFlowable;
    public bool isChangDirection;

    public float directionMultiplier = 1.0f;
    public float predirection = 0f;
    public float speedMultiplier = 1f;// ³t«×­¿²v
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
        animator.SetFloat("Direction", 0);
    }

    public void ControlTime(float scroll)
    {
        float dragAmount = Mathf.Abs(scroll);
        if (dragAmount !=0)
        {
            float direction = Mathf.Sign(scroll) * directionMultiplier;
            float speed = dragAmount * speedMultiplier;

            animator.speed += speed;

            if (direction != predirection)
            {
                isChangDirection = true;
                predirection = direction;
            }
            else
            {
                isChangDirection = false;
            }
            if (isChangDirection)
            {
                animator.speed = speed;
                animator.SetFloat("Direction", direction);
                Debug.Log(this.name+direction);
            }
        }
    }
    public void PauseTime()
    {
        Debug.Log("PauseTime");
        animator.speed = 0;
        //magicState = 0;
    }
}
