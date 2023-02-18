using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header ("플레이어 스탯")]
    [SerializeField] public float ShootSpeed = 3;
    [SerializeField] public float TearRange = 1;
    [SerializeField] public float PlayerSpeed = 2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
