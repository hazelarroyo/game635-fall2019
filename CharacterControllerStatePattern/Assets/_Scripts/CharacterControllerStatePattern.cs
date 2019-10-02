using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStatePattern : MonoBehaviour
{
    private enum Player_State {S_Walk, S_Idle, S_Run, S_Jump}
    Player_State state;
    Animator anim;
    Rigidbody jump;
    Vector3 jumpForce;
 
    void Start()
    {
        state = Player_State.S_Idle;
        anim = gameObject.GetComponent<Animator>();
        jump = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0f, 5f, 0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (state == Player_State.S_Jump)
        {
            anim.SetTrigger("walk");
            state = Player_State.S_Walk;
        }

    }
  

    void Update()
    {
        switch (state)
        {
            case Player_State.S_Idle:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    anim.SetTrigger("walk");
                    state = Player_State.S_Walk;
                }
                break;

            case Player_State.S_Walk:
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetTrigger("stop");
                    state = Player_State.S_Idle;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetTrigger("run");
                    state = Player_State.S_Run;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("jump");
                    state = Player_State.S_Jump;
                }
                break;

            case Player_State.S_Run:
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetTrigger("walk");
                    state = Player_State.S_Walk;
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetTrigger("stop");
                    state = Player_State.S_Idle;
                }
                break;

            case Player_State.S_Jump:
                jump.AddForce(jumpForce, ForceMode.Force);
                state = Player_State.S_Walk;
                break;
        }
    }
}
