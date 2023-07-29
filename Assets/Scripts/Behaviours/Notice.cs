using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public GameObject targetObject;

    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public Vector2 target;

    private void OnEnable()
    {
        target = targetObject.transform.position;
        direction = target - (Vector2)transform.position;
    }
}
