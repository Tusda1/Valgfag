using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Sword")]
public class Sword : BaseScriptableObject
{
    public string itemName;
    public int damage;
    public float attackSpeed;
}
