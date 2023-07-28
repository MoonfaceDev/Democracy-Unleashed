using UnityEngine;

public class PoliceBarrierRetreat : MonoBehaviour
{
    private const float Speed = 5;

    public GameObject police;
    public GameObject blockade;

    private bool walking;

    public void Retreat()
    {
        blockade.SetActive(false);
        walking = true;
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (walking)
        {
            police.transform.Translate(blockade.transform.up * (-1 * Speed * Time.deltaTime));
        }
    }
}