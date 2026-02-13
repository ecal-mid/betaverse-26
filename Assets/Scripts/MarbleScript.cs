using System.Collections; // <--- Ajoutez cette ligne !
using System.Runtime.CompilerServices;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public enum MarbleState { Checkpoint1, Checkpoint2, Checkpoint3, Win }
    public GameManager gameManager;

    public SphereCollider TargetSpotCollider;
    public BoxCollider[] CheckPointColliders;

    public ParticleSystem confettis;
    public ParticleSystem[] debris;

    public int marbleType = 0;

    public Material[] materials;

    private MarbleSound marbleSound;
    public MarbleState CurrentState { get; private set; }
    void Start()
    {
        marbleSound = GetComponent<MarbleSound>();
        gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        gameManager.updateMarbleArray();

        TargetSpotCollider = GameObject.Find("TargetSpot" + marbleType).GetComponent<SphereCollider>();

        int checkpointLength = gameManager.currentLevelCheckpoints.Length;
        CheckPointColliders = new BoxCollider[checkpointLength];
        for (int i = 0; i < checkpointLength; i++)
        {
            CheckPointColliders[i] = GameObject.Find("CheckPointCollider" + (i + 1)).GetComponent<BoxCollider>();
        }
        CurrentState = MarbleState.Checkpoint1;
    }


    public void setMarbleType(int type)
    {
        marbleType = type;
        gameObject.GetComponent<MeshRenderer>().material = materials[type];

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Instantiate(debris[gameManager.currentLevel], transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        if (other == CheckPointColliders[0] && CurrentState == MarbleState.Checkpoint1)
        {
            CurrentState = MarbleState.Checkpoint2;
            UnityEngine.Debug.Log("Checkpoint 2 reached");
            spawnConfettis();
            return;
        }

        if (other == CheckPointColliders[1] && CurrentState == MarbleState.Checkpoint2)
        {
            CurrentState = MarbleState.Checkpoint3;
            spawnConfettis();
            UnityEngine.Debug.Log("Checkpoint 2 reached");
            return;
        }

        if (other == TargetSpotCollider)
        {
            CheckForWin(other);
            return;
        }


    }

    void CheckForWin(Collider other)
    {

        if (CurrentState == MarbleState.Checkpoint3)
        {
            other.enabled = false;
            spawnConfettis();
            marbleSound.PlaySound(marbleSound.winSound);
            gameManager.WinLevel();
        }
    }

    void spawnConfettis()
    {
        if (confettis == null) return;
        Instantiate(confettis, transform.position, Quaternion.identity);
    }
}
