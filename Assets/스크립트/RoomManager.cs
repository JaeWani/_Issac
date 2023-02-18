using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{
    [Header("���� ����")]
    [SerializeField] public bool IsBattle = false;
    bool si;

    [Header("�� ����")]
    [SerializeField] AudioClip close;
    [SerializeField] AudioClip open;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            BattleStart();
        else if (Input.GetKeyDown(KeyCode.L))
            BattleEnd();


    }
    void BattleStart() 
    {
        IsBattle = true;
        AudioManager.Instance.DoorSounds(close);
    }
    void BattleEnd() 
    {
        IsBattle = false;
        AudioManager.Instance.DoorSounds(open);
    }
}
