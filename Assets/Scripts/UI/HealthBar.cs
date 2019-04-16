using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;
    [SerializeField] private Image midleground;
    [SerializeField] private Image background;
    [SerializeField] private bool isBase = false;

    private Damagable damagable;

    private void OnEnable()
    {
        if (isBase)
        {
            damagable = Base.Instance.GetComponent<Damagable>();
        }
        else
            damagable = GetComponentInParent<Damagable>();

        if (damagable != null)
        {
            damagable.DamageEvent += OnDamage;
        }
    }

    private void OnDamage(Damagable obj)
    {
        midleground.DOFillAmount(obj.Health / obj.HealthMax, 0.5f);
        foreground.fillAmount = obj.Health / obj.HealthMax;
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(0, 180, 0);
    }
}
