using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Plat : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float zSpeed;
    public float horizRange;
    public float verticalRange;
    public float zRange;

    private Vector3 move;
    private Vector3 startPosition;
    private Vector3 finalPosition;

    private bool towardsFinal;
    private float timeVal;
    // Start is called before the first frame update
    void Start()
    {
        timeVal = 0.5f;
        towardsFinal = true;
        move = new Vector3(horizontalSpeed, verticalSpeed, zSpeed);
        startPosition = this.transform.position - new Vector3(horizRange, verticalRange, zRange);
        finalPosition = this.transform.position + new Vector3(horizRange, verticalRange, zRange);
    }

    // Update is called once per frame
    void Update()
    {
        Interpolate();
        timeVal += (Time.deltaTime / 10f) * move.magnitude;
    }

    public void Interpolate()
    {

        float f = (Mathf.Pow(timeVal, 2) * (3f - (2f * timeVal)));
        if (towardsFinal)
        {
            if (timeVal <= 1f)
            {
                this.transform.position = (1 - f) * startPosition + f * finalPosition;
            }
            else
            {
                towardsFinal = false;
                timeVal = 0f;
            }
        }
        else
        {
            if (timeVal <= 1f)
            {
                this.transform.position = (1 - f) * finalPosition + f * startPosition;
            }
            else
            {
                towardsFinal = true;
                timeVal = 0f;
            }
        }


    }
}
