using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private readonly float _speed = 0.1f;
    private readonly float _removeTime = 5f;

    private float _timeCounter = 0f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Invoke(nameof(StartRemove), _removeTime);
    }

    private void Update()
    {
        if (_timeCounter <= 0)
            return;

        _timeCounter -= Time.deltaTime;
        Move();
    }

    private void StartRemove()
    {
        _timeCounter = _removeTime;
        _rigidbody.isKinematic = true;
        Destroy(gameObject, _removeTime);
    }

    private void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}