using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// �ֻ����� �����ϴ� Ŭ����
/// </summary>
public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;

    private void Awake()
    {
        instance = this;
        normalDice = _normalDiceInit = 20;
        goldenDice = _goldenDiceInit = 2;
    }

    public const int DIRECTION_FORWARD = 1;
    public const int DIRECTION_BACKWARD = -1;
    public int direction = DIRECTION_FORWARD;
    public int normalDice
    {
        get
        {
            return _normalDice;
        }
        set
        {
            _normalDice = value;
            onNormalDiceChanged?.Invoke(value);
        }
    }
    public int goldenDice
    {
        get
        {
            return _goldenDice;
        }
        set
        {
            _goldenDice = value;
            onGoldenDiceChanged?.Invoke(value);
        }
    }
    private int _normalDice;
    private int _goldenDice;
    [SerializeField] int _normalDiceInit;
    [SerializeField] int _goldenDiceInit;
    public event Action<int> onNormalDiceChanged;
    public event Action<int> onGoldenDiceChanged;
    public event Action<int> onRollDice;
    private int _currentTypeIndex;

    public int RollNormalDice()
    {
        //���� �ֻ����� �ִ��� Ȯ��
        if (_normalDice <= 0)
            return -1;

        _normalDice--; //�ֻ��� ����
        int diceValue = Random.Range(1, 7); //������ �ֻ����� ����
        onRollDice?.Invoke(diceValue); //�����ڵ鿡�� �ֻ��� ���ȴٴ� �˸� ����
        return diceValue;
    }
    public int RollGoldenDice(int diceValue)
    {
        if (_goldenDice <= 0)
            return -1;

        _goldenDice--;
        onRollDice?.Invoke(diceValue);
        return diceValue;
    }
}
