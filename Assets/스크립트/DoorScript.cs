using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    GameObject Left_Door;
    GameObject Right_Door;

    
    enum DoorState 
    { 
    Open,
    Close
    }
    private DoorState Current_State;

    private void Start()
    {
        Left_Door = gameObject.transform.GetChild(1).gameObject;
        Right_Door = gameObject.transform.GetChild(2).gameObject;
    }
    void Update()
    {
        DoorSystem();
    }
    void DoorSystem()
    {
        if (RoomManager.Instance.IsBattle == false)
            Current_State = DoorState.Open;
        else
            Current_State = DoorState.Close;

        if (Current_State == DoorState.Open) { Left_Door.SetActive(false); Right_Door.SetActive(false); }
        else if (Current_State == DoorState.Close) { Left_Door.SetActive(true); Right_Door.SetActive(true); }
    }
}
