using UnityEngine;

public class setArriveeColor : MonoBehaviour
{
    public Material[] materials;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materials[gameManager.currentLevel];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
