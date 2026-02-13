using UnityEngine;

public class MarbleSound : MonoBehaviour
{
    public AudioClip[] woodImpactSounds;
    public AudioClip[] xyloSounds;

    public AudioClip[] billeImpactSounds;
    public AudioClip[] groundImpactSounds;
    public AudioClip winSound;
    public AudioSource oneShotAudioSource;
    public AudioSource rollingAudioSource;

    private Rigidbody rb;
    public float currentVelocity;
    public float velMultiplier;
    private float soundMultiplier;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        currentVelocity = rb.linearVelocity.magnitude;
        velMultiplier = Mathf.InverseLerp(-3, 3, currentVelocity);

        if (currentVelocity < 0.1f)
        {
            rollingAudioSource.volume = 0.5f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wood>() != null)
        {
            if (currentVelocity > 1.2f)
            {
                int randomIndex = Random.Range(0, woodImpactSounds.Length);
                oneShotAudioSource.pitch = 0.5f;
                oneShotAudioSource.pitch += currentVelocity / 12f;
                oneShotAudioSource.volume = 0.3f;
                oneShotAudioSource.volume += currentVelocity / 5f;
                oneShotAudioSource.PlayOneShot(woodImpactSounds[randomIndex]);

                int randomIndex2 = Random.Range(0, xyloSounds.Length);
                oneShotAudioSource.PlayOneShot(xyloSounds[randomIndex2]);
            }
        }

        //HIT GROUND
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (currentVelocity > 1.2f)
            {
                int randomIndex = Random.Range(0, groundImpactSounds.Length);
                oneShotAudioSource.pitch = 1;
                oneShotAudioSource.pitch += Random.Range(-0.1f, 0.1f);
                oneShotAudioSource.PlayOneShot(groundImpactSounds[randomIndex]);
            }
        }

        //HIT MARBLE
        if (collision.gameObject.GetComponent<MarbleSound>() != null)
        {
            if (currentVelocity > 1.2f)
            {
                int randomIndex = Random.Range(0, billeImpactSounds.Length);
                oneShotAudioSource.pitch = 1;
                oneShotAudioSource.pitch += Random.Range(-0.1f, 0.1f);
                oneShotAudioSource.PlayOneShot(billeImpactSounds[randomIndex]);
            }

        }
    }

    void OnCollisionStay(Collision other)
    {
        //HIT BLOCK WOOD
        if (other.gameObject.CompareTag("Block"))
        {
            if (currentVelocity > 0.4f)
            {
                rollingAudioSource.pitch = 1f;
                rollingAudioSource.pitch += currentVelocity / 6f;
                rollingAudioSource.volume = 0.5f;
                rollingAudioSource.volume += currentVelocity / 10f;

                if (!rollingAudioSource.isPlaying)
                {
                    rollingAudioSource.Play();
                }
            }


            else
            {
                rollingAudioSource.volume = 0f;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            rollingAudioSource.volume = 0f;
        }
    }

    

    public void PlaySound(AudioClip clip)
    {
        oneShotAudioSource.PlayOneShot(clip);
    }
}
