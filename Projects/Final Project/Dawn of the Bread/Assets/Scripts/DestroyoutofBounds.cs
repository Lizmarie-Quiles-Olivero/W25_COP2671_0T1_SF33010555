using UnityEngine;

public class DestroyoutofBounds : MonoBehaviour
{
    //Private Variables
    private float topBound = 40;
    private float lowBound = -10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
