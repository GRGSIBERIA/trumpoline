using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum FileType
{
    MIDI,
    WAV
}

public class DownloadButtonScript : MonoBehaviour {

    public GameObject InputFieldObj;
    public string URL { get; private set; }
    public bool downloadEnded { get; private set; }

    public AudioClip clip;
    public byte[] midi;

    public FileType AudioType { get; private set; }

    InputField inputField;
    WWW www;

    void Awake()
    {
        if (this.name.IndexOf("WAV") >= 0)
        {
            this.AudioType = FileType.WAV;
        }
        else if (this.name.IndexOf("MIDI") >= 0)
        {
            this.AudioType = FileType.MIDI;
        }
        else
        {
            throw new System.Exception("Do not match names: MIDI or WAV");
        }
    }


	// Use this for initialization
	void Start () {
        this.inputField = InputFieldObj.GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GetContents()
    {
        yield return new WaitWhile(() => this.www.isDone);
    }

    // MIDIやWAVのバリデーションをしたい


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
                Debug.Log(this.midi.Length);
                break;
            case FileType.WAV:
                this.clip = this.www.GetAudioClip(false, true);
                break;
        }
    }
}
