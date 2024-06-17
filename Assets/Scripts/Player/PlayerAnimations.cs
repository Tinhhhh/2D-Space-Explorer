using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int dead = Animator.StringToHash("Dead");

    // Update is called once per frame
    private Animator animator;
    
    private void Awake(){
        animator = GetComponent<Animator>();
    }
    public void ShowDeadAnimation()
    {
        animator.SetTrigger(dead);
    }
}
