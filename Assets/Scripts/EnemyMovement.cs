using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public Transform partToRotate;
    public float turnSpeed = 20f;
    public bool isBoss = false;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }
    void Update()
    {
        MoveAndRotate();

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void MoveAndRotate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {

            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }


    void EndPath()
    {
        if(isBoss)
        {
            PlayerStats.Lives -= PlayerStats.Lives;
        }
        else
        {
            PlayerStats.Lives--;
        }
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
