using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthManager : MonoBehaviour {

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite halfHearth;
    public Sprite emptyHearth;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    private void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i<heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHearth;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RunTimeValue / 2;
        for(int i = 0; i<heartContainers.RunTimeValue; i++)
        {
            if(i <= tempHealth-1)
            {
                hearts[i].sprite = fullHearth;
            }
            else if(i >= tempHealth)
            {
                hearts[i].sprite = emptyHearth;
            }
            else
            {
                hearts[i].sprite = halfHearth;
            }
        }
    }
}
