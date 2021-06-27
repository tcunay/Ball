using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speedReductionRatio;

    private Rigidbody2D _rigidbody;
    private int _direction = 1;
    private bool _isStanding = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        AnimateWheelSpin();
        TryJump();
    }

    private void Move()
    {
        transform.Translate(new Vector2(_direction, 0) * _speed);
    }

    private void TryJump()
    {
        if (Input.GetKey(KeyCode.Space) && _isStanding == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void AnimateWheelSpin()
    {
        _transform.Rotate(new Vector3(0, 0, -_direction * _rotateSpeed));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isStanding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isStanding = false;
    }
}
