using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;
    private float rangeModifier = 1;

    [Header("Use Bullets (default)")]
    public bool isBallista = false;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireRateModifier = 1;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public float damageOverTime = 30f;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public float hitOffset = .5f;
    public Light impactLight;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(isBallista)
            rangeModifier = PlayerPrefs.GetFloat("BallistaMoreRange");
        else if (useLaser)
            rangeModifier = PlayerPrefs.GetFloat("MageMoreRange");
        else if(!isBallista && !useLaser)
            rangeModifier = PlayerPrefs.GetFloat("CannonMoreRange");

        if (nearestEnemy != null && shortestDistance <= range * rangeModifier)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
                    
            }

            return;
        }
            

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (isBallista)
            {
                fireRateModifier = PlayerPrefs.GetFloat("BallistaMoreFireRate");
            }
            else
            {
                fireRateModifier = PlayerPrefs.GetFloat("CannonMoreFireRate");
            }
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / (fireRate * fireRateModifier);
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser ()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime * PlayerPrefs.GetFloat("MageMoreDamage"));
        targetEnemy.Slow(slowAmount * PlayerPrefs.GetFloat("MageMoreSlow"));

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
            

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized * hitOffset;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
