using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _coinSpawnTime;
    [SerializeField] [Range(0f, 1f)] private float _elevation;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        
        StartCoroutine(DelayedCoinSpawn());
    }

    private IEnumerator DelayedCoinSpawn()
    {
        Coin coin = null;
        Vector3 position = _transform.position;
        Vector3 coinPosition = new Vector3(position.x, position.y + _transform.localScale.y +
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
