using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool running = Input.GetKey(KeyCode.W);
        mAnimator.SetBool("running", running);

        bool backwards = Input.GetKey(KeyCode.S);
        mAnimator.SetBool("backwards", backwards);

    }
}
