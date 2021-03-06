using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System; // Actionに必要

public class TimelineUiController : MonoBehaviour
{
    [SerializeField]
    PlayableDirector timeline;

    [SerializeField]
    Slider slider;

    [SerializeField]
    GameObject playButton;

    [SerializeField]
    GameObject pauseButton;

    double length;

    float sliderValue;
    float sliderValueStored;
    float time;

    private void Start()
    {
        length = timeline.duration;
        Play();
    }

    void Update()
    {
        sliderValue = slider.value;
        time = ConvertDtoF(timeline.time);

        if (time >= 0.995 && timeline.extrapolationMode != DirectorWrapMode.Loop)
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
        }

        if (sliderValue != sliderValueStored)
        {
            sliderValueStored = sliderValue;
            time = sliderValue;
            SetTimelineTime(time);
        }
        else if (time != sliderValueStored)
        {
            slider.value = time;
            sliderValueStored = time;
        }
    }

    public void Play()
    {
        timeline.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Stop()
    {
        timeline.Stop();
        PlayOneFrame();
    }

    public void Pause()
    {
        timeline.Pause();

        time = ConvertDtoF(timeline.time);
        sliderValue = time;
        sliderValueStored = time;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void LengthReset()
    {
        length = timeline.duration;
    }
    void PlayOneFrame()
    {
        Play();

        //1フレーム後にPauseする
        StartCoroutine(DelayMethod(1, () => { Pause(); }));
    }

    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for (var i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }

    void SetTimelineTime(float f)
    {
        double d = ConvertFtoD(f);
        timeline.time = d;
        PlayOneFrame();
    }

    double ConvertFtoD(float f)
    {
        double d = (double)(f * length);
        return d;
    }

    float ConvertDtoF(double d)
    {
        float f = (float)d / (float)length;
        return f;
    }
}

