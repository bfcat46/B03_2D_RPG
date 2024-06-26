using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class VolumeChange : UnityEvent<float> { }

public class EventBus : MonoBehaviour
{
    public static VolumeChange VolumeChange = new VolumeChange();
}