using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTriangle : MonoBehaviour
{
    public Vector3[] vert = {   
                                new Vector3(0f, 0f, 0f),
                                new Vector3(1f, 0f, 0f),
                                new Vector3(0f, 1f, 0f)};
    public int[] tris = {
                                0, 2, 1
    };
    public Vector3[] normals = {
                                new Vector3(0f, 0f, -1f),
                                new Vector3(0f, 0f, -1f),
                                new Vector3(0f, 0f, -1f),
    };
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tris;
        mesh.normals = normals;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        
    }
}
