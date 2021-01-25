using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PointsCounter _pointsCounter;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Trigger");
            _player.ScoreChanged();
            _player.OnScoreChanged -= _pointsCounter.OnScoreChanged;
            Destroy(gameObject);

        }
        else if (collision.gameObject.TryGetComponent(out Border border))
        {
            Destroy(gameObject);
        }
    }
}
