using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour {
    [SerializeField] private Behaviour[] disables;
    [SerializeField] private GameObject[] doNotRender;
    [SerializeField] private AlexUI ui;
    [SyncVar] private int players;
    


    // Disable scripts for non-local players and disable rendering for body parts of local player
    void Start() {
        if (!isLocalPlayer) {
            for (int i = 0; i < disables.Length; i++) {
                disables[i].enabled = false;
            }
        }
        else {
            for (int i = 0; i < doNotRender.Length; i++) {
                doNotRender[i].layer = 8;
            }

        }

        string id = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = id;

        hideNetworkHUD();
        CmdPlayersLeft();
    }

    private void Update() {
        checkPlayersLeft();
    }

    private void hideNetworkHUD() {
        NetworkManagerHUD hud = FindObjectOfType<NetworkManagerHUD>();
        hud.showGUI = false;
    }

    private void checkPlayersLeft() {
        CmdPlayersLeft();
        ui.SetPlayersLeft(players);
        if (players == 1) {
           ui.SetEndMessage(0);
           ui.DisplayEndMessage();
        }
    }

    [Command]
    void CmdPlayersLeft() {
        NetworkRoomManager networkManager = FindObjectOfType<NetworkRoomManager>();
        players = networkManager.numPlayers;
    }
}
