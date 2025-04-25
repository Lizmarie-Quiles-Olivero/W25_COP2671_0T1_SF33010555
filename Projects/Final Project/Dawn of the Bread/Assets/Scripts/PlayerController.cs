using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float horizontalInput;
    public GameObject [] projectilePrefab;
    public AudioClip flyingSound;
    public AudioClip magicSound;

    //Private variables
    private float speed = 45.0f;
    private float xRange = 25;
    private AudioSource playerAudio;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            //Player movement
            horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(horizontalInput) > 0.01f)
            {
                if (!playerAudio.isPlaying)
                {
                    playerAudio.clip = flyingSound;
                    playerAudio.loop = true;
                    playerAudio.Play();
                }
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            }
            else
            {
                if (playerAudio.isPlaying)
                {
                    playerAudio.Stop();
                }
            }

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
                AudioSource.PlayClipAtPoint(magicSound, Camera.main.transform.position, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Instantiate(projectilePrefab[1], transform.position, projectilePrefab[1].transform.rotation);
                AudioSource.PlayClipAtPoint(magicSound, Camera.main.transform.position, 0.5f);
            }
        }
    }
}
