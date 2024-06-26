using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    public void VolumeChanged()
    {
        EventBus.VolumeChange.Invoke(volumeSlider.value);
    }
}
