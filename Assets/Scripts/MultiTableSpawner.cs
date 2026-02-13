
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.BuildingBlocks; // Vérifiez votre version du SDK pour l'espace de noms

public class MultiTableSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToSpawn;
    private int _spawnCount = 0;

    // Cette méthode sera appelée par l'événement OnAnchorPrefabSpawned 
    // ou via le système de Building Blocks de Meta
    public void SpawnNextPrefab(GameObject anchor)
    {
        if (_spawnCount < prefabsToSpawn.Count)
        {
            // On récupère la position de l'ancre (la table)
            Vector3 position = anchor.transform.position;
            Quaternion rotation = anchor.transform.rotation;

            // On instancie le prefab correspondant à l'index actuel
            Instantiate(prefabsToSpawn[_spawnCount], position, rotation);

            _spawnCount++;
        }
    }
}

