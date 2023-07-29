using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class ProtesterAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite regular, flag;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayFlag()
    {
        spriteRenderer.sprite = flag;
        animator.SetTrigger("flag");
        StartCoroutine(WaveFlagAnimationDuration());
    }

    public void PlayShake()
    {
        spriteRenderer.sprite = regular;
        animator.SetTrigger("shake");
    }

    IEnumerator WaveFlagAnimationDuration()
    {
        yield return new WaitForSeconds(3);
        PlayShake();
    }
}
