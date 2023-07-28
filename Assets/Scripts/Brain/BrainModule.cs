using UnityEngine;

/**
 * Brain Module is a class, responsible for updating animator parameters in `Run`
 */
public abstract class BrainModule : MonoBehaviour
{
    protected Animator Animator { get; private set; }

    public virtual void Create(Animator animator)
    {
        Animator = animator;
    }
    
    public abstract void UpdateAnimator();
}