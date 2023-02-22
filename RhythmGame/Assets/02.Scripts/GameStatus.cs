using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static int currentCombo
    {
        get => _currentCombo;
        set
        {
            maxCombo = maxCombo > value ? maxCombo : value;
            _currentCombo = value;
        }
    }
    public static int maxCombo { get; set; }
    public static int score
    {
        get => _score;
        set
        {
            _score = value;
            ScoringText.instance.score = value;
        }
    }

    public static int coolCount;
    public static int greatCount;
    public static int goodCount;
    public static int missCount;
    public static int badCount;   

    private static int _currentCombo;
    private static int _score;

    public static void IncreaseCoolCount()
    {
        coolCount++;
        _currentCombo++;
        score += PlaySettings.SCORE_COOL;
    }
    public static void IncreaseGreatCount()
    {
        greatCount++;
        _currentCombo++;
        score += PlaySettings.SCORE_GREAT;
    }
    public static void IncreaseGoodCount()
    {
        goodCount++;
        _currentCombo++;
        score += PlaySettings.SCORE_GOOD;
    }
    public static void IncreaseMissCount()
    {
        missCount++;
        _currentCombo = 0;
        score += PlaySettings.SCORE_MISS;
    }
    public static void IncreaseBadCount()
    {
        badCount++;
        _currentCombo = 0;
        score += PlaySettings.SCORE_BAD;
    }
}
