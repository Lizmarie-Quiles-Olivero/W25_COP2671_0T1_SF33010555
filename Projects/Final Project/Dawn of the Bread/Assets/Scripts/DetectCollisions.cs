using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //Public variables
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;

    //Private Variables
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

    //Destroy scavenger if collided with a can
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Can"))
        {
            explosionParticle.Play();
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
            Destroy(gameObject, 0.05f);
            Destroy(other.gameObject, 0.05f);
        }
    }
}
