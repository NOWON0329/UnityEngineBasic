using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;

    public GameObject[] horses;
    List<GameObject> horseFinished = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void StartRace()
    {

    }
    public void StopRace()
    {

    }
    public void RegisterFinishedHorses(Horse horse)
    {

    }
    public void CheckRaceFinished()
    {

    }
}
