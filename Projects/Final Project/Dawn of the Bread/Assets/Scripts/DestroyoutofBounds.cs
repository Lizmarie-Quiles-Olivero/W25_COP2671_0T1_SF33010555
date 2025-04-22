using UnityEngine;

public class DestroyoutofBounds : MonoBehaviour
{
    //public variables
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;

    //Private Variables
    private float topBound = 40;
    private float lowBound = -10;
    private AudioSource enemyAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over!");
            explosionParticle.transform.parent = null;
            explosionParticle.Play();
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
            Destroy(gameObject);
        }
    }
}
