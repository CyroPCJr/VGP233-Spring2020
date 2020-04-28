﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private Character character;
    private Dictionary<string, float> animationNameLengthDictionary = new Dictionary<string, float>();

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<Character>();

        character.OnMovePerformed += PerformMove;
        character.OnMoveReceived += ReceiveMove;

        foreach(AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            animationNameLengthDictionary.Add(clip.name, clip.length);
    }

    public float GetAnimationLength(string name)
    {
        if (animationNameLengthDictionary.ContainsKey(name))
            return animationNameLengthDictionary[name];
        throw new System.Exception("The animation of name " + name + " does not exist in the animationNameLengthDictionary");
    }

    private void PerformMove()
    {
        // TODO: get trigger name from Move
        animator.SetTrigger("Attack");
    }

    private void ReceiveMove()
    {
        // TODO: get trigger name from Move
        animator.SetTrigger("Damage");
    }
}