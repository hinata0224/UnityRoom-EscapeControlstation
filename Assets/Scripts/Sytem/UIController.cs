using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("プレイヤー関係")]
    [SerializeField] private Slider stamina;
    [SerializeField] private Slider energy;

    [Header("クリア条件")]
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

    //UIの初期設定
    private void PlayerIitiSetting()
    {
        stamina.maxValue = player.GetMaxStamina();
        energy.maxValue = player.GetMaxEnergy();
    }
    private void GameIitiSetting()
    {
        keyText.text = "" + 0 + "/" + game.ReturnMaxKey();
    }

    //実行中のUI
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
