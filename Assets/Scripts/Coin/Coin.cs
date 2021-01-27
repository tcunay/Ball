using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ChangeScore();
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Border border))
        {
            Destroy(gameObject);
        }
    }
}
