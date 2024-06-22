using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class DesignerModeImageController : MonoBehaviour
{
    public Image itemImage; // UI Image to display the item image
    private int currentIndex = 0;
    public Image itemScreenImage;

    void DisplayItem(Item item)
    {
        Sprite itemSprite = Resources.Load<Sprite>(item.itemName);
        if (itemSprite != null)
        {
            itemImage.sprite = itemSprite;
            itemScreenImage.sprite = itemSprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + item.itemName);
        }
    }

    public void ShowNextFoodImage()
    {
        if (FoodItemDatabase.foodItems != null && FoodItemDatabase.foodItems.Count > 0)
        {
            currentIndex = (currentIndex + 1) % FoodItemDatabase.foodItems.Count;
            DisplayItem(FoodItemDatabase.foodItems[currentIndex]);
            Debug.Log("ShowNextFoodItem is called " + currentIndex);
        }
    }

    public void ShowPreviousFoodImage()
    {
        if (FoodItemDatabase.foodItems != null && FoodItemDatabase.foodItems.Count > 0)
        {
            currentIndex = (currentIndex - 1 + FoodItemDatabase.foodItems.Count) % FoodItemDatabase.foodItems.Count;
            DisplayItem(FoodItemDatabase.foodItems[currentIndex]);
            Debug.Log("ShowPreviousFoodItem is called " + currentIndex);
        }
}
}
