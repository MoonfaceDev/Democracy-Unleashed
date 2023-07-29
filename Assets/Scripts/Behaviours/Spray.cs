using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spray : MonoBehaviour
{
    public float range;
    public float shootCooldown;
    public float hitForce;
    public string targetTag;
    public int crowdTaken;
    public UnityEvent onShoot;

    private Transform target;
    private bool canShoot = true;

    private void Awake()
    {
        target = GameObject.FindWithTag(targetTag).transform;
    }

    private void Update()
    {
        var distance = target.position - transform.position;
        if (canShoot && distance.magnitude < range)
        {
            Shoot();
        }
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private IEnumerator KnockbackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Knockback();
    }

    private void Knockback()
    {
        target.GetComponent<PeopleInventory>().TakeCrowd(crowdTaken);
        target.GetComponent<Knockback>().Apply(hitForce * transform.right);
    }

    private void Shoot()
    {
        var direction = (target.transform.position - transform.position).normalized;
        transform.right = direction;

        onShoot?.Invoke();
        StartCoroutine(KnockbackDelay());
        StartCoroutine(Cooldown());
    }
}