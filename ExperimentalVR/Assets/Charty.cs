using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO;
using ArduinoConnect;
//using Random = UnityEngine.Random;

public class Charty : MonoBehaviour
{  
    private Queue myQueuea = new Queue();
    private Queue myQueuex = new Queue();
    private Queue myQueuey = new Queue();
    public int hertz = 50;
    public float voltage;
    public GameObject thing;  
    public Texture2D texture;
    int x = 0;
    int zz = 0;
    void Start()
    {
        Debug.Log(texture.height);
        
        
    }

    void Update()
    {
        
        int y = texture.height;
        //get Voltage
        //Voltage = Arduino[0];
        voltage = Random.Range(-1f,1f);
        //get time
        
        
        //use time and voltage to find relevant pixel
        y = (Mathf.RoundToInt(voltage * y/2)+ y/2);
        Color a = texture.GetPixel(x, y);
        
         //save it to queue 
        myQueuea.Enqueue(a);
        myQueuex.Enqueue(x);
        myQueuey.Enqueue(y);
        //Debug.Log("still running "+ x +" "+  y);
        //change it to black SetPixel
        
        texture.SetPixel(x,y,Color.black);
       
        
        
        x = x+1;
        if (x == texture.width)
        {
            x = 0;
            zz++;
        }

        //poplast element of queue
        if (zz >= 1)
        {
            Color a1 = (Color) myQueuea.Dequeue();
            int x1 = (int) myQueuex.Dequeue();
            int y1 = (int) myQueuey.Dequeue();
            texture.SetPixel(x1,y1,a1);
        }
        texture.Apply();
    }
}