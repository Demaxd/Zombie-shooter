using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _moveSpeed;
    private Vector3 _direction;

    private void Update()
    {
        if (gameObject.activeSelf) transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir, float speed)
    {

        _direction = dir;
        _moveSpeed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {

        gameObject.SetActive(false);
    }

}
