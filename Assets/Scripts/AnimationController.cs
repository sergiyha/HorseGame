using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    public Animator animator;
    private PlayerController playerController;
    private bool enableDownJumpAnimation;
    public Animation animation;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (playerController.enableJumpAnimation)
        {
           animator.SetTrigger("Up");
            playerController.enableJumpAnimation = false;
            enableDownJumpAnimation = true;
        } else if (enableDownJumpAnimation) {
           animator.SetTrigger("Down");
            enableDownJumpAnimation = false;
        }
	
	}
}
