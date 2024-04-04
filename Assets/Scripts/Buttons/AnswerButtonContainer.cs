using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    // Class representing a container for answer buttons in a quiz or similar interface
    public class AnswerButtonContainer : MonoBehaviour
    {
        // Array of answer buttons contained within this container
        [SerializeField] private AnswerButton[] answerButtons;

        // Property to access the answer buttons array as an enumerable
        public IEnumerable<AnswerButton> AnswerButtons => answerButtons;

        // List of additional UI buttons within the container
        [SerializeField] private List<Button> buttons = new();
        
        // Property to access the list of UI buttons
        public List<Button> Buttons => buttons;
    }
}