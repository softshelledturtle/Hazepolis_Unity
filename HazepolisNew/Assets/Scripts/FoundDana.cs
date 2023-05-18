using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDana : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    BoxCollider2D boxCollider2;
    bool completeTalk;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        boxCollider2 = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            skeletonAnimation.state.SetAnimation(0, "su", false);
            skeletonAnimation.timeScale = 1;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                completeTalk = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && completeTalk)
        {
            Eammon.instance.foundDan = true;
            Eammon.instance.KeyPassword = "foundDan";
            Destroy(gameObject);
        }
    }
}
