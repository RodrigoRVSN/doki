using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        void Start()
        {
            SendFileToParse();
        }

        void SendFileToParse()
        {
            List<string> Lines = FileManager.ReadTextAsset("text-file");

            foreach (string line in Lines)
            {
                if (line == string.Empty) continue;

                DialogueLine dl = DialogueParser.Parse(line);
            }

        }
    }
}
