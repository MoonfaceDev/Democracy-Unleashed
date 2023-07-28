using UnityEngine;

public class LookDirectionBrainModule : BrainModule
{
    private Walk walk;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        walk = animator.GetComponentInParent<Walk>();
    }

    public override void UpdateAnimator()
    {
        Animator.SetInteger("lookDirection", (int)walk.lookDirection);
    }
}