using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Range
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float GetRandomPoint()
    {
        return Random.Range(_min, _max);
    }
}
