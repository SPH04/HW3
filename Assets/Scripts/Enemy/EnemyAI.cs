using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Point[] _points = new Point[2];
    [SerializeField] private float _speed;

    private float _direction = 1f;

    private void Update() => 
        transform.position += Vector3.right * Time.deltaTime * _speed * _direction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == _points[0].name)
            _direction = 1f;
        if (collision.name == _points[1].name)
            _direction = -1f;
    }
}
