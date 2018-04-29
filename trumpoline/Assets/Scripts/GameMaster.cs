using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public AudioClip clip;
    public byte[] midiData;

    MIDIManager midiManager;

    public static GameMaster Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMIDIManager()
    {
        this.midiManager = new MIDIManager(this.midiData);
    }
}
