using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMangerController : MonoBehaviour
{

    [SerializeField] private int necessaryKey = 3;
    private int key = 0;

    [SerializeField] private float endTime = 60;
    private float nowTime = 0;

    [Header("�N���A�|�[�^���̏ꏊ")]
    [SerializeField] private GameObject clearPos;

    [SerializeField] private SceneManagerController scene;
    [SerializeField] private PlayerController player;

    private SceneManagerController scenemanager;

    private void Awake()
    {
        clearPos.SetActive(false);
        scenemanager = GetComponent<SceneManagerController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Rezult();
        GetKey();
    }

    //clear��̃^�C�����C��
    void Rezult()
    {
        if(key == necessaryKey)
        {
            clearPos.SetActive(true);
        }
        if (player.GetDead())
        {
            scenemanager.GoLoser();
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
