using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDana : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    BoxCollider2D boxCollider2;
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
            Eammon.instance.foundDan = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Dan.instance.transform.position = Eammon.instance.transform.position;
            Destroy(gameObject);
        }
    }
}
