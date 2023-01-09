using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class FramePrinter : MonoBehaviour
{
    public FrameData frames;
    public int fps = 30;
    public int segmentLength = 30;
    private int currentFrame;
    private float interval;
    public AudioSource videoAudio;

    private void Start()
    {
        interval = fps * 0.001f;
        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        //yield return null;
        videoAudio.Play();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PrintFrames());
    }

    private void PrintFrame(TextAsset frame)
    {
        String[] segmentedStrings = frame.text.Split('\n');
        foreach (String s in segmentedStrings)
        {
            Debug.LogError(s);
        }
    }

    private IEnumerator PrintFrames()
    {
        while (currentFrame < frames.frames.Length)
        {
            Debug.ClearDeveloperConsole();
            PrintFrame(frames.frames[currentFrame]);
            currentFrame++;
            yield return new WaitForSeconds(interval);
        }
    }
}
