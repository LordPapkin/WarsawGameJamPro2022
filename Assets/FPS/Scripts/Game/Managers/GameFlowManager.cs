using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.FPS.Game
{
    public class GameFlowManager : MonoBehaviour
    {
        [Header("Parameters")] [Tooltip("Duration of the fade-to-black at the end of the game")]
        public float EndSceneLoadDelay = 3f;

        [Tooltip("The canvas group of the fade-to-black screen")]
        public CanvasGroup EndGameFadeCanvasGroup;

        [Header("Win")] [Tooltip("This string has to be the name of the scene you want to load when winning")]
        public string WinSceneName = "WinScene";

        [Tooltip("Duration of delay before the fade-to-black, if winning")]
        public float DelayBeforeFadeToBlack = 4f;

        [Tooltip("Win game message")]
        public string WinGameMessage;
        [Tooltip("Duration of delay before the win message")]
        public float DelayBeforeWinMessage = 2f;

        [Tooltip("Sound played on win")] public AudioClip VictorySound;

        [Header("Lose")] [Tooltip("This string has to be the name of the scene you want to load when losing")]
        public string LoseSceneName = "LoseScene";


        public bool GameIsEnding { get; private set; }

        float m_TimeLoadEndGameScene;
        string m_SceneToLoad;
        [SerializeField] private Animator animator;
        void Awake()
        {
            EventManager.AddListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);
        }

        void Start()
        {
            AudioUtility.SetMasterVolume(1f - PlayerPrefs.GetFloat("volume"));
        }

        private void Update()
        {
            AudioUtility.SetMasterVolume(1f - PlayerPrefs.GetFloat("volume"));
        }

        //void Update()
        //{
        //    if (GameIsEnding)
        //    {
        //        float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / EndSceneLoadDelay;
        //        EndGameFadeCanvasGroup.alpha = timeRatio;

        //        AudioUtility.SetMasterVolume(1 - timeRatio);

        //        // See if it's time to load the end scene (after the delay)
        //        if (Time.time >= m_TimeLoadEndGameScene)
        //        {
        //            SceneManager.LoadScene(m_SceneToLoad);
        //            GameIsEnding = false;
        //        }
        //    }
        //}

        void OnAllObjectivesCompleted(AllObjectivesCompletedEvent evt) => EndGame(true);
        void OnPlayerDeath(PlayerDeathEvent evt) => EndGame(false);

        void EndGame(bool win)
        {
            // unlocks the cursor before leaving the scene, to be able to click buttons
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Remember that we need to load the appropriate end scene after a delay
            GameIsEnding = true;            
            if (win)
            {               
                StartCoroutine(WonGame());            
            }
            else
            {
                StartCoroutine(LostGame());
            }
        }

        private IEnumerator WonGame()
        {
            Time.timeScale = 0;
            m_SceneToLoad = WinSceneName;
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = VictorySound;
            audioSource.playOnAwake = false;
            audioSource.Play();
            yield return new WaitForSecondsRealtime(2.79f);
            SceneManager.LoadScene(m_SceneToLoad);
        }

        private IEnumerator LostGame()
        {
            m_SceneToLoad = SceneManager.GetActiveScene().name;
            EndGameFadeCanvasGroup.gameObject.SetActive(true);
            animator.SetTrigger("FadeOut");
            yield return new WaitForSecondsRealtime(3f);
            SceneManager.LoadScene(m_SceneToLoad);
        }

       

        void OnDestroy()
        {
            EventManager.RemoveListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
        }
    }
}