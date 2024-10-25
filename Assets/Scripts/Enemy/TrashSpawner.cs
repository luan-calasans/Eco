using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;  
    public float spawnInterval = 2f; 
    public int initialSpawnCount = 9;  
    public int groupSize = 4;          
    private List<GameObject> activeTrash = new List<GameObject>(); 

    void Start()
    {
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

        int randomIndex = Random.Range(0, trashPrefabs.Length); 
        GameObject newTrash = Instantiate(trashPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        activeTrash.Add(newTrash);

        float randomFallSpeed = Random.Range(1f, 5f);
        newTrash.GetComponent<TrashMovement>().fallSpeed = randomFallSpeed;
    }

    public void RemoveTrash(GameObject trash)
    {
        activeTrash.Remove(trash);
    }
}
