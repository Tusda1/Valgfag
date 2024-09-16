using System.Collections.Generic;
using UnityEngine;

public class JsonToPrint : MonoBehaviour
{
    private Dictionary<string, List<string>> dialogueDictionary = new Dictionary<string, List<string>>();

    void Start()
    {
        dialogueDictionary = JsonParser.GetDialogueDictionaryJsonUtility();

        foreach (var dialoguePiece in dialogueDictionary)
        {
            foreach (var text in dialoguePiece.Value)
            {
                print(dialoguePiece.Key + "Says: " + text);
            }
        }

        dialogueDictionary = JsonParser.GetDialogueDictionaryNewtonsoftJson();

        foreach (var dialoguePiece in dialogueDictionary)
        {
            foreach (var text in dialoguePiece.Value)
            {
                print(dialoguePiece.Key + "Says: " + text);
            }
        }
    }
}