﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouNowThese.M.Views
{

    public class LeftMenuMasterMenuItem
    {
        public LeftMenuMasterMenuItem()
        {
            TargetType = typeof(LeftMenuMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}