using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    public GameObject arrowGameObject;

    public GameObject ModelTarget;

    public void ShowArrowAt(float x, float y, float z)
    {
        var arrow = Resources.Load<GameObject>("Arrow");
        arrowGameObject = Instantiate(arrow, new Vector3(x, y, z), Quaternion.identity);
        arrowGameObject.transform.SetParent(ModelTarget.transform);
    }
}
