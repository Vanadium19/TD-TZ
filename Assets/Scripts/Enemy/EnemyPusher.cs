using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyPusher : MonoBehaviour
{
    private readonly float _delay = 2f;

    [SerializeField] private float _force;
    
    private Rigidbody _rigidbidy;
    private float _timeCounter;

    private void Awake()
    {
        _rigidbidy = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_timeCounter > 0)
            _timeCounter -= Time.deltaTime;

        Push();
    }

    private void Push()
    {
        if (_timeCounter > 0)
            return;

        _rigidbidy.AddForce(
            Vector3.right * Random.Range(-_force, _force) + Vector3.forward * Random.Range(-_force, _force), 
            ForceMode.Impulse);

        _timeCounter = _delay;
    }
}