using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraits;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        ObjScriptsData();
    }

    private void ObjScriptsData()
    {
        //talk
        talkData.Add(100, new string[] { "ó�� ���� ���̱� :0", "�̰��� ��Ȱ�� ���:0" });
        talkData.Add(1000, new string[] { "잠겨있다.:0 " });
        talkData.Add(2000, new string[] { " :0 " });

        //Quest
        talkData.Add(10 + 100, new string[] { "자네 여기 근처에 상자를 보지 못했는가?:0",
            "상자를 보았다면 안을 한번 확인해주게나:0" , "상자가 잠겨 있을테니 내 열쇠를 줌세:0" });
        talkData.Add(11 + 100, new string[] { "상자를 아직 확인하지 못했는가 :0", "이 늙은이를 기다리게 하지말게 :0" });

        talkData.Add(11 + 1000, new string[] { "낡은 시계를 획득했다. :0 " });

        talkData.Add(20 + 100, new string[] { " 잃어버렸었던 시계가 거기 있었군. :0 " , "고맙네 :0" });


        //portrait
        portraitData.Add(100, portraits[0]);

        portraitData.Add(1000, portraits[1]);
        portraitData.Add(2000, portraits[1]);
    }

    public string SendScripts(int idNumber, int talkIndex)
    {
        if (!talkData.ContainsKey(idNumber))
        {
            if (!talkData.ContainsKey(idNumber - idNumber % 10))
                return SendScripts(idNumber - idNumber % 100, talkIndex);
            else
                return SendScripts(idNumber - idNumber % 10, talkIndex);
        }
        if (talkIndex == talkData[idNumber].Length)
        {
            return null;
        }
        else
        {
            return talkData[idNumber][talkIndex];
        }
    }

    public Sprite SendPortrait(int idNumber, int portraitIndex)
    {
        return portraitData[idNumber + portraitIndex];
    }
}
