using UnityEngine;

public class updateTargetName : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        gameObject.name = "TargetSpot" + gameManager.currentLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
