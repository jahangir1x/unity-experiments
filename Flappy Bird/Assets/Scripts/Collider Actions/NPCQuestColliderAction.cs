using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class NPCQuestColliderAction : MonoBehaviour {
    private QuestGiver _npcQuestGiver;

    private void Start() {
        _npcQuestGiver = GetComponent<QuestGiver>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            _npcQuestGiver.StartDialogueWithPlayer();
        }
    }
}
