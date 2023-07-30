using UnityEngine;

public class CheerBrainModule : BrainModule
{

    public override void Create(Animator animator)
    {
        base.Create(animator);
        var playerMorale = GameObject.FindGameObjectWithTag("Player").GetComponent<Morale>();
        playerMorale.onLevelUp += () => animator.SetTrigger("cheer");
    }

    public override void UpdateAnimator()
    {
    }
}