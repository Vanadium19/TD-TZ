using UnityEngine;

internal class Shotgun : MonoBehaviour, IGun
{
    private readonly float _effectDestroyDelay = 0.5f;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _distance;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _hitEffectPrefab;
    [SerializeField] private ParticleSystem _shootEffectPrefab;

    public void Shoot()
    {
        _shootEffectPrefab.Play();

        if (Physics.Raycast(_startPoint.position, _startPoint.forward, out RaycastHit hitInfo, _distance))
        {
            if (hitInfo.collider.TryGetComponent(out IDamageable enemy))
            {
                enemy.TakeDamage(_damage);
                var effect = Instantiate(_hitEffectPrefab, hitInfo.point, Quaternion.identity);
                effect.rotation = Quaternion.FromToRotation(effect.forward, hitInfo.normal) * effect.rotation;
                Destroy(effect.gameObject, _effectDestroyDelay);
            }
        }
    }
}