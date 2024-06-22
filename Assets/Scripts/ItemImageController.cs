using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemImageController : MonoBehaviour
{
    public UserInput userInput;
    public Image itemImage; // UI Image to display the item image
    private List<Item> rankedItems;
    private int currentIndex = 0;
    public PolarizingFilm film21;
    public PolarizingFilm film22;
    public PolarizingFilm film23;

    void Start()
    {
    }

    void Update()
    {
    }

    public void RecommendItem()
    {
        float[] userInterests = userInput.GetUserInterests();
        Debug.Log("user input" + userInterests[0]);
        rankedItems = FoodItemDatabase.foodItems.OrderByDescending(item => CalculateDotProduct(userInterests, item.GetAttributes())).ToList();
        currentIndex = 0;
        Debug.Log("db " + FoodItemDatabase.foodItems[0].itemName);
        Debug.Log("ranked items + " + rankedItems[0].itemName);

        if (rankedItems.Count > 0)
        {
            DisplayItem(rankedItems[currentIndex]);
            SetItemVector(rankedItems[currentIndex]);
        }
        Debug.Log("RecommendItem is called" + currentIndex);

    }

    float CalculateDotProduct(float[] vector1, float[] vector2)
    {
        float dotProduct = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            dotProduct += vector1[i] * vector2[i];
        }
        return dotProduct;
    }

    void DisplayItem(Item item)
    {
        Sprite itemSprite = Resources.Load<Sprite>(item.itemName);
        if (itemSprite != null)
        {
            itemImage.sprite = itemSprite;
        }
        else
        {
            // Log an error if the sprite failed to load
            Debug.LogError("Failed to load sprite: " + item.itemName);
        }
    }

    void SetItemVector(Item item)
    {
        float[] itemVector = item.GetAttributes();
        film21.Value = itemVector[0];
        film21.SetValue(itemVector[0]);
        film22.Value = itemVector[1];
        film22.SetValue(itemVector[1]);
        film23.Value = itemVector[2];
        film23.SetValue(itemVector[2]);
    }

        public void ShowNextItem()
    {
        if (rankedItems != null && rankedItems.Count > 0)
        {
            if (currentIndex < rankedItems.Count - 1)
            {
                currentIndex++;
                DisplayItem(rankedItems[currentIndex]);
                SetItemVector(rankedItems[currentIndex]);
                Debug.Log("NextItem is called " + currentIndex);
            }
            else
            {
                Debug.Log("Already at the last item, can't go to next.");
            }
        }
        Debug.Log("NextItem is called " + currentIndex);
    }

    public void ShowPreviousItem()
    {
        if (rankedItems != null && rankedItems.Count > 0)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayItem(rankedItems[currentIndex]);
                SetItemVector(rankedItems[currentIndex]);
                Debug.Log("PrevItem is called " + currentIndex);
            }
            else
            {
                Debug.Log("Already at the first item, can't go to previous.");
            }
        }
        Debug.Log("PrevItem is called " + currentIndex);
    }

    // public void ShowNextFoodImage()
    // {
    //     if (FoodItemDatabase.foodItems != null && FoodItemDatabase.foodItems.Count > 0)
    //     {
    //         currentIndex = (currentIndex + 1) % FoodItemDatabase.foodItems.Count;
    //         DisplayItem(FoodItemDatabase.foodItems[currentIndex]);
    //         SetItemVector(FoodItemDatabase.foodItems[currentIndex]);
    //         Debug.Log("ShowNextFoodItem is called " + currentIndex);
    //     }
    // }

    // public void ShowPreviousFoodImage()
    // {
    //     if (FoodItemDatabase.foodItems != null && FoodItemDatabase.foodItems.Count > 0)
    //     {
    //         currentIndex = (currentIndex - 1 + FoodItemDatabase.foodItems.Count) % FoodItemDatabase.foodItems.Count;
    //         DisplayItem(FoodItemDatabase.foodItems[currentIndex]);
    //         SetItemVector(FoodItemDatabase.foodItems[currentIndex]);
    //         Debug.Log("ShowPreviousFoodItem is called " + currentIndex);
    //     }
    // }
}
