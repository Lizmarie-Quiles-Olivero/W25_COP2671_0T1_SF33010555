using UnityEngine;

public class DetectCollisions_2 : MonoBehaviour
{
    //Public variables
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;

    //Private variables
    private AudioSource enemyAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Destroy zombie if collided with a meat
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meat"))
        {
            explosionParticle.Play();
            enemyAudio.PlayOneShot(explosionSound, 1f);
            Destroy(gameObject, 0.05f);
            Destroy(other.gameObject, 0.05f);
        }
    }
}
