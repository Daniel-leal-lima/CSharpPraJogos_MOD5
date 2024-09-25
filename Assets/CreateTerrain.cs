using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;

    [SerializeField] int terrainSize;

    List<GameObject> allCubes = new List<GameObject>();
    void Start()
    {
        GenerateTerrain();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DeleteLastLayer();
        }
    }

    void DeleteLastLayer()
    {
        if (allCubes.Count == 0) return;

        float maxHeight = allCubes[allCubes.Count - 1].transform.position.y;

        for (int i = allCubes.Count - 1; i >=0; i--)
        {
            if (allCubes[i].transform.position.y == maxHeight)
            {
                Destroy(allCubes[i]);
                allCubes.Remove(allCubes[i]);
            }
        }
    }

    void GenerateTerrain()
    {
        for (int column = 0; column < terrainSize; column++)
        {
            for (int line = 0; line < terrainSize; line++)
            {
                bool isFirstOrLast = IsFirstOrLast(line,terrainSize) || IsFirstOrLast(column, terrainSize);

                int randomHeight;

                if (isFirstOrLast) randomHeight = 5;
                else randomHeight = Random.Range(1, 4);


                for (int height = 0; height < randomHeight; height++)
                {
                    GameObject cube = Instantiate(cubePrefab, new Vector3(line, height, column), Quaternion.identity);
                    allCubes.Add(cube);
                }
            }

        }
    }

    bool IsFirstOrLast(int i, int lenght)
    {
        return (i == 0 || i == lenght - 1);
    }
}
