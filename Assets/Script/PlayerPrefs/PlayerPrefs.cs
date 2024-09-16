using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        inputField.onEndEdit.AddListener(EndEdit);

        StartCoroutine(RoutineStringUpdate());
    }

    void EndEdit(string text)
    {
        SaveString();
        print("Worked");
    }
    
    // Put a string from inputfield and save the string to playerprefs
    private void SaveString()
    {
        string word = inputField.text;
        UnityEngine.PlayerPrefs.SetString("Word", word);
    }
    
    // Get the string from playerprefs and show it on the screen
    private void GetString()
    {
        string word = UnityEngine.PlayerPrefs.GetString("Word");
        text.text = word;
    }

    private IEnumerator RoutineStringUpdate()
    {
        while (true)    
        {
            GetString();
            yield return new WaitForSeconds(3);
        }
    }
}
