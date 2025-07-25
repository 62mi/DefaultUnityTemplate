using System;
using UnityEngine;

public abstract class AbstractManager : MonoBehaviour
{
    // 派生クラスごとにインスタンスを管理する辞書
    private static readonly System.Collections.Generic.Dictionary<System.Type, AbstractManager> Instances =
        new System.Collections.Generic.Dictionary<System.Type, AbstractManager>();
    
    // シングルトンの取得
    public static T GetInstance<T>() where T : AbstractManager
    {
        System.Type type = typeof(T);

        if (!Instances.ContainsKey(type))
        {
            T instance = FindObjectOfType<T>();

            if (instance == null)
            {
                Debug.LogError($"No instance of {type.Name} found in the scene.");
                return null;
            }

            Instances[type] = instance;
        }

        return Instances[type] as T;
    }

    // インスタンス登録（初期化時に登録）
    private void Awake()
    {
        System.Type type = GetType();

        if (Instances.ContainsKey(type) && Instances[type] != this)
        {
            Debug.LogWarning($"Multiple instances of {type.Name} detected. Destroying duplicate.");
            Destroy(gameObject);
        }
        else
        {
            Instances[type] = this;
        }
    }

    //ゲームの開始時に一度だけ呼ばれる
    internal abstract void Init();
}