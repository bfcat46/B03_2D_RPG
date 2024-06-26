using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] npcIDNumber;

    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcIDNumber = npc;
    }
}
