using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AFEI.Client.Helpers
{
    public class AutoCompleteFocusableBox : System.Windows.Controls.AutoCompleteBox
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var textbox = Template.FindName("Text", this) as TextBox;
            if (textbox != null) 
                textbox.Focus();
        }
    }
}