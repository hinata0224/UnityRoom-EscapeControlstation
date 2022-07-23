using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    [SerializeField] private int hp = 2;

    [SerializeField] private float witeTime = 3;
    [SerializeField] private float searceAngle = 130f;

    private float nowtime = 0;

    private bool search = false;
    private bool target = false;
    private bool move = false;
    private bool dead = false;

    private Transform pos;

    private NavMeshAgent agent;

    [SerializeField] private SelectPos spos;

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
            Dead();
        }
    }

    //AIの動き
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
    //agentで動かす
    void AgentMove(NavMeshAgent agent,Transform pos)
    {
        if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            agent.destination = pos.transform.position;
        }
    }
    //視界に入ったら
    void ViewPlayer()
    {

        //else
        //{
        //    search = false;
        //}
    }

    //範囲に入ったら
    public void InPlayer()
    {
        target = true;
    }
    public void OutPlaer()
    {
        target = false;
        move = false;
    }

    //ボールに当たったら
    public void Hit(int damege)
    {
        hp -= damege;
        if(hp <= 0)
        {
            dead = true;
        }
    }

    //HPが0になったら
    void Dead()
    {
        Destroy(this.gameObject);
    }
}
