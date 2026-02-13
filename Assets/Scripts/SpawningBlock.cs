using System.Collections; // <--- Ajoutez cette ligne !
using UnityEngine;

public class SpawningBlock : MonoBehaviour
{
    public GameObject spawnPrefab;
    public UnityEngine.Vector3 spawnRotation;
    public UnityEngine.Vector3 spawnScale;

    private GameObject currentSpawnedObject;

    private bool grow = false;
    private float growSpeed = 48f;


    void Start()
    {
        StartCoroutine(SpawnNextBlock());
    }

    void Update()
    {
        // if (currentSpawnedObject != null && grow)
        // {

        //     currentSpawnedObject.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        // }

        // if (currentSpawnedObject != null && currentSpawnedObject.transform.localScale.x >= 8f)
        // {
        //     grow = false;
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            StartCoroutine(SpawnNextBlock());

        }
    }

    public IEnumerator SpawnNextBlock()
    {
        yield return new WaitForSeconds(0.5f);
        currentSpawnedObject = Instantiate(spawnPrefab, transform.position, Quaternion.Euler(spawnRotation));
        currentSpawnedObject.transform.localScale = spawnScale;
    }
}
