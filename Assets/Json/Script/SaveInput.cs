using System.Collections;
using TMPro;
using UnityEngine;

public class SaveInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI text;
    
    public static string staticString = "Static string";

    private void Start()
    {
        inputField.onEndEdit.AddListener(delegate { Save(); });
        
        StartCoroutine(LoadCoroutine());
    }

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputField.text);
    }
    
    public void Load()
    {
        text.text = PlayerPrefs.GetString("Name");
    }
    
    private IEnumerator LoadCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Load();
    }
}
