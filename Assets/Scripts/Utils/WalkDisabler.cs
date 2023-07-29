using System.Collections.Generic;
using UnityEngine;

public class WalkDisabler : MonoBehaviour
{
    private Dictionary<Rigidbody2D, RigidbodyConstraints2D> previousState;

    public void Disable()
    {
        previousState = new Dictionary<Rigidbody2D, RigidbodyConstraints2D>();
        foreach (var walk in FindObjectsOfType<Rigidbody2D>())
        {
            previousState[walk] = walk.constraints;
            walk.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void Enable()
    {
        foreach (var pair in previousState)
        {
            pair.Key.constraints = previousState[pair.Key];
        }
    }
}