using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager_KYJ : MonoBehaviour
{
    private static CharacterManager_KYJ instance;
    public static CharacterManager_KYJ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CharacterManager").AddComponent<CharacterManager_KYJ>();
            }
            return instance;
        }
    }

    public KDHPlayer Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private KDHPlayer _player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
