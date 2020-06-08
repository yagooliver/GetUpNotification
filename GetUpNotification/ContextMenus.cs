using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GetUpNotification
{
    class ContextMenus
    {
        private System.Threading.Timer _timer;

        public ContextMenus()
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Iniciar Serviço.
            item = new ToolStripMenuItem();
            item.Text = "Start";
            item.Name = "Start";
            item.Click += Start_Click;
            menu.Items.Add(item);

            // Parar Serviço.
            item = new ToolStripMenuItem();
            item.Text = "Stop";
            item.Name = "Stop";
            item.Click += Stop_Click;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Sair.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += Exit_Click;
            menu.Items.Add(item);

            return menu;
        }

        void Start_Click(object sender, EventArgs e)
        {
            _timer = new System.Threading.Timer(CallMessage, null, TimeSpan.Zero, TimeSpan.FromSeconds(3600));
        }

        void Stop_Click(object sender, EventArgs e)
        {
            _timer = null;
        }

        void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CallMessage(object state)
        {
            MessageBox.Show("You should get up of your chair, you've been sitting by an hour");
        }
    }
}
