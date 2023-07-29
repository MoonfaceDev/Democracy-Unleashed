using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PoliceBarrierRetreat : MonoBehaviour
{
    public GameObject police;
    public float angle;
    public UnityEvent onRetreat;

    private const float Speed = 10;

    private bool walking;

    public void Retreat()
    {
        walking = true;
        onRetreat.Invoke();
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (walking)
        {
            police.transform.Translate(Quaternion.Euler(0, 0, angle) * Vector3.right * (Speed * Time.deltaTime));
        }
    }

    private void OnDrawGizmosSelected()
    {
        var start = transform.position;
        var end = start + Quaternion.Euler(0, 0, angle) * Vector3.right * 3;
        Handles.DrawBezier(start, end, start, end, Color.blue, null, 10);
    }
}