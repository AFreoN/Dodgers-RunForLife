using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceofDemo : MonoBehaviour
{
    public GameObject[] arrows;
    public GameObject[] buttonAllower;
    public GameObject SPBtnBlock;
    public Button left;
    public Button right;
    public Button jump;
    public Transform player;
    public static bool timeControl;
    private int num = 0;
    float timer;
    float x, y;
    bool work;
    bool num4;

    private void OnEnable()
    {
        left.interactable = false;
        right.interactable = false;
        jump.interactable = false;
        SPBtnBlock.SetActive(true);
        timeControl = false;
        Time.timeScale = 0;
        timer = Time.unscaledTime;
        for(int i=0;i < arrows.Length;i++)
        {
            arrows[i].SetActive(false);
        }
        arrows[0].SetActive(true);
        num = 1;
        for (int j = 0;j < buttonAllower.Length;j++)
        {
            buttonAllower[j].SetActive(true);
        }
    }

    void Start ()
    {
        timeControl = true;
        work = false;
        num4 = false;
	}
	
	void Update ()
    {
        x = PlayerMovement2.x;
        y = PlayerMovement2.y;
        if (Time.unscaledTime > timer + 1 && num < 4)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.touchCount > 0)
            {
                switch (num)
                {
                    case 1:
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            arrows[i].SetActive(false);
                        }
                        arrows[num].SetActive(true);
                        num = 2;
                        timer = Time.unscaledTime;
                        break;
                    case 2:
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            arrows[i].SetActive(false);
                        }
                        arrows[num].SetActive(true);
                        num = 3;
                        timer = Time.unscaledTime;
                        break;
                    case 3:
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            arrows[i].SetActive(false);
                        }
                        arrows[num].SetActive(true);
                        Time.timeScale = 1;
                        timeControl = false;
                        num = 4;
                        timer = Time.unscaledTime;
                        break;
                }
            }
        }
        else if(num > 3 && num < 7 && work == true)
        {
            switch(num)
            {
                case 4:
                    for (int i = 0; i < arrows.Length; i++)
                    {
                        arrows[i].SetActive(false);
                    }
                    arrows[num].SetActive(true);
                    left.interactable = true;
                    for(int j=0;j<buttonAllower.Length;j++)
                    {
                        buttonAllower[j].SetActive(false);
                    }
                    buttonAllower[0].SetActive(true);
                    work = false;
                    break;
                case 5:
                    for (int i = 0; i < arrows.Length; i++)
                    {
                        arrows[i].SetActive(false);
                    }
                    arrows[num].SetActive(true);
                    right.interactable = true;
                    for (int j = 0; j < buttonAllower.Length; j++)
                    {
                        buttonAllower[j].SetActive(false);
                    }
                    buttonAllower[1].SetActive(true);
                    work = false;
                    break;
                case 6:
                    timeControl = false;
                    for (int i = 0; i < arrows.Length; i++)
                    {
                        arrows[i].SetActive(false);
                    }
                    for (int j = 0; j < buttonAllower.Length; j++)
                    {
                        buttonAllower[j].SetActive(false);
                    }
                    if (player.position.z >= 38.8f)
                    {
                        Time.timeScale = 0;
                        jump.interactable = true;
                        arrows[num].SetActive(true);
                        buttonAllower[2].SetActive(true);
                        timeControl = true;
                        work = false;
                    }
                    break;
                case 7:
                    break;
            }
        }
        else if(num > 6 && Time.unscaledTime > timer+1)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.touchCount > 0)
            {
                switch(num)
                {
                    case 7:
                        num = 8;
                        work = true;
                        break;
                    case 8:
                        break;
                }
            }
        }
        if(num == 4)
        {
            if(Time.unscaledTime > timer+1 && Input.touchCount > 0 || Time.unscaledTime > timer + 1 && Input.GetKeyDown(KeyCode.Q))
            {
                timeControl = false;
                Time.timeScale = 1;
                work = true;
                num4 = true;
            }
            else
            {
                timeControl = true;
                Time.timeScale = 0.01f;
            }
            if (x != 0 && num4 == true)
            {
                timeControl = false;
                Time.timeScale = 1;
            }
            else if(x == 0 && num4 == true)
            {
                timeControl = true;
                Time.timeScale = 0.0001f;
            }
            if (player.position.x < -4)
            { 
                if (x == 0)
                {
                    num = 5;
                    left.interactable = false;
                    work = true;
                }
                else
                {
                    Time.timeScale = 0.001f;
                }
            }
        }
        if(num == 5)
        {
            if (y != 0)
            {
                timeControl = false;
                Time.timeScale = 1;
            }
            else if (y == 0)
            {
                timeControl = true;
                Time.timeScale = 0.0001f;
            }
            if (player.position.x >= 0)
            {
                if (y == 0)
                {
                    num = 6;
                    Time.timeScale = 1;
                    right.interactable = false;
                    timeControl = false;
                    work = true;
                }
                else
                {
                    Time.timeScale = 0.001f;
                }
            }
        }
        if(num == 6)
        {
            if(player.position.y > 0.3f)
            {
                num = 7;
                timeControl = false;
                for (int i = 0; i < arrows.Length; i++)
                {
                    arrows[i].SetActive(false);
                }
                jump.interactable = false;
                for (int j = 0; j < buttonAllower.Length; j++)
                {
                    buttonAllower[j].SetActive(true);
                }
                work = true;
                timer = Time.unscaledTime;
            }
        }
        if(num == 7 && work == true)
        {
            if(player.position.z > 60.6f)
            {
                Time.timeScale = 0;
                timeControl = true;
                for (int i = 0; i < arrows.Length; i++)
                {
                    arrows[i].SetActive(false);
                }
                arrows[num].SetActive(true);
                timer = Time.unscaledTime;
                work = false;
            }
        }
        if(num == 8 && work == true)
        {
            SPBtnBlock.SetActive(false);
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].SetActive(false);
            }
            for (int j = 0; j < buttonAllower.Length; j++)
            {
                buttonAllower[j].SetActive(false);
            }
            arrows[num].SetActive(true);
            left.interactable = true;
            right.interactable = true;
            jump.interactable = true;
            timer = Time.unscaledTime;
            work = false;
        }
        if(DemoTime1.powered == true && work == false)
        {
            num = 9;
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].SetActive(false);
            }
            work = true;
        }
	}
}
