using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Morale morale;


    private void Update()
    {
        text.text = "Next Reward: " + (morale.currentMilestone + 1);
    }
}