﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchEnemySpawner : MonoBehaviour
{
    [SerializeField]
    string twitchMessageToSpawn = "enemy";

    [SerializeField]
    GameObject enemyPrefab;

    private void Awake()
    {
        TwitchChat twitchChat = FindObjectOfType<TwitchChat>();
        twitchChat.OnMessageReceived += (x) => AttemptEnemySpawn(x);
    }

    private void AttemptEnemySpawn(string twitchMessage)
    {
        Debug.Log("attempt enemy spawn " + twitchMessage);
        if (twitchMessage.ToLower() == twitchMessageToSpawn.ToLower())
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}