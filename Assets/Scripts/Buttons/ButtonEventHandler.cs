using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    // Class handling events for various buttons in a quiz or similar interface
    public class ButtonEventHandler : MonoBehaviour
    {
        // Reference to the answer button container
        [SerializeField] private AnswerButtonContainer answerButtonContainer;
       
        // Reference to the start button
        [SerializeField] private Button startButton;
        
        // Reference to the start over button
        [SerializeField] private Button startOverButton;
        
        // Event invoked after a delay when any answer button is pressed
        public event Action OnPressedDelay;
        
        // Event invoked when the start button is pressed
        public event Action OnStartPressed;
        
        // Event invoked when the start over button is pressed
        public event Action OnStartOverPressed;

        // Subscribe to button click events during initialization
        private void Awake()
        {
            startButton.onClick.AddListener(StartButtonPressed);
            startOverButton.onClick.AddListener(StartOverButtonPressed);

        }

        // Subscribe to answer button press events when the object is enabled
        private void OnEnable()
        {
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnAnswerPressed += InvokePressedEvent;
        }

        // Unsubscribe from answer button press events when the object is disabled
        private void OnDisable()
        {
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnAnswerPressed -= InvokePressedEvent;
        }

        // Invoke the event after a delay when any answer button is pressed
        private void InvokePressedEvent()
        {
            StartCoroutine(InvokePressedEventDelay());
        }

        // Coroutine to delay invoking the pressed event
        private IEnumerator InvokePressedEventDelay()
        {
            yield return new WaitForSecondsRealtime(2f);
            OnPressedDelay?.Invoke();
        }

        // Invoke the event when the start button is pressed
        private void StartButtonPressed()
        {
            OnStartPressed?.Invoke();
        }
    
        // Invoke the event when the start over button is pressed
        private void StartOverButtonPressed()
        {
            OnStartOverPressed?.Invoke();
        }
    }
}