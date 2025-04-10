using UnityEngine;

public class DetectCollisions_2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
