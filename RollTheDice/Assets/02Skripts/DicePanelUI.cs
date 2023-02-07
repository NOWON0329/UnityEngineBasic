using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// 주사위 개수가 바뀔 때 마다 주사위 갯수 UI갱신
/// </summary>
public class DicePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _normalDice;
    [SerializeField] private TMP_Text _goldenDice;
    [SerializeField] private Button _normalDiceButton;
    [SerializeField] private Button _goldenDiceButton;

    private void Awake()
    {
        DiceManager diceManager = DiceManager.instance;
        diceManager.onNormalDiceChanged += (dice) =>
        {
            _normalDiceButton.interactable = dice > 0;
            _normalDice.text = dice.ToString();
        };
        diceManager.onGoldenDiceChanged += (dice) =>
        {
            _normalDiceButton.interactable = dice > 0;
            _goldenDice.text = dice.ToString();
        };
        //일반 주사위버튼 클릭 시
        //주사위 굴리고 나온 눈금으로 애니메이션 재생하고, 애니메이션 끝날때 플레이어를 해당 눈금만큼 이동시킴
        _normalDiceButton.onClick.AddListener(() =>
        {
            int diceValue = diceManager.RollNormalDice();
            DiceAnimationUI.instance.Play(diceValue, () => Player.instance.Move(diceValue));
        });

        _normalDice.text = diceManager.normalDice.ToString();
        _goldenDice.text = diceManager.goldenDice.ToString();
        _normalDiceButton.interactable = diceManager.normalDice > 0;
        _goldenDiceButton.interactable = diceManager.goldenDice > 0;
    }
}

