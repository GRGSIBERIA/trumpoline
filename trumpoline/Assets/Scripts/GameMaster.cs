using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public AudioClip clip;
    public byte[] midiData;

    MIDIManager midiManager;
    
    public void LoadMIDIManager()
    {
        this.midiManager = new MIDIManager(this.midiData);
    }
}
