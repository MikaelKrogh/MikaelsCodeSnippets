using System;
using System.Collections.Generic;
using System.Text;

namespace OutlookSender {
    public class EmailContent {
        public bool IsHtml { get; set; }
        public string Content { get; set; }
        public string AttachFileName { get; set; }
    }
}
