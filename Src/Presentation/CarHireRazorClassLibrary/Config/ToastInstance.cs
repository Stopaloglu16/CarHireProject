﻿using System;

namespace CarHireRazorClassLibrary.Config
{
    public class ToastInstance
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public ToastSettings toastSettings { get; set; }

    }
}
