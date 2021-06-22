﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mailer.Models
{
    public class Mail
    {
        
            public string From
            {
                get;
                set;
            }
            public string To
            {
                get;
                set;
            }
            public string Subject
            {
                get;
                set;
            }
            public string Body
            {
                get;
                set;
            }
            public string Password
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
    }
}
