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

        if (GameValues.difficulty == 4){
            GameValues.speed = ConfigManager.appConfig.GetInt("speedAlumni");
            GameValues.jumpForce = ConfigManager.appConfig.GetInt("jumpForce") + 2;
            GameValues.gravity = 7;
        }
        else if (GameValues.difficulty == 3){
            GameValues.speed = ConfigManager.appConfig.GetInt("speedFull");
            GameValues.gravity = 6;
        }
        else if (GameValues.difficulty == 2){
            GameValues.speed = ConfigManager.appConfig.GetInt("speedBaby");
            GameValues.gravity = 6;
        }
        else {
            GameValues.speed = ConfigManager.appConfig.GetInt("speedObserver");
            GameValues.gravity = 5;
        }
    }
}
