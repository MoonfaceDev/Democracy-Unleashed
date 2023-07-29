using UnityEngine;

public class TriggerAnimator : MonoBehaviour
{
    public string triggerName;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger()
    {
        animator.SetTrigger(triggerName);
    }
}