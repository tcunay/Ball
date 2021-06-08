using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _reward = 1;

    Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {

    }

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

    }
}
