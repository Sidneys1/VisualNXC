using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visual_NXC.Controls
{
	internal class highlighterBox : UrielGuy.SyntaxHighlightingTextBox.SyntaxHighlightingTextBox
	{
		public highlighterBox()
		{

		}

		public void RefreshHighlighting()
		{
			OnTextChanged(null);
		}

		protected override void OnTextChanged(EventArgs e)
		{
				base.OnTextChanged(e);
		}
	}
}
