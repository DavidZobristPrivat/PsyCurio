using UnityEngine;

// Could be stored as json for local or server side saving

[System.Serializable]
public class ItemData
{
   public string name = "";
   public int price = 1;
  [HideInInspector] public Color color = Color.black; // Since i have no images, I just set material colors. In a real situation here would be a sprite reference.
}
