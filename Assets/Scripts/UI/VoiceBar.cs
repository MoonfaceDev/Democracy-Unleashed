using UnityEngine;

public class VoiceBar : MonoBehaviour
{
    public Megaphone megaphone;
    public Transform placeholder;

    private void Update()
    {
        placeholder.transform.localScale =
            new Vector2(megaphone.voice / Megaphone.MaxVoice, placeholder.transform.localScale.y);
    }
}