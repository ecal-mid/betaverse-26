using UnityEngine;

public class FixRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(transform.up, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
