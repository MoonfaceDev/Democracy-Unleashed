using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Morale morale;

    
    void Update()
    {
        text.text = "Next Reward: " + (morale.currentMilestone + 1);
    }
}
