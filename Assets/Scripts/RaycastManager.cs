using System;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private bool isPointerDown = false;
    private bool isPointerHeld = false;

    private HashSet<Interactable> pointerDownedObjects = new HashSet<Interactable>();

    private Vector2 initPointerDownPosition;
    private Vector2 prevPointerHeldPosition;

    private void Update()
    {
        Vector2 interactionPosition = Vector2.negativeInfinity;

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
        // If mouse left button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            isPointerDown = true;
            interactionPosition = Input.mousePosition;
            initPointerDownPosition = Input.mousePosition;
            prevPointerHeldPosition = Input.mousePosition;
        }
        // If mouse left button is held
        if (Input.GetMouseButton(0))
        {
            isPointerHeld = true;
            interactionPosition = Input.mousePosition;
        }
        // If mouse left button is released
        if (Input.GetMouseButtonUp(0))
        {
            isPointerDown = false;
            isPointerHeld = false;
            interactionPosition = Input.mousePosition;
        }
#endif

#if UNITY_IOS || UNITY_ANDROID
	        if(Input.touchCount == 1)
	        {
	        	switch(Input.GetTouch(0).phase)
	        	{
	        		case TouchPhase.Began:
		            	isPointerDown = true;
		                interactionPosition = Input.GetTouch(0).position;
		                initPointerDownPosition = Input.GetTouch(0).position;
		                prevPointerHeldPosition = Input.GetTouch(0).position;
		            	break;
		            case TouchPhase.Moved:
		            	isPointerHeld = true;
	        			interactionPosition = Input.GetTouch(0).position;
	        			break;
		            case TouchPhase.Ended:
		            	isPointerDown = false;
	        			isPointerHeld = false;
	        			interactionPosition = Input.GetTouch(0).position;
	        			break;
	        	}
	        }
#endif

        if (!IsVector2NegativeInfinity(interactionPosition))
        {
            PointerActionByRayCast(interactionPosition);
        }
    }

    private void PointerActionByRayCast(Vector2 position)
    {
        // If raycast hits something
        if (Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(position), out RaycastHit hit, 5.0f))
        {
            if (hit.transform != null)
            {
                // Check if it's an Eikonal Interactable
                var component = hit.transform.gameObject.GetComponent<Interactable>();
                if (component != null)
                {
                    if (isPointerDown && position == initPointerDownPosition)
                    {
                        component.OnPointerDown();
                        pointerDownedObjects.Add(component);
                    }
                    if (!isPointerDown)
                    {
                        component.OnPointerUp(true);
                        pointerDownedObjects.Remove(component);
                    }
                }
            }
        }
        // If raycast hits nothing
        if (!isPointerDown)
        {
            // Call point up outside for all interactable that was held down before
            foreach (Interactable i in pointerDownedObjects)
            {
                i.OnPointerUp(false);
            }
            pointerDownedObjects = new HashSet<Interactable>();
        }
        // If pointer moves while down
        if (isPointerHeld)
        {
            // Call pointer dragged for all interactable that was held down before
            foreach (Interactable i in pointerDownedObjects)
            {
                i.OnPointerDragged(prevPointerHeldPosition, position);
            }
            prevPointerHeldPosition = position;
        }
    }

    private bool IsVector2NegativeInfinity(Vector2 v)
    {
        return float.IsNegativeInfinity(v.x) && float.IsNegativeInfinity(v.y);
    }
}

