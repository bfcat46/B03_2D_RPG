using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjScan : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI talk;
    public GameObject rayObject;
    public GameObject talkPanel;
    public TalkManager talkManager;
    public QuestManager questManager;
    public bool isInteraction;
    public int talkIndex;
    public void Scan(GameObject scan)
    {
        rayObject = scan;
        ObjData objData = rayObject.GetComponent<ObjData>();
        Talk(objData.idNumber, objData.isNPC);

        talkPanel.SetActive(isInteraction);
    }

    void Talk(int idNumber , bool isNPC)
    {
        int questTalkIndex = questManager.QuestTalkIndex(idNumber);
        string talkData = talkManager.SendScripts(idNumber + questTalkIndex , talkIndex);

        if(talkData == null)
        {
            isInteraction = false;
            talkIndex = 0;
            questManager.CheckQuest(idNumber);
            return;
        }

        if(isNPC)
        {
            talk.text = talkData.Split(':')[0];
            portrait.sprite = talkManager.SendPortrait(idNumber, int.Parse(talkData.Split(':')[1]));
            portrait.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talk.text = talkData.Split(':')[0];
            portrait.sprite = talkManager.SendPortrait(idNumber, int.Parse(talkData.Split(':')[1]));
            portrait.color = new Color(1, 1, 1, 1);

        }

        isInteraction = true;
        talkIndex++;
    }
}
