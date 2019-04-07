using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Plat : MonoBehaviour
{
    Mesh mesh;
   
    public int numberSquares;
    public float length;
    public GameObject player;
    public Vector3[] vertices;
        //= new Vector3[(numberSquares - 1) * 2 + 4];
    public int[] triangles; 
        //= new int[numberSquares * 2 * 3];
    private bool pathJumpStarted;
    private bool pathRampStarted;
    private bool compTriangle;
    private bool compVertices;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        pathJumpStarted = false;
        mesh = new Mesh();
        mesh = this.GetComponent<MeshFilter>().mesh;
        vertices = new Vector3[(numberSquares - 1) * 2 + 4];
        triangles = new int[numberSquares* 2 * 3];
    }

    // Update is called once per frame
    void Update()
    {
        if (!pathJumpStarted)
        {
            if (this.gameObject.name == "JumpPath")
            {
                if (player.GetComponent<PlayerInfo>().jumpPowerUp)
                {
                    pathJumpStarted = true;
                    compTriangle = false;
                    compVertices = false;
                    buildPath(numberSquares, this.transform.position, length, new Vector3(0, 0, -1));

                }
            }
        }
        if (!pathRampStarted)
        {
            if (this.gameObject.name == "OptionalRampPath")
            {
                if (player.GetComponent<PlayerInfo>().Collectibles[1])
                {
                    pathRampStarted = true;
                    compTriangle = false;
                    compVertices = false;
                    buildPath(numberSquares, this.transform.position, length, new Vector3(0, 1, -1));

                }

            }
        }


    }

    public void buildPath(int numSquares, Vector3 startVertex, float edgeLength, Vector3 Direction)
    {
        int numVertices = (numSquares - 1) * 2 + 4;
        bool compVertex = false;
        int numTriangles = 2 * numSquares;
        int numTriangleVertex = 0;
        int numVertex = 0;
        int i;
        vertices = new Vector3[numVertices];
        triangles = new int[numTriangles * 3];
        // vertices[0] = startVertex;
        
        
            for (i = 0; i < numVertices; i++)
            {
                print(vertices[i]);
                if (!compVertices)
                {
                    // vertices[i] = new Vector3(startVertex.x, startVertex.y, startVertex.z - numVertex * edgeLength);
                    //vertices[i] = new Vector3(1f, 0f, 0f - numVertex * edgeLength);
                    vertices[i] = new Vector3(1f + Direction.x * numVertex * edgeLength, (Direction.y * numVertex * edgeLength) * Mathf.Sin(25 * Mathf.Deg2Rad), 0f + Direction.z * numVertex * edgeLength);
                    print("work");
                    compVertices = true;
                }
                else
                {
                    // vertices[i] = new Vector3(startVertex.x - edgeLength, startVertex.y, startVertex.z - numVertex * edgeLength);
                    // vertices[i] = new Vector3(1f - edgeLength, 0f, 0f - numVertex * edgeLength);
                    vertices[i] = new Vector3(Mathf.Abs(Direction.z) * (1f + Direction.x * numVertex * edgeLength - edgeLength), (Direction.y * numVertex * edgeLength) * Mathf.Sin(25 * Mathf.Deg2Rad),  0f + Direction.z * numVertex * edgeLength - (Direction.x * edgeLength));
                    compVertices = false;
                    numVertex++;
                }


            }
            for (i = 0; i < numTriangles; i++)
            {
                print(triangles);
                if (!compTriangle)
                {
                    triangles[numTriangleVertex] = i;
                    triangles[numTriangleVertex + 1] = i + 2;
                    triangles[numTriangleVertex + 2] = i + 1;
                    numTriangleVertex += 3;
                    compTriangle = true;
                }
                else
                {
                    triangles[numTriangleVertex] = i;
                    triangles[numTriangleVertex + 1] = i + 1;
                    triangles[numTriangleVertex + 2] = i + 2;
                    numTriangleVertex += 3;
                    compTriangle = false;

                }
            }
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            MeshCollider myMC = this.gameObject.GetComponent<MeshCollider>();
            myMC.sharedMesh = mesh;
            rend = this.gameObject.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Random.ColorHSV());
       }
    
 
}
