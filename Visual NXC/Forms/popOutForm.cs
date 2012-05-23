using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual_NXC.Forms
{
	internal partial class popOutForm : Form
	{
		Form pForm;
		public popOutForm(Form parentForm)
		{
			InitializeComponent();
			pForm = parentForm;
			pForm.Move += new EventHandler(ParentForm_Move);
		}

		Point lastPointMove;
		void ParentForm_Move(object sender, EventArgs e)
		{
			if (lastPointMove != Point.Empty && pForm != null)
			{
				Point newPoint = Location;
				newPoint.Offset(pForm.Location.X - lastPointMove.X, pForm.Location.Y - lastPointMove.Y);
				Location = newPoint;
			}
			lastPointMove = pForm.Location;
		}
	}
}
