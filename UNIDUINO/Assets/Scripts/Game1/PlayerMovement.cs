using UnityEngine;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    SerialPort sp = new SerialPort("COM3", 9600);  //Receiving the input data from arduino

    void Start()
    {
        sp.Open(); //Opens the serial port
        sp.ReadTimeout = 1; //Readtimeout should be kept low
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (sp.IsOpen)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
                if (rb.position.y < -1f)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
            try
            {
                if (sp.ReadByte() == 1)
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    Debug.Log("Left");
                }

                if (sp.ReadByte() == 2)
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    Debug.Log("Right");
                }
               
            }
            catch (System.Exception)
            { }
        }
    }
}

