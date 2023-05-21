using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class TestingArchitect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;

        string[] lines = new string[5]
        {
            "Hello World!",
            "This is a test.",
            "This is a test of the emergency broadcast system.",
            "This is only a test.",
            "Yes, this is only a test.",
        };

        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
        }

        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                architect.Stop();
            }

            string longLine = "This is a test of the emergency broadcast system. This is only a test. Yes, this is only a test okay. A very ang big long good line to be very long.";

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                    {
                        architect.hurryUp = true;
                    }
                    else
                    {
                        architect.ForceComplete();
                    }
                }
                else
                    // architect.Build(lines[Random.Range(0, lines.Length)])
                    architect.Build(longLine);
            } else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
                // architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }

}