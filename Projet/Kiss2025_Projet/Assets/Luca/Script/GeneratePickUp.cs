using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratePickUp : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public int[] numberOfPickups;
    public Transform parentObject; // Objet parent contenant les points de spawn
    private Transform[] spawnPoints; // Points de spawn définis
    public float spawnRadius = 50f;

    void Start()
    {
        InitializeSpawnPoints();
        GeneratePickups();
    }

    void InitializeSpawnPoints()
    {
        // Remplir le tableau spawnPoints avec chaque enfant de parentObject
        spawnPoints = new Transform[parentObject.childCount];
        for (int i = 0; i < parentObject.childCount; i++)
        {
            spawnPoints[i] = parentObject.GetChild(i);
        }
    }

    void GeneratePickups()
    {
        for (int i = 0; i < pickupPrefabs.Length; i++)
        {
            for (int j = 0; j < numberOfPickups[i]; j++)
            {
                GameObject pickupPrefab = pickupPrefabs[i];
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Sélectionner un point de spawn aléatoire

                NavMeshHit hit;
                if (NavMesh.SamplePosition(spawnPoint.position, out hit, spawnRadius, NavMesh.AllAreas))
                {
                    Instantiate(pickupPrefab, hit.position, Quaternion.identity);
                }
            }
        }
    }
}
