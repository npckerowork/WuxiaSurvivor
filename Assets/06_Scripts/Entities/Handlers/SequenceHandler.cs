using DG.Tweening;
using System;
using UnityEngine;

public class SequenceHandler
{
    public Sequence Birth { get; private set; }
    public Sequence Stand { get; private set; }
    public Sequence Death { get; private set; }

    public void Initialize()
    {
        Birth = Utility.RecyclableSequence();
        Stand = Utility.RecyclableSequence().SetLoops(-1);
        Death = Utility.RecyclableSequence();
    }

    public void Deinitialize()
    {
        Birth.Kill();
        Stand.Kill();
        Death.Kill();
    }

    public void Bind(BaseState type, params Func<Sequence>[] sequences)
    {
        Sequence sequence = sequences[0]();
        for (int i = 1; i < sequences.Length; i++)
        {
            sequence.Join(sequences[i]());
        }

        switch (type)
        {
            case BaseState.Destroyed:
                Debug.LogWarning($"Failed to BindSequences({type})");
                break;
            case BaseState.Birth:
                Birth.Append(sequence);
                break;
            case BaseState.Stand:
                Stand.Append(sequence);
                break;
            case BaseState.Death:
                Death.Append(sequence);
                break;
        }
    }
}