using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionNumber;

    Dictionary<int, QuestData> questList; 
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        SendData();
    }

    private void SendData()
    {
        questList.Add(10, new QuestData("������Ʈ ��ȣ �ۿ� ����Ʈ" , new int[] {100 , 1000}));
        questList.Add(20, new QuestData(" ����Ʈ Ȯ��", new int[] { 0 }));
    }

    public int QuestTalkIndex(int idNumber)
    {
        return questID + questActionNumber;
    }

    public string CheckQuest(int idNumber)
    {
        if(idNumber == questList[questID].npcIDNumber[questActionNumber])
        questActionNumber++;

        if (questActionNumber == questList[questID].npcIDNumber.Length)
            NextQuest();

        return questList[questID].questName;
    }
    void NextQuest()
    {
        questID += 10;
        questActionNumber = 0;
    }
}
