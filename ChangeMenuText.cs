using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


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
	public GameObject TranscriptPanel;
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
	public Text Transcript;
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
	public string transcriptOutput;
	public string DesktopPath;



    void Start() {
		DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
		DesktopPath += "\\PharmacySimTranscript.txt";
        Text0.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        textCount = 0;
        Debug.Log(textCount);
        Menu.GetComponent<Text>().text = Text0.GetComponent<TextMesh>().text;
		Transcript.text = "USER SUGGESTIONS\r\n" +
			"1) What seems to be the problem here?\r\n" +
			"2) Are you carrying any weapons?\r\n" +
			"3) Have you taken any drugs today?\r\n" +
			"4) Are you under the influence of alcohol?\r\n" +
			"5) I am officer _____ and I am here to help you.\r\n" +
			"6) Take deep breaths.\r\n" +
			"7) I understand you are feeling stressed.\r\n" +
			"8) Remember, you cannot do anything illegal.\r\n" +
			"9) Can we move to a more private locations?\r\n" +
			"10) How long have you had anxiety?.\r\n" +
			"11) What causes you're anxiety?\r\n" +
			"12) Do you see a doctor?\r\n" +
			"13) Call your doctor to set up an appointment.\r\n" +
			"14) Call someone to take you home.\r\n\r\n\r\nTRANSCRIPT\r\n";

    }
    private void Update()
    {
		if (Input.GetKeyUp(KeyCode.Space))
		{
			callupdateText ("skip");
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
		if (response == "skip") {
			textCount++;
			Transcript.text += "User skipped, see USER SUGGESTION number ";
			Transcript.text += textCount;
			Transcript.text += "\r\n";
			Debug.Log (textCount);
		}


        if (textCount == 1 || response == "The pharmacist is refusing to fill my medication. I'm trying to explain it to her, that I need my medication now.")
        {
			textCount=1;
            audioTrue = true;
            megTest.changeAnimation("Happy");
            //Text0.SetActive(false);
            //Text1.SetActive(true);
            megTest.playAudio("prog1");
			Transcript.text += "Megan: The pharmacist is refusing to fill my medication. I'm trying to explain it to her, that I need my medication now";
			Transcript.text += "\r\n\r\n";
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text1.GetComponent<TextMesh>().text;

        }
        else if (textCount == 2 || response == "No, I don't have any weapons on me.")
        {
			textCount = 2;
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
			Transcript.text += "Megan: No, I don't have any weapons on me.";
			Transcript.text += "\r\n\r\n";
			megTest.playAudio("prog2");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text2.GetComponent<TextMesh>().text;

        }
		else if (textCount == 3 || response == "No, I have not taken any drugs today.")
        {
			textCount = 3;
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
			Transcript.text += "Megan: No, I have not taken any drugs today.";
			Transcript.text += "\r\n\r\n";
			megTest.playAudio("prog3");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text3.GetComponent<TextMesh>().text;

        }
		else if (textCount == 4 || response == "No, I haven't had anything to drink either. I need my medication, is there anybody that can help me?")
        {
			textCount = 4;
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
			Transcript.text += "Megan: No, I haven't had anything to drink either. I need my medication, is there anybody that can help me?";
			Transcript.text += "\r\n\r\n";
			megTest.playAudio("prog4");
            yield return new WaitForSeconds(2);
			Menu.GetComponent<Text>().text = Text4.GetComponent<TextMesh>().text;

        }
		else if (textCount == 5 || response == "Thank you, officer. I'm overwhelmed because this pharmacist isn't helping me refill my medication. I'm going through a panic attack because I don't have my medication, and it seems like nobody understands how serious this is!")
        {
			textCount = 5;
            audioTrue = true;
            megTest.changeAnimation("Happy");
			Transcript.text += "Megan: Thank you, officer. I'm overwhelmed because this pharmacist isn't helping me refill my medication. I'm going through a panic attack because I don't have my medication, and it seems like nobody understands how serious this is!";
			Transcript.text += "\r\n\r\n";
			megTest.playAudio("prog5");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text5.GetComponent<TextMesh>().text;

        }
		else if (textCount == 6 || response == "Okay, but I need my medication after. These panic attacks get so intense, I - I just don't feel in control without my pills.")
        {
			textCount = 6;
            audioTrue = true;
            megTest.changeAnimation("Thoughtful");
			Transcript.text += "Megan: Okay, but I need my medication after. These panic attacks get so intense, I - I just don't feel in control without my pills.";
			Transcript.text += "\r\n\r\n";
			megTest.playAudio("prog6");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text6.GetComponent<TextMesh>().text;
        }
		else if (textCount == 7 || response == "Yes, that's exactly it. Can you explain that to the pharmacist?")
        {
			textCount = 7;
            audioTrue = true;
			Transcript.text += "Megan: Yes, that's exactly it. Can you explain that to the pharmacist?";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog7");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text7.GetComponent<TextMesh>().text;
        }
		else if (textCount == 8 || response == "I just can't get my medication otherwise! Look, all I need is one refill. That's it!")
        {
			textCount = 8;
            audioTrue = true;
			Transcript.text += "Megan: I just can't get my medication otherwise! Look, all I need is one refill. That's it!";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog8");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text8.GetComponent<TextMesh>().text;

        }
		else if (textCount == 9 || response == "Okay we can move to another room. But I am not leaving the pharmacy until I get my refill.")
        {
			textCount = 9;
            audioTrue = true;
			Transcript.text += "Megan: Okay we can move to another room. But I am not leaving the pharmacy until I get my refill.";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog9");

            StartCoroutine("Pause", 6);
			Menu.GetComponent<Text>().text = Text9.GetComponent<TextMesh>().text;
        }
		else if (textCount == 10 || response == "For two years, but my panic attacks have never been this bad before.")
        {
			textCount = 10;
            audioTrue = true;
			Transcript.text += "Megan: For two years, but my panic attacks have never been this bad before.";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog10");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text10.GetComponent<TextMesh>().text;
        }
		else if (textCount == 11 || response == " I just got a new job, and I don’t want to jeopardize it. If they see me like this, who knows what they'll think?")
        {
			textCount = 11;
            audioTrue = true;
			Transcript.text += "Megan: I just got a new job, and I don’t want to jeopardize it. If they see me like this, who knows what they'll think?";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog11");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text11.GetComponent<TextMesh>().text;
        }
		else if (textCount == 12 || response == "I see a doctor from Meridian Clinic.")
        {
			textCount=12;
            //call megan's doctor
            audioTrue = true;
			Transcript.text += "Megan: I see a doctor from Meridian Clinic.";
			Transcript.text += "\r\n\r\n";
            megTest.playAudio("prog12");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text12.GetComponent<TextMesh>().text;
        }
		else if (textCount == 13 || response == "Okay, we can call my doctor.")
        {
			textCount = 13;
			Transcript.text += "Megan: Okay, we can call my doctor.";
			Transcript.text += "\r\n\r\n";
            audioTrue = true;
            megTest.playAudio("prog13");
            yield return new WaitForSeconds(2);
            Menu.GetComponent<Text>().text = Text13.GetComponent<TextMesh>().text;
        }
		else if (textCount == 14 || response == "I'll call someone.")
        {
			textCount = 14;
            //end scene after this audio
            audioTrue = true;
            megTest.playAudio("prog14");
			Transcript.text += "Megan: I'll call someone.";
			Transcript.text += "\r\n\r\n";
            yield return new WaitForSeconds(2);
			Transcript.text += "SITUATION DEESCALATED \r\nEND OF SIMULATION";
			transcriptOutput = Transcript.text;
			System.IO.File.WriteAllText(DesktopPath,transcriptOutput);
            Fade(true, 3);
            endScreen.texture = endingImages[2];
            endScreen.enabled = true;
        }

        else
        {
            //textCount = 0;
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
			Menu.GetComponent<Text> ().text = "Are your sure you want to take Megan to the Hospital?? Press up on the touch pad if yes, down on the touch pad if no";
            //if yes then
			//fade to black and display hospital jpg
            Fade(true, 3);
            endScreen.texture = endingImages[0];
            endScreen.enabled = true;
			Transcript.text += "MEGAN TAKEN TO HOSPITAL \r\nEND OF SIMULATION";
			transcriptOutput = Transcript.text;
			System.IO.File.WriteAllText(DesktopPath,transcriptOutput);

			//if no restore menu

        }    

        if (ending == "Jail") {
			Menu.GetComponent<Text> ().text = "Are your sure you want to arrest Megan? Press up on the touch pad if yes, down on the touch pad if no";
            //fade to black and display jail jpg;
			//if yes continue
            Fade(true,3);
            endScreen.texture = endingImages[1];
            endScreen.enabled = true;
			Transcript.text += "MEGAN ARRESTED \r\nEND OF SIMULATION";
			transcriptOutput = Transcript.text;
			System.IO.File.WriteAllText(DesktopPath,transcriptOutput);
			//if no restore menu
        }

    }
}
		
	

