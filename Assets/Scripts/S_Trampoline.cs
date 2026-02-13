using UnityEngine;
using System.Collections;

public class S_Trampoline : MonoBehaviour
{
    public float bounceForce = 40f;
    private bool bounceEnabled = true;

    private AudioSource trampolineAudioSource;
    public AudioClip[] bounceSounds;

    void Start()
    {
        trampolineAudioSource = GetComponent<AudioSource>();
    }

    // Move this to OnCollisionEnter instead of Update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble") && bounceEnabled)
        {
            bounceEnabled = false; // Disable bounce until the marble leaves the trampoline
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("jump" + collision.contacts[0].normal);

                rb.AddForce(-collision.contacts[0].normal * bounceForce, ForceMode.Impulse);
            }

            float marbleVel = collision.gameObject.GetComponent<MarbleSound>().currentVelocity;
            trampolineAudioSource.pitch = 1;
            trampolineAudioSource.pitch += marbleVel / 20f;
            trampolineAudioSource.volume = 0f;
            trampolineAudioSource.volume += marbleVel / 10f;
            trampolineAudioSource.PlayOneShot(bounceSounds[Random.Range(0, bounceSounds.Length)]);
            StartCoroutine(ResetBounce());
        }
    }

    IEnumerator ResetBounce()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay as needed
        bounceEnabled = true; // Re-enable bounce after the delay
    }

}
