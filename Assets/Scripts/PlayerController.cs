using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float spead = 5;
    [SerializeField] private float runSpeed = 8;
    [SerializeField] private float angleSpead = 100;
    [SerializeField] private float stamina = 50;
    [SerializeField] private float gravty = 20;

    private bool runcheck = false;
    private bool moveCheck = true;
    private bool play = true;

    private Vector3 move;

    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (play)
        {
            if (moveCheck)
            {
                PlayerMove();
            }
            else
            {
                WaiteTime();
            }
        }
    }
    //プレイヤーを動かす
    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Mouse X");

        float numspeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            numspeed = runSpeed;
            runcheck = true;
        }
        else
        {
            numspeed = spead;
            runcheck = false;
        }

        if (runcheck)
        {
            stamina -= 1;
            if(stamina <= 0)
            {
                runcheck = false;
            }
        }
        else
        {
            if(stamina < 50)
            {
                stamina += 0.5f;
            }
        }

        move = numspeed * new Vector3(x, 0, z);
        move = transform.TransformDirection(move);

        move.y -= gravty;

        controller.Move(move * Time.deltaTime);
        transform.Rotate(new Vector3(0, y * angleSpead * Time.deltaTime, 0));
    }

    //スタミナ切れ
    private void WaiteTime()
    {
        while(stamina < 50)
        {
            stamina++;
        }
        moveCheck = true;
    }

    private void Attack()
    {

    }

    //タイムアップ
    public void TimeUp()
    {
        play = !play;
    }
}
