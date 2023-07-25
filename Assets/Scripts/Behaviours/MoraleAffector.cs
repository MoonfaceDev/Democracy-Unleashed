using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleAffector : MonoBehaviour
{
    
    public AffectorType affectorType;
    Morale moraleSystem;

    private void AffectMorale()
    {
        moraleSystem.AddAffector(this);
    }

    //sign for scream event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MegaPhone")
        {
            moraleSystem = collision.gameObject.GetComponentInParent<Morale>();
            collision.gameObject.GetComponentInParent<MegaPhone>().events.AddListener(AffectMorale);
            print("signed for event!");
        }
    }

    //sign off from scream event
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MegaPhone")
        {
            collision.gameObject.GetComponentInParent<MegaPhone>().events.RemoveListener(AffectMorale);
            print("signed off from event!");
        }
    }
}

public enum AffectorType { policeman, cavalary, waterCannon }


