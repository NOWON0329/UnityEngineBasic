using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// �ֻ��� ������ �ٲ� �� ���� �ֻ��� ���� UI����
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
        //�Ϲ� �ֻ�����ư Ŭ�� ��
        //�ֻ��� ������ ���� �������� �ִϸ��̼� ����ϰ�, �ִϸ��̼� ������ �÷��̾ �ش� ���ݸ�ŭ �̵���Ŵ
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

