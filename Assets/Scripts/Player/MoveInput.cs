using UnityEngine;

internal class MoveInput : MonoBehaviour, IMoveInput
{
    private readonly string VerticalAxes = "Vertical";
    private readonly string HorizontalAxes = "Horizontal";

    private Vector3 _value;

    public Vector3 Value => _value;

    private void Update()
    {
        _value = Vector3.right * Input.GetAxis(HorizontalAxes) +
            Vector3.forward * Input.GetAxis(VerticalAxes);
    }
}