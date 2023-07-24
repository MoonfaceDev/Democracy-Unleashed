using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public Animator brainAnimator;
    public List<BrainModule> modules;

    private void Update()
    {
        modules.ForEach(module => module.UpdateAnimator(brainAnimator));
    }
}