using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private Bullet bullet;

    private void OnEnable()
    {
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
                Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(bullet.gameObject, transform.position, transform.rotation);
    }
}
