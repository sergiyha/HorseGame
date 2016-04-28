using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float timeToSmoothCamecaBack;
    public float timeToSmoothCamecaForvard;
    public Vector3 lastCameraPosition;
    private Vector3 firstCameraPosition;
    private ShootController shootController;
    private float i = 0.0f;

    // Use this for initialization
    void Start ()
    {
        shootController = FindObjectOfType<ShootController>();
        firstCameraPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shootController.cameraCanSmoothlyMove)
        {
           // MoveCamera(transform,transform.position,lastCameraPosition,timeToSmoothCamecaBack);
           transform.position = Vector3.Lerp(transform.position, lastCameraPosition, timeToSmoothCamecaBack*Time.deltaTime);
          
        }else if (!shootController.cameraCanSmoothlyMove)
        {
            transform.position = Vector3.Lerp(transform.position, firstCameraPosition, timeToSmoothCamecaForvard * Time.deltaTime );
        }
        
	
	}
    void MoveCamera(Transform thisTransform,Vector3 startPosition, Vector3 endPosition, float time)
    {
        float rate =  1.0f / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPosition,endPosition,i);
        }
    }

   
}
