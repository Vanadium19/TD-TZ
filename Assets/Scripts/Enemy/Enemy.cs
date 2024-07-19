using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;

        _health -= value;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}