using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offset;

    private void Update()
    {
        transform.position = GetNextPosition();
    }

    private Vector3 GetNextPosition()
    {
        Vector3 nextPosition = new Vector3(_player.transform.position.x + _offset, transform.position.y, transform.position.z);

        return nextPosition;
    }
}
