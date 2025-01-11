using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{

    //word list with 10 random words
    private List<string> originalWords = new List<string>
{
    "rocket", "planet", "star", "comet",
    "galaxy", "orbit", "satellite", "cosmos", "astronaut", "universe",
    "sun", "moon"
};

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        workingWords.AddRange(originalWords);  // Copy original words to workingWords
        Shuffle(workingWords);                 // Shuffle the words for randomness
        ConvertToLowerCase(workingWords);      // Convert all words to lowercase
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void ConvertToLowerCase(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;
        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }

    public bool HasWords()
    {
        return workingWords.Count > 0;
    }
}
