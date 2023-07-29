using UnityEngine;
using UnityEngine.Events;

public class GainProtester : MonoBehaviour
{
    public ProtesterType type;
    public UnityEvent onGain;

    private PeopleInventory inventory;

    private void Awake()
    {
        var player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PeopleInventory>();
    }

    public void Gain()
    {
        inventory.GainProtester(type);
        onGain.Invoke();
    }
}