using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Look Direction")]
public class LookDirectionBrainModule : BrainModule
{
    private Walk walk;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        walk = animator.GetComponent<Walk>();
    }

    public override void UpdateAnimator()
    {
        Animator.SetInteger("lookDirection", (int)walk.lookDirection);
    }
}