using UnityEngine;

public class TriggerDialogBrainModule : BrainModule
{
    public override void Create(Animator animator)
    {
        base.Create(animator);
        Dialog.Instance.onDialogShow.AddListener(() => animator.SetTrigger("dialog"));
    }

    public override void UpdateAnimator()
    {
    }
}