using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// ���� ���� �� ���� UI
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// �̱��� ����
    /// static ��������� �ν��Ͻ��� �����ϴ� ����
    /// �ַ� ��Ÿ���߿� �� �ϳ��� �����ϴ� ��ü�� �ְ� �ٸ� Ŭ�������� �����ϴ� ��찡 ���� ��� �����
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
