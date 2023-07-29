using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomClips : MonoBehaviour
{
    public AudioClip[] clips;

    [HideInInspector]
    public bool run;

    private int randomIndex;
    private float randomDelay;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        run = true;
        StartCoroutine(PlayClips());
    }

    IEnumerator PlayClips()
    {
        while (run)
        {
            randomIndex = Random.Range(0, clips.Length - 1);
            randomDelay = Random.Range(20, 40);

            yield return new WaitForSeconds(randomDelay);
            source.PlayOneShot(clips[randomIndex]);
        }
    }
}
