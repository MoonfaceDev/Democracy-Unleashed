using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Distance")]
public class DistanceBrainModule : BrainModule
{
    public string targetTag;

    private Transform target;
    private const string Distance = "distance";

    private void Awake()
    {
        target = GameObject.FindWithTag(targetTag).transform;
    }

    public override void Run(Animator animator)
    {
        var distance = Vector3.Distance(target.position, animator.transform.position);
        animator.SetFloat(Distance, distance);
    }

    public override string[] GetParameters()
    {
        return new[] { Distance };
    }
}