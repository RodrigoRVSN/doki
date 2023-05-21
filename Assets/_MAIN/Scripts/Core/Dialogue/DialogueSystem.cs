using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueSystem : MonoBehaviour
    {
        public DialogueContainer dialogueContainer = new DialogueContainer();
        private ConversationManager conversationManager;
        private TextArchitect architect;

        public static DialogueSystem instance;

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPrompt_Next;

        public bool isRunningConversation => conversationManager.isRunning;

        private void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }
            instance = this;
            Initialize();
        }

        bool _initialized = false;
        private void Initialize()
        {
            if (_initialized) return;
            architect = new TextArchitect(dialogueContainer.dialogueText);
            conversationManager = new ConversationManager(architect);
        }

        public void OnUserPrompt_Next()
        {
            onUserPrompt_Next?.Invoke();
        }

        public void ShowSpeakerName(string speakerName = "")
        {
            if (speakerName == "narrator")
            {
                dialogueContainer.nameContainer.Hide();
            }
            else
            {
                dialogueContainer.nameContainer.Show(speakerName);
            }
        }

        public void HideSpeakerName() => dialogueContainer.nameContainer.Hide();

        public void Say (string speaker, string dialogue)
        {
            List<string> conversation = new List<string>() { $"{speaker}: \"{dialogue}\"" };
            Say(conversation);
        }

        public void Say(List<string> conversation)
        {
            conversationManager.StartConversation(conversation);
        }

    }
}
