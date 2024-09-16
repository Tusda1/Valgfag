using UnityEngine;

public class JsonUtilityClass : MonoBehaviour
{

    private void Start()
    {
        string json = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/TestJson.Json");
        Dialogues dialogueData = JsonUtility.FromJson<Dialogues>(json);

        foreach (var dialoguePiece in dialogueData.Dialogue)
        {
            print(dialoguePiece.Speaker + "Says: " + dialoguePiece.Text + " with " + dialoguePiece.Emotion);
        }
    }
}

[System.Serializable]
public class DialogueEntry
{
    public string Speaker;
    public string Text;
    public string Emotion;
}

[System.Serializable]
public class Dialogues
{
    public DialogueEntry[] Dialogue;
}