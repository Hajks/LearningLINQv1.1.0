﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace LearningLINQv1._1._0
{
    class ComicQuery
    {
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public BitmapImage Image { get; private set; }

        public ComicQuery(string title, string subtitle, string description, BitmapImage image)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Image = image;
        }
    }
}
