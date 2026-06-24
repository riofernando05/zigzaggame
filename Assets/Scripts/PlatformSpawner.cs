using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;
    Quaternion diamondRotation;
    public bool gameOver;

    void Start()
    {
        if (platform != null)
        {
            lastPos = platform.transform.position;
            size = platform.transform.localScale.x;
        }

        if (diamond != null)
        {
            diamondRotation = diamond.transform.rotation;
        }

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }
    }

    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1f, pos.z), diamondRotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1f, pos.z), diamondRotation);
        }
    }
}