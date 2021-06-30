using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerScriptable playerStats;
    [SerializeField] Transform playerTransform;
    [SerializeField] EnemyManager enemyManager;


    [Header("GUI References")]
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameoverUI;

    private StateMachine stateMachine;
    private StateMachine.State inGame;
    private StateMachine.State paused;
    private StateMachine.State gameover;

    private void Awake()
    {
        inGame = new StateMachine.State(Enter: InGameEnter,
                                        Update: InGameUpdate,
                                        Exit: InGameExit);
        paused = new StateMachine.State(Enter: PauseEnter,
                                       Update: PauseUpdate,
                                       Exit: PauseExit);
        gameover = new StateMachine.State(Enter: GameoverEnter,
                                          Update: GameoverUpdate,
                                          Exit: GameoverExit);
        stateMachine = new StateMachine(inGame);
    }

    private void Start()
    {
        playerStats.ResetPlayer();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    #region InGameState
    private void InGameEnter()
    {
        scoreUI.SetActive(true);
        playerUI.SetActive(true);
        Time.timeScale = 1;
    }

    private void InGameUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            stateMachine.ChangeState(paused);

        if (playerStats.healthPoints <= 0)
            stateMachine.ChangeState(gameover);
    }

    private void InGameExit()
    {
        scoreUI.SetActive(false);
        playerUI.SetActive(false);
        Time.timeScale = 0;
    }

    #endregion
    #region PausedState

    private void PauseEnter()
    {
        pauseUI.SetActive(true);
    }

    private void PauseUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            stateMachine.ChangeState(inGame);
    }

    private void PauseExit()
    {
        pauseUI.SetActive(false);
    }

    #endregion
    #region GameoverState

    private void GameoverEnter()
    {
        gameoverUI.SetActive(true);
    }

    private void GameoverUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(inGame);
    }

    private void GameoverExit()
    {
        enemyManager.RemoveAllEnemies();
        playerStats.ResetPlayer();
        playerTransform.position = Vector3.zero;
        gameoverUI.SetActive(false);
    }
    #endregion
}
