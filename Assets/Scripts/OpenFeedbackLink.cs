using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFeedbackLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void FeedbackLink()
    {
        Application.OpenURL("https://forms.gle/8hMtNr1cK9ER42Ee7");
    }
}
