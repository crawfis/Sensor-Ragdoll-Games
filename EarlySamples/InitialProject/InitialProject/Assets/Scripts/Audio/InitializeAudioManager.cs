using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTMY.Audio;

public class InitializeAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public MusicPlayerExplicit Music; 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioManagerSingleton.Instance.SetMusicPlayer(Music);
    }
}
