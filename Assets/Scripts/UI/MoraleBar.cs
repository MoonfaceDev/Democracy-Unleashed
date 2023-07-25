using UnityEngine;
using UnityEngine.UI;

public class MoraleBar : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Morale morale;

    private void Update()
    {
        scrollbar.size = morale.ProgressToNextMilestone;
    }
}