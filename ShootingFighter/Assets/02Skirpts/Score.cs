using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// 현재 점수 밀 점수 UI
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// 싱글톤 패턴
    /// static 멤버변수로 인스턴스를 참조하는 형태
    /// 주로 런타임중에 단 하나만 존재하는 객체가 있고 다른 클래스들이 참조하는 경우가 잦은 경우 사용함
    /// </summary>
    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            _scoreText.text = value.ToString();
        }
    }

    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    public int _score;
    [SerializeField] private TMP_Text _scoreText;
}
