using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Distance")]
public class DistanceBrainModule : BrainModule
{
    public string targetTag;

    private Transform target;

    public override void Create(Animator animator)
    {
        base.Create(animator);
        target = GameObject.FindWithTag(targetTag).transform;
    }

    public override void UpdateAnimator()
    {
        var distance = Vector3.Distance(target.position, Animator.transform.position);
        Animator.SetFloat("distance", distance);
    }
}