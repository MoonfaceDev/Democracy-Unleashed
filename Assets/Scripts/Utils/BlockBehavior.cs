using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : TriggerDialog
{
    private const float speed = 5;

    public GameObject police;
    public GameObject blockade;
    public DialogEvent retreatDialog;
    public int requiredCrowd;

    private bool walking;
    public Callback unblock;

    private void Unblock()
    {
        blockade.SetActive(false);
        walking = true;
        Destroy(this.gameObject, 5);
    }

    protected override void Awake()
    {
        base.Awake();
        unblock = Unblock;
    }

    protected override void Update()
    {
        base.Awake();
        if (walking)
        {
            police.transform.Translate(blockade.transform.up * -1 * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && readyForConversation)
        {
            PeopleInventory crowd = collision.gameObject.GetComponent<PeopleInventory>();
            int crowdSize = crowd.crowdSize;

            if (crowdSize >= requiredCrowd)
            {
                retreatDialog.Invoke(unblock);
                blockade.SetActive(false);
            }
            else
            {
                dialogEvent.Invoke();
                readyForConversation = false;
                timer = cooldown;
            }
        }
    }

    
}
