using UnityEngine;

/*

    1.Spawn only at the 4th spawn point at a faster pace.

    Info:
    1.platformSpawned_1 will not become null even after despawning.
    */

public class Prime31_PlatformGenerator : MonoBehaviour
{
    public static Prime31_PlatformGenerator prime31_PlatformGen;
    public GameObject[] platformTypes;
    public GameObject platformSpawnLoc_1, platformSpawnLoc_2, platformSpawnLoc_3, platformSpawnLoc_4;

    private float timeElapsed, spawnInterval=1.38f;
    private bool isAlreadySpawned = false;
    public bool startGame=false;
    private bool hasSpawnedInitialPlatforms;

    // Use this for initialization
    void Start()
    {
    }

    public void Awake()
    {
        prime31_PlatformGen = this;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (ComboManager.gameRunning && Time.time - timeElapsed > spawnInterval)
        {
            createPlatform(getRandomPlatform(), platformSpawnLoc_4);
            timeElapsed = Time.time;
        }

    }

    //Create platforms at the spawn points
    public void createPlatformsAtStart()
    {
        createPlatform(platformTypes[0], platformSpawnLoc_1);
        createPlatform(platformTypes[0], platformSpawnLoc_2);
        createPlatform(platformTypes[0], platformSpawnLoc_3);
        createPlatform(platformTypes[0], platformSpawnLoc_4);

        Debug.Log("Created dummy platforms ****** ");
    }

    //creates a single platform at the given spawn point
    private GameObject createPlatform(GameObject platformType, GameObject platformSpawnPoint)
    {
        // Debug.Log("Created a new platform of Type = "+platformType);
        GameObject temp= TrashMan.spawn(platformType, platformSpawnPoint.transform.position);
        temp.transform.SetParent(GameObject.Find("Runtime_SpawnHolder").transform);
        return temp;
    }

    private GameObject getRandomPlatform()
    {
        return platformTypes[Random.Range(0, platformTypes.Length)];
    }

    /// <summary>
    /// Cleans the old platforms.
    /// </summary>
    public void cleanOldPlatforms()
    {
        GameObject spawnHolderParent = GameObject.Find("Runtime_SpawnHolder") ;

        for (int i = 0; i < spawnHolderParent.transform.childCount; i++)
        {
            Destroy(spawnHolderParent.transform.GetChild(i).gameObject);
        }

        Debug.Log("Cleared the leftover platforms.");
    }
}