using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    float planeSize = 5.0f; //Area Size
    public int nValue = 3;
    public GameObject gridCellPrefab; // Grid prefab
    public float cellSize = 1.0f; // Cell Size
    public GameObject plane; // Plane
    List<GameObject> gridPrefabs = new List<GameObject>();

    public TMP_InputField inputField; // Input Field
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        GridListClear();

        if (!string.IsNullOrEmpty(inputField.text))
            nValue = int.Parse(inputField.text);

        float cellSize = planeSize / (float)nValue;

        for (int x = 0; x < nValue; x++)
        {
            for (int y = 0; y < nValue; y++)
            {

                GameObject gridCell = Instantiate(gridCellPrefab) as GameObject;
                gridCell.transform.parent = this.transform;
                gridCell.transform.localPosition =new Vector3((x * cellSize) - (cellSize * (nValue - 1) * 0.5f), (y * cellSize) - (cellSize * (nValue - 1) * 0.5f), 0f); 
                Vector3 newScale = gridCell.transform.localScale;
                newScale.x = cellSize;
                newScale.y = cellSize;
                gridCell.transform.localScale =  new Vector3(cellSize, cellSize, cellSize);

                gridPrefabs.Add(gridCell);
            }
        }

    }
    void GridListClear()
    {
        for (int i = gridPrefabs.Count - 1; i >= 0; i--)
        {
            GameObject _go = gridPrefabs[i];
            gridPrefabs.RemoveAt(i);
            Destroy(_go);
        }

    }
}
