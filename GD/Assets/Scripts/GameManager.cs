using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;
    //public GameManager HealthPackSpawner;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,

    }

    GameManagerState GMState;
   
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

   void UpdateGameManagerState()
   {
       switch (GMState)
       {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);
                playButton.SetActive(true);
                GameTitleGO.SetActive(true);
                break;
            
            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                GameTitleGO.SetActive(false);
               // HealthPackSpawner.GetComponent<HealthPackSpawner>().SpawnHealthPack();
                break;

            case GameManagerState.GameOver:

                enemySpawner.GetComponent<EnemySpawner>().UnsheduleEnemySpawner();

                GameOverGO.SetActive(true); 

                Invoke ("ChangeToOpeningState",5f);
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                break;

       }
   }


   public void SetGameManagerState(GameManagerState state)
   {
       GMState =state;
       UpdateGameManagerState();
   }

   public void StartGamePlay()
   {
       GMState = GameManagerState.Gameplay;
       UpdateGameManagerState();
   }

   public void ChangeToOpeningState()
   {
       SetGameManagerState(GameManagerState.Opening);
   }
}
