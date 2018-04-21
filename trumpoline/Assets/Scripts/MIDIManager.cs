using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

public class CorrectTrackException : System.Exception
{

}

public struct Note
{
    byte noteNumber;
    float time;
    byte velocity;
}

public class MIDIManager
{
    public float Tempo { get; private set; } = 120f;
    public List<float> EventSeconds { get; private set; }

    MIDIManager()
    {
        
    }

    float LoadTempo(MidiFileContainer smf)
    {
        float tmp = 120f;

        foreach (var ev in smf.tracks[0])
        {
            if (ev.midiEvent is TempoEvent)
            {
                tmp = ((TempoEvent)ev.midiEvent).Tempo;
                break;
            }
        }

        return tmp;
    }

    List<float> LoadEvents(MidiFileContainer smf, float tmp)
    {
        var track = smf.tracks[1];
        var events = new List<float>();
        var totalDelta = 0;
        
        foreach (var ev in track)
        {
            if ((ev.midiEvent.status & 0xf0) == 0x80)
            {
                var totalSeconds = ((float)totalDelta / smf.division) * (60f / tmp);
                events.Add(totalSeconds);
            }
            totalDelta += ev.delta;
        }

        return events;
    }

    void InitializeMIDI(byte[] midiBytes)
    {
        var smf = MidiFileLoader.Load(midiBytes);

        // トラック0にテンポ，トラック1にノーツが入っている前提
        // テンポとトランペットのトラック以外が入っていたら落とす
        if (smf.tracks.Count == 2)
            throw new CorrectTrackException();

        this.Tempo = LoadTempo(smf);
        this.EventSeconds = LoadEvents(smf, this.Tempo);
    }
}
