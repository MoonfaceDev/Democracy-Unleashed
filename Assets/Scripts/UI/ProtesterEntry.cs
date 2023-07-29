using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtesterEntry : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    [HideInInspector] public string label;
    [HideInInspector] public Sprite emoji;
    [HideInInspector] public bool unlocked;

    private void Update()
    {
        image.sprite = emoji;
        text.text = unlocked ? $"<s>{label}</s>" : label;
    }
}