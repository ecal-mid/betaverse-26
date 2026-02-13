using UnityEngine;

public class SpawningMarble : MonoBehaviour
{
    public GameObject marblePrefab;
    float yet;
    public float interval = 1.0f;
    public int marbleType = 1;

    private MarbleScript marbleScript;
    private GameManager gameManager;

  


    void Start()
    {
        gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        marbleType = gameManager.currentLevel;
    }

    void Update()
    {
        yet += Time.deltaTime;

        if (yet >= interval)
        {
            yet -= interval;

            spawnMarble();
        }
    }

    void spawnMarble()
    {
        GameObject marble = Instantiate(marblePrefab, transform.position, Quaternion.identity);
        marbleScript = marble.GetComponent<MarbleScript>();
        marbleScript.setMarbleType(marbleType);
    }
}
