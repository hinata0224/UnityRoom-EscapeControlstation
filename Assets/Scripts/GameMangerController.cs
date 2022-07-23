using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMangerController : MonoBehaviour
{
    private int allyPoint = 0;
    private int enemyPoint = 0;

    private static int allyp;
    private static int enemyp;

    [SerializeField] private float endTime = 60;
    private float nowTime = 0;

    [SerializeField] private PlayableDirector endTimeline;

    [SerializeField] private SceneManagerController scene;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        endTimeline.Pause();
    }
    void Start()
    {
        
    }

    void Update()
    {
        LimitTime();
    }

    void LimitTime()
    {
        nowTime += Time.deltaTime;
        if(endTime <= nowTime)
        {
            player.TimeUp();
            StaticPoint();
            endTimeline.Play();
        }
    }
    //”’l‚Ì•Û‘¶
    void StaticPoint()
    {
        allyp = allyPoint;
        enemyp = enemyPoint;
    }
}
