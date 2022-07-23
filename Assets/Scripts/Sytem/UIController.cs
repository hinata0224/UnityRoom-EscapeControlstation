using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("�v���C���[�֌W")]
    [SerializeField] private Slider stamina;
    [SerializeField] private Slider energy;

    [Header("�N���A����")]
    [SerializeField] private Text keyText;

    [SerializeField] private PlayerController player;
    [SerializeField] private GameMangerController game;

    void Start()
    {
        PlayerIitiSetting();
        GameIitiSetting();
    }

    void Update()
    {
        PlayerUI();
        GameUI();
    }

    //UI�̏����ݒ�
    private void PlayerIitiSetting()
    {
        stamina.maxValue = player.GetMaxStamina();
        energy.maxValue = player.GetMaxEnergy();
    }
    private void GameIitiSetting()
    {
        keyText.text = "" + 0 + "/" + game.ReturnMaxKey();
    }

    //���s����UI
    private void PlayerUI()
    {
        stamina.value = player.GetStamina();
        energy.value = player.GetEenergy();
    }
    private void GameUI()
    {
        keyText.text = "" + game.ReturnKey() + "/" + game.ReturnMaxKey();
    }
}
