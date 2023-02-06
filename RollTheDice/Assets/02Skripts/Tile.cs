using UnityEngine;

public class Tile : MonoBehaviour
{
    public int index;

    public virtual void OnHere()
    {
        Debug.Log($"Tile : {index} ¹øÂ° Ä­ µµÂø!");
    }
}
