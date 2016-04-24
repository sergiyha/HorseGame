using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private PlayerController playerController;
    public Transform horseCollider;




    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = horseCollider.position;
       transform.rotation = Quaternion.Euler(-horseCollider.eulerAngles.z,transform.eulerAngles.y, transform.eulerAngles.z);
        
        if (playerController.enableJumpAnimation)
        {
            animator.SetTrigger("Up");
            playerController.enableJumpAnimation = false;
        }
    }
}
