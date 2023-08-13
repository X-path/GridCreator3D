using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [Header("Values")]
    public int nValue = 3;
    float cellSize = 1.0f; 
    float planeSize = 5.0f; 
    public GameObject cellPrefab; 
    List<GameObject> cellPrefabs = new List<GameObject>();


    [Header("UI")]
    public TMP_InputField inputField; // Input Field

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        GridListClear();

        if (!string.IsNullOrEmpty(inputField.text))
            nValue = int.Parse(inputField.text);

        if (nValue < 3)
            return;

        MatchController.instance.gridGeneratorNValue = nValue;    

        float cellSize = planeSize / (float)nValue;

        for (int x = 0; x < nValue; x++)
        {
            for (int y = 0; y < nValue; y++)
            {

                GameObject gridCell = Instantiate(cellPrefab) as GameObject;
                gridCell.transform.parent = this.transform;
                gridCell.transform.localPosition = new Vector3((x * cellSize) - (cellSize * (nValue - 1) * 0.5f), (y * cellSize) - (cellSize * (nValue - 1) * 0.5f), 0f);
                gridCell.transform.localScale = new Vector3(cellSize, cellSize, cellSize);

                cellPrefabs.Add(gridCell);
                gridCell.transform.GetComponent<CellController>().cellNumber += cellPrefabs.Count;
            }
        }

    }
    void GridListClear()
    {
        for (int i = cellPrefabs.Count - 1; i >= 0; i--)
        {
            GameObject _go = cellPrefabs[i];
            cellPrefabs.RemoveAt(i);
            Destroy(_go);
        }

    }
}
