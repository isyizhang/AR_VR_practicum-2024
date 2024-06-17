using UnityEngine;
public class Item
{
    public string itemName;
    public float[] attributes;

    public Item(string itemName, float[] attributes)
    {
        this.itemName = itemName;
        this.attributes = attributes;
    }

    public float[] GetAttributes()
    {
        return attributes;
    }
}