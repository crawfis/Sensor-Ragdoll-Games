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
    private Animation playerAnimation;
    public Animator Animator;

    private void Awake()
    {
        playerAnimation = bodyToAnimate.GetComponent<Animation>();
    }
    private void OnEnable()
    {
        TestPlayerInputManager.moveDown += TestPlayerInputManagerRunBackwards; ;
        TestPlayerInputManager.moveUp += TestPlayerInputManagerRunForward; ;
        TestPlayerInputManager.moveRight += TestPlayerInputManagerRunForward;
        TestPlayerInputManager.moveLeft += TestPlayerInputManagerRunForward;
        TestPlayerInputManager.StrafeRightRequest += TestPlayerInputManagerRunForward;
        TestPlayerInputManager.StrafeLeftRequest += TestPlayerInputManagerRunForward;

        
    }

    private void TestPlayerInputManagerRunForward(object sender, EventArgs e)
    {
        playerAnimation.clip = walking;
        playerAnimation.Play();
        playerAnimation.CrossFadeQueued(idle.name);
    }

    private void TestPlayerInputManagerRunBackwards(object sender, EventArgs e)
    {
        playerAnimation.clip = backwards;
        playerAnimation.Play();
        playerAnimation.PlayQueued(idle.name);
    }



}
