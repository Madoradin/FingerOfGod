using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetter : MonoBehaviour
{

    public Transform target;
    public float range = 200f;

    private float fireRate;
    private float fireCooldown = 0f; 

    private float findTargetDelay;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private Vector3 lookDirection;

    [SerializeField] private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        fireRate = gameObject.GetComponent<Defender>().fireRate;
        findTargetDelay = 1 / fireRate;
        fireCooldown = 1f / fireRate;
        InvokeRepeating("UpdateTarget", 0f, findTargetDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if(fireCooldown <= 0)
        {
            StartCoroutine(PlayFire());
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    IEnumerator PlayFire()
    {
        animator.speed = (Mathf.Clamp((1 / fireRate), 0, 1) * 2);
        animator.Play("ArcherAnim");
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f);
        Fire();
    }

    void Fire()
    {
        lookDirection = (target.position - firePoint.position).normalized;
        var projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(lookDirection));
        if (projectile != null)
        {
            projectile.GetComponent<Projectile>().GetTarget(target);
            projectile.GetComponent<Projectile>().SetDamage(gameObject.GetComponent<Defender>().damage);
        }
    }
    
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
