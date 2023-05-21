using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

public class TestDialogueFile : MonoBehaviour
{
    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset("text-file");

        DialogueSystem.instance.Say(lines);
    }
}
