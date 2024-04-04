using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Player;
    public GameObject timerCanvas;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); 
        animator.Play("Level01");
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Intro01") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            mainCamera.SetActive(true);
            Player.SetActive(true);
            timerCanvas.SetActive(true);
            this.enabled = false;
        }
    }
}