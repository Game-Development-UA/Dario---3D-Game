using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMovingPath : MonoBehaviour
{
    public GameObject player;
    private Vector3[] vertices;
    private int[] triangles;
    private bool pathJumpStarted;

    // Start is called before the first frame update
    void Start()
    {
        //pathStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pathJumpStarted)
        {
            if (player.GetComponent<Jump>().jumpPowerUp)
            {
                pathJumpStarted = true;
                //buildPath();

            }
        }
    }

    public void buildPath(int numSquares, Vector3 startVertex, int edgeLength) {
        int numVertices = (numSquares - 1) * 2 + 4;
        bool compVertex = false;
        int numTriangles = 2 * numSquares;
        int numVertex = 0;
        vertices[0] = startVertex;
        int i;
        for (i = 1; i < numVertices/2; i++) {

            vertices[i] = new Vector3(startVertex.x, startVertex.y, startVertex.z - numVertex * edgeLength);
            vertices[i] = new Vector3(startVertex.x - edgeLength, startVertex.y, startVertex.z - numVertex * edgeLength);
           

        }
        for (i = 0; i < numTriangles; i++) {
            triangles[i] = i;
            triangles[i + 1] = i + 2;
            triangles[i + 2] = i + 1;
        }
    }
}
