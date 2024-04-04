using System;
using TMPro;
using UnityEngine;

namespace Buttons
{
    // Class representing an answer button in a quiz or similar interface
    public class AnswerButton : MonoBehaviour
    {
        // Reference to the TextMeshProUGUI component for displaying answer text
        [SerializeField] private TextMeshProUGUI answerText;
        
        // Index of the answer
        [SerializeField] private int index;
        
        // Flag indicating whether this answer is correct or not
        public bool isCorrect;
        
        // Event invoked when the correct answer is selected
        public event Action<int> OnCorrectAnswer;
        
        // Event invoked when a wrong answer is selected
        public event Action<int> OnWrongAnswer;
        
        // Event invoked when any answer is pressed
        public event Action OnAnswerPressed;

        // Method to set the text of the answer button
        public void SetAnswerText(string newText)
        {
            answerText.text = newText;
        }

        // Method to set whether the answer is correct or not
        public void SetIsCorrect(bool newBool)
        {
            isCorrect = newBool;
        }
        
        // Method called when the button is clicked
        public void OnClick()
        {
            // Invoke the event indicating that an answer has been pressed
            OnAnswerPressed?.Invoke();
            
            // Check if the answer is correct and invoke the corresponding event
            switch (isCorrect)
            {
                case true:
                    OnCorrectAnswer?.Invoke(index);
                    break;
                default:
                    OnWrongAnswer?.Invoke(index);
                    break;
            }
        }
    }
}