using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Transform _target;
    public void Init(Transform target)
    {
        _target = target;
        if (_target)
            StartCoroutine(MoveCoroutine(_target));
    }

    IEnumerator MoveCoroutine(Transform target)
    {
        while (isActiveAndEnabled)
        {
            if (!target)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
