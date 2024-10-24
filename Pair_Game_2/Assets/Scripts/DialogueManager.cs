using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    private bool gottaChoose;
    [SerializeField] private Animator portraitAnimator;

    [Header ("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    //tags. add more as needed
    private const string PORTRAIT_TAG = "portrait";
    private const string SPEAKER_TAG = "speaker";

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("wtf there's another dialogue manager");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        gottaChoose = false;

        //get choices stuff
        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing. todo test if using z twice is bad
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying=false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue && !gottaChoose)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();

            //handle tags
            HandleTags(currentStory.currentTags);
        }
        else if(!gottaChoose)
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            //parse into kv pair
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagVal = splitTag[1].Trim();

            //handle the Tag
            switch(tagKey)
            {
                case PORTRAIT_TAG:
                    Debug.Log("portrait=" + tagVal);
                    portraitAnimator.Play(tagVal);
                    break;
                default:
                    Debug.Log("ayo wtf?");
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //too many choices for UI
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than UI can support. # choices: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            gottaChoose=true;
            index++;
        }

        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        gottaChoose=false;
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
