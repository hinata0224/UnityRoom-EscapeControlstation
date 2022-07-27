using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    [SerializeField] private int hp = 2;

    [SerializeField] private float witeTime = 3;
    [SerializeField] private float searceAngle = 130f;

    private float deadTime = 0f;

    private float nowtime = 0;

    private bool target = false;
    private bool move = false;
    private bool dead = false;

    private Transform pos;

    private NavMeshAgent agent;

    [SerializeField] private SelectPos spos;

    [SerializeField] private Animator animator;

    private GameObject player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!dead)
        {
            ToMove();
        }
        else
        {
            StopMove();
            Dead();
        }
    }

    //AI�̓���
    void ToMove()
    {
        if (target)
        {
            var positionDiff = player.transform.position - transform.position;
            var angle = Vector3.Angle(transform.forward, positionDiff);
            if (angle <= searceAngle)
            {
                AgentMove(agent, player.transform);
            }
            else
            {
                move = false;
            }
        }
        else
        {
            if (!move)
            {
                Transform temp = pos;
                pos = spos.GetPos();
                if(temp != pos)
                {
                    move = true;
                }
            }
            else
            {
                AgentMove(agent, pos);
            }
            if(move && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (nowtime >= witeTime)
                {
                    move = false;
                    nowtime = 0;
                }
                else
                {
                    nowtime += Time.deltaTime;
                }
            }
        }
    }

    //AI���~�߂�
    void StopMove()
    {
        agent.isStopped = true;
    }
    //agent�œ�����
    void AgentMove(NavMeshAgent agent,Transform pos)
    {
        if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            agent.destination = pos.transform.position;
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    //�͈͂ɓ�������
    public void InPlayer()
    {
        target = true;
    }
    public void OutPlaer()
    {
        target = false;
        move = false;
    }

    //�{�[���ɓ���������
    public void Hit(int damege)
    {
        hp -= damege;
        if(hp <= 0)
        {
            dead = true;
        }
    }

    //HP��0�ɂȂ�����
    void Dead()
    {
        deadTime += Time.deltaTime;
        animator.SetBool("Dead", true);
        if (deadTime >= 3f)
        {
            Destroy(this.gameObject);
        }
    }

    //Selectposs��ݒ�
    public void SetSelectPos(SelectPos select)
    {
        spos = select;
    }

    //AI������ł邩�m�F
    public bool GetDead()
    {
        return dead;
    }
}
