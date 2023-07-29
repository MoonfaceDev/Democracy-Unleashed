using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimator : MonoBehaviour
{
    public string triggerName;
    private Animator animator;

    public void SetTrigger()
    {
        animator.SetTrigger(triggerName);
    }
}
