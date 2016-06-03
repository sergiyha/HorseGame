using UnityEngine;
using System.Collections;

public class TextAnimationController : MonoBehaviour {
    private Animator animator;
    public float startAnimation;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        Invoke("MoveText",startAnimation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void MoveText()
    {
        animator.SetTrigger("MoveText");
    }
}
