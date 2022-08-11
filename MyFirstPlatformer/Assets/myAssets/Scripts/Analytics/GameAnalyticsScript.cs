using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticsScript : MonoBehaviour
{
    public static GameAnalyticsScript instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelComplete(int _level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level: " + _level);
        Debug.Log("Level: " + _level);
    }
}
