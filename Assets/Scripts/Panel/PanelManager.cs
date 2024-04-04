using Buttons;
using Question;
using UnityEngine;

namespace Panel
{
    // Class managing different panels (start, game, finish) in a quiz or similar interface
    public class PanelManager : MonoBehaviour
    {
        // Reference to the start panel GameObject
        [SerializeField] private GameObject startPanel;
       
        // Reference to the game panel GameObject
        [SerializeField] private GameObject gamePanel;
        
        // Reference to the finish panel GameObject
        [SerializeField] private GameObject finishPanel;
        
        // Reference to the button event handler
        [SerializeField] private ButtonEventHandler buttonEventHandler;
        
        // Reference to the counter
        [SerializeField] private Counter counter;

        // Initialize panel states during Awake
        private void Awake()
        {
            startPanel.SetActive(true);
            gamePanel.SetActive(false);
            finishPanel.SetActive(false);
        }

        // Subscribe to events when the object is enabled
        private void OnEnable()
        {
            buttonEventHandler.OnStartPressed += GamePanel;
            buttonEventHandler.OnStartOverPressed += StartPanel;
            counter.OnNoQuestionsLeft += FinishPanel;
        }

        // Unsubscribe from events when the object is disabled
        private void OnDisable()
        {
            buttonEventHandler.OnStartPressed -= GamePanel;
            buttonEventHandler.OnStartOverPressed -= StartPanel;
            counter.OnNoQuestionsLeft -= FinishPanel;
        }

        // Switch to the start panel
        private void StartPanel()
        {
            if (gamePanel.activeSelf) gamePanel.SetActive(false);
            if (finishPanel.activeSelf) finishPanel.SetActive(false);
            startPanel.SetActive(true);
        }

        // Switch to the game panel
        private void GamePanel()
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
        }

        // Switch to the finish panel
        private void FinishPanel()
        {
            gamePanel.SetActive(false);
            finishPanel.SetActive(true);
        }
    }
}