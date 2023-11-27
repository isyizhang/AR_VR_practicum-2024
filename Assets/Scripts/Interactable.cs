using UnityEngine;

public interface Interactable
{
    void OnPointerDown();
    void OnPointerUp(bool isInside);
    void OnPointerDragged(Vector2 oldPointerPosition, Vector2 newPointerPosition);
}
