using TMPro;
using UnityEngine;

public class ScrobManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScrobDatabase.Initialize();
        
        foreach (var sword in ScrobDatabase.swords)
        {
            Debug.Log(sword.itemName);
        }
        
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }
    
    private void OnInputFieldEndEdit(string text)
    {
        foreach (var sword in ScrobDatabase.swords)
        {
            if (sword.itemName == text)
            {
                Debug.Log("Found sword: " + sword.itemName + " with damage: " + sword.damage + " and attack speed: " + sword.attackSpeed);
                return;
            }
        }
    }
}
