﻿using System;

namespace EmoticonImageService.Models
{
    public interface ICacheModel
    {
        string Get(string imageId);

        byte[] Square(string imageId, int size, string format);

        byte[] Thumbnail(string imageId, int width, int maxHeight, string format);
    }
}