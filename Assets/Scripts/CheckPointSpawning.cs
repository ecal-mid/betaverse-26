using UnityEngine; // On garde seulement Unity

public class CheckPointSpawning : MonoBehaviour
{
    private GameObject child;

    private AudioSource checkPointAudioSource;
    public AudioClip sound;

    void Start()
    {
        checkPointAudioSource = GetComponent<AudioSource>();
        // 1. Utilisation de Random.Range
        float newPosition = Random.Range(0f, 1f);
        float newRotation = Random.Range(0f, 180f);



        if (transform.childCount > 0)
        {
            child = transform.GetChild(0).gameObject;

            // 2. Ajout de "new" devant Vector3
            child.transform.localPosition = new Vector3(0, newPosition, 0);
            child.transform.localRotation = Quaternion.Euler(new Vector3(newRotation, newRotation, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marble"))
        {
            checkPointAudioSource.PlayOneShot(sound);
        }
    }
}