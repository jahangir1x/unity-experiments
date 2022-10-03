using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using PixelCrushers;

public class ChestActivatorCheck : MonoBehaviour {
    public GameObject NPC;
    public Quest npcQuest;

    private void Start() {
        QuestGiver questGiver = NPC.GetComponent<QuestGiver>();
        npcQuest = questGiver.questList[0];
        Debug.Log(npcQuest.nodeList[1].internalName);
    }

    private void Update() {
        if (npcQuest.GetNode("acquireChests").GetState() == QuestNodeState.Active) {
            Debug.Log("acccccc");
        }
    }
}
