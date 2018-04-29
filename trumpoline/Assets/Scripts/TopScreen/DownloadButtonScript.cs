using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum FileType
{
    MIDI,
    WAV
}

[RequireComponent(typeof(InputField))]
[RequireComponent(typeof(GameMaster))]
public class DownloadButtonScript : MonoBehaviour {

    public GameObject InputFieldObj;
    public GameObject GameMasterObj;
    public string URL { get; private set; }
    public bool downloadEnded { get; private set; }

    AudioClip clip;
    byte[] midi;

    public FileType AudioType; 

    InputField inputField;
    GameMaster master;
    WWW www;
    
	// Use this for initialization
	void Start () {
        this.inputField = InputFieldObj.GetComponent<InputField>();
        this.master = GameMasterObj.GetComponent<GameMaster>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GetContents()
    {
        yield return new WaitWhile(() => this.www.isDone);
    }

    // MIDIやWAVのバリデーションをしたい

    void ValidatesMIDI(bytes[] midi)
    {

    }

    public void OnClick()
    {
        this.URL = this.inputField.text;

        this.www = new WWW(this.URL);
        while (!this.www.isDone) { }

        this.downloadEnded = this.www.isDone;
        Debug.Log(this.downloadEnded);

        switch (AudioType)
        {
            case FileType.MIDI:
                this.midi = this.www.bytes;
                this.master.midiData = this.midi;
                Debug.Log(this.midi.Length);
                break;
            case FileType.WAV:
                this.clip = this.www.GetAudioClip(false, true);
                this.master.clip = this.clip;
                Debug.Log(this.clip.length);
                break;
        }
    }
}
