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

    //코루틴 (Coroutine)
    //함수가 반환시에 다른 함수를 호출하는 형태로 함수끼리 서로 상호작용하면서 호출되는 루틴
    //UnityEngine의 코루틴
    //IEnumerator를 MonoBehavior StartCoroutine()에 인자로 전달해주면 해당 Enumerator를 등록하고
    //Update 함수와 협동적으로 Update 이벤트가 끝날때등록되어있는 IEnumerator의 MoveNext()함수를 호출해서
    //그 다음 yield로직을 수행 할 수 있도록 돌아가는 루틴
    //
    //yield 키워드
    //c#에서 Collection이 있을 때 이 Collection을 하나씩 Iterating 하기 위한 키워드
    //IEnumerator / IEnumerable 을 반환할 때 약식으로 사용하기 위한 용도
    //
    private IEnumerator E_Play(int diceValue, Action onAnimationFinished)
    {
        float timeMark = Time.time;
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
                timer -= Time.deltaTime; //이런식으로 Time.deltaTime 같은 걸 써서 타이머 체크하는 방법은 좋지 않음
            }
            yield return null;
        }
        _image.sprite = _sprites[diceValue - 1];
        onAnimationFinished?.Invoke();

        yield return new WaitForSeconds(0.5f);
        isBusy = false;
    }
}
