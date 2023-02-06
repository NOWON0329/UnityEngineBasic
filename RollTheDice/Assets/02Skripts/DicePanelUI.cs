using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 주사위 개수가 바뀔 때 마다 주사위 갯수 UI갱신
/// 
/// </summary>
public class DicePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _normalDice;
    [SerializeField] private TMP_Text _goldenDice;

    private void Awake()
    {
        DiceManager.instance.onNormalDiceChanged += (dice) => _normalDice.text = dice.ToString();
        DiceManager.instance.onGoldenDiceChanged += (dice) =>
        {
            _goldenDice.text = dice.ToString();
        };
        _normalDice.text = DiceManager.instance.normalDice.ToString();
        _goldenDice.text = DiceManager.instance.goldenDice.ToString();
    }
}

