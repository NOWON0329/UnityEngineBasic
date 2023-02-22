using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ScoringText : MonoBehaviour
{
    public static ScoringText instance;

    private TMP_Text _scoreText;

    private void Awake()
    {
        instance = this;
        _scoreText = GetComponent<TMP_Text>();
        _buffer = new StringBuilder();
    }

    public int score
    {
        get => _score;
        set
        {
            _after = value;
            _score = value;
            _delta = (int)((_after - _before) / _duration);
        }
    }
    private int _score;

    private int _before;
    private int _after;
    private int _delta;
    private float _duration = 0.1f;
    private StringBuilder _buffer;

    private void Update()
    {
        if(_before < _after)
        {
            _before += (int)(_delta * Time.deltaTime);

            if (_before > _after)
                _before = _after;

            _buffer.Clear();
            _buffer.Append(_before);
            _scoreText.text = _buffer.ToString();
        }
    }
}
