using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Npc npc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!string.IsNullOrEmpty(npc.npcName))
        {
            gameObject.name = npc.npcName; 
        }
        
        if (npc.npcSprite != null)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = npc.npcSprite;
            }
        }
    }
}
