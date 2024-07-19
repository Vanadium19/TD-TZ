using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    private readonly float _explosionForce = 300f;
    private readonly float _explosionRadius = 5f;

    private List<Rigidbody> _children = new List<Rigidbody>();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        FindChildren();
    }

    private void FindChildren()
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            if (_transform.GetChild(i).TryGetComponent(out Rigidbody rigidbody))
            {
                _children.Add(rigidbody);
            }
        }
    }

    protected override void Die()
    {
        foreach (var child in _children)
        {
            child.transform.parent = null;
            child.gameObject.SetActive(true);
            child.AddExplosionForce(_explosionForce, _transform.position, _explosionRadius);
        }

        base.Die();
    }
}