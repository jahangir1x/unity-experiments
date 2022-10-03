using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

// Implement IMessageHandler to receive message from quest machine message system
public class ChestActivator : MonoBehaviour, IMessageHandler {

    private void Start() {
        MessageSystem.AddListener(this, "Spawn", "chests");     // Register listener
    }

    public void OnMessage(MessageArgs messageArgs) {        // Do things when proper messages is passed
        foreach (Transform child in transform) {        // activate children
            child.gameObject.SetActive(true);
        }
    }

    private void OnDestroy() {
        MessageSystem.RemoveListener(this, "Spawn", "chests");  // Remove listener
    }


}
