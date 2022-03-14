using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionContr : MonoBehaviour
{
    public Slider slideVolume;

    public void Volume()
    {
        AudioListener.volume = slideVolume.value;
    }
}
