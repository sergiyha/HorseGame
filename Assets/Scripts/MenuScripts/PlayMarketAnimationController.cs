using UnityEngine;
using System.Collections;

public class PlayMarketAnimationController : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("playAnimation", 1.5f);
    }

    // Update is called once per frame


    private void playAnimation()
    {
        anim.SetTrigger("Up");
    }
    public void playBackward()
    {
        Debug.Log("dowe");
        anim.SetTrigger("Down");
    }
}
