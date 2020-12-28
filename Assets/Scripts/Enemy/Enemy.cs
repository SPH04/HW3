using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player _))
            Destroy(collision.gameObject);
    }
}
