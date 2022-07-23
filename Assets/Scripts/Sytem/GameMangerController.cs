using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMangerController : MonoBehaviour
{

    [SerializeField] private int necessaryKey = 3;
    private int key = 0;

    private static int allyp;
    private static int enemyp;

    [SerializeField] private float endTime = 60;
    private float nowTime = 0;

    [Header("�N���A�|�[�^���̏ꏊ")]
    [SerializeField] private GameObject clearPos;

    [SerializeField] private PlayableDirector endTimeline;

    [SerializeField] private SceneManagerController scene;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        endTimeline.Pause();
        clearPos.SetActive(false);
    }
    void Start()
    {
        
    }

    void Update()
    {
        LimitTime();
        GetKey();
    }

    //clear��̃^�C�����C��
    void LimitTime()
    {
        //nowTime += Time.deltaTime;
        //if(endTime <= nowTime)
        //{
        //    player.TimeUp();
        //    StaticPoint();
        //    endTimeline.Play();
        //}
        if(key == necessaryKey)
        {
            clearPos.SetActive(true);
        }
    }
    //���̃Q�b�g
    public void GetKey()
    {
        key = player.GetKey();
    }
    
    //UI�p
    public int ReturnKey()
    {
        return key;
    }
    public int ReturnMaxKey()
    {
        return necessaryKey;
    }
}
