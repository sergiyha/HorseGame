using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private PlayerController playerController;




    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.enableJumpAnimation)
        {
            animator.SetTrigger("Up");
            playerController.enableJumpAnimation = false;
        }
    }
}
