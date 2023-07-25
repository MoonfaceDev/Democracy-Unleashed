using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MegaPhone : MonoBehaviour
{
    public UnityEvent events;
    public ParticleSystem ps;

    public void Scream()
    {
        ps.Emit(100);
    }
}
