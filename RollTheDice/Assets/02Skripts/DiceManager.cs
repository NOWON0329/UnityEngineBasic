using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;

    private void Awake()
    {
        instance = this;
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
    public event Action<int> onNormalDiceChanged;
    public event Action<int> onGoldenDiceChanged;
    public event Action<int> onRollDice;
    private int _currentTypeIndex;
    [SerializeField] private TileMap _tileMap;
    private List<TileStar> _tileStars = new List<TileStar>();

    public void RollNormalDice()
    {
        //남은 주사위가 있는지 확인
        if (_normalDice <= 0)
            return;

        _normalDice--; //주사위 차감
        int diceValue = Random.Range(1, 7); //랜덤한 주사위값 생성
        onRollDice?.Invoke(diceValue); //구독자들에게 주사위 굴렸다는 알림 통지
    }
    public void RollGoldenDice(int diceValue)
    {
        if (_goldenDice <= 0)
            return;

        _goldenDice--;
        onRollDice?.Invoke(diceValue);
    }

    private void Start()
    {
        foreach(Tile tile in _tileMap.tiles)
        { 
            if(tile is TileStar)
            {
                _tileStars.Add((TileStar)tile);
            }
        }
    }

    private void EarnStarValue(int prev, int diceValue)
    {
        int sum = 0;
        foreach(TileStar tileStar in _tileStars)
        {
            if(prev + diceValue > _tileMap.total)
            {
                if(tileStar.index <= prev)
                {
                    if(tileStar.index <= prev + diceValue - _tileMap.total)
                    {
                        sum += tileStar.starValue;
                    }
                }
                else
                {
                    sum += tileStar.starValue;
                }
            }
            else
            {
                //이 샛별칸이 주사위를 굴린 범위 내에 있는지 
                if(tileStar.index > prev &&
                    tileStar.index <= prev + diceValue)
                {
                    sum += tileStar.starValue; 
                }
            }
        }
    }
}
