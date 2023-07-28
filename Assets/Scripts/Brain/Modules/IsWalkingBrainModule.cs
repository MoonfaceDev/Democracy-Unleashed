using UnityEngine;

public class IsWalkingBrainModule : BrainModule
{
    private Walk walk;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        walk = animator.GetComponentInParent<Walk>();
    }

    public override void UpdateAnimator()
    {
        Animator.SetBool("isWalking", walk.direction != Vector2.zero);
    }
}