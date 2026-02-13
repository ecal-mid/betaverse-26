using UnityEngine;

public class FilterTables : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;

    void Start()
    {
        var tables = FindObjectsOfType<OVRSceneAnchor>();

        foreach (var table in tables)
        {
            if (table.name.Contains("1"))
            {
                Instantiate(prefabA, table.transform.position, table.transform.rotation);
            }
            else if (table.name.Contains("2"))
            {
                Instantiate(prefabB, table.transform.position, table.transform.rotation);
            }
        }
    }
}
