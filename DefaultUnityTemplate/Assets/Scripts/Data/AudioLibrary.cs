using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Audio/AudioLibrary")]
public class AudioLibrary : ScriptableObject
{
    [System.Serializable]
    public class BgmEntry
    {
        public string label; // "Title", "Battle" など
        public AudioClip clip;
    }

    [System.Serializable]
    public class SeEntry
    {
        public string label; // "Click", "Explosion" など
        public AudioClip clip;
    }

    public List<BgmEntry> bgmList = new();
    public List<SeEntry> seList = new();
    public AudioClip submitSe;
    public AudioClip cancelSe;
    public AudioClip cursorMoveSe;

    public AudioClip GetBgm(string label)
    {
        return bgmList.Find(b => b.label == label)?.clip;
    }

    public AudioClip GetSe(string label)
    {
        return seList.Find(s => s.label == label)?.clip;
    }
}