using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _jumpSpeed;

        private Rigidbody2D _rigidbody2D;
        private bool _isGrounded;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Vector2 movingVector = Vector2.right * (_speed * Time.deltaTime * Input.GetAxis("Horizontal") * 
                                                    (Input.GetKey(KeyCode.LeftShift) ? _acceleration : 1));
            transform.Translate(movingVector);
        }
        private void FixedUpdate()
        {
            if (!Input.GetKey(KeyCode.Space) || !_isGrounded) return;
            _rigidbody2D.AddForce(Vector2.up * _jumpSpeed);
            _isGrounded = false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Floor _))
                _isGrounded = true;
        }
    }
}
