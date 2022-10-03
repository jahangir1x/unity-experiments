using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class GreenAreaColliderAction : MonoBehaviour {
    private QuestControl _areaQuestControl;

    private void Start() {
        _areaQuestControl = GetComponent<QuestControl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            _areaQuestControl.SendToMessageSystem("Explored:Green");
        }
    }
}
