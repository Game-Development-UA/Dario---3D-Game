using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject toFollow;
    private Camera mCamera;
    public float zOffset;
    public float yOffset;
    public float limitTangent;
    // Start is called before the first frame update
    void Start()
    {
        mCamera = Camera.main;
        Vector3 off = new Vector3(0f, yOffset, zOffset);
        mCamera.transform.position = toFollow.transform.position - off;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();
        UpdateCameraSpace(GetLookAtMatrix(this.transform.position, toFollow.transform.position, Vector3.up));
    }

    public Matrix4x4 GetLookAtMatrix(Vector3 eye, Vector3 target, Vector3 up)
    {
        Matrix4x4 matrix = Matrix4x4.identity;

        ///////////////// put your code here ///////////////// 
        // To change the members of a matrix, you can use 
        // SetColumn(int index, Vector4 column)
        // SetRow(int index, Vector4 row)
        // or [int,int] to reach single member


        Vector3 F = target - eye;
        F.Normalize();
        Vector4 F4 = new Vector4(F.x, F.y, F.z, 0);


        Vector3 L = Vector3.Cross(up, F);
        L.Normalize();
        Vector4 L4 = new Vector4(L.x, L.y, L.z, 0);

        Vector3 U = Vector3.Cross(F, L);
        U.Normalize();
        Vector4 U4 = new Vector4(U.x, U.y, U.z, 0);

        Vector4 E4 = new Vector4(eye.x, eye.y, eye.z, 1);

        matrix.SetColumn(0, L4);
        matrix.SetColumn(1, U4);
        matrix.SetColumn(2, F4);
        matrix.SetColumn(3, E4);


        //////////////////////////////////////////////////////

        return matrix;
    }

    public void UpdateCameraSpace(Matrix4x4 matrix)
    {
        mCamera.transform.position = matrix.MultiplyPoint3x4(Vector3.zero);
        mCamera.transform.rotation = matrix.rotation;
    }

    public void CheckPlayerInput() {
        Vector3 F = toFollow.transform.position - this.transform.position;
        F.Normalize();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (this.transform.position.y > toFollow.transform.position.y)
            {
                this.transform.Translate(new Vector3(0f, -2f * Time.deltaTime, 0f));
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            print(F.y / F.z);
            if (Mathf.Abs(F.y / F.z) < limitTangent)
            {
                this.transform.Translate(new Vector3(0f, 2f * Time.deltaTime, 0f));
            }
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(0f, 2f * Time.deltaTime, 0f));        
        }
    }

}
