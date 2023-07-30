using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogBrainModule : BrainModule
{
    public Dialog dialog;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        dialog.onDialogShow.AddListener(() => animator.SetTrigger("dialog"));
    }

    public override void UpdateAnimator()
    {
        ;
    }
}
