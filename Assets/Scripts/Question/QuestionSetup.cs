using System.Collections.Generic;
using Buttons;
using TMPro;
using UnityEngine;

namespace Question
{
    // Class responsible for setting up questions and answers in a quiz or similar interface
    public class QuestionSetup : MonoBehaviour
    {
        // List of question data assets
        [SerializeField] private List<QuestionData> questions;
        
        // Reference to the TextMeshProUGUI component for displaying the question
        [SerializeField] private TextMeshProUGUI questionText;
        
        // Array of answer buttons
        [SerializeField] private AnswerButton[] answerButtons;
       
        // Reference to the button event handler
        [SerializeField] private ButtonEventHandler buttonEventHandler;
        
        // Index of the correct answer choice
        [SerializeField] private int correctAnswerChoice;
        
        // The currently selected question
        private QuestionData _currentQuestion;

        // Initialize question assets during Awake
        private void Awake()
        {
            GetQuestionAssets();
        }

        // Subscribe to events when the object is enabled
        private void OnEnable()
        {
            buttonEventHandler.OnStartPressed += SetNewQuestion;
            buttonEventHandler.OnPressedDelay += SetNewQuestion;
            if (buttonEventHandler != null) buttonEventHandler.OnStartOverPressed += GetQuestionAssets;
        }

        // Unsubscribe from events when the object is disabled
        private void OnDisable()
        {
            buttonEventHandler.OnStartPressed -= SetNewQuestion;
            buttonEventHandler.OnPressedDelay -= SetNewQuestion;
            if (buttonEventHandler != null) buttonEventHandler.OnStartOverPressed -= GetQuestionAssets;
        }
        
        // Set up a new question
        private void SetNewQuestion()
        {
            // Exit if there are no questions left
            if(questions.Count == 0) return;
            
            // Select a new question
            SelectNewQuestion();
           
            // Set question text and answer choices
            SetQuestionValues();
            
            SetAnswerValues();
        }

        // Load question assets from resources
        private void GetQuestionAssets()
        {
            questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
        }

        // Select a new question from the available list
        private void SelectNewQuestion()
        {
            var randomQuestionIndex = Random.Range(0, questions.Count);
            _currentQuestion = questions[randomQuestionIndex];
            questions.RemoveAt(randomQuestionIndex);
        }

        // Set the question text
        private void SetQuestionValues()
        {
            questionText.text = _currentQuestion.question;
        }

        // Set up answer choices, including randomization
        private void SetAnswerValues()
        {
            var answers = RandomizeAnswers(new List<string>(_currentQuestion.answers));

            for (var i = 0; i < answerButtons.Length; i++)
            {
                var isCorrect = i == correctAnswerChoice;
                answerButtons[i].SetIsCorrect(isCorrect);
                answerButtons[i].SetAnswerText(answers[i]);
            }
        }

        // Randomize the order of answer choices
        private List<string> RandomizeAnswers(List<string> originalList)
        {
            var correctAnswerChosen = false;
            var  newList = new List<string>();
            for(var i = 0; i < answerButtons.Length; i++)
            {
                var random = Random.Range(0, originalList.Count);
                if(random == 0 && !correctAnswerChosen)
                {
                    correctAnswerChoice = i;
                    correctAnswerChosen = true;
                }
                newList.Add(originalList[random]);
                originalList.RemoveAt(random);  
            }
            return newList;
        }
    }
}
