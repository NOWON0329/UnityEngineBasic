using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� Ŭ����
/// </summary>
public class RaceManager : MonoBehaviour
{
    [SerializeField]
    private Horse[] horses;
    List<Horse> finishedHorses = new List<Horse>();
    [SerializeField]
    private TargetFollowCamera[] _followCamera;
    [SerializeField]
    private GameObject _finishedUI;


    //======================================================
    //                      public Methods
    //======================================================

    /// <summary>
    /// ���� ���� : ������ ��߽�Ŵ
    /// </summary>
    public void StartRace()
    {
        for(int i = 0; i < horses.Length; i++)
        {
            horses[i].doMove = true;
        }
    }

    /// <summary>
    /// ���� �� : 1,2,3���� UI�� �����
    /// </summary>
    public void StopRace()
    {
        for(int i = 0; i<_followCamera.Length; i++)
        {
            //���� ī�޶�� ��� ��
            if (i > finishedHorses.Count - 1)
                break;
            _followCamera[i].target = finishedHorses[i].transform;
        }
        _finishedUI.SetActive(true);
    }

    public void RegisterFinishedHorses(Horse horse)
    {
        if(finishedHorses.Contains(horse))
        {
            return;
        }
        finishedHorses.Add(horse);
        CheckRaceFinished();
    }

    /// <summary>
    /// ���� ������ ���� üũ�ϰ� ���ָ� ����
    /// </summary>
    public void CheckRaceFinished()
    {
        if(horses.Length == finishedHorses.Count)
        {
            StopRace();
        }
    }
}
