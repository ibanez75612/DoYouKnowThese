﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DoYouNowThese.M.Dependencies
{
   public static class TokenAccesModel
    {
        public static string accesValue = Application.Current.Properties["token"].ToString();
    }
}
