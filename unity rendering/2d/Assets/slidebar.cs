using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidebar : MonoBehaviour
{
    public Slider myslider;
    public void SetHealth(int healths)
    {
        myslider.value = healths;
    }
    public void MaxHealth(int healths)
    {
        myslider.value = healths;
        myslider.maxValue = healths;
    }

}
