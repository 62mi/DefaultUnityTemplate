using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSceneMap", menuName = "Scriptable Objects/GameStateSceneMap")]
public class GameStateSceneMap : ScriptableObject
{
    [System.Serializable]
    public class Entry
    {
        public GameState state;
        public string sceneName;
    }

    public List<Entry> entries = new();

    public string GetSceneName(GameState state)
    {
        var entry = entries.Find(e => e.state == state);
        return entry != null ? entry.sceneName : null;
    }
    
    public bool TryGetStateFromScene(string sceneName, out GameState state)
    {
        foreach (var entry in entries)
        {
            if (string.Equals(entry.sceneName, sceneName, System.StringComparison.OrdinalIgnoreCase))
            {
                state = entry.state;
                return true;
            }
        }

        state = default;
        return false;
    }
}
