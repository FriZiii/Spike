using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [Header("Refereces")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private ChangeDirection direction;
    [SerializeField] private Camera cam;
    [SerializeField] private Coin coin;
    private float camHeight;
    private float camWidth;

    private float leftSide;
    private float rightSide;

    private void Awake()
    {

        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        rightSide = camWidth / 2f;
        leftSide = -rightSide;
    }
    private void Update()
    {
        if (FindObjectOfType<Coin>() == null)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        Instantiate(coinPrefab, RandomPosition(), Quaternion.identity);
    }

    private Vector3 RandomPosition()
    {
            return new Vector3(Random.Range(leftSide + 1.5f, rightSide - 1.5f), Random.Range(-3, 4) * 0.7f, 0);
    }
}
