using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float horizontalInput;
    public GameObject [] projectilePrefab;

    //Private variables
    private float speed = 45.0f;
    private float xRange = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Keeps player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Launch projectiles from the player
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(projectilePrefab[0], transform.position, projectilePrefab[0].transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(projectilePrefab[1], transform.position, projectilePrefab[1].transform.rotation);
        }
    }
}
