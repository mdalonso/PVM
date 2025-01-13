using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorExample : MonoBehaviour
{
    //Se definen las dimensiones del terreno en los 3 ejes: ancho, largo y alto (altura m�xima).
    public int width = 1024;
    public int height = 1024;
    public float maxHeight = 50f;

    //En la generaci�n del terreno utilizaremos una t�cnica con RUIDO PERLIN.
    //Este tipo de ruido es una t�cnica matem�tica que genera un ruido en los valores generados
    //destinado a evitar cambios bruscos entre valores cercanos.
    //Esta t�cnica requiere definir un factor de escala.
    //A mayor escala, m�s detallado y denso ser� el terreno.
    public float scale = 5f; // Escala de ruido Perlin (para suavizar el terreno)
    //Aunque la t�cnica de ruido Perlin parece que genera valores aleatorios,
    //esto no es as� sino que genera un patr�n.
    //Los valores de offset sirven para desplazar el ruido y que el patr�n que se genera no sea siempre el mismo.
    public float offsetX = 10f; // Desplazamiento en X para variar el terreno
    public float offsetY = 10f; // Desplazamiento en Y para variar el terreno

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainData();
    }

    TerrainData GenerateTerrainData()
    {
        TerrainData terrainData = new TerrainData();
        //Se define la resolucic�n del mapa de alturas.
        terrainData.heightmapResolution = width+1;
        //Se establecen las dimensiones del terreno
        terrainData.size = new Vector3(width, maxHeight, height);
        //Se crea la matriz de alturas.
        float[,] heights = new float[width, height];
        //Se recorre la matriz para genera una altura aleatoria en cada punto.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //heights[x, y] = Random.Range(0, maxHeight);
                heights[x, y] = CalculateHeight(x, y);//Con Perlin noise

            }
        }
        //Se asigna la matriz de alturas al mapa de alturas
        terrainData.SetHeights(0, 0, heights);
        return terrainData;
    }

    float CalculateHeight(int x, int y)
    {

        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
