using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�X�s�[�h����")]
    [SerializeField] private float spead = 5;
    [SerializeField] private float runSpeed = 8;
    private float numspeed;

    [Header("���т��ѓ������ꍇ���₷")]
    [SerializeField] private float moveForceMultiplier = 500;

    [Header("�}�E�X�̊��x")]
    [SerializeField] private float angleSpead = 100;

    [Header("�X�^�~�i���")]
    [SerializeField] private float stamina = 50;

    [Header("�d�͂̐ݒ�")]
    [SerializeField] private float gravty = 20;

    [Header("�o���i����p�x")]
    [SerializeField] private float stepOffset = 0.5f;
    [SerializeField] private float slopeLimit = 65f;

    [Header("�i���Ȃǂ̂��߂̃��C�ݒ�")]
    [SerializeField] private float stepdistance = 0.5f;
    [SerializeField] private float slopedistance = 1f;

    private bool runcheck = false;
    private bool moveCheck = true;
    private bool play = true;

    [SerializeField] private Transform stepRay;

    private Vector3 move;
    private Vector3 subtractmove;

    private Rigidbody rb;

    [SerializeField] private GroundChecker checker;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

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
    private void FixedUpdate()
    {
        rb.AddForce(moveForceMultiplier * (subtractmove));
    }
    //�v���C���[�𓮂���
    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Mouse X");

        float grv = 0;

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

        move = new Vector3(x, 0, z);
        move = move * numspeed;
        move = transform.TransformDirection(move);
        subtractmove = new Vector3(move.x - rb.velocity.x, 0f, move.z - rb.velocity.z);
        transform.Rotate(0, y, 0);
    }

    //�X�^�~�i�؂�
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

    //�^�C���A�b�v
    public void TimeUp()
    {
        play = !play;
    }
}
