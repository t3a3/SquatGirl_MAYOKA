﻿using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEditor.Timeline;

namespace uLipSync.Timeline
{

[CustomEditor(typeof(uLipSyncClip))]
public class uLipSyncClipEditor : Editor
{
    uLipSyncClip clip { get => target as uLipSyncClip; }
    BakedData data { get => clip.bakedData; }
    Editor _bakedDataEditor = null;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (EditorUtil.Foldout("Data", true, "-uLipSyncClip"))
        {
            ++EditorGUI.indentLevel;
            DrawBakedData();
            --EditorGUI.indentLevel;
            EditorGUILayout.Separator();
        }

        if (EditorUtil.Foldout("Parameters", true, "-uLipSyncClip"))
        {
            ++EditorGUI.indentLevel;
            DrawParameters();
            --EditorGUI.indentLevel;
            EditorGUILayout.Separator();
        }

        serializedObject.ApplyModifiedProperties();
    }

    void DrawBakedData()
    {
        EditorUtil.DrawProperty(serializedObject, nameof(clip.bakedData));

        if (data)
        {
            EditorGUILayout.Separator();

            CreateCachedEditor(data, typeof(BakedDataEditor), ref _bakedDataEditor);
            var editor = _bakedDataEditor as BakedDataEditor;
            if (editor) 
            {
                editor.OnInspectorGUI();
            }
        }
    }

    void DrawParameters()
    {
        EditorUtil.DrawProperty(serializedObject, nameof(clip.volume));
        EditorUtil.DrawProperty(serializedObject, nameof(clip.timeOffset));
    }
}

[CustomTimelineEditor(typeof(uLipSyncClip))]
public class uLipSyncClipTimelineEditor : ClipEditor
{
    public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
    {
        var ls = clip.asset as uLipSyncClip;
        var data = ls.bakedData;
        if (!data) return;

        var audioClip = data.audioClip;
        if (!audioClip) return;

        EditorUtil.DrawBackgroundRect(region.position, new Color(0f, 0f, 0f, 0.3f), Color.clear);

        var rect = region.position;
        var duration = region.endTime - region.startTime;
        var width = (float)(rect.width * audioClip.length / duration);
        var left = Mathf.Max((float)clip.clipIn, (float)region.startTime);
        var offset = (float)(width * left / audioClip.length);
        rect.x -= offset;
        rect.width = width;

        var phonemeColors = BakedDataEditor.phonemeColors;
        var currentColor = new Color();
        var smooth = 0.15f;
        EditorUtil.DrawWave(rect, data.audioClip, new EditorUtil.DrawWaveOption()
        {
            colorFunc = x => {
                var t = x * data.duration;
                var frame = data.GetFrame(t);
                var color = new Color();
                for (int i = 0; i < frame.phonemes.Count; ++i)
                {
                    var colorIndex = i % phonemeColors.Length;
                    color += phonemeColors[colorIndex] * frame.phonemes[i].ratio;
                }
                currentColor += (color - currentColor) * smooth;
                return currentColor;
            },
            waveScale = 1f,
        });
    }
}

}
