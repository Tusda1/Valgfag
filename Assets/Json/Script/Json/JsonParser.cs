using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public static class JsonParser
{
    // JsonUtility is a built-in Unity class that can be used to serialize and deserialize JSON data.
    public static Dictionary<string, List<string>> GetDialogueDictionaryJsonUtility()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/TestJson.Json");
        Dialogues dialogueData = JsonUtility.FromJson<Dialogues>(json);

        Dictionary<string, List<string>> dialogueDictionary = new Dictionary<string, List<string>>();

        foreach (var dialoguePiece in dialogueData.Dialogue)
        {
            if (!dialogueDictionary.ContainsKey(dialoguePiece.Speaker))
            {
                dialogueDictionary[dialoguePiece.Speaker] = new List<string>();
            }
            dialogueDictionary[dialoguePiece.Speaker].Add(dialoguePiece.Text);
        }

        return dialogueDictionary;
    }
    
    // Newtonsoft.Json is a popular third-party library that can be used to serialize and deserialize JSON data.
    public static Dictionary<string, List<string>> GetDialogueDictionaryNewtonsoftJson()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/TestJson.Json");
        Dialogues dialogueData = JsonConvert.DeserializeObject<Dialogues>(json);

        Dictionary<string, List<string>> dialogueDictionary = new Dictionary<string, List<string>>();

        foreach (var dialoguePiece in dialogueData.Dialogue)
        {
            if (!dialogueDictionary.ContainsKey(dialoguePiece.Speaker))
            {
                dialogueDictionary[dialoguePiece.Speaker] = new List<string>();
            }
            dialogueDictionary[dialoguePiece.Speaker].Add(dialoguePiece.Text);
        }

        return dialogueDictionary;
    }
    
    // This method demonstrates how to parse JSON data without using classes.
    public static Dictionary<string, List<string>> GetDialogueDictionaryNewtonsoftJsonNoClasses()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/TestJson.Json");
        JObject jsonObject = JObject.Parse(json);

        Dictionary<string, List<string>> dialogueDictionary = new Dictionary<string, List<string>>();

        foreach (var dialoguePiece in jsonObject["Dialogue"])
        {
            string speaker = dialoguePiece["Speaker"].ToString();
            string text = dialoguePiece["Text"].ToString();

            if (!dialogueDictionary.ContainsKey(speaker))
            {
                dialogueDictionary[speaker] = new List<string>();
            }
            dialogueDictionary[speaker].Add(text);
        }

        return dialogueDictionary;
    }
}
