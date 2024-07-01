using UnityEngine;
using UnityEngine.UI;

public class SplitImage : MonoBehaviour
{
    public Image originalImage;

    void Start()
    {
        if (originalImage != null)
        {
            RectTransform originalRect = originalImage.GetComponent<RectTransform>();

            // Create left half image GameObject
            GameObject leftImageObject = new GameObject("LeftImage");
            leftImageObject.transform.SetParent(originalImage.transform.parent);
            leftImageObject.transform.SetSiblingIndex(originalImage.transform.GetSiblingIndex() + 1);

            // Add Image component to the new GameObject
            Image leftImage = leftImageObject.AddComponent<Image>();
            leftImage.sprite = originalImage.sprite;

            // Adjust RectTransform of the left image
            RectTransform leftRectTransform = leftImage.GetComponent<RectTransform>();
            leftRectTransform.anchorMin = originalRect.anchorMin;
            leftRectTransform.anchorMax = originalRect.anchorMax;
            leftRectTransform.pivot = originalRect.pivot;
            leftRectTransform.sizeDelta = new Vector2(originalRect.rect.width / 2, originalRect.rect.height);
            leftRectTransform.anchoredPosition = originalRect.anchoredPosition + new Vector2(-originalRect.rect.width / 4, 0);

            // Set the UV Rect for the left image to display only the left half
            Material leftMaterial = new Material(Shader.Find("UI/Default"));
            leftMaterial.mainTexture = originalImage.sprite.texture;
            leftMaterial.mainTextureScale = new Vector2(0.5f, 1);
            leftMaterial.mainTextureOffset = new Vector2(0, 0);
            leftImage.material = leftMaterial;
        }
    }
}
