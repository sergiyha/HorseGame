using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    public float timeToRespawnSpear;
    public GameObject newSpear;
    public float spearSpeed;

    private int LogicPlane;
    private int LogicPlaneMask;

    private Ray ray;
    private RaycastHit hitInfo;
    
    private Vector3 shootDirection;
    private Vector3 positionToInstantiate;

    private bool flying;
    private bool rayHitLogicPlane;

    private GameObject instantiatedSpear;



    // Use this for initialization
    void Start()
    {
        positionToInstantiate = new Vector3(-7.59f, 7.44f, -0.9f);
        LogicPlane = 9;
        LogicPlaneMask = 1 << LogicPlane;
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
            ShootSpear();
        }

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    CastRay(i);
                    if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LogicPlaneMask))
                    {
                        rayHitLogicPlane = true;
                    }
                }
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    if (rayHitLogicPlane && !flying)
                    {
                        CastRay(i);
                        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LogicPlaneMask))
                        {
                            instantiatedSpear.transform.rotation = Quaternion.Euler(0f, 0f, SpearAngleRotation());

                           Debug.Log(SpearAngleRotation());
                        }
                    }
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    if (rayHitLogicPlane)
                    {
                        SetDirection();
                        flying = true;
                        rayHitLogicPlane = false;
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


    void CastRay(int i)
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
