using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    private readonly float _cursorPositionZ = 15f;
    private readonly float _lookPositionY = 0f;

    private Camera _camera;
    private Transform _transform;
    private Vector3 _mousePosition;
    private Vector3 _cursorPosition;
    private Vector3 _lookPosition;
    private Vector3 _lastMousePosition;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    private void Update()
    {
        _mousePosition = Input.mousePosition;

        if (_mousePosition != _lastMousePosition)
        {
            Rotate();
            _lastMousePosition = _mousePosition;
        }
    }

    private void Rotate()
    {
        CalculateCursorPosition();
        CalculateLookPosition();

        _transform.rotation = Quaternion.LookRotation(_lookPosition);        
    }

    private void CalculateCursorPosition()
    {
        _cursorPosition = new Vector3(_mousePosition.x, _mousePosition.y, _cursorPositionZ);
        _cursorPosition = _camera.ScreenToWorldPoint(_cursorPosition);
    }

    private void CalculateLookPosition()
    {
        _lookPosition = _cursorPosition - _transform.position;
        _lookPosition.y = _lookPositionY;
    }
}