using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public AudioClip clip;
    public byte[] midiData;

    MIDIManager midiManager;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMIDIManager()
    {
        this.midiManager = new MIDIManager(this.midiData);
    }
}
