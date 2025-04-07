using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolManager
{
    public partial class from_PreviewTool : Form
    {
        public from_PreviewTool(string img)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(img);
        }
    }
}
