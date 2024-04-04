using UnityEngine;

namespace Buttons
{
    // Class responsible for managing button colors in a quiz or similar interface
    public class ButtonColorManager : MonoBehaviour
    {
        // Default color for buttons
        [SerializeField] private Color defaultColor;
        
        // Color for indicating a wrong answer
        [SerializeField] private Color wrongColor;
        
        // Color for indicating a correct answer
        [SerializeField] private Color correctColor;
        
        // Reference to the answer button container
        [SerializeField] private AnswerButtonContainer answerButtonContainer;
        
        // Reference to the button event handler
        [SerializeField] private ButtonEventHandler buttonEventHandler;

        // Subscribe to events when the object is enabled
        private void OnEnable()
        {
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnCorrectAnswer += SetCorrectColor;
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnWrongAnswer += SetWrongColor;
            buttonEventHandler.OnPressedDelay += SetDefaultColor;
        }

        // Unsubscribe from events when the object is disabled
        private void OnDisable()
        {
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnCorrectAnswer -= SetCorrectColor;
            foreach (var button in answerButtonContainer.AnswerButtons) button.OnWrongAnswer -= SetWrongColor;
            buttonEventHandler.OnPressedDelay -= SetDefaultColor;
        }

        // Set the color for indicating a wrong answer
        private void SetWrongColor(int index)
        {
            answerButtonContainer.Buttons[index].targetGraphic.color = wrongColor;
            ButtonInteractableCondition(false);
        }

        // Set the color for indicating a correct answer
        private void SetCorrectColor(int index)
        {
            answerButtonContainer.Buttons[index].targetGraphic.color = correctColor;
            ButtonInteractableCondition(false);
        }

        // Set the default color for buttons
        private void SetDefaultColor()
        {
            foreach (var buttonColor in answerButtonContainer.Buttons) buttonColor.targetGraphic.color = defaultColor;
            ButtonInteractableCondition(true);
        }
    
        // Set the interactable state of buttons
        private void ButtonInteractableCondition(bool isActive)
        {
            foreach (var button in answerButtonContainer.Buttons) button.interactable = isActive;
        }
    }
}