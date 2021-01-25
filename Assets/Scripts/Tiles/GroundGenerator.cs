using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _ground;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parent;

    private Vector3 _initPosition;

    private float _groundWidth = 18;

    private void Update()
    {
        if(_player.transform.position.x > _initPosition.x - _groundWidth/2)
        {
            _initPosition += _ground.transform.position + new Vector3(_groundWidth, 0);
            Instantiate(_ground, _initPosition, Quaternion.identity, _parent);
        }
    }
}
