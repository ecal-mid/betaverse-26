using UnityEngine;
using System.Collections;

public class TrashCan : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()    
        {
            audioSource = GetComponent<AudioSource>();
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            StartCoroutine(ShrinkAndDestroy(other.transform.root.gameObject));
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }


    private IEnumerator ShrinkAndDestroy(GameObject obj)
    {
        float duration = 0.1f; // durée de l'animation
        float time = 0f;

        Vector3 startScale = obj.transform.localScale;
        Vector3 targetScale = Vector3.zero;

        while (time < duration)
        {
            obj.transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = Vector3.zero;
        Destroy(obj);
    }

    
}
