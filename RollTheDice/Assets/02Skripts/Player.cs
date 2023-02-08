using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public int star
    {
        get
        {
            return _star;
        }
        private set
        {
            _star = value;
            onStarChanged?.Invoke(value);
        }
    }

    private int _star;
    public event Action<int> onStarChanged;

    public const int DIRECTION_FORWARD = 1;
    public const int DIRECTION_BACKWARD = -1;

    public int direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
            onDirectionChanged?.Invoke(value);
        }
    }
    public int _direction = DIRECTION_FORWARD; 
    public event Action<int> onDirectionChanged;
    [SerializeField] private TileMap _tileMap;
    private List<TileStar> _tileStars = new List<TileStar>();
    private int _currentTypeIndex = -1;

    public void Move(int diceValue)
    {
        //Á¤¹æÇâ
        if(direction == DIRECTION_FORWARD)
        {
            //»ûº° È¹µæ
            EarnStarValue(_currentTypeIndex, diceValue);

            //´ÙÀ½ Ä­ °è»ê
            _currentTypeIndex += diceValue;
            _currentTypeIndex %= _tileMap.total;
        }
        //¿ª¹æÇâ
        else if(direction == DIRECTION_BACKWARD)
        {
            _currentTypeIndex -= diceValue;
            if (_currentTypeIndex < 0)
                _currentTypeIndex += _tileMap.total;

            direction = DIRECTION_FORWARD;
        }

        transform.position += _tileMap[_currentTypeIndex].transform.position;
    }
    private void Start()
    {
        foreach (Tile tile in _tileMap.tiles)
        {
            if (tile is TileStar)
            {
                _tileStars.Add((TileStar)tile);
            }
        }
    }
    private void EarnStarValue(int prev, int diceValue)
    {
        int sum = 0;
        foreach (TileStar tileStar in _tileStars)
        {
            if (prev + diceValue > _tileMap.total)
            {
                if (tileStar.index <= prev)
                {
                    if (tileStar.index <= prev + diceValue - _tileMap.total)
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
                //ÀÌ »ûº°Ä­ÀÌ ÁÖ»çÀ§¸¦ ±¼¸° ¹üÀ§ ³»¿¡ ÀÖ´ÂÁö 
                if (tileStar.index > prev &&
                    tileStar.index <= prev + diceValue)
                {
                    sum += tileStar.starValue;
                }
            }
        }
        star += sum;
    }
}
