using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

public class CorrectTrackException : System.Exception
{

}

public class Note
{
    public byte NoteNumber { get; private set; }    // ノート番号
    public float StartTime { get; private set; }    // 吹き始め時間
    public float EndTime { get; private set; }      // 吹き終わり時間
    public byte Velocity { get; private set; }      // ベロシティ

    public Note(byte notenum, float time, byte vel)
    {
        this.NoteNumber = notenum;
        this.StartTime = time;
        this.Velocity = vel;
        this.EndTime = time + 1;
    }

    public void SetEndTime(float time)
    {
        this.EndTime = time;
    }
}

public class MIDIManager
{
    public float Tempo { get; private set; }
    public List<Note> Events { get; private set; }

    public MIDIManager(byte[] midiBytes)
    {
        var smf = MidiFileLoader.Load(midiBytes);

        // トラック0にテンポ，トラック1にノーツが入っている前提
        // テンポとトランペットのトラック以外が入っていたら落とす
        if (smf.tracks.Count == 2)
            throw new CorrectTrackException();

        this.Tempo = LoadTempo(smf);
        this.Events = LoadEvents(smf, this.Tempo);
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

    float GetTotalSeconds(int totalDelta, int division, float tmp)
    {
        return ((float)totalDelta / division) * (60f / tmp);
    }

    List<Note> LoadEvents(MidiFileContainer smf, float tmp)
    {
        Debug.Log("tracks:" + smf.tracks.Count.ToString());
        var track = smf.tracks[1];
        var events = new List<Note>();
        var totalDelta = 0;


        foreach (var ev in track)
        {
            // 0x09がノートオン，0x08がノートオフになっている
            // 他のサイトで逆になっているケースを見かけた

            if ((ev.midiEvent.status & 0xf0) == 0x90)   // ノートオン
            {
                events.Add(new Note(
                    ev.midiEvent.data1,
                    GetTotalSeconds(totalDelta, smf.division, tmp),
                    ev.midiEvent.data2));
            }
            else if ((ev.midiEvent.status & 0xf0) == 0x80)  // ノートオフ
            {
                var totalSec = GetTotalSeconds(totalDelta, smf.division, tmp);
                events[events.Count - 1].SetEndTime(totalSec);
            }
            totalDelta += ev.delta;
        }

        return events;
    }
}
