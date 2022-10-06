using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Pool
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shotSpeed = 5f;
    [SerializeField] private Transform _gunBarrel;

    private void Start()
    {
        FillPool(_bullet.gameObject);
        ResetPool();
    }


    public void Shoot(Vector3 point)
    {
        if(TryGetObject(out GameObject bulletObj))
        {
            point.y = 0f;
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bulletObj.transform.position = _gunBarrel.position;

            bullet.SetDirection(point, _shotSpeed);
            bulletObj.SetActive(true);
        }
    }

}
