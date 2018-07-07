﻿using System;

namespace Yers.AdminWeb
{
    //这个Attribute可以应用到方法上，而且可以添加多个
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SkipCheckLoginAttribute : Attribute
    {
    }
}