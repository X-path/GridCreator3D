using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellController : MonoBehaviour
{
    public GameObject textObject;
    bool isDown = false;
    private void OnMouseDown()
    {
        if (isDown)
            return;

        Debug.Log("OnMouseDown");
        isDown = true;
        textObject.SetActive(true);
    }

}
