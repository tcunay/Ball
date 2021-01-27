using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _displacementCamera;

    private Vector3 _newPosition;

    private void Update()
    {
        transform.position = GetNewPosition();
    }

    private Vector3 GetNewPosition()
    {
        _newPosition = new Vector3(_player.transform.position.x + _displacementCamera, transform.position.y, transform.position.z);

        return _newPosition;
    }

}
