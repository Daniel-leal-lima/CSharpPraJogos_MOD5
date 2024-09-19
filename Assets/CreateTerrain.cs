using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;

    [SerializeField] int terrainSize;
    void Start()
    {
        GenerateTerrain();
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
                    Instantiate(cubePrefab, new Vector3(line, height, column), Quaternion.identity);
                }
            }

        }
    }

    bool IsFirstOrLast(int i, int lenght)
    {
        return (i == 0 || i == lenght - 1);
    }
}
