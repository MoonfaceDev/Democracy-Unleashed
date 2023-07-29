using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PeopleInventory inventory;

    private void Update()
    {
        text.text = "crowd: " + inventory.CrowdSize;
    }
}