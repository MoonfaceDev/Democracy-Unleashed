using UnityEngine;

public abstract class BrainModule : ScriptableObject
{
    public abstract void Run(Animator animator);
    
    public abstract string[] GetParameters();
}