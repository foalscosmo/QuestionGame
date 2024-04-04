using Buttons;
using TMPro;
using UnityEngine;

namespace Question
{
    // Class responsible for rating player performance based on correct answers
    public class QuestionRate : MonoBehaviour
    {
        // Reference to the TextMeshProUGUI component for displaying the rating text
        [SerializeField] private TextMeshProUGUI rateText;
        
        // Reference to the TextMeshProUGUI component for displaying the correct answer count
        [SerializeField] private TextMeshProUGUI rateIndexText;
        
        // Counter for correct answers
        private int _correctAnswerCount;
        
        // Reference to the answer button container
        [SerializeField] private AnswerButtonContainer answerButtonContainer;
        
        // Reference to the button event handler
        [SerializeField] private ButtonEventHandler buttonEventHandler;

        // Initialize UI elements during Awake
        private void Awake()
        {
            rateText.text = "TERRIBLE";
            rateIndexText.text = _correctAnswerCount + " / 5";
        }

        // Subscribe to events when the object is enabled
        private void OnEnable()
        {
            foreach (var correctAnswer in answerButtonContainer.AnswerButtons) correctAnswer.OnCorrectAnswer += RatePlayer;
            buttonEventHandler.OnStartOverPressed += ResetCorrectAnswerIndex;
        }

        // Unsubscribe from events when the object is disabled
        private void OnDisable()
        {
            foreach (var correctAnswer in answerButtonContainer.AnswerButtons) correctAnswer.OnCorrectAnswer -= RatePlayer;
            buttonEventHandler.OnStartOverPressed -= ResetCorrectAnswerIndex;
        }

        // Update the correct answer count and rating text based on performance
        private void RatePlayer(int index)
        {
            _correctAnswerCount++;
            rateIndexText.text = _correctAnswerCount + " / 5";

            switch (_correctAnswerCount)
            {
                case <= 1:
                    rateText.text = "TERRIBLE";
                    rateText.color = Color.red;
                    break;
                case < 5:
                    rateText.text = "GOOD JOB";
                    rateText.color = Color.yellow;
                    break;
                default:
                    rateText.text = "GREAT JOB";
                    rateText.color = Color.green;
                    break;
            }
        }

        // Reset the correct answer count when starting over
        private void ResetCorrectAnswerIndex ()
        {
            _correctAnswerCount = 0;
            rateIndexText.text = _correctAnswerCount + " / 5";
        }
    }
}