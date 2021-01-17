using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImagesLoader
{
    static private Dictionary<string, Sprite> Images = new Dictionary<string, Sprite>(); 

    public static void LoadImages()
    {
        Images.Clear();
        int x = 0;
        foreach (Sprite image in Resources.LoadAll("ItemImages", typeof(Sprite)))
        {
            Images.Add(image.name, image);
        }
    }

    public static Sprite FindImage(string imageName)
    {
        foreach (var image in Images)
        {
            if (image.Key == imageName)
                return image.Value;
        }
        // Error window (imageName)
        try
        {
            return Images["NoImage"];
        }
        catch (NullReferenceException)
        {
            return null;
        }
    }

    public static void ShowImages()
    {
        foreach (var image in Images)
        {
            Debug.Log(image.Key);
        }
    }

}
