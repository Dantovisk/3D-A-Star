using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveCoordinates : MonoBehaviour
{
    public PathFinding pathFinding; // Referência ao script de pathfinding
    public Transform seeker; // Referência ao seeker
    public Transform target; // Referência ao target
    public string fileName = "coordinates.txt"; // Nome do arquivo para salvar as coordenadas

    private void Update()
    {
        // Verifica se a tecla espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
        }
    }

    void SaveData()
    {
        // Caminho do arquivo
        string path = Application.persistentDataPath + "/" + fileName;

        // Cria ou abre o arquivo
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            // Salva as coordenadas do seeker e do target (coordenadas do mundo)
            writer.WriteLine("Seeker Position: " + seeker.position);
            writer.WriteLine("Target Position: " + target.position);

            // Salva as coordenadas da lista de path
            writer.WriteLine("Path:");
            if (pathFinding.usedGrid.path != null)
            {
                foreach (Node node in pathFinding.usedGrid.path)
                {
                    writer.WriteLine(node.worldPosition); // Escreve a posição de cada nó do caminho
                }
            }
            else
            {
                writer.WriteLine("No path found");
            }
        }

        Debug.Log("Dados salvos em: " + path);
    }
}
