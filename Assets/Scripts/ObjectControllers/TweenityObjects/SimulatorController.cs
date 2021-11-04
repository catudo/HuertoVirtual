//
//  SimulatorController.cs
//  Tweenity
//
//  Created by Vivian Gómez.
//  Copyright © 2021 Vivian Gómez - Pablo Figueroa - Universidad de los Andes
//

using System;
using System.Threading.Tasks;
using UnityEngine;

public class SimulatorController : MonoBehaviour
{
    public DialogueViewer dialogueViewer;

    public void ShowReminder(object countdown, object activeObject)
    {
        Debug.Log(activeObject.ToString().Trim());
        GameObject.Find("Reminder").GetComponent<ReminderController>().MoveOverObject(activeObject.ToString().Trim());
    }

    public int Wait(object time)
    {
        return Convert.ToInt32(time) * 1000;
    }

    public void InitializeAudiosDirectory(string dirAudio)
    {
        SimulationController.currentDirectoryAudios = dirAudio;
    }

    public int Play(object audioName)
    {
        return VoiceController.PlayVoice(audioName.ToString());
    }

    public void OpenDialogueViewer()
    {
        Debug.Log("Entering Open Dialogue Viewer");
        dialogueViewer.OpenDialogue();
    }

    public void CloseDialogueViewer()
    {
        dialogueViewer.CloseDialogue();
    }

    public void ChangeX()
    {
        dialogueViewer.transform.position = new Vector3(4f, 0.43f, 6.31f);
    }
}
