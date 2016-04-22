using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public Transform groungCheck;
    public float jumpSpeed;
    public float gravity;

    private float defaultPosition;
    private Rigidbody rb;
    private  RaycastHit hit;
    private Vector3 lengthOfLine;

    private Vector3 startPos;
    private bool isTouch;
    private float minSwipeDistY = 40f;
    private float minSwipeDistX_Jump = 30f;

    private float timeToNextJump;

  public  bool enableJumpAnimation;



    void Start()
    {
        defaultPosition = transform.position.y;
       // rb = GetComponent<Rigidbody>();
        lengthOfLine = new Vector3(0f, -0.5f, 0.0f);
        timeToNextJump = 0f;
}

    void FixedUpdate()
    {
      //  if (transform.position.y > defaultPosition)
          //  rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity * Time.fixedDeltaTime, rb.velocity.z);
    //    if (transform.position.y < defaultPosition)
          //  transform.position = new Vector3(transform.position.x, defaultPosition, transform.position.z);

    }

    void Update()
    {

#if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    /*if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0 && !isTouch)//to right swipe
                        {
                            isTouch = true;
                            StartCoroutine(Right());
                        }
                        else if (swipeValue < 0 && !isTouch)//to left swipe
                        {
                            isTouch = true;
                            StartCoroutine(Left());
                        }
                    }*/

                    //add swipe to up
                    if (swipeDistVertical > minSwipeDistY && swipeDistHorizontal<minSwipeDistX_Jump && Time.time > timeToNextJump)
                    {
                        timeToNextJump = Time.time + 1.20f;
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0 && !isTouch && Grounded())
                        {
                            enableJumpAnimation = true;
                           // rb.velocity = new Vector3(0, rb.velocity.y + jumpSpeed, 0);
                            isTouch = true;
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    isTouch = false;
                    break;
            }
        }
#endif
    }

    bool Grounded()
    {
        return Physics.Linecast(groungCheck.position, groungCheck.position + lengthOfLine, out hit, 1 << LayerMask.NameToLayer("Ground"));
    }

}
