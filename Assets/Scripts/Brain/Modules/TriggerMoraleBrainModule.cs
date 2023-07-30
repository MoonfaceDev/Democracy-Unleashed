using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ExtEvents;

public class TriggerMoraleBrainModule : BrainModule
{
    public Morale playerMorale;

    
    public override void Create(Animator animator)
    {
        base.Create(animator);
        playerMorale.onLevelUp += () => animator.SetTrigger("morale");
    }

    public override void UpdateAnimator()
    {
        ;
    }
}
