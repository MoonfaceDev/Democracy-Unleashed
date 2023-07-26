using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : TriggerDialog
{
    public DialogEvent retreatDialog;
    public int requiredCrowd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && enabled)
        {
            PeopleInventory crowd = collision.gameObject.GetComponent<PeopleInventory>();
            int crowdSize = crowd.crowdSize;

            if (crowdSize >= requiredCrowd)
            {
                retreatDialog.Invoke();

            }
            else
            {
                dialogEvent.Invoke();
                enabled = false;
                timer = cooldown;
            }
        }
    }
}
