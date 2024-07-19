using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
internal class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;
    private IMoveInput _moveInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveInput = gameObject.AddComponent<MoveInput>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.up * _rigidbody.velocity.y + _speed * _moveInput.Value;
        _animator.SetBool("IsRunning", _moveInput.Value != Vector3.zero);
    }
}