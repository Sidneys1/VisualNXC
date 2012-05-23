namespace Visual_NXC.Classes
{
	internal class ExMenuRenderer : STP.Classes.cTsRenderer
	{
		public ExMenuRenderer()
		{}

		protected override void OnRenderButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		{
			base.OnRenderMenuItemBackground(e);
		}
	}
}
