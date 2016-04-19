using UnityEngine;


public class PlatformMover : MonoBehaviour
{

    public GameObject[] platforms;
    private GameObject[] instanstiatedObjects = new GameObject[3];
    public float offScrean;//-45
    public float onScreen;
    public Vector3 spawnPosition;
    public GameObject firstPlatform;
    public float platformSpeed;


    private int left = 0, middle = 1, right = 2;
    // Use this for initialization
    void Start()
    {
        instanstiatedObjects[left] = Instantiate(firstPlatform, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        instanstiatedObjects[middle] = Instantiate(firstPlatform, new Vector3(42f, 0f, 0f), Quaternion.identity) as GameObject;
       instanstiatedObjects[right] = Instantiate(firstPlatform, new Vector3(84f, 0f, 0f), Quaternion.identity) as GameObject;

       

    }

    void FixedUpdate()
    {
        if (instanstiatedObjects[left] != null)
        {
            if (Mathf.Abs(instanstiatedObjects[left].transform.position.x) > Mathf.Abs(offScrean))
            {
                Destroy(instanstiatedObjects[left]);
                instanstiatedObjects[left] = instanstiatedObjects[middle];
                instanstiatedObjects[middle] = instanstiatedObjects[right];
                GameObject platform = platforms[Random.Range(0, platforms.Length)];
                instanstiatedObjects[right] = Instantiate(platform, instanstiatedObjects[middle].transform.position + new Vector3(42f, 0f, 0f), Quaternion.identity) as GameObject;
            }
        }
        if (instanstiatedObjects[left] != null)
            TranslatreGround(instanstiatedObjects[left]);
        if (instanstiatedObjects[middle] != null)
            TranslatreGround(instanstiatedObjects[middle]);
        if (instanstiatedObjects[right] != null)
            TranslatreGround(instanstiatedObjects[right]);
    }

    //Usefull Functions

    void TranslatreGround(GameObject obj)
    {
        obj.transform.Translate(new Vector3(platformSpeed, 0f, 0f) * Time.deltaTime);

    }

}
