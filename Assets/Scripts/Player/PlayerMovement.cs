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

    private int _direction;
    private bool _isStanding = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement(SetDirection());
        SetRotation(SetDirection());
        Jump();
    }

    private int SetDirection()
    {
        _direction = 1;
        return _direction;
    }

    private void Movement(int direction)
    {
        transform.Translate(Vector2.right * _speed);
    }

    private void Jump()
    {
        if (_isStanding == true && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void SetRotation(int direction)
    {
        _transform.Rotate(new Vector3(0, 0, -direction * _rotateSpeed));
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
