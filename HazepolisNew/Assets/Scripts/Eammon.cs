using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eammon : MonoBehaviour
{
    //Singleton Mode
    public static Eammon instance;
    //change scene
    public string scenePassWord;
    public string KeyPassword;
    //QuestSystem
    //public Quest quest;
    //public int health = 100;
    //public int gold = 100;

    private SkeletonAnimation skeletonAnimation;
    private string previousState, currentState ;
    private Rigidbody2D rigid2D;
    private CircleCollider2D collider2D;
    private CapsuleCollider2D capcollider2D;
    private float jumpForce = 2000.0f;
    private float climbingSpeed = 3f;
    [SerializeField]
    private float walkForce;
    [SerializeField]
    private float maxWalkForce;
    private bool isJumping = false;
    public bool isClimbling = false;
    private bool afterSu = false;
    public bool foundDan = false;
    public int horizontalKey;
    public int verticalKey;

    bool inputEnabled = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CircleCollider2D>();
        capcollider2D = GetComponent<CapsuleCollider2D>();
        skeletonAnimation.state.SetAnimation(0, "sleep", false);
        currentState = "sleep";
    }
    void Update()
    {
        //��ܮɨ��ⰱ���
        if (DialogManager.isActive == true)
            return;
        if (inputEnabled == true)
        {
            Move();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision" + collision.gameObject.tag);

        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Bridge") && afterSu)
        {
            isJumping = false;
            skeletonAnimation.state.SetAnimation(0, currentState, true);
        }
    }
    private void WakeUp()
    {
        afterSu = true;
    }
    private void Move()
    {
        if (afterSu == false)
        {
            previousState = currentState;
            currentState = "su";
            if (previousState != currentState)
            {
                skeletonAnimation.state.SetAnimation(0, currentState, false);
            }
            else
            {
                Invoke("WakeUp", 7f);
            }
            previousState = currentState;
        }
        else if (afterSu)
        {
            horizontalKey = 0;
            verticalKey = 0;

            //climb
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 20, 1 << LayerMask.NameToLayer("ladder"));
            if (hitInfo.collider != null)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    verticalKey = 1;
                    isClimbling = true;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    verticalKey = -1;
                    isClimbling = true;
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {
                        isClimbling = false;
                    }
                }
            }
            else
            {
                isClimbling = false;
            }
            if (isClimbling == true && hitInfo.collider != null)
            {
                currentState = verticalKey == 0 ? "ladderidle" : "ladder";
                rigid2D.velocity = new Vector2(0, verticalKey*climbingSpeed);
                rigid2D.gravityScale = 0;
                Physics2D.IgnoreLayerCollision(9, 10, true);
            }
            else
            {
                rigid2D.gravityScale = 2;
                Physics2D.IgnoreLayerCollision(9, 10, false);
            }
            //jump
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                isJumping = true;
                rigid2D.AddForce(transform.up * jumpForce);
                skeletonAnimation.state.SetAnimation(0, "jump", false);
            }
            //basic movement
            if (Input.GetKey(KeyCode.A))
            {
                horizontalKey = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                horizontalKey = 1;
            }
            //Crouch or Standing
            if(isClimbling == false)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    currentState = horizontalKey == 0 ? "Crouch idle2" : "Crouch walk2";
                    maxWalkForce = 3.0f;
                    collider2D.enabled = false;
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        currentState = horizontalKey == 0 ? "idle" : "run";
                        walkForce = 200.0f;
                        maxWalkForce = 9.0f;
                    }
                    else
                    {
                        currentState = horizontalKey == 0 ? "idle" : "walk";
                        walkForce = 122.0f;
                        maxWalkForce = 5.0f;
                    }
                    collider2D.enabled = true;
                }
            }
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);
            if (speedx < maxWalkForce)
            {
                rigid2D.AddForce(transform.right * horizontalKey * walkForce);

            }
            if (previousState != currentState)
            {
                skeletonAnimation.state.SetAnimation(0, currentState, true);
            }
            previousState = currentState;

            if (horizontalKey != 0)
            {
                skeletonAnimation.Skeleton.ScaleX = horizontalKey > 0 ? -1f : 1f;
            }
        }
    }
    private void MagicTimeReverseSpeedUp()
    {
        skeletonAnimation.state.SetAnimation(0, "Magic time reverse speed up", false);
    }

    private void MagicTimeStop()
    {
        skeletonAnimation.state.SetAnimation(0, "Magic time stop", false);
    }

    public void Activate()
    {
        inputEnabled = true;
        //if(scenePassWord == "gate" && Input.GetKeyDown(KeyCode.F))
        //{
        //    foundDan = true;
        //}
        if (foundDan)
        {
            gameObject.GetComponent<FollowingPlayer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<FollowingPlayer>().enabled = false;
        }
    }

    public void Deactivate()
    {
        inputEnabled = false;
        gameObject.GetComponent<FollowingPlayer>().enabled = false;
        gameObject.GetComponent<FollowingPlayer>().positionList.Clear();
    }

    //public void GoGathring()
    //{
    //    if (quest.isActive)
    //    {
    //        if (quest.goal.isReached())
    //        {
    //            gold += quest.goldReward;
    //            quest.Complete();
    //        }
    //    }
    //}
}


