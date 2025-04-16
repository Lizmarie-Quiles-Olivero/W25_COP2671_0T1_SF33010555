using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //Public variables
    public ParticleSystem explosionParticle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            explosionParticle.transform.parent = null;
            explosionParticle.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
