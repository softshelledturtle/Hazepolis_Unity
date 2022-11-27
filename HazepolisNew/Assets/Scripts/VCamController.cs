using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamController : MonoBehaviour
{
    private Cinemachine.CinemachineConfiner confiner;
    private Collider2D mapConfiner;

    private void Start()
    {
        confiner = GetComponent<Cinemachine.CinemachineConfiner>();
        mapConfiner = GameObject.FindWithTag("MapConfiner").GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        confiner.m_BoundingShape2D = mapConfiner;
    }
}
