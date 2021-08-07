using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MyMesh : MonoBehaviour
{
    private MeshFilter meshFilter;

    private Mesh ourMesh;

    public List<Transform> Vertices = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        CreateMesh();
    }

    void CreateMesh()
    {
        ourMesh = new Mesh();

        Vector3[] vertices = new Vector3[Vertices.Count];

        int i = 0;
        foreach(Transform transform in Vertices)
        {
            vertices[i] = Vertices[i].position;
            i++;
        }

        Vector3[] normals = new Vector3[Vertices.Count];
        i = 0;
        foreach (Transform transform in Vertices)
        {
            normals[i] = Vertices[i].up;
            i++;
        }

        // Clock wise winding order
        int[] triangles = new int[]
        {
            0, 1, 2,
            2, 1, 3
        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(1.0f, 0.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f)
        };

        ourMesh.vertices = vertices;
        ourMesh.normals = normals;
        ourMesh.triangles = triangles;
        ourMesh.uv = uvs;

        meshFilter.mesh = ourMesh;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        for (int i = 0; i < meshFilter.sharedMesh.vertexCount; i++)
        {
            Vector3 point1 = transform.localToWorldMatrix * meshFilter.sharedMesh.vertices[i];
            Vector3 normal1 = transform.localToWorldMatrix * meshFilter.sharedMesh.normals[i];
            Gizmos.DrawLine(transform.position + point1, transform.position + point1 + normal1 * 2.0f);
        }
    }
}
