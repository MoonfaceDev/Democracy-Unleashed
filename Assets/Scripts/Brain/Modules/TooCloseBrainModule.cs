using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Brain Modules/Too Close")]
public class TooCloseBrainModule : BrainModule
{
    public float range;

    private Transform target;

    public override void UpdateAnimator()
    {
        var colliders = FindObjectsOfType<Collider2D>()
            .Where(collider => collider.gameObject != Animator.gameObject && !collider.isTrigger);
        var closeColliders = colliders
            .Where(collider => (collider.transform.position - Animator.transform.position).magnitude < range);
        Animator.SetBool("tooClose", closeColliders.Any());
    }
}