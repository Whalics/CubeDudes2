using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TurnManager turnmanager;
    [SerializeField] ShootController shootcontroller;
    [SerializeField] PlayerCollisionController playercollisioncontroller;
    [SerializeField] FlickController flickcontroller;
    [SerializeField] TimerController timercontroller;
    [SerializeField] CharacterClass characterclass;
    [SerializeField] PlayerInputManager playerinputmanager;
    [SerializeField] HUDMenuController hudmenucontroller;
    [SerializeField] DeckManager deckmanager;
    [SerializeField] ForceSliderController forceslidercontroller;
    void Start()
    {
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        playercollisioncontroller = GetPlayer().GetComponent<PlayerCollisionController>();
        flickcontroller = GameObject.Find("Finger").GetComponent<FlickController>();
        timercontroller = GameObject.Find("Time_txt").GetComponent<TimerController>();
        playerinputmanager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
        hudmenucontroller = GameObject.Find("HUD_cnvs").GetComponent<HUDMenuController>();
        deckmanager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        forceslidercontroller = GameObject.Find("ForceStrength_sldr").GetComponent<ForceSliderController>();
    }

    public GameObject GetPlayer(){
        return turnmanager.players[turnmanager.playerTurn];
    }

    public int GetPlayerCount(){
        return turnmanager.players.Length;
    }

    public int GetTurn(){
        return turnmanager.playerTurn;
    }

    public int GetFlicks(){
        return GetPlayer().GetComponent<CharacterClass>().ReturnFlicks();
    }

    public GameObject GetXPlayer(int player){
        return turnmanager.players[player];
    }
    public void ShowDeck(){
        deckmanager.DisplayDeck();
    }

    public void HideDeck(){
        deckmanager.HideDecks();
    }

    public Rigidbody GetPlayerRb(){
        return GetPlayer().GetComponent<Rigidbody>();
    }

    public Transform GetPlayerTransform(){
        return GetPlayer().transform;
    }

    public bool PlayerDead(){
        return GetPlayer().GetComponent<CharacterDeath>().dead;
    }

    public bool XPlayerDead(int player){
        return GetXPlayer(player).GetComponent<CharacterDeath>().dead;
    }

    // public void TMGetNextPlayerTurn(int player){
    //     turnmanager.GetNextPlayersTurn(player);
    // }

    public Vector3 GetPlayerPos(){
        return GetPlayer().transform.position;
    }

    public PlayerCollisionController GetPlayerCollisionController(){
        return GetPlayer().GetComponent<PlayerCollisionController>();
    }

    public CharacterClass GetCharacterClass(){
        return GetPlayer().GetComponent<CharacterClass>();
    }

    public void FlickVisuals(){
        StartCoroutine(flickcontroller.Flicked());
        timercontroller.PauseTimer();
    }

    public void DisplayHUDMenu(){
        hudmenucontroller.OpenMenu();
    }

    public void CloseHUDMenu(){
        hudmenucontroller.CloseMenu();
    }
    
    public void ResetTurn(){
        shootcontroller.Reset();
        playerinputmanager.Reset();
        timercontroller.ResetTimer();
    }

    public void ResetFlick(){
        shootcontroller.Reset();
        playerinputmanager.Reset();
        timercontroller.ResumeTimer();
    }

    public void UnlockMenu(){
        playerinputmanager.Unlock();
    }

    public void EndFlick(){
        StartCoroutine(turnmanager.EndFlick());
    }

    public void EndTurn(){
        StartCoroutine(turnmanager.EndTurn());
        hudmenucontroller.CloseMenu();
    }

    public bool GetControls(){
        return playerinputmanager.disableControls;
    }

    public void DisableControls(){
        playerinputmanager.disableControls = true;
    }

    public void EnableControls(){
        playerinputmanager.disableControls = false;
    }

    public void ForceSliderIn(){
        forceslidercontroller.SliderIn();
    }

    public void ForceSliderOut(){
        forceslidercontroller.SliderOut();
    }

    public void ForceSliderShake(){
         forceslidercontroller.SliderShake();
    }
    
}
