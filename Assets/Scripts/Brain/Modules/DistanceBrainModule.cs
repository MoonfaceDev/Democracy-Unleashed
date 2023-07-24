using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Distance")]
public class DistanceBrainModule : BrainModule
{
    public string targetTag;

    private Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag(targetTag).transform;
    }

    public override void UpdateAnimator(Animator animator)
    {
        var distance = Vector3.Distance(target.position, animator.transform.position);
        animator.SetFloat("distance", distance);
    }
}