using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    public float timeToRespawnSpear;
    public GameObject newSpear;
    public float spearSpeed;

    private int LogicPlane;
    public int LogicPlaneMask;
    public int LogicPlaneStartSwipe;
    public int LogicPlaneStartSwipeMask;

    private Ray ray;
    private RaycastHit hitInfo;
    
    private Vector3 shootDirection;
    private Vector3 positionToInstantiate;

    private bool flying;
    private bool rayHitLogicPlane;
    private bool spearCanBeReleased;
    

    private GameObject instantiatedSpear;
    public PlayerController playerController;



    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        positionToInstantiate = new Vector3(-7.59f, 7.44f, -0.9f);
        LogicPlaneStartSwipe = 10;
        LogicPlane = 9;
        LogicPlaneMask = 1 << LogicPlane;
        LogicPlaneStartSwipeMask = 1 << LogicPlaneStartSwipe;
        instantiatedSpear = Instantiate(newSpear, positionToInstantiate, Quaternion.identity) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedSpear.Equals(null))
        {
            flying = false;
            instantiatedSpear = Instantiate(newSpear, positionToInstantiate, Quaternion.identity) as GameObject;
        }

        if (flying)
        {
            spearCanBeReleased = false;
            ShootSpear();
        }

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    if (playerController.aimingAvaliable && !flying)
                    {
                        CastRay(i);
                        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LogicPlaneMask))
                        {
                            spearCanBeReleased = true;
                            instantiatedSpear.transform.rotation = Quaternion.Euler(0f, 0f, SpearAngleRotation());
                          // Debug.Log(SpearAngleRotation());
                        }
                    }
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    if (playerController.aimingAvaliable)
                    {
                        SetDirection();
                        if(spearCanBeReleased ==true) flying = true;
                        playerController.aimingAvaliable = false;
                        DestroySpear();
                    }
                }

            }
        }
    }


    void SetDirection()
    {
        shootDirection = (instantiatedSpear.transform.GetChild(1).position - instantiatedSpear.transform.GetChild(0).position).normalized;
    }


    void ShootSpear()
    {
        instantiatedSpear.transform.position += shootDirection * spearSpeed * Time.deltaTime;
    }


    float SpearAngleRotation()
    {
        float angle;

        Vector3 worldSpaceHitInfo = hitInfo.point;
        //Debug.Log(worldSpaceHitInfo);
        Vector3 first = worldSpaceHitInfo - instantiatedSpear.transform.position;
        Vector3 second = new Vector3(worldSpaceHitInfo.x, instantiatedSpear.transform.position.y, instantiatedSpear.transform.position.z) - instantiatedSpear.transform.position;
        angle = Vector3.Angle(first, second);



        if (worldSpaceHitInfo.y >= instantiatedSpear.transform.position.y) angle = -angle;
        return angle;
    }
   private  void CastRay(int i)
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
    }


    void DestroySpear()
    {
        if (flying)
        {
            Destroy(instantiatedSpear, timeToRespawnSpear);
        }
    }



}
