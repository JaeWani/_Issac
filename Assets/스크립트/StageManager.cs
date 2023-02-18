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

    [Header("�������� ����")]
    [SerializeField] public static int RoomSize= 5;
    [SerializeField] GameObject RoomArray;
    [SerializeField] List<GameObject> RoomNum = new List<GameObject>(new GameObject[RoomSize]);
    [SerializeField] GameObject StartRoom;


    [Header("���� ��  �迭")]
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
            var array = Instantiate(RoomArray,new Vector2(X_Range, Y_Range),Quaternion.identity); // �� �迭 ����
            var room = Instantiate(Room_kind[1], array.transform.position,Quaternion.identity); // �� ����
            room.transform.parent = array.transform; //���� �θ� ������Ʈ�� �� �迭�� ����
            array.name = i + 1+""; // �� �迭�� �̸��� �迭�� �ε��� + 1�� ����
            RoomNum.Add(array); // �迭 ������Ʈ�� ����Ʈ�� �߰�
            X_Range += 10; // �� ������ ������ 10�� ������
            if (X_Range >= Max_X_Range) // �� ���� ������ �̿��Ͽ� ���� ĭ�� �Ѿ�� ������ �������� ��.
            {
                X_Range = 0;
                Y_Range -= 7;
            }
            Debug.Log(X_Range);
        }
        // �� �߽��� ���� ������ ������ִ� ����
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
