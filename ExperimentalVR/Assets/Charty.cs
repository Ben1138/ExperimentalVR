using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO;
using System.Runtime.CompilerServices;
using ArduinoConnect;

public class Charty : MonoBehaviour
{  
    private Queue myQueuea = new Queue();
    private Queue myQueuex = new Queue();
    private Queue myQueuey = new Queue();
    //public int hertz = 50;
    public float voltage;
    //public GameObject thing;
    //public Texture2D farbe;
    public Texture2D texture;
    int x = 0;
    int zz = 0;
    
    bool copy = false;
    
    void Start()
    {
      
       // IsCopy();
        
    }

  /* void IsCopy()
    {
        if (copy == false)
        {
            texture = new Texture2D(farbe.width,farbe.height,TextureFormat.ARGB32,false);
            for (int i = 0; i < farbe.width; i++)
            {
                for (int j = 0; j < farbe.height; j++)
                {
                  Color colorcopy=  farbe.GetPixel(i, j);
                  texture.SetPixel(i,j,colorcopy);
                }
            }
            
            texture.Apply();
            
        }
        
        copy = true;

    }*/
    void Update()
    {
        int y = texture.height;
        //get Voltage
        //Voltage = Arduino[0];
        //voltage = Random.Range(-1f,1f);
        voltage = 0.5f;
        //get time
        
        
        //use time and voltage to find relevant pixel
        y = (Mathf.RoundToInt(voltage * y/2)+ y/2);
        Color a = texture.GetPixel(x, y);
        
         //save it to queue 
        myQueuea.Enqueue(a);
        myQueuex.Enqueue(x);
        myQueuey.Enqueue(y);
        Debug.Log("still running "+ x +" "+  y);
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
        //thing.GetComponent<RawImage>().texture = Texture2D.Create(texture,new Rect(0,0,farbe.width,y),new Vector2(0.5f,0.5f) );
    }
}