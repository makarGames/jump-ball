using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    [SerializeField] private float yMinRange = 1f;
    [SerializeField] private float yMaxRange = 1f;
    [SerializeField] private float xMinRange = 1f;

    [SerializeField] private float minTimeToSpawn = 5f;
    [SerializeField] private float maxTimeToSpawn = 10f;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        GameObject prefab = Instantiate(prefabToSpawn, thisTransform.position, thisTransform.rotation);
        Transform prefabTransform = prefab.GetComponent<Transform>();
        Vector3 scale = new Vector3(Random.Range(yMinRange, yMaxRange), xMinRange, 1f);

        prefabTransform.localScale = scale;

        float timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(SpawnPrefab());
    }
}
