using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private PlayerController playerController;
    private ShootController shootController;
    public Transform horseCollider;




    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        shootController = FindObjectOfType<ShootController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootController.swingAnimation)
        {
            animator.SetBool("swingAnim", true);
            shootController.swingAnimation = false;
        }
        else if (shootController.throwAnimation)
        {
            shootController.throwAnimation = false;
            animator.SetBool("swingAnim", false);
            animator.SetTrigger("throw");
        }

        transform.position = horseCollider.position;
        transform.rotation = Quaternion.Euler(-horseCollider.eulerAngles.z, transform.eulerAngles.y, transform.eulerAngles.z);

        if (playerController.enableJumpAnimation)
        {
            animator.SetTrigger("Up");
            playerController.enableJumpAnimation = false;
        }
    }
    public void resetSwingAnimation()
    {
        animator.SetTrigger("resetSwing");
        animator.SetTrigger("resetThrow");

    }
}
