using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private Vector3 _offset;


    private void LateUpdate()
    {
        Vector3 newPos = _target.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, newPos, _moveSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }
}
