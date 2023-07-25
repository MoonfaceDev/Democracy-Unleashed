using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MegaPhone : MonoBehaviour
{
    public UnityEvent events;
    public ParticleSystem ps;
    public GameObject staminaBar;

    private float voiceStamina = 100, voiceThreshold = 50, screamStaminaCost = 15, voiceRegenerationPace = 10;
    private float voice;
    private bool regenerating;

    private void Awake()
    {
        voice = voiceStamina;
        regenerating = false;
    }

    public void Scream()
    {

        if (voice < voiceThreshold && regenerating)
            return;

        if (voice < screamStaminaCost)
        {
            voice = 0;
            regenerating = true;
            return;
        }

        ps.Emit(100);
        voice -= screamStaminaCost;
    }

    private void Update()
    {
        voice = Mathf.Min(voice + Time.deltaTime * voiceRegenerationPace, voiceStamina);
        staminaBar.transform.localScale = new Vector2(voice / voiceStamina ,staminaBar.transform.localScale.y);

        if (regenerating)
            regenerating = voice < voiceThreshold;
    }
}
