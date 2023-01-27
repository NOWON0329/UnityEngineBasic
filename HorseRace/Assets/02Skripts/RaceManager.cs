using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 경주 로직을 관리하는 클래스
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
    /// 경주 시작 : 말들을 출발시킴
    /// </summary>
    public void StartRace()
    {
        for(int i = 0; i < horses.Length; i++)
        {
            horses[i].doMove = true;
        }
    }

    /// <summary>
    /// 경주 끝 : 1,2,3등을 UI에 띄워줌
    /// </summary>
    public void StopRace()
    {
        for(int i = 0; i<_followCamera.Length; i++)
        {
            //남는 카메라는 놀게 함
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
    /// 경주 끝나는 조건 체크하고 경주를 끝냄
    /// </summary>
    public void CheckRaceFinished()
    {
        if(horses.Length == finishedHorses.Count)
        {
            StopRace();
        }
    }
}
