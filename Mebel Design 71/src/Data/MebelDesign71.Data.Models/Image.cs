﻿using System;

namespace MebelDesign71.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public FileOnFileSystem ImageName { get; set; }
    }
}