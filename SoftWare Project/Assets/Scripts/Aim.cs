using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Transform _arm;
    float _offset = -90;
    Vector3 _startingSize;
    Vector3 _armStartingSize;
    #region Start
    void Start()
    {
        _startingSize = transform.localScale;
        _armStartingSize = _arm.localScale;
    }
    #endregion
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perendicular = _arm.position - mousePos;
        Quaternion val = Quaternion.LookRotation(Vector3.forward, perendicular);
        val *= Quaternion.Euler(0, 0, _offset);
        _arm.rotation = val;

        if (transform.position.x - mousePos.x < 0)
        {
            transform.localScale = _startingSize;
            _arm.localScale = _armStartingSize;
        }
        else if (transform.position.x - mousePos.x > 0)
        {
            transform.localScale = new Vector3(-_startingSize.x, _startingSize.y, _startingSize.z);
            _arm.localScale = new Vector3(-_armStartingSize.x, -_armStartingSize.y, _armStartingSize.z);
        }
    }
}
