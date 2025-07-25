using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : AbstractManager
{
    
    [SerializeField] private InputActionAsset inputActions;

    private InputActionMap uiMap;
    private InputAction submitAction;
    private InputAction cancelAction;
    private InputAction navigateAction;
    
    private bool inputEnabled = true;
    public bool InputEnabled => inputEnabled;
    
    
    internal override void Init()
    {
        Debug.Log("InputManager: Init");

        uiMap = inputActions.FindActionMap("UI");
        submitAction = uiMap.FindAction("Decide");
        cancelAction = uiMap.FindAction("Cancel");
        navigateAction = uiMap.FindAction("Move");

        uiMap.Enable(); // 入力を有効化
    }
    
    //決定
    public void OnSubmit()
    {
        if (!inputEnabled) return;
        
        // 決定処理
        Debug.Log("決定ボタンが押されました。");
    }
    
}
