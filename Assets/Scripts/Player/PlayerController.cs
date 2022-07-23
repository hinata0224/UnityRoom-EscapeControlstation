using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int key = 0;

    [Header("�X�s�[�h����")]
    [SerializeField] private float spead = 5;
    [SerializeField] private float runSpeed = 8;
    private float numspeed;

    [Header("���т��ѓ������ꍇ���₷")]
    [SerializeField] private float moveForceMultiplier = 500;

    [Header("�}�E�X�̊��x")]
    [SerializeField] private float angleSpead = 100;

    [Header("HP")]
    [SerializeField] private int hp = 3;

    [Header("�X�^�~�i���")]
    [SerializeField] private float maxStamin = 50;
    private float stamina;

    [Header("�G�l���M�[�e�̃G�l���M�[")]
    [SerializeField] private float energy = 60;
    private float nowenerrgy = 0;
    [SerializeField] private float oneshot = 20;
    [SerializeField] private float maxchage = 40;

    [Header("�G�l���M�[�e�̃`���[�W����")]
    [SerializeField] private float chageTime = 5f;
    private float nowChageTime = 0f;

    private bool runcheck = false;
    private bool moveCheck = true;
    private bool staminaCheck = false;
    private bool chagebullet = false;
    private bool play = true;
    private bool dead = false;

    private Vector3 move;
    private Vector3 subtractmove;

    [Header("�G�l���M�[�e�𐶐�����ꏊ")]
    [SerializeField] private Transform bulletpos;

    private Rigidbody rb;

    [SerializeField] private BulletController bullet;

    [Header("���X�|�[���n�_")]
    [SerializeField] private Transform respawn;

    private Animator animator;

    private BulletController createBullet;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        nowenerrgy = energy;
        stamina = maxStamin;
    }

    void Start()
    {
    }

    void Update()
    {
        if (play)
        {
            if (!dead)
            {
                if (moveCheck)
                {
                    PlayerMove();
                    Attack();
                }
                else
                {
                    WaiteTime();
                }
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
        float x = 0, y = 0, z = 0;
        if (!chagebullet)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            y = Input.GetAxis("Mouse X") * angleSpead * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift) && !staminaCheck)
            {
                numspeed = runSpeed;
                runcheck = true;
            }
            else
            {
                numspeed = spead;
                runcheck = false;
            }

        }
        else
        {
            runcheck = false;
        }

        if(x != 0 || z != 0)
        {
            if (runcheck)
            {
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
        }

        if (runcheck)
        {
            if (stamina >= 1)
            {
                stamina -= 3 * Time.deltaTime;
            }
            else
            {
                runcheck = false;
                staminaCheck = true;
            }
        }
        else
        {
            if (stamina < 50)
            {
                stamina += 2 * Time.deltaTime;
            }
            else
            {
                staminaCheck = false;
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
        if (stamina >= 1)
        {
            stamina += 2 * Time.deltaTime;
        }
        else
        {
            moveCheck = true;
        }
    }
    
    //�U��
    private void Attack()
    {
        bool check = false;
        if ((energy >= nowenerrgy && nowenerrgy > oneshot) || energy <= nowenerrgy)
        {
            check = true;
        }
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && createBullet == null)
        {
            if (check)
            {
                createBullet = bullet.CreateBullet(bulletpos, this.transform);
                nowenerrgy -= oneshot;
                chagebullet = true;
            }
        }
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            nowChageTime += Time.deltaTime;
        }
        if((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E)) && chagebullet)
        {
            if(nowChageTime >= chageTime)
            {
                bullet.ShotBullet(true,createBullet);
                nowenerrgy -= (maxchage - oneshot);
            }
            else
            {
                bullet.ShotBullet(false,createBullet);
            }
            nowChageTime = 0;
            createBullet = null;
            chagebullet = false;
        }
        else
        {
            if(nowenerrgy < energy && !chagebullet)
            {
                nowenerrgy += 2f * Time.deltaTime;
            }
        }
    }

    //�^�C���A�b�v
    public void TimeUp()
    {
        play = !play;
    }

    //�v���C���[�̓����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 1;
            if(hp <= 0)
            {
                dead = true;
            }
            else
            {
                transform.position = respawn.position;
            }
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            key++;
            Destroy(collision.gameObject);
        }
    }

    //������n��
    public int GetKey()
    {
        return key;
    }
    //Ui�p
    public float GetMaxStamina()
    {
        return maxStamin;
    }
    public float GetStamina()
    {
        return stamina;
    }
    public float GetMaxEnergy()
    {
        return energy;
    }
    public float GetEenergy()
    {
        return nowenerrgy;
    }
}
