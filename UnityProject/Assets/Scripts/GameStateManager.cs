using UnityEngine;
using System.Collections;


public enum GameState
{
	MainMenu,
	Playing,
	Pause,
	GameOver
}


public class GameStateManager : MonoBehaviour
{
   public static GameStateManager instance;

   public GameObject MainMenuUi;
   public GameObject InGameMenuUi;
   public GameObject PauseMenuUi;
   public GameObject GameOverMenuUi;

   public int delay = 1;

   public GameState CurrentState { get; private set; }

   private void Awake()
   {
	   if(instance == null)
	   {
		   instance = this;
		   DontDestroyOnLoad(gameObject);
	   }
	   else
	   {
		   Destroy(gameObject);
	   }
   }

   private void Start()
   {
	   ChangeState(GameState.MainMenu);
   }

   public void ChangeState(GameState newState)
   {

	   StartCoroutine(TransitionToState(newState));
   }

   // Click events
   public void ChangeToMainMenu()
   {
	   ChangeState(GameState.MainMenu);
   }
   public void ChangeToPlaying()
   {
	   ChangeState(GameState.Playing);
   }
   public void ChangeToPause()
   {
	   ChangeState(GameState.Pause);
   }
   public void ChangeToGameOver()
   {
	   ChangeState(GameState.GameOver);
   }

   private IEnumerator TransitionToState(GameState newState)
   {
	   if(newState != GameState.MainMenu)
			yield return new WaitForSecondsRealtime(delay);

	   CurrentState = newState;
	   HandleStateChange();
   }

   private void HandleStateChange()
   {
	   HideAllMenu();

	   switch (CurrentState)
	   {
		   case GameState.MainMenu:
				Time.timeScale = 0;
				MainMenuUi.SetActive(true);
				break;
			case GameState.Playing:
				Time.timeScale = 1;
				InGameMenuUi.SetActive(true);
				break;
			case GameState.Pause:
				Time.timeScale = 0;
				PauseMenuUi.SetActive(true);
				break;
			case GameState.GameOver:
				Time.timeScale = 0;
				GameOverMenuUi.SetActive(true);
				break;
	   }
   }

   private void HideAllMenu()
   {
	   MainMenuUi.SetActive(false);
	   InGameMenuUi.SetActive(false);
	   PauseMenuUi.SetActive(false);
	   GameOverMenuUi.SetActive(false);
   }
}
