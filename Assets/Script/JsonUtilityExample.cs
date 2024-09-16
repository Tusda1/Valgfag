using System;
using UnityEngine;

public class JsonUtilityExample : MonoBehaviour
{
    private void Start()
    {
        string json = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/TestJson.json");
        Class2 dialogues = JsonUtility.FromJson<Class2>(json);

        foreach (var dialogue in dialogues.Dialogue)
        {
            print(dialogue.Speaker + "Says: " + dialogue.Text + " with " + dialogue.Emotion);
        }
    }
}

[System.Serializable]
public class Class1
{
    public string Speaker;
    public string Text;
    public string Emotion;
}

[System.Serializable]
public class Class2
{
    public Class1[] Dialogue;
}
