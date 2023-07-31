using UnityEngine;
using UnityEngine.UI;

public class ImageColorRandom : MonoBehaviour
{
    public Morale morale;

    private static readonly Color[] Colors = { Color.red, Color.magenta, Color.blue, Color.cyan, Color.green, Color.yellow };
    private const float CycleDuration = 0.5f;
    
    private Image image;
    private float cycleStart;
    private int currentIndex;

    private void Awake()
    {
        image = GetComponent<Image>();
        morale.onTurboStart += () => enabled = true;
        morale.onTurboEnd += () => enabled = false;
        enabled = false;
    }

    private void Update()
    {
        if (Time.time - cycleStart > CycleDuration) {
            currentIndex = (currentIndex + 1) % Colors.Length;
            cycleStart = Time.time;
        }

        var nextIndex = (currentIndex + 1) % Colors.Length;
        image.color = Color.Lerp(Colors[currentIndex], Colors[nextIndex], (Time.time - cycleStart) / CycleDuration);
    }
}