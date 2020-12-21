using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionController1 : MonoBehaviour
{
    private KeywordRecognizer recEngine;
    private Dictionary<string, Action> Commands = new Dictionary<string, Action>();

    private void Start()
    {
        Commands.Add("forward", Forward);
        Commands.Add("back", Back);
        Commands.Add("up", Up);
        Commands.Add("down", Down);

        recEngine = new KeywordRecognizer(Commands.Keys.ToArray());
        recEngine.OnPhraseRecognized += SpeechRecognized;
        recEngine.Start();
    }

    private void SpeechRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        Commands[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }
}
