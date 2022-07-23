using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum KindOfStates
{
    Enemy,
    Ally
}

public class AIController : MonoBehaviour
{
    [SerializeField] private KindOfStates states;

    [SerializeField] private int hp = 2;

    [SerializeField] private float witeTime = 3;
    [SerializeField] private float searceAngle = 130f;

    private float nowtime = 0;

    private bool search = false;
    private bool move = false;
    private bool dead = false;

    private Transform pos;

    private NavMeshAgent agent;

    [SerializeField] private SelectPos spos;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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

    //AI‚Ì“®‚«
    void ToMove()
    {
        if (!search)
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
        else
        {

        }
    }
    //agent‚Å“®‚©‚·
    void AgentMove(NavMeshAgent agent,Transform pos)
    {
        if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            agent.destination = pos.transform.position;
        }
    }
    //Ž‹ŠE‚É“ü‚Á‚½‚ç
    void ViewEnemy()
    {
        var positionDiff = pos.transform.position - transform.position;
        var angle = Vector3.Angle(transform.forward, positionDiff);
        if (angle <= searceAngle)
        {
            search = true;
        }
    }

    //ƒ{[ƒ‹‚É“–‚½‚Á‚½‚ç
    public void Hit(int damege)
    {
        hp -= damege;
        Debug.Log(hp);
        if(hp <= 0)
        {
            dead = true;
        }
    }

    //HP‚ª0‚É‚È‚Á‚½‚ç
    void Dead()
    {
        Destroy(this.gameObject);
    }
}
