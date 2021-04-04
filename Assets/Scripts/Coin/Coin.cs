using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _reward = 1;

    private void AddCoin(Player player)
    {
        player.ChangeScore(_reward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            AddCoin(player);
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            Destroy(gameObject);
        }


    }
}
