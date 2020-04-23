using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;


public class LoadRemoteConfig : MonoBehaviour
{
    public struct userAttributes {}
    public struct appAtributes {}

    void Awake()
    {
        ConfigManager.FetchCompleted += SetVariables;
        ConfigManager.FetchConfigs<userAttributes, appAtributes>(new userAttributes(), new appAtributes());
    }

    private void SetVariables(ConfigResponse response){
        GameValues.jumpForce = ConfigManager.appConfig.GetInt("jumpForce");
        GameValues.speedObserver = ConfigManager.appConfig.GetInt("speedObserver");
        GameValues.speedBaby = ConfigManager.appConfig.GetInt("speedBaby");
        GameValues.speedFull = ConfigManager.appConfig.GetInt("speedFull");
        GameValues.speedAlumni = ConfigManager.appConfig.GetInt("speedAlumni");
    }
}
