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
        Move(GetDirection());
        SetRotation(GetDirection());
        TryJump();
    }

    private int GetDirection()
    {
        _direction = 1;
        return _direction;
    }

    private void Move(int direction)
    {
        transform.Translate(new Vector2(direction, 0) * _speed);
    }

    private bool GetAJumpOrder()
    {
        if (Input.GetKey(KeyCode.Space))
            return true;
        else
            return false;
    }
    private void TryJump()
    {
        if (_isStanding == true && GetAJumpOrder())
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
