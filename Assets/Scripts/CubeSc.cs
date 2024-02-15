using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSc : MonoBehaviour
{
    
    void Start()
    {
        Mesh mesh = new Mesh();

        // Define the vertices of the cube
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0), // Front bottom left
            new Vector3(0, 1, 0), // Front top left
            new Vector3(1, 1, 0), // Front top right
            new Vector3(1, 0, 0), // Front bottom right
            new Vector3(0, 0, 1), // Back bottom left
            new Vector3(0, 1, 1), // Back top left
            new Vector3(1, 1, 1), // Back top right
            new Vector3(1, 0, 1)  // Back bottom right
        };

        // Define the triangles (indices of vertices) to form the faces of the cube
        int[] triangles = new int[]
        {
            // Front face
            0, 1, 2,
            2, 3, 0,
            // Back face
            4, 6, 5,
            4, 7, 6,
            // Left face
            4, 5, 1,
            4, 1, 0,
            // Right face
            3, 2, 6,
            3, 6, 7,
            // Top face
            1, 5, 6,
            1, 6, 2,
            // Bottom face
            4, 0, 3,
            4, 3, 7
        };

        // Assign the vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Automatically calculate normals to ensure proper lighting
        mesh.RecalculateNormals();

        // Add a MeshFilter component to the cube game object
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    void Update()
    {
        
    }
}
