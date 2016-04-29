using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    public float timeToRespawnSpear;
    public GameObject newSpear;
    public float spearSpeed;

    private int LogicPlane;

    private Ray ray;
    private RaycastHit hitInfo;
    
    private Vector3 shootDirection;
    private Vector3 positionToInstantiate;

    private bool flying;
    private bool rayHitLogicPlane;
    private bool spearCanBeReleased;
    

    private GameObject instantiatedSpear;
    private PlayerController playerController;
    public float timeScale;

    [System.NonSerialized]
    public int LogicPlaneMask;
    [System.NonSerialized]
    public int LogicPlaneStartSwipe;
    [System.NonSerialized]
    public int LogicPlaneStartSwipeMask;

    public bool cameraCanSmoothlyMove;

    private bool canCheckIfTouchIsOutOfAimingRange;
    public bool setShootSettingsWhenThouchPhaseEnded;


    // Use this for initialization
    void Start()
    {
        setShootSettingsWhenThouchPhaseEnded = true;
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
           // Debug.Log("a");
            for (int i = 0; i < Input.touchCount; ++i)
            {
                //Debug.Log("b");
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    if (canCheckIfTouchIsOutOfAimingRange)
                    {
                        Ray checkRay;
                        checkRay = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LogicPlaneStartSwipeMask))
                        {
                            Debug.Log("dfdf");
                            Time.timeScale = 1;
                            cameraCanSmoothlyMove = false;
                            SetDirection();
                            if (spearCanBeReleased == true) flying = true;
                            playerController.aimingAvaliable = false;
                            DestroySpear();
                            setShootSettingsWhenThouchPhaseEnded = false;

                        }
                    }
                    
                    if (playerController.aimingAvaliable && !flying)
                    {
                      //  Debug.Log("d");
                        CastRay(i);
                        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LogicPlaneMask))
                        {
                            Time.timeScale = timeScale; //slow the game when you're aiming 
                            cameraCanSmoothlyMove = true;//move camera when you're aiming
                            spearCanBeReleased = true;
                            instantiatedSpear.transform.rotation = Quaternion.Euler(0f, 0f, SpearAngleRotation());
                            canCheckIfTouchIsOutOfAimingRange = true;
                          // Debug.Log(SpearAngleRotation());
                        }
                    }
                 
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    if (setShootSettingsWhenThouchPhaseEnded)
                    {
                        Debug.Log("Settings");
                        Time.timeScale = 1;
                        cameraCanSmoothlyMove = false;
                        SetDirection();
                        if (spearCanBeReleased == true) flying = true;
                        playerController.aimingAvaliable = false;
                        DestroySpear();
                    }else {
                        setShootSettingsWhenThouchPhaseEnded = true;
                    }
                        canCheckIfTouchIsOutOfAimingRange = false;
                    
                    
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
        Vector3 first = worldSpaceHitInfo - playerController.firstTouchPosition;
        Vector3 second = new Vector3(worldSpaceHitInfo.x, playerController.firstTouchPosition.y, playerController.firstTouchPosition.z) - playerController.firstTouchPosition;
        angle = Vector3.Angle(first, second);

        

        if (worldSpaceHitInfo.y >= playerController.firstTouchPosition.y) angle = -angle;
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
