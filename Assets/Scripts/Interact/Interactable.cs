using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Sprite baseSprite;
    public Sprite hoverSprite;

    public virtual void Use()
    {
        Debug.Log("Interactable Clicked");
    }
}
