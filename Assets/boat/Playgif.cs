/*using System.Drawing;
using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Gif動畫播放
/// 1.掛載此腳本到UGUI的Image上
/// 2.使用SetGifPath(string path)傳入GIF圖片路徑
/// </summary>
public class Playgif : MonoBehaviour
{
    //幀數(數值越大播放速度越快)
    private const float Fps = 24;
    private UnityEngine.UI.Image _image;
    public List<Texture2D> _tex2DList = new List<Texture2D>();
    private float _time;
    private int _framCount;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    /// <summary>
    /// 設置Gif圖片的絕對路徑
    /// </summary>
    /// <param name="path"></param>
    public void SetGifPath(string path)
    {        
        var image = System.Drawing.Image.FromFile(C:Users/Tina/Desktop/gamejam2021_10/Assets/boatgif);
        _tex2DList = GifToTexture2D(image);
    }
  
    /// <summary>
    /// Gif轉Texture2D
    /// </summary>
    /// <param name="image"> System.Image</param>
    /// <returns>Texture2D集合</returns>
    private List<Texture2D> GifToTexture2D(Image image)
    {
        var tex = new List<Texture2D>();
        if (image == null) return tex;    
        var frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
        //獲取指定維度的幀數
        _framCount = image.GetFrameCount(frameDimension);
        Debug.Log("gif總幀數 = " + _framCount);     
        for (var i = 0; i < _framCount; i++)
        {          
            image.SelectActiveFrame(frameDimension, i);         
            var framBitmap = new Bitmap(image.Width, image.Height);       
            using (var newGraphics = System.Drawing.Graphics.FromImage(framBitmap))
            {
                newGraphics.DrawImage(image, Point.Empty);
            }           
            var frameTexture2D = new Texture2D(framBitmap.Width, framBitmap.Height, TextureFormat.ARGB32, true);        
            frameTexture2D.LoadImage(BitmapToByte(framBitmap));      
            tex.Add(frameTexture2D);
        }
        return tex;
    }

    /// <summary>
    /// Bitmap轉Byte
    /// </summary>
    /// <param name="bitmap">Bitmap</param>
    /// <returns>byte數組</returns>
    private byte[] BitmapToByte(Bitmap bitmap)
    {
        using (var stream = new MemoryStream())
        {           
            bitmap.Save(stream, ImageFormat.Png);          
            var data = new byte[stream.Length];           
            stream.Seek(0, SeekOrigin.Begin);          
            stream.Read(data, 0, Convert.ToInt32(stream.Length));
            return data;
        }
    }

    private void Update()
    {
        if (_tex2DList.Count <= 0) return;
        if (_framCount < 2) return;
        _time += Time.deltaTime;
        var index = (int)(_time * Fps) % _tex2DList.Count;
        if (_image != null)
        {
            _image.sprite = Sprite.Create(_tex2DList[index], new Rect(0, 0, _tex2DList[index].width, _tex2DList[index].height), new Vector2(0.5f, 0.5f));
        }
    }

}*/