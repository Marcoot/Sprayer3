using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossdead : MonoBehaviour
{
    public EnemyCounter enemyCounter;
    public Gate gate;
    public float EnemiesLeftTrigger;
    [SerializeField] private bool ChangeGates;
    [SerializeField] private bool changeIsDone;
    void Update()
    {
        if(enemyCounter.enemyCount == EnemiesLeftTrigger)
        {
            ChangeGates = true;
            if(ChangeGates && !changeIsDone) Changinggates();
        }
    }

    void Changinggates()
    {
        gate.ToggleGateActiveStatus();
        changeIsDone = true;
    }
}
