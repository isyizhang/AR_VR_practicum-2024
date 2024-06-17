using System.Collections.Generic;
using UnityEngine;

// public class FoodItemDatabase : MonoBehaviour
// {
//     public List<Item> foodItems;

//     void Awake()
//     {
//         foodItems = new List<Item>
//         {
//             new Item("chocolate", new float[] { 0.9f, 0.2f, 0.5f }),
//             new Item("frenchFried", new float[] { 0.7f, 0.9f, 0.2f }),
//             new Item("popcorn", new float[] { 0.5f, 0.5f, 0.9f })
//         };
//     }
// }

public static class FoodItemDatabase
{
    public static List<Item> foodItems = new List<Item>
    {
        new Item("chocolate", new float[] { 0.9f, 0.2f, 0.5f }),
        new Item("frenchFries", new float[] { 0.7f, 0.9f, 0.2f }),
        new Item("popcorn", new float[] { 0.5f, 0.5f, 0.9f })
    };
}

