using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAI))]
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Player.Player _))
                Destroy(collision.gameObject);
        }
    }
}
