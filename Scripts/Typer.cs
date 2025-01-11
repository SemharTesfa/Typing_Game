using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    public Text wordOutput = null;
    public Text resultOutput = null; // UI Text for displaying results
    public Text speedOutput = null; // UI Text for displaying typing speed
    public Animator animator; // Animator component for Walk_0 object
    public GameObject walkObject; // Reference to the Walk_0 GameObject

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private int correctCharacterCount = 0; // Count of correct characters
    private int wrongCharacterCount = 0;   // Count of incorrect characters
    private bool gameEnded = false; // To track if the game has ended
    private float fallSpeed; // Current speed of the text falling
    private float initialFallSpeed = 200f; // Initial speed of the text falling
    private float fallSpeedIncreaseRate = 5f; // Rate at which the fall speed increases
    private float wordStartTime; // Time when a new word is set
    private float totalTypingTime = 0f; // Total time spent typing
    private int wordsTyped = 0; // Number of words typed correctly
    public AudioSource audioSource;

    private void Start()
    {
        fallSpeed = initialFallSpeed;
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        if (wordBank.HasWords())
        {
            currentWord = wordBank.GetWord();
            SetRemainingWord(currentWord);
            wordOutput.rectTransform.anchoredPosition = new Vector2(0, Screen.height);
            wordStartTime = Time.time; // Start timer for this word
        }
        else
        {
            EndGame();
        }
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        if (!gameEnded)
        {
            MoveTextDown();
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            if (keyPressed.Length == 1)
            {
                // Check if the key pressed is a letter or allowed control character
                if (char.IsLetter(keyPressed[0]))
                {
                    EnterLetter(keyPressed.ToLower());
                }
                else if (keyPressed[0] == ' ' || keyPressed[0] == '\n' || keyPressed[0] == '\r') // Space or Enter key
                {
                    // Ignore these keys or perform an action like starting the game
                    // You can put some optional code here if needed (e.g., StartGameIfNeeded())
                }
            }
        }
    }




    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            correctCharacterCount++;
            RemoveLetter(); // Remove the letter only if it's correct
            if (animator != null)
            {
                animator.SetTrigger("Walk"); // Trigger the walking animation
            }
            MoveBotForward();

            if (IsWordComplete())
            {
                wordsTyped++;
                fallSpeed += fallSpeedIncreaseRate; // Increase text fall speed if applicable
                totalTypingTime += Time.time - wordStartTime; // Update typing time
                UpdateTypingSpeed(); // Update displayed typing speed
                SetCurrentWord(); // Reset for a new word
            }
        }
        else
        {
            wrongCharacterCount++;
            if (audioSource != null)
            {
                audioSource.Play();  // Play the sound for wrong input
            }

            RemoveLetter(); // Remove the letter even if it's wrong
        }
    }

    private void MoveBotForward()
    {
        float moveDistance = 0.1f; // Adjust this value based on the desired speed and response feel
        if (walkObject != null)
        {
            walkObject.transform.Translate(Vector2.right * moveDistance); // Move right in 2D space
        }
        else
        {
            Debug.Log("Walk_0 reference not set.");
        }
    }

    private void UpdateTypingSpeed()
    {
        if (speedOutput != null && wordsTyped > 0)
        {
            float typingSpeed = (wordsTyped / totalTypingTime) * 60f; // Calculate WPM
            speedOutput.text = "Speed: " + typingSpeed.ToString("F2") + " WPM";
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.ToLower().IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        if (!string.IsNullOrEmpty(remainingWord) && remainingWord.Length > 0)
        {
            // Safely remove the first character
            remainingWord = remainingWord.Substring(1);
            SetRemainingWord(remainingWord);
            MoveBotForward(); // Move the character when a letter is removed
        }
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void MoveTextDown()
    {
        wordOutput.rectTransform.anchoredPosition += new Vector2(0, -fallSpeed * Time.deltaTime);
        if (wordOutput.rectTransform.anchoredPosition.y < -Screen.height)
        {
            SetCurrentWord();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        wordOutput.text = ""; // Clear the word output

        if (resultOutput != null)
        {
            float finalTypingSpeed = (wordsTyped > 0) ? (wordsTyped / totalTypingTime) * 60f : 0;
            resultOutput.text = "Game Over!\n" +
                                "Correct Characters: " + correctCharacterCount + "\n" +
                                "Wrong Characters: " + wrongCharacterCount + "\n" +
                                "Typing Speed: " + finalTypingSpeed.ToString("F2") + " WPM";
        }
        else
        {
            Debug.LogError("ResultOutput Text is not assigned!");
        }
    }
}