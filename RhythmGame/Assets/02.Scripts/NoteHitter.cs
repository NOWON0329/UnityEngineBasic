using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NoteHitter : MonoBehaviour
{
    public enum HitJudge
    {
        None,
        Bad,
        Miss,
        Good,
        Great,
        Cool
    }

    [SerializeField] private KeyCode _key;

    [SerializeField] private LayerMask _hitMask;
    private SpriteRenderer _spriteRenderer;
    private Color _colorOrigin;
    [SerializeField] private Color _colorPressed;
    [SerializeField] private GameObject _hitEffect;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colorOrigin = _spriteRenderer.color;
    }

    private void Update()
    {
        if(Input.GetKeyDown(_key))
        {
            Hit();
            _spriteRenderer.color = _colorPressed;
            _hitEffect.SetActive(true);
        }

        if(Input.GetKeyUp(_key))
        {
            _spriteRenderer.color = _colorOrigin;
            _hitEffect.SetActive(false);
        }
    }

    private void Hit()
    {
        HitJudge hitJudge = HitJudge.Bad;

        Collider2D[] cols = Physics2D.OverlapBoxAll(point: transform.position,
                                size: new Vector2(transform.lossyScale.x / 2f,
                                 PlaySettings.HIT_JUDGE_RANGE_MISS),
                                angle: 0f,
                                layerMask: _hitMask);

        if(cols.Length > 0)
        {
            IOrderedEnumerable<Collider2D> colsFiltered = cols.OrderBy(x => Mathf.Abs(x.transform.position.y - transform.position.y));

            float distance = Mathf.Abs(colsFiltered.First().transform.position.y - transform.position.y);

            if (distance < PlaySettings.HIT_JUDGE_RANGE_COOL / 2)
            {
                hitJudge = HitJudge.Cool;
                GameStatus.IncreaseCoolCount();
            }
            else if (distance < PlaySettings.HIT_JUDGE_RANGE_GREAT / 2)
            {
                hitJudge = HitJudge.Great;
                GameStatus.IncreaseGreatCount();
            }
            else if (distance < PlaySettings.HIT_JUDGE_RANGE_GOOD / 2)
            {
                hitJudge = HitJudge.Good;
                GameStatus.IncreaseGoodCount();
            }
            else if (distance < PlaySettings.HIT_JUDGE_RANGE_MISS / 2)
            {
                hitJudge = HitJudge.Miss;
                GameStatus.IncreaseMissCount();
            }

            Destroy(colsFiltered.First().gameObject);
         
            HitAlertManager.instance.PopUp(hitJudge);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x / 2f,
                                                            PlaySettings.HIT_JUDGE_RANGE_MISS,
                                                            0.0f));

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x / 2f,
                                                            PlaySettings.HIT_JUDGE_RANGE_GOOD,
                                                            0.0f));

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x / 2f,
                                                            PlaySettings.HIT_JUDGE_RANGE_GREAT,
                                                            0.0f));

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x / 2f,
                                                            PlaySettings.HIT_JUDGE_RANGE_COOL,
                                                            0.0f));
    }
}
