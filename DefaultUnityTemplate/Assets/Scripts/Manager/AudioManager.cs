using UnityEngine;

public class AudioManager : AbstractManager
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSourcePrefab;
    [SerializeField] private int maxSeSources = 5;

    [Header("Audio Data")]
    [SerializeField] private AudioLibrary audioLibrary;

    private AudioSource[] seSources;
    private int currentSeIndex = 0;

    internal override void Init()
    {
        Debug.Log("AudioManager: Init");

        // SE用AudioSourceを複数生成
        seSources = new AudioSource[maxSeSources];
        for (int i = 0; i < maxSeSources; i++)
        {
            seSources[i] = Instantiate(seSourcePrefab, transform);
        }
    }

    // BGM再生
    public void PlayBgm(string label, bool loop = true)
    {
        var clip = audioLibrary.GetBgm(label);
        if (clip == null)
        {
            Debug.LogWarning($"BGMラベル '{label}' が見つかりませんでした");
            return;
        }

        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    // SE再生（同時再生対応）
    public void PlaySe(string label)
    {
        var clip = audioLibrary.GetSe(label);
        if (clip == null) return;

        var source = seSources[currentSeIndex];
        source.clip = clip;
        source.Play();

        currentSeIndex = (currentSeIndex + 1) % maxSeSources;
    }
    
    public void PlaySubmitSe()
    {
        var clip = audioLibrary.submitSe;
        if (clip == null) return;

        var source = seSources[currentSeIndex];
        source.clip = clip;
        source.Play();

        currentSeIndex = (currentSeIndex + 1) % maxSeSources;
    }
    public void PlayCancelSe()
    {
        var clip = audioLibrary.cancelSe;
        if (clip == null) return;

        var source = seSources[currentSeIndex];
        source.clip = clip;
        source.Play();

        currentSeIndex = (currentSeIndex + 1) % maxSeSources;
    }
    public void PlayCursorMoveSe()
    {
        var clip = audioLibrary.cursorMoveSe;
        if (clip == null) return;

        var source = seSources[currentSeIndex];
        source.clip = clip;
        source.Play();

        currentSeIndex = (currentSeIndex + 1) % maxSeSources;
    }

    public void SetBgmVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSeVolume(float volume)
    {
        foreach (var source in seSources)
        {
            source.volume = volume;
        }
    }
}