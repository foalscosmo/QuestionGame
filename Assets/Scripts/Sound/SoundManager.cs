using Buttons;
using UnityEngine;

namespace Sound
{
    /// <summary>
    /// Manages sound effects for the game, playing specific sounds when correct or wrong answers are given.
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
         [SerializeField] private AnswerButtonContainer answerButtonContainer; // Reference to the container holding answer buttons
        [SerializeField] private ButtonEventHandler buttonEventHandler; // Reference to the button event handler
        [SerializeField] private AudioSource audioSource; // Reference to the audio source component
        [SerializeField] private AudioClip wrongSound; // Sound to play for wrong answers
        [SerializeField] private AudioClip correctSound; // Sound to play for correct answers
        [SerializeField] private AudioClip buttonPressedSound; // Sound to play when buttons are pressed

        /// <summary>
        /// Called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Subscribe to events for each answer button
            foreach (var button in answerButtonContainer.AnswerButtons)
            {
                button.OnCorrectAnswer += PlayCorrectSound;
                button.OnWrongAnswer += PlayWrongSound;
            }

            // Subscribe to events for button press
            buttonEventHandler.OnStartPressed += PlayClickSound;
            buttonEventHandler.OnStartOverPressed += PlayClickSound;
        }

        /// <summary>
        /// Called when the behaviour becomes disabled or inactive.
        /// </summary>
        private void OnDisable()
        {
            // Unsubscribe from events for each answer button
            foreach (var button in answerButtonContainer.AnswerButtons)
            {
                button.OnCorrectAnswer -= PlayCorrectSound;
                button.OnWrongAnswer -= PlayWrongSound;
            }

            // Unsubscribe from events for button press
            buttonEventHandler.OnStartPressed -= PlayClickSound;
            buttonEventHandler.OnStartOverPressed -= PlayClickSound;
        }

        /// <summary>
        /// Plays the sound for a correct answer.
        /// </summary>
        /// <param name="index">Index of the answer button</param>
        private void PlayCorrectSound(int index)
        {
            audioSource.clip = correctSound; // Set the audio clip to the correct sound
            audioSource.Play(); // Play the audio
        }

        /// <summary>
        /// Plays the sound for a wrong answer.
        /// </summary>
        /// <param name="index">Index of the answer button</param>
        private void PlayWrongSound(int index)
        {
            audioSource.clip = wrongSound; // Set the audio clip to the wrong sound
            audioSource.Play(); // Play the audio
        }

        /// <summary>
        /// Plays the sound when a button is pressed.
        /// </summary>
        private void PlayClickSound()
        {
            audioSource.clip = buttonPressedSound; // Set the audio clip to the button pressed sound
            audioSource.Play(); // Play the audio
        }
    }
}

