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

    [Header("�G�l���M�[�e�̃`���[�W����")]
    [SerializeField] private float chageTime = 5f;
    private float nowChageTime = 0f;

    private bool runcheck = false;
    private bool moveCheck = true;
    private bool chagebullet = false;
    private bool play = true;

    private Vector3 move;
    private Vector3 subtractmove;

    [Header("�G�l���M�[�e�𐶐�����ꏊ")]
    [SerializeField] private Transform bulletpos;

    private Rigidbody rb;

    [SerializeField] private BulletController bullet;
    private BulletController createBullet;

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
                if (!chagebullet)
                {
                    PlayerMove();
                }
                Attack();
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
        float y = Input.GetAxis("Mouse X") * angleSpead * Time.deltaTime;


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
    
    //�U��
    private void Attack()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && createBullet == null)
        {
            createBullet = bullet.CreateBullet(bulletpos,this.transform);
            chagebullet = true;
        }
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            nowChageTime += Time.deltaTime;
        }
        if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
        {
            if(nowChageTime >= chageTime)
            {
                bullet.ShotBullet(true,createBullet);
            }
            else
            {
                bullet.ShotBullet(false,createBullet);
            }
            createBullet = null;
            chagebullet = false;
            nowChageTime = 0;
        }
    }

    //�^�C���A�b�v
    public void TimeUp()
    {
        play = !play;
    }
}
