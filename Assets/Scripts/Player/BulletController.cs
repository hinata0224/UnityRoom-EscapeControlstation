using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int attackDamege;

    [SerializeField] private float bulletSpeed = 5f;

    [Header("�A�j���[�^�[��Parameters�̖��O")]
    [SerializeField] private string small;
    [SerializeField] private string tall;

    private bool chageCheck = false;
    private bool shot = false;

    private Vector3 direction = new Vector3();
    private Vector3 subtractmove = new Vector3();

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator animator;

    private void Awake()
    {
    }

    void Start()
    {
    }

    void Update()
    {
        DeleteThis();
    }

    //�T�C�Y��0�ɂȂ��������
    void DeleteThis()
    {
        if(transform.localScale.x <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    //�e�̐���
    public BulletController CreateBullet(Transform pos,Transform player)
    {
        BulletController bullet;
        bullet = Instantiate(this.gameObject, pos.position,player.rotation).GetComponent<BulletController>();
        return bullet;
    }
    //�e�̔���
    public void ShotBullet(bool check,BulletController bullet)
    {
        if (check)
        {
            bullet.animator.SetTrigger(tall);
            bullet.attackDamege = 2;
        }
        else
        {
            bullet.animator.SetTrigger(small);
            bullet.attackDamege = 1;
        }
        bullet.chageCheck = true;
        bullet.rb.velocity = bullet.transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && chageCheck)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<AIController>().Hit(attackDamege);
            }
            Destroy(this.gameObject);
        }
    }
}
