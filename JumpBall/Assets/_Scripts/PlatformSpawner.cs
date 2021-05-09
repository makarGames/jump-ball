using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(SpawnPlatform());
    }

    private IEnumerator SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab, thisTransform.position, thisTransform.rotation);

        Transform platformTransform = platform.GetComponent<Transform>();

        Vector3 scale = new Vector3(Random.Range(7f, 9f), 0.5f, 1f);

        platformTransform.localScale = scale;

        float timeToSpawn = Random.Range(2f, 3f);
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(SpawnPlatform());
    }
}
