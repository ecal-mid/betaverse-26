using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int currentLevel = -2;
    public GameObject[] currentLevelBlocks;
    public GameObject[] currentLevelMarbles;
    public GameObject[] currentLevelCheckpoints;
    public GameObject[] currentLevelDispensers;

    public GameObject checkPointSpawnerPrefab;
    public GameObject dispenserSpawnerPrefab;
    public GameObject arriveeSpawnerPrefab;

    public Material[] checkpointMaterials; // Array pour stocker les matériaux des checkpoints
    [SerializeField] private Color[] couleurCheckpoints;


    void Start()
    {
        LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {

        currentLevel++;
        destroyCurrentLevel();
        spawnNextLevel();

        StartCoroutine(updateArrays());


        // Logic to load the next level goes here
    }

    void destroyCurrentLevel()
    {
        // On détruit les objets physiquement dans la scène
        if (currentLevelCheckpoints != null)
        {
            foreach (GameObject checkpoint in currentLevelCheckpoints)
            {
                if (checkpoint != null) Destroy(checkpoint);
            }
        }
        // On vide les tableaux APRES la boucle
        currentLevelCheckpoints = new GameObject[0];
    }

    void spawnNextLevel()
    {
        // On instancie tes spawners
        Instantiate(checkPointSpawnerPrefab, Vector3.zero, Quaternion.identity);
        Instantiate(dispenserSpawnerPrefab, Vector3.zero, Quaternion.identity);
        Instantiate(arriveeSpawnerPrefab, Vector3.zero, Quaternion.identity);

        // Note : Si tes spawners créent eux-mêmes des objets, 
        // assure-toi qu'ils ont bien les bons TAGS ("Checkpoint", etc.)
    }

    IEnumerator updateArrays()
    {
        // On attend un peu que les objets soient bien instanciés par les spawners
        yield return new WaitForSeconds(0.4f);
        currentLevelCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        setCheckpointsOrder();
    }

    public void updateMarbleArray()
    {
        currentLevelMarbles = GameObject.FindGameObjectsWithTag("Marble");
    }

    void setCheckpointsOrder()
    {
        for (int i = 0; i < currentLevelCheckpoints.Length; i++)
        {


            // 1. On cherche l'enfant
            Transform colliderTransform = currentLevelCheckpoints[i].transform.Find("Anneau/Plane/CheckPointCollider");
            UnityEngine.Debug.Log("Collider trouvé : " + colliderTransform);

            // 2. On vérifie d'abord s'il existe !
            if (colliderTransform != null)
            {
                // On le renomme
                colliderTransform.gameObject.name = "CheckPointCollider" + (i + 1);

                // 3. On récupère le parent (Correction : colliderTransform.parent est déjà un Transform)
                Transform planeTransform = colliderTransform.parent;
                UnityEngine.Debug.Log("Parent trouvé : " + planeTransform.name);

                // 4. On récupère le Renderer sur ce parent
                Renderer planeRenderer = planeTransform.GetComponent<Renderer>();

                if (planeRenderer != null && i < checkpointMaterials.Length)
                {
                    planeRenderer.material = checkpointMaterials[i];
                }
            }
        }

        for (int i = 0; i < checkpointMaterials.Length; i++)
        {
            checkpointMaterials[i].SetColor("_BorderColor", couleurCheckpoints[currentLevel]);
        }


    }

    public void WinLevel()
    {
        UnityEngine.Debug.Log("Level " + currentLevel + " won!");
        LoadNextLevel();
    }


}
