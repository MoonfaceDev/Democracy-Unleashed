using UnityEngine;

public class CheerBrainModule : BrainModule
{
    private Morale playerMorale;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        playerMorale = GameObject.FindGameObjectWithTag("Player").GetComponent<Morale>();
        playerMorale.onLevelUp += () => animator.SetTrigger("cheer");
    }

    public override void UpdateAnimator()
    {
    }
}