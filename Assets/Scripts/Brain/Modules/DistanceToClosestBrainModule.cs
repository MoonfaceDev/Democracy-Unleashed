using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Distance To Closest")]
public class DistanceToClosestBrainModule : BrainModule
{
    private Transform target;

    public override void UpdateAnimator()
    {
        var colliders = FindObjectsOfType<Collider2D>()
            .Where(collider => collider.gameObject != Animator.gameObject && !collider.isTrigger);
        var distances = colliders
            .Select(collider => (collider.transform.position - Animator.transform.position).magnitude);
        Animator.SetFloat("distanceToClosest", distances.Min());
    }

}