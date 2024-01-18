using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1 : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    private float _speed = 2f;
    private float _canFire = 0f;
    private float _fireRate = 0.5f;
    private int _ammoCount = 3;

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void Fire()
    {
        if (Time.time >= _canFire && _ammoCount > 0)
        {
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            _canFire = Time.time + _fireRate;
            _ammoCount--;
        }  
    }
}
