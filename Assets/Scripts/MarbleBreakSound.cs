using UnityEngine;

public class MarbleBreakSound : MonoBehaviour
{

    public AudioClip[] groundImpactSounds;
    public AudioSource oneShotAudioSource;

    private Rigidbody rb;
    private float currentVelocity;
    private float velMultiplier;
    private float soundMultiplier;

    void Start()
    {
        // rb = gameObject.GetComponent<Rigidbody>();

        PlaySound(groundImpactSounds[Random.Range(0, groundImpactSounds.Length)]);
        
    }



    
    // void OnCollisionEnter(Collision collision)
    // {

    //     //HIT GROUND
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         int randomIndex = Random.Range(0, groundImpactSounds.Length);
    //             oneShotAudioSource.pitch = 1;
    //             oneShotAudioSource.pitch += Random.Range(-0.1f, 0.1f);
    //             oneShotAudioSource.PlayOneShot(groundImpactSounds[randomIndex]);
    //             oneShotAudioSource.volume = 0.8f;
            
    //     }

        
    // }    

    public void PlaySound(AudioClip clip)
    {
        oneShotAudioSource.PlayOneShot(clip);
    }
}
