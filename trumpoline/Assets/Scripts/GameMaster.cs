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

    public void TransfarGameMaster(GameMaster master)
    {
        master.clip = this.clip;
        master.midiData = this.midiData;
        master.midiManager = this.midiManager;
    }
}
