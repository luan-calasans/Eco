using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;  
    public float spawnInterval = 2f;
    public int initialSpawnCount = 9;
    public int groupSize = 4;
    private List<GameObject> activeTrash = new List<GameObject>();

    void Start()
    {
        // Spawn inicial de resíduos
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnTrash();
        }

        StartCoroutine(SpawnGroupsOfTrash());

        Time.timeScale = 1;
    }

    private IEnumerator SpawnGroupsOfTrash()
    {
        while (true)
        {
            for (int i = 0; i < groupSize; i++)
            {
                SpawnTrash();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnTrash()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 5f, 0f);
        GameObject newTrash = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
        activeTrash.Add(newTrash);

        float randomFallSpeed = Random.Range(1f, 5f);
        newTrash.GetComponent<TrashMovement>().fallSpeed = randomFallSpeed;
    }

    public void RemoveTrash(GameObject trash)
    {
        activeTrash.Remove(trash);
    }
}
