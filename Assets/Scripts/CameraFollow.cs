using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _displacementCamera;

    private void Start()
    {
        transform.position = new Vector3(_player.transform.position.x + _displacementCamera, transform.position.y, transform.position.z);
    }
    private void Update()
    {
        if (transform.position.x < _player.transform.position.x + _displacementCamera)
        {
        transform.position = 
                new Vector3(_player.transform.position.x + _displacementCamera, transform.position.y, transform.position.z);
        }
    }

    public void AddignATarget(Player player)
    {
        _player = player;
    }
}
