using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class ChestColliderAction : MonoBehaviour {
    private QuestControl _questControl;

    private void Start() {
        _questControl = GetComponent<QuestControl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {               // if player collided with chest then send message to quest control
            _questControl.SendToMessageSystem("Got:Chest");
        }

        gameObject.SetActive(false);        // deactive the chest
    }
}
