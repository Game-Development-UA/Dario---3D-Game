using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject toFollow;
    private Vector3 currOffset;
    private Vector3 defaultCameraPosition;
    private Camera mCamera;
    public string camDirection;
    public float zOffset;
    public float yOffset;
    public float limitTangent;
    public float cameraSpeed;
    public bool viewMode;
    // Start is called before the first frame update
    void Start()
    {
        camDirection = "Forward";
        viewMode = false;
        mCamera = Camera.main;
       currOffset = new Vector3(0f, yOffset, zOffset);
        defaultCameraPosition = new Vector3(0f, yOffset, zOffset);
        mCamera.transform.position = toFollow.transform.position - currOffset;
        print("start position: " + this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!viewMode)
        {
            if (Input.GetKey(KeyCode.R))
            {
                currOffset = defaultCameraPosition;
                camDirection = "Forward";

            }
            else if (Input.GetKey(KeyCode.V))
            {
                UpdateViewMode();
            }
            //print(viewMode);
            else if (Input.GetKey(KeyCode.A))
            {

                // this.transform.position = toFollow.transform.position - new Vector3(currOffset.z, currOffset.y, 0f);
                currOffset = new Vector3(zOffset, yOffset, 0f);
                camDirection = "Right";

            }
            else if (Input.GetKey(KeyCode.D))
            {

                // this.transform.position = toFollow.transform.position - new Vector3(currOffset.z, currOffset.y, 0f);
                currOffset = new Vector3(-zOffset, yOffset, 0f);
                camDirection = "Left";

            }
            else if (Input.GetKey(KeyCode.W))
            {

                // this.transform.position = toFollow.transform.position - new Vector3(currOffset.z, currOffset.y, 0f);
                currOffset = new Vector3(0f, yOffset, -zOffset);
                camDirection = "Back";

            }
        }

        else
        {
            //  if (viewMode)
            // {
            if (camDirection == "Forward") {
                CheckPlayerInput();
                this.transform.position = toFollow.transform.position - currOffset;
            }
            if (Input.GetKey(KeyCode.V))
            {
                UpdateViewMode();
            }

            //  }
            // else
            //  {
            // this.transform.position = toFollow.transform.position - currOffset;  
            //this.transform.position = toFollow.transform.position - currOffset;

            // }
        }
        this.transform.position = toFollow.transform.position - currOffset;
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
        Vector3 zMotion = new Vector3(F.x, 0f, F.z);
        F.Normalize();
        if (Input.GetKey(KeyCode.S))
        {
            if (this.transform.position.y > toFollow.transform.position.y)
            {
                //this.transform.Translate(new Vector3(0f, -cameraSpeed * Time.deltaTime, 0f));
                currOffset = new Vector3(currOffset.x, currOffset.y + (cameraSpeed * Time.deltaTime), currOffset.z);
                print(currOffset.y);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            print(F.y / F.z);
            if (Mathf.Abs(F.y / F.z) < limitTangent)
            {
                //this.transform.Translate(new Vector3(0f, cameraSpeed * Time.deltaTime, 0f));
                currOffset = new Vector3(currOffset.x, currOffset.y - (cameraSpeed * Time.deltaTime), currOffset.z);
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.Translate(new Vector3(cameraSpeed * Time.deltaTime, 0f,0f));
            currOffset = new Vector3(currOffset.x - (cameraSpeed * Time.deltaTime), currOffset.y, currOffset.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //this.transform.Translate(new Vector3(-cameraSpeed * Time.deltaTime, 0f, 0f));
            currOffset = new Vector3(currOffset.x + (cameraSpeed * Time.deltaTime), currOffset.y, currOffset.z);
        }

        if (Input.GetKey(KeyCode.I)) {
           
            currOffset = new Vector3(currOffset.x - (F.x * cameraSpeed * Time.deltaTime),currOffset.y - (F.y * cameraSpeed * Time.deltaTime), currOffset.z - (F.z * cameraSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.O))
        {
            currOffset = new Vector3(currOffset.x + (F.x * cameraSpeed * Time.deltaTime), currOffset.y + (F.y * cameraSpeed * Time.deltaTime), currOffset.z + (F.z * cameraSpeed * Time.deltaTime));
        }
       
    }

public void UpdateViewMode() {
    if (viewMode == false) {
        viewMode = true;
    }
    else {
        viewMode = false;
    }
}

}
