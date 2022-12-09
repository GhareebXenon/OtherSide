using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _gunLocation;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] AudioSource _audioSource;
    Vector3 _mousePos;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
            Instantiate(_bulletPrefab, _gunLocation.position, _gunLocation.rotation).Shoot(_mousePos) ;
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
