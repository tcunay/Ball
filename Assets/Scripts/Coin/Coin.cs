using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private int _reward = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IScoreCollecting scoreCollecting))
        {
            scoreCollecting.ChangeScore(_reward);
            Destroy(gameObject);
        }
    }
}
