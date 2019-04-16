using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedGun : MonoBehaviour
{
    [SerializeField] private float findRadius;
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject carriage;
    private Enemy _enemy;
    private Bullet _bullet;
    private float shootTime = 0;

    private void OnEnable()
    {
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds(shootTime);
            if (_enemy)
            {
                Shoot();
                shootTime = attackSpeed;
            }
            else
                shootTime = 0;
        }
    }

    private void Update()
    {
        if (!_enemy)
        {
            _enemy = FindEnemy();
        }
        else
        {
            if (carriage)
                TurnCarriage(_enemy.transform);
            transform.LookAt(_enemy.transform);
            float dist = Vector3.Distance(_enemy.transform.position, transform.position);
            if (dist > findRadius)
            {
                _enemy = null;
            }
        }
    }
    private void Shoot()
    {
        _bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        _bullet.Init(_enemy.transform);
    }
    private Enemy FindEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float minDistance = findRadius;
        Enemy nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    private void TurnCarriage(Transform target)
    {
        Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, target.position.z);
        carriage.transform.LookAt(targetPostition);
    }
}
