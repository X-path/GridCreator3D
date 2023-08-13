using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellController : MonoBehaviour
{
    [Header("Values")]
    public GameObject textObject;
    [HideInInspector] public bool isDown = false;
    public int cellNumber = 0;
    private void OnMouseDown()
    {
        if (isDown)
            return;

        isDown = true;
        textObject.SetActive(true);
        MatchController.instance.MatchCheck(this.gameObject);
    }

    public void CellReset()
    {
        isDown = false;
        textObject.SetActive(false);
    }

}
