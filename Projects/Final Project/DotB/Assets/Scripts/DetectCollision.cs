using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    //Public variables
    public AudioClip explosionSound;
    public ParticleSystem explosionParticle;
    public int pointValue;

    //Private Variables
    private AudioSource enemyAudio;
    private GameManager gameManager;

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
        if (CompareTag("Zombie"))
        {
            if (other.CompareTag("Meat"))
            {
                explosionParticle.Play();
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject, 0.05f);
                Destroy(other.gameObject, 0.05f);
            }
        }

        //Destroy alien if collided with a can
        if (CompareTag("Alien"))
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
}
