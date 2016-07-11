using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {

        keywords.Add("Toggle Follow", () =>
        {
            if (Map.Instance != null)
                Map.Instance.Follow = !Map.Instance.Follow;
        });

        keywords.Add("Toggle Mapping", () =>
        {
            if (SpatialMapping.Instance != null)
                SpatialMapping.Instance.DrawVisualMeshes = !SpatialMapping.Instance.DrawVisualMeshes;
        });

        keywords.Add("Toggle Cylinders", () =>
        {
            CylHelper.DebugEnabled = !CylHelper.DebugEnabled;
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}