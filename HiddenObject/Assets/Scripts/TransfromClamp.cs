using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromClamp : MonoBehaviour
{
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        position.y = Mathf.Clamp(position.y, _minY, _maxY);
        transform.position = position;
    }
}
