using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _coinSpawnTime;
    [SerializeField] [Range(0f, 1f)] private float _elevation;

    private void Start() =>
        StartCoroutine(DelayedCoinSpawn());

    private IEnumerator DelayedCoinSpawn()
    {
        Coin coin = null;
        Vector3 coinPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y +
            _template.transform.localScale.y + _elevation);

        while (true)
        {
            if (coin == null)
            {
                coin = Instantiate(_template, coinPosition, Quaternion.identity);
                yield return new WaitForSecondsRealtime(_coinSpawnTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
