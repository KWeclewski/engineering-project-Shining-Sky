using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneAnimationController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("MenuScene", true);
    }

    // Called on end of scene
    private void OnDestroy()
    {
        anim.SetBool("MenuScene", false);
    }
}