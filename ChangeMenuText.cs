using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenuText : MonoBehaviour {
    //TextAttributes
    public GameObject Text0;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public GameObject Text8;
    public GameObject Text9;
    public GameObject Text10;
    public GameObject Text11;
    public GameObject Text12;
    public GameObject Text13;
    public bool audioTrue;
    int textCount;
    //Moving the GUI
    public GameObject MainGuiPanel;
    public GameObject GuiTarget;
    public GameObject OutputPanel;
    public GameObject outputTarget;
    //Fade attributes
    public Image fade;
    private bool InTrans;
    private bool isShowing;
    private float duration;
    private float transition;
    //misc
    public Text Menu;
    public MeganEvents megTest;
    //Camera and targets
    public GameObject cam1;
    public GameObject camTarget;
    //Moving Megan
    public GameObject Megan;
    public GameObject megTarget;
    // Use this for initialization
    public Texture[] endingImages;
    public RawImage endScreen;
    void Start() {
        Text0.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        textCount = 0;
        Debug.Log(textCount);
        Menu.GetComponent<Text>().text = Text0.GetComponent<TextMesh>().text;

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //megTest.changeAnimation("Thoughtful"); 
			StartCoroutine(updateText("No, I don't have any weapons on me."));
        }
        if (Input.GetKeyUp(KeyCode.H)) {
            endScene("Hospital");
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            endScene("Jail");
        }
        if (!InTrans)
        {
            return;
        }
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fade.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        if (transition > 1 || transition < 0)
            InTrans = false;
    }

    // Update is called once per frame
    public void callupdateText(string response) {
        StartCoroutine("updateText", response);
    }

    public IEnumerator updateText(string response) {

        if (response == "The pharmacist is refusing to fill my medication. I'm trying to explain it to her, that I need my medication now.")
        {
            audioTrue = true;
            megTest.changeAnimation("Happy");
            //Text0.SetActive(false);
            //Text1.SetActive(true);
            megTest.playAudio("prog1");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text1.GetComponent<TextMesh>().text;
        }
        else if (response == "No, I don't have any weapons on me.")
        {
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
            
			megTest.playAudio("prog2");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text2.GetComponent<TextMesh>().text;
        }
        else if (response == "No, I have not taken any drugs today.")
        {
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
          
			megTest.playAudio("prog3");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text3.GetComponent<TextMesh>().text;
        }
        else if (response == "No, I haven't had anything to drink either. I need my medication, is there anybody that can help me?")
        {
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
            
			megTest.playAudio("prog4");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text4.GetComponent<TextMesh>().text;
        }
        else if (response == "Thank you, officer. I'm overwhelmed because this pharmacist isn't helping me refill my medication. I'm going through a panic attack because I don't have my medication, and it seems like nobody understands how serious this is!")
        {
            audioTrue = true;
            megTest.changeAnimation("Happy");
           
			megTest.playAudio("prog5");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text5.GetComponent<TextMesh>().text;
        }
        else if (response == "Okay, but I need my medication after. These panic attacks get so intense, I - I just don't feel in control without my pills.")
        {
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
            
			megTest.playAudio("prog6");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text6.GetComponent<TextMesh>().text;
        }
        else if (response == "Yes, that's exactly it. Can you explain that to the pharmacist?")
        {
            audioTrue = true;
            megTest.playAudio("prog7");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text7.GetComponent<TextMesh>().text;
        }
        else if (response == "I just can't get my medication otherwise! Look, all I need is one refill. That's it!")
        {

            audioTrue = true;
            megTest.playAudio("prog8");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text8.GetComponent<TextMesh>().text;

        }
        else if (response == "Okay we can move to another room. But I am not leaving the pharmacy until I get my refill.")
        {
            audioTrue = true;
            megTest.playAudio("prog9");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text9.GetComponent<TextMesh>().text;
            StartCoroutine("Pause", 6);
        }
        else if (response == "For two years, but my panic attacks have never been this bad before.")
        {
            audioTrue = true;
            megTest.playAudio("prog10");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text10.GetComponent<TextMesh>().text;
        }
        else if (response == " I just got a new job, and I don’t want to jeopardize it. If they see me like this, who knows what they'll think?")
        {

            audioTrue = true;
            megTest.playAudio("prog11");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text11.GetComponent<TextMesh>().text;
        }
        else if (response == "I see a doctor from Meridian Clinic.")
        {
            //call megan's doctor
            audioTrue = true;
            megTest.playAudio("prog12");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text12.GetComponent<TextMesh>().text;
        }
        else if (response == "Okay, we can call my doctor.")
        {
           

            audioTrue = true;
            megTest.playAudio("prog13");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text13.GetComponent<TextMesh>().text;
        }
        else if (response == "I'll call someone.")
        {
            //end scene after this audio
            audioTrue = true;
            megTest.playAudio("prog13");
            yield return new WaitForSeconds(2);
            Fade(true, 3);
            endScreen.texture = endingImages[2];
            endScreen.enabled = true;
        }
        else
        {
            textCount = 0;
        }
    }
    public void Fade(bool showing, float duration)
    {
        
        isShowing = showing;
        InTrans = true;
        this.duration = duration;
        transition = isShowing ? 0 : 1;
        
    }
    public IEnumerator Pause(float duration) {
        Debug.Log("In-Coroutine");
        yield return new WaitForSeconds(duration);
        Fade(true, 2);
        
        yield return new WaitForSecondsRealtime(2);
        //screen should be black, pause scene and move assets
        cam1.transform.position = camTarget.transform.position;
        cam1.transform.rotation = camTarget.transform.rotation;
        Megan.transform.position = megTarget.transform.position;
        Megan.transform.rotation = megTarget.transform.rotation;
        MainGuiPanel.transform.position = GuiTarget.transform.position;
        MainGuiPanel.transform.rotation = GuiTarget.transform.rotation;
        OutputPanel.transform.position = outputTarget.transform.position;
        OutputPanel.transform.rotation = outputTarget.transform.rotation;
        yield return new WaitForSecondsRealtime(1);
        Fade(false, 2);
        Debug.Log("Out-Coroutine");
    }

    public void endScene(string ending) {
        if (ending == "Hospital")
        {
            //fade to black and display hospital jpg
            Fade(true, 3);
            endScreen.texture = endingImages[0];
            endScreen.enabled = true;
        }    

        if (ending == "Jail") {
            //fade to black and display jail jpg;
            Fade(true,3);
            endScreen.texture = endingImages[1];
            endScreen.enabled = true;
        }

    }
}
		
	

