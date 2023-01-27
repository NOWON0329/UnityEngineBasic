using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���� ������Ű�� RaceManager���� �����ߴٰ� �������
/// </summary>
public class GoalLine : MonoBehaviour
{
    [SerializeField]
    private RaceManager raceManager;
    private void OnTriggerEnter(Collider other)
    {
        //Getcomponent�� �ش� GameObject�� ��� ������Ʈ���� �˻��ϴ� ���ſ� ����. ȣ���� �ּ�ȭ�ؾ���
        Horse horse = other.GetComponent<Horse>();
        horse.doMove = false;
        raceManager.RegisterFinishedHorses(horse);
    }
}
