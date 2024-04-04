using System;
using Buttons;
using TMPro;
using UnityEngine;

namespace Question
{
    // Class representing a counter for tracking question indices in a quiz or similar interface
    public class Counter : MonoBehaviour
    {
        // Reference to the TextMeshProUGUI component for displaying the question index
        [SerializeField] private TextMeshProUGUI questionIndexText;
       
        // Current question index
        [SerializeField] private int questionIndex = 1;
        
        // Reference to the button event handler
        [SerializeField] private ButtonEventHandler buttonEventHandler;
       
        // Event invoked when there are no more questions left
        public event Action OnNoQuestionsLeft;
       
        // Subscribe to events when the object is enabled
        private void OnEnable()
        {
            buttonEventHandler.OnPressedDelay += SetQuestionIndex;
            buttonEventHandler.OnStartPressed += SetQuestionText;
        }

        // Unsubscribe from events when the object is disabled
        private void OnDisable()
        {
            buttonEventHandler.OnPressedDelay -= SetQuestionIndex;
            buttonEventHandler.OnStartPressed -= SetQuestionText;
        }

        // Increment the question index and update the question text if not at the end
        private void SetQuestionIndex()
        {
            if (questionIndex < 5)
            {
                questionIndex++;
                SetQuestionText();
            }
            else
            {
                // Invoke event indicating that there are no more questions left
                OnNoQuestionsLeft?.Invoke();
                // Reset question index for the next round
                questionIndex = 1;

            }
        }

        // Update the question text to display the current question index
        private void SetQuestionText()
        {
            questionIndexText.text = questionIndex + " / 5";
        }
    }
}