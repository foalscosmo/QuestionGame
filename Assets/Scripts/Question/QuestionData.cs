using UnityEngine;

namespace Question
{
    // ScriptableObject representing a question data
    [CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
    public class QuestionData : ScriptableObject
    {
        // The question text
        public string question;
       
        [Tooltip("The correct answer should always be listed first, they are randomized later")]
        public string[] answers;
    }
}
