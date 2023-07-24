using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public Animator brainAnimator;
    public List<BrainModule> modules;

    private void Awake()
    {
        modules.ForEach(module => module.Create(brainAnimator));
    }

    private void Update()
    {
        modules.ForEach(module => module.UpdateAnimator());
    }
}