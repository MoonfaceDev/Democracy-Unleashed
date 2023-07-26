using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetScore(int score)
    {
        text.text = "crowd: " + score;
    }
}