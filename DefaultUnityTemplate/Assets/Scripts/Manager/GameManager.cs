using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/// <summary>
/// ゲーム全体の状態
/// </summary>
public enum GameState
{
    None,
    Title,
    Loading,
    InGame,
    Paused,
}

/// <summary>
/// ゲームを管理するクラス
/// ・ゲーム状態尾管理
/// ・状態変更イベント
/// ・セーブロード
/// ・初期化、再起動
/// </summary>
public class GameManager : AbstractManager
{
    
    //--フィールド
    [SerializeField] private GameState currentState;
    public GameState CurrentState => currentState;
    
    [SerializeField] private GameStateSceneMap sceneMap;

    //--イベント
    [SerializeField] private UnityEvent<GameState> onGameStateChanged;
    public UnityEvent<GameState> OnGameStateChanged => onGameStateChanged;
    
    //--メソッド
    //初期化
    internal override void Init()
    {
        var activeSceneName = SceneManager.GetActiveScene().name;
        
        // 現在のシーンに合った状態を自動設定
        if (sceneMap.TryGetStateFromScene(activeSceneName, out GameState detectedState))
        {
            currentState = detectedState;
            Debug.Log($"[GameManager] GameState自動設定: {currentState}");
        }
        else
        {
            Debug.LogWarning($"[GameManager] シーン {activeSceneName} に対応する GameState が見つかりません。");
            currentState = GameState.None;
        }
        
        Debug.Log("ゲームマネージャーを初期化しました。");
    }
    
    //ゲーム開始
    public void StartGame()
    {
        Debug.Log("ゲームを開始します。");
        
    }
    
    //ゲーム終了
    public void EndGame()
    {
        Debug.Log("ゲームを終了します。");
    }
    
    //シーンの変更
    public async void ChangeScene(GameState newState)
    {
        // 遷移前処理（セーブ・BGMフェードなど）
       // await
       
       currentState = newState;

       string sceneName = sceneMap.GetSceneName(newState);
       if (string.IsNullOrEmpty(sceneName))
       {
           Debug.LogError($"Scene name not defined for GameState: {newState}");
           return;
       }

       SceneManager.LoadScene(sceneName);

        // 遷移後処理（UIセットアップなど）
        // await
    }
    
    
}
