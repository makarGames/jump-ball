using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bonusPrefab;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        Instantiate(bonusPrefab, transform.position, transform.rotation);

        float timeToSpawn = Random.Range(5f, 10f);
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(SpawnBonus());
    }
}
