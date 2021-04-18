using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] GameObject bodyToAnimate;
    public AnimationClip idle;
    public AnimationClip walking;
    public AnimationClip backwards;
    private Animation animation;

    private void Awake()
    {
        animation = bodyToAnimate.GetComponent<Animation>();
    }
    private void OnEnable()
    {
        TestPlayerInputManager.moveDown += TestPlayerInputManagerRunBackwards; ;
        TestPlayerInputManager.moveUp += TestPlayerInputManagerRunForward; ;
        TestPlayerInputManager.moveRight += TestPlayerInputManagerRunForward;
        TestPlayerInputManager.moveLeft += TestPlayerInputManagerRunForward;

        
    }

    private void TestPlayerInputManagerRunForward(object sender, EventArgs e)
    {
        animation.clip = walking;
        animation.Play();
        animation.CrossFadeQueued(idle.name);
    }

    private void TestPlayerInputManagerRunBackwards(object sender, EventArgs e)
    {
        animation.clip = backwards;
        animation.Play();
        animation.PlayQueued(idle.name);
    }



}
