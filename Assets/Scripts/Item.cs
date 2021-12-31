using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string Name {private set;get;} = "Name";
    public int maxStackSize {private set;get;} = 5;
    public abstract void Use();
}