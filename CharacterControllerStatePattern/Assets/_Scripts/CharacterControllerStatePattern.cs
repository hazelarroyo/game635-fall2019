using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStatePattern : MonoBehaviour
{
    private enum Player_State 
    {
        S_Walk, 
        S_Idle, 
        S_Run, 
        S_Jump
    }

    Player_State state;
    Animator anim;
    Rigidbody jump;
    Vector3 jumpForce;
 
    void Start()
    {
        /*LinkedList list = new LinkedList();
        list.Add("the");
        list.Add("cat");
        list.Add("is");
        list.Add("frash");
        list.Add("and");
        list.Add("hip");
        list.TraverseAndPrint();*/

        List<string> list = new List<string>();
        list.Add("the");
        list.Add("cat");
        list.RemoveAt(1);
        Debug.Log(list.Count);

        state = Player_State.S_Idle;
        anim = gameObject.GetComponent<Animator>();
        jump = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0f, 10f, 0f);
    }

    void TurnLeft()
    {
        transform.Rotate(new Vector3(0, -1f, 0));
    }

    void TurnRight()
    {
        transform.Rotate(new Vector3(0, 1f, 0));
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
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }

        switch (state)
        {
            case Player_State.S_Idle:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    anim.SetTrigger("walk");
                    state = Player_State.S_Walk;
                    Debug.Log("Walkin'");
                }
                break;

            case Player_State.S_Walk:
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetTrigger("stop");
                    state = Player_State.S_Idle;
                    Debug.Log("Breathin'");
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    anim.SetTrigger("run");
                    state = Player_State.S_Run;
                    Debug.Log("Runnin'");
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("jump");
                    state = Player_State.S_Jump;
                    Debug.Log("Jumpin'");
                }
                break;

            case Player_State.S_Run:
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetTrigger("walk");
                    state = Player_State.S_Walk;
                    Debug.Log("Walkin'");
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetTrigger("stop");
                    state = Player_State.S_Idle;
                    Debug.Log("Breathin'");
                }
                break;

            case Player_State.S_Jump:
                jump.AddForce(jumpForce, ForceMode.Force);
                state = Player_State.S_Walk;
                break;
        }
    }
}
