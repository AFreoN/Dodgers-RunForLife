using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLegendary : MonoBehaviour
{
    private Text special;
    private int red = 0;
    private int blue = 0;
    private int green = 0;
    private bool increase = true;
	// Use this for initialization
	void Start ()
    {
        special = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        int choose = Random.Range(0, 3);
        if (choose == 0)
        {
            if (increase == true)
            {
                if (red < 256)
                {
                    red++;
                }
                else if (blue < 256)
                {
                    blue++;
                }
                else if (green <= 255)
                {
                    green++;
                }
                else
                {
                    increase = false;
                }
                special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
            }
            else
            {
                if (red >= 0)
                {
                    red--;
                }
                else if (blue >= 0)
                {
                    blue--;
                }
                else if (green >= 0)
                {
                    green--;
                }
                else
                {
                    increase = true;
                }
                special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
            }
        }
        if (choose == 1)
        {
            if (increase == true)
            {
                if (blue < 256)
                {
                    blue++;
                }
                else if (green < 256)
                {
                    green++;
                }
                else if (red <= 255)
                {
                    red++;
                }
                else
                {
                    increase = false;
                }
                special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
            }
            else
            {
                if (blue >= 0)
                {
                    blue--;
                }
                else if (green >= 0)
                {
                    green--;
                }
                else if (red >= 0)
                {
                    red--;
                }
                else
                {
                    increase = true;
                }
                special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
            }
            if (choose == 2)
            {
                if (increase == true)
                {
                    if (green < 256)
                    {
                        green++;
                    }
                    else if (red < 256)
                    {
                        red++;
                    }
                    else if (blue <= 255)
                    {
                        blue++;
                    }
                    else
                    {
                        increase = false;
                    }
                    special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
                }
                else
                {
                    if (green >= 0)
                    {
                        green--;
                    }
                    else if (red >= 0)
                    {
                        red--;
                    }
                    else if (blue >= 0)
                    {
                        blue--;
                    }
                    else
                    {
                        increase = true;
                    }
                    special.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
                }
            }
        }
    }
}
