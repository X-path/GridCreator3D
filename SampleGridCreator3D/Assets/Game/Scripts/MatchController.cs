using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchController : MonoBehaviour
{
    public static MatchController instance = null;

    [Header("Values")]
    List<GameObject> selectedGridCells = new List<GameObject>();
    int matchCounter = 0;
    [HideInInspector]public int gridGeneratorNValue = 0;
    bool isMatch = false;
    [SerializeField]bool isCellCrossControl = false;
    bool isDifferencesEqual = false;

    [Header("UI")]
    [SerializeField] TMP_Text matchCounterText;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public void MatchCheck(GameObject _cell)
    {
        if (isMatch)
        {
            CellsResetAll();
            isMatch = false;
        }

        selectedGridCells.Add(_cell);

        if (selectedGridCells.Count != 3)
            return;


        CellsNumberControl();


        if (isDifferencesEqual)
        {
            isMatch = true;
            matchCounter++;
            matchCounterText.text = "MatchCount:" + matchCounter.ToString();
        }
        else
        {
            CellsResetAll();
        }

    }
    void CellsNumberControl()
    {
        List<int> cellNumbers = new List<int>();
        for (int i = 0; i < selectedGridCells.Count; i++)
        {
            cellNumbers.Add(selectedGridCells[i].GetComponent<CellController>().cellNumber);
        }

        cellNumbers.Sort();

        if (isCellCrossControl)
        {
            isDifferencesEqual = cellNumbers[1] - cellNumbers[0] == cellNumbers[2] - cellNumbers[1];
        }
        else
        {
            int difference1 = cellNumbers[1] - cellNumbers[0];
            int difference2 = cellNumbers[2] - cellNumbers[1];

            if (difference1 == 1 && difference2 == 1 || difference1 == gridGeneratorNValue && difference2 == gridGeneratorNValue)
            {
                isDifferencesEqual = true;
            }


        }
    }
    void CellsResetAll()
    {
        for (int i = 0; i < selectedGridCells.Count; i++)
        {
            if (selectedGridCells[i] != null)
                selectedGridCells[i].GetComponent<CellController>().CellReset();
        }

        selectedGridCells.Clear();
        isDifferencesEqual = false;
    }
}
