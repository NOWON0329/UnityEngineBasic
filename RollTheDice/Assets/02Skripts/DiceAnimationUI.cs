using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    public bool isBusy;
    

    public void Play(int diceValue, Action onAnimationFinished)
    {
        if (isBusy)
            return;
         
        isBusy = true;
        StartCoroutine(E_Play(diceValue, onAnimationFinished));
    }

    //�ڷ�ƾ (Coroutine)
    //�Լ��� ��ȯ�ÿ� �ٸ� �Լ��� ȣ���ϴ� ���·� �Լ����� ���� ��ȣ�ۿ��ϸ鼭 ȣ��Ǵ� ��ƾ
    //UnityEngine�� �ڷ�ƾ
    //IEnumerator�� MonoBehavior StartCoroutine()�� ���ڷ� �������ָ� �ش� Enumerator�� ����ϰ�
    //Update �Լ��� ���������� Update �̺�Ʈ�� ��������ϵǾ��ִ� IEnumerator�� MoveNext()�Լ��� ȣ���ؼ�
    //�� ���� yield������ ���� �� �� �ֵ��� ���ư��� ��ƾ
    //
    //yield Ű����
    //c#���� Collection�� ���� �� �� Collection�� �ϳ��� Iterating �ϱ� ���� Ű����
    //IEnumerator / IEnumerable �� ��ȯ�� �� ������� ����ϱ� ���� �뵵
    //
    private IEnumerator E_Play(int diceValue, Action onAnimationFinished)
    {
        float timeMark = 0;
        float timer = 0;
        while(Time.deltaTime - timeMark > _duration)
        {
            if(timer <0)
            {
                _image.sprite = _sprites[Random.Range(0, _sprites.Length)];
                timer = 1 / _speed;
            }
            else
            {
                timer -= Time.deltaTime; //�̷������� Time.deltaTime ���� �� �Ἥ Ÿ�̸� üũ�ϴ� ����� ���� ����
            }
            yield return null;
        }
        _image.sprite = _sprites[diceValue - 1];
        onAnimationFinished?.Invoke();

        isBusy = false;
    }
}
