using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Is Walking")]
public class IsWalkingBrainModule : BrainModule
{
    private Walk walk;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        walk = animator.GetComponent<Walk>();
    }

    public override void UpdateAnimator()
    {
        Animator.SetBool("isWalking", walk.direction != Vector2.zero);
    }
}