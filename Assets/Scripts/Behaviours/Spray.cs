using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spray : MonoBehaviour
{
    public float range;
    public float shootCooldown;
    public float hitForce;
    public Transform target;
    public UnityEvent onShoot;

    private bool canShoot = true;

    private void Update()
    {
        var distance = target.position - transform.position;
        if (canShoot && distance.magnitude < range)
        {
            Shoot(target.transform);
        }
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    } 

    private void Shoot(Transform hit)
    {
        var direction = (hit.position - transform.position).normalized;
        transform.right = direction;
        target.GetComponent<Knockback>().Apply(hitForce * direction);
        StartCoroutine(Cooldown());
        onShoot?.Invoke();
    }
}