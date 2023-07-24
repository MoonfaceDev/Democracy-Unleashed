using UnityEngine;

/**
 * Brain Module is a class, responsible for updating animator parameters in `Run`
 */
public abstract class BrainModule : ScriptableObject
{
    public abstract void Run(Animator animator);
}