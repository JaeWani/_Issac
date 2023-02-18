using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Header("Stage Bgm")]
    [SerializeField] AudioClip[] BgmIntroClip;
    [SerializeField] AudioClip[] BgmClip;

    [Header("Stage Number")]
    public Stage StageNumber;

    [Header("스테이지 관리")]
    [SerializeField] public static int RoomSize= 5;
    [SerializeField] GameObject RoomArray;
    [SerializeField] List<GameObject> RoomNum = new List<GameObject>(new GameObject[RoomSize]);
    [SerializeField] GameObject StartRoom;


    [Header("전투 방  배열")]
    [SerializeField] List<GameObject> Room_kind = new List<GameObject>();
    public enum Stage 
    { 
        Stage_1,
        Stage_2,
        Stage_3,
        Stage_4,
        Stage_5,
        Stage_6,
        Stage_7,
        Stage_8
    }
    public enum RoomDirection 
    { 
    Right =1,
    Left,
    Up,
    Down
    }
    RoomDirection direction;
    public void CreatStage() 
    {
        int X_Range = 0, Y_Range = 0;
        int Max_X_Range = 10 * RoomSize;
        for (int i = 0; i < RoomSize * RoomSize; i++) 
        {
            var array = Instantiate(RoomArray,new Vector2(X_Range, Y_Range),Quaternion.identity); // 맵 배열 생성
            var room = Instantiate(Room_kind[1], array.transform.position,Quaternion.identity); // 방 생성
            room.transform.parent = array.transform; //방의 부모 오브젝트를 맵 배열로 설정
            array.name = i + 1+""; // 맵 배열의 이름을 배열의 인덱스 + 1로 변경
            RoomNum.Add(array); // 배열 오브젝트를 리스트에 추가
            X_Range += 10; // 방 사이의 간격을 10씩 벌려줌
            if (X_Range >= Max_X_Range) // 방 사이 간격을 이용하여 일정 칸을 넘어가면 밑으로 내려가게 함.
            {
                X_Range = 0;
                Y_Range -= 7;
            }
            Debug.Log(X_Range);
        }
        // 맵 중심을 시작 방으로 만들어주는 과정
        int Start_Index = (RoomSize * RoomSize / 2) + 1;
        var Center = GameObject.Find(Start_Index.ToString());
        StartRoom = Instantiate(Room_kind[0], Center.transform);
        var Center_Child = Center.transform.GetChild(0);
        Destroy(Center_Child.gameObject);
    }
    void Start()
    {
        StageNumber = Stage.Stage_1;
        StageBgm(BgmIntroClip[(int)StageNumber], BgmClip[(int)StageNumber],0.01f);
        CreatStage();
    }

    void Update()
    {
    }
    public void ChangeStage()
    {
       
    }
    public void StageBgm(AudioClip intro,AudioClip bgm, float volume) 
    {
        StartCoroutine(AudioManager.Instance.UseIntroBgm(intro, bgm, volume));
    }
}
