﻿using System.Collections.Generic;
using UnityEngine;

 
public class GameManager : MonoBehaviour {

    private const string PLAYER_ID_PREFIX = "Player";
    public static Dictionary<string, Player> players = new Dictionary<string, Player>();


    public static void RegisterPlayer (string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;

        // Set player name to include netID
        _player.transform.name = _playerID;
        players.Add(_playerID, _player);        
    }

    public static void UnRegisterPlayer (string _playerName)
    {
        players.Remove(_playerName);
    }

    public static Player GetPlayer (string _playerID)
    {
        if (players[_playerID])
        {
            return players[_playerID];
        } else
        {
            return null;
        }
            
    }
}
