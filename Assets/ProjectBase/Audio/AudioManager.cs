using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : BaseManager<AudioManager>
{
    private AudioSource BGMusic=null;
    private float BGMValue = 1;
    private float SoundValue = 1;

    private GameObject soudeObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();

    public AudioManager()
    {
        MonoManager.GetInstance().AddUpdetaLiatenter(UpdetaAudio);
    }

    //检测音效是否播放完毕
    private void UpdetaAudio()
    {
        for (int i = soundList.Count - 1; i >= 0; i--)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }
    //播放背景音乐
    public void PlayBackGroundMusic(string name)
    {
        if (BGMusic == null)
        {
            GameObject obj = new GameObject();
            obj.name = "BackGroundMusic";
            BGMusic = obj.AddComponent<AudioSource>();
        }
        //异步加载背景音乐
        ResourceManager.GetInstance().LoadAsync<AudioClip>("Audio/" + name, (clip) =>
        {
            BGMusic.clip = clip;
                BGMusic.volume = BGMValue;
                BGMusic.loop = true;
                BGMusic.Play();
        });
    }
    //改变音量大小
    public void ChangeBGMValue(float v)
    {
        BGMValue = v;
        if (BGMusic == null)
            return;
        BGMusic.volume = BGMValue;
    }
    public void ChangeSoundValue(float v)
    {
        SoundValue = v;
        for (int i = 0; i < soundList.Count; i++)
        {
            soundList[i].volume = v;
        }
    }
    //暂停背景音乐
    public void PauseBackGroundMusic()
    {
        if (BGMusic==null)
            return;
        BGMusic.Pause();
    }
    //关闭背景音乐
    public void StopBackGroundMusic()
    {
        if (BGMusic==null)
            return;
        BGMusic.Stop();
    }

    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callback=null)
    {
        if (soudeObj==null)
        {
            soudeObj = new GameObject();
            soudeObj.name = "Sound";
        }
        ResourceManager.GetInstance().LoadAsync<AudioClip>("Audio/" + name, (clip) =>
        {
            AudioSource source= soudeObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = isLoop;
            soundList.Add(source);
            source.volume = SoundValue;
            source.Play();
            if (callback!=null)
                callback(source);
        });
    }

    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }
}
