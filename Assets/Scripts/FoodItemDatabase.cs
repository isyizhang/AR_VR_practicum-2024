using System.Collections.Generic;
using UnityEngine;

public static class FoodItemDatabase
{
    public static List<Item> foodItems = new List<Item>
    {
        new Item("chocolate", new float[] { 0.9f, 0.2f, 0.4f }),
        new Item("frenchFries", new float[] { 0.1f, 0.7f, 0.9f }),
        new Item("popcorn", new float[] { 0.5f, 0.5f, 0.9f }),
        new Item("apple", new float[] { 0.7f, 0.1f, 0.1f }),
        new Item("banana", new float[] { 0.8f, 0.1f, 0.1f }),
        new Item("cake", new float[] { 0.9f, 0.2f, 0.4f }),
        new Item("lettuce", new float[] { 0.1f, 0.1f, 0f }),
        new Item("milk", new float[] { 0.5f, 0.1f, 0.2f }),
        new Item("iceCream", new float[] { 1f, 0f, 0.4f }),
    };
}

