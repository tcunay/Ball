using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player= GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            _player.Die();
        }
    }
}
