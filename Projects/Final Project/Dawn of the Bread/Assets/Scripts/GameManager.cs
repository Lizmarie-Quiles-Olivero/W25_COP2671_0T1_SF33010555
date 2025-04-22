using TMPro;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Public variables
    public AudioClip explosionSound;
    public TextMeshProUGUI timeText;
    public GameObject[] enemyPrefabs;
    public ParticleSystem explosionParticle;

    //Private Variables
    private float time = 60;
    private float spawnPosZ = 40;
    private float spawnRangeX = 25;
    private float spawnRate = 4.0f;
    private AudioSource enemyAudio;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft();
    }

    //Spawns enemies randomly in a set area
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
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
                Destroy(gameObject, 0.03f);
                Destroy(other.gameObject, 0.03f);
            }
        }

        //Destroy alien if collided with a can
        if (CompareTag("Alien"))
        {
            if (other.CompareTag("Can"))
            {
                explosionParticle.Play();
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject, 0.03f);
                Destroy(other.gameObject, 0.03f);
            }
        }
    }

    //Timer for game
    public void TimeLeft()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(time);
    }
}
