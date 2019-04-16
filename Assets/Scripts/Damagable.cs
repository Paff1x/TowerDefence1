using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damagable : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] HealthBar healthBar;

    public float Health { get; private set; }
    public float HealthMax { get { return maxHealth; } }

    public Action<Damagable> DamageEvent;
    public Action<Damagable> DieEvent;

    private void Awake()
    {
        Health = maxHealth;

    }

    public void OnCollisionEnter(Collision collision)
    {
        var damageProvider = collision.collider.GetComponentInParent<DamageProvider>();
        if (damageProvider != null)
        {
            Health -= damageProvider.Damage;
            EnableHealthBar();
            DamageEvent?.Invoke(this);


            if (Health <= 0)
            {
                DieEvent?.Invoke(this);

                Destroy(gameObject);
            }
            if (damageProvider.DestroyAfterCollide)
                Destroy(damageProvider.gameObject);
        }
    }

    private void EnableHealthBar()
    {
        if (healthBar)
        {
            healthBar.gameObject.SetActive(true);
            healthBar = null;
        }
    }
}
