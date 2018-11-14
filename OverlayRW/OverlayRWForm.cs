using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OverlayRW
{
  public partial class OverlayRWForm : Form
  {
    Graphics g;
    Pen p = new Pen(Color.Black);
    SolidBrush b = new SolidBrush(Color.Black);

    int[]
      evelation1RW = new int[0],
      evelation2RW = new int[0],
      evelation3RW = new int[0],
      evelation4RW = new int[0],
      evelationOverlay = new int[0];

    public OverlayRWForm()
    {
      InitializeComponent();
    }

    private void buttonDraw1RW_Click(object sender, EventArgs e)
    {
      if (pictureBox1RW.Visible) pictureBox1RW.Visible = false;
      if (!buttonShowList1RW.Visible) buttonShowList1RW.Visible = true;

      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(b, pictureBox1RW.Left, pictureBox1RW.Top, pictureBox1RW.Width, pictureBox1RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(p, pictureBox1RW.Left, pictureBox1RW.Top, pictureBox1RW.Width, pictureBox1RW.Height);

      Array.Resize(ref evelation1RW, pictureBox1RW.Width);
      Random r = new Random();
      int height = pictureBox1RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox1RW.Width - 1; i++)
      {
        switch (r.Next(0, 3))
        {
          case 0: height = height; break;
          case 1: height = height + (int)numericUpDown1RW.Value; evelationOverlay[i] = height; break;
          case 2: height = height - (int)numericUpDown1RW.Value; evelationOverlay[i] = height; break;
          default: height = height; break;
        }
        evelation1RW[i] = height;

        if (checkBoxDam1RW.Checked)
        {
          if (height <= 1) { height = 0; evelation1RW[i] = height; }
          if (height >= 100) { height = pictureBox1RW.Height - 1; evelation1RW[i] = height; }
          if (i != 0) g.DrawLine(p, pictureBox1RW.Left + i - 1, pictureBox1RW.Top + evelation1RW[i - 1], pictureBox1RW.Left + i, pictureBox1RW.Top + evelation1RW[i]);
        }
        else if (pictureBox1RW.Top + evelation1RW[i] - (int)numericUpDown1RW.Value > pictureBox1RW.Top && pictureBox1RW.Top + evelation1RW[i] + (int)numericUpDown1RW.Value < pictureBox1RW.Top + pictureBox1RW.Height)
        {
          if (i != 0) g.DrawLine(p, pictureBox1RW.Left + i - 1, pictureBox1RW.Top + evelation1RW[i - 1], pictureBox1RW.Left + i, pictureBox1RW.Top + evelation1RW[i]);
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox1RW.Top + evelation1RW[i] - (int)numericUpDown1RW.Value < pictureBox1RW.Top)
          {
            g.DrawLine(p, pictureBox1RW.Left, pictureBox1RW.Top, pictureBox1RW.Left + pictureBox1RW.Width, pictureBox1RW.Top);
          }
          else
          {
            g.DrawLine(p, pictureBox1RW.Left, pictureBox1RW.Top + pictureBox1RW.Height, pictureBox1RW.Left + pictureBox1RW.Width, pictureBox1RW.Top + pictureBox1RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void buttonDraw2RW_Click(object sender, EventArgs e)
    {
      if (pictureBox2RW.Visible) pictureBox2RW.Visible = false;
      if (!buttonShowList2RW.Visible) buttonShowList2RW.Visible = true;

      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(b, pictureBox2RW.Left, pictureBox2RW.Top, pictureBox2RW.Width, pictureBox2RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(p, pictureBox2RW.Left, pictureBox2RW.Top, pictureBox2RW.Width, pictureBox2RW.Height);

      Array.Resize(ref evelation2RW, pictureBox2RW.Width);
      Random r = new Random();
      int height = pictureBox2RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox2RW.Width - 1; i++)
      {
        switch (r.Next(0, 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] = evelationOverlay[i] + (int)numericUpDown2RW.Value; ; height = height + (int)numericUpDown2RW.Value; break;
          case 2: evelationOverlay[i] = evelationOverlay[i] - (int)numericUpDown2RW.Value; ; height = height - (int)numericUpDown2RW.Value; break;
          default: height = height; break;
        }
        evelation2RW[i] = height;

        if (checkBoxDam2RW.Checked)
        {
          if (height <= 1) { height = 0; evelation2RW[i] = height; }
          if (height >= 100) { height = pictureBox2RW.Height - 1; evelation2RW[i] = height; }
          if (i != 0) g.DrawLine(p, pictureBox2RW.Left + i - 1, pictureBox2RW.Top + evelation2RW[i - 1], pictureBox2RW.Left + i, pictureBox2RW.Top + evelation2RW[i]);
        }
        else if (pictureBox2RW.Top + evelation2RW[i] - (int)numericUpDown2RW.Value > pictureBox2RW.Top && pictureBox2RW.Top + evelation2RW[i] + (int)numericUpDown2RW.Value < pictureBox2RW.Top + pictureBox2RW.Height)
        {
          if (i != 0) g.DrawLine(p, pictureBox2RW.Left + i - 1, pictureBox2RW.Top + evelation2RW[i - 1], pictureBox2RW.Left + i, pictureBox2RW.Top + evelation2RW[i]);
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox2RW.Top + evelation2RW[i] - (int)numericUpDown2RW.Value < pictureBox2RW.Top)
          {
            g.DrawLine(p, pictureBox2RW.Left, pictureBox2RW.Top, pictureBox2RW.Left + pictureBox2RW.Width, pictureBox2RW.Top);
          }
          else
          {
            g.DrawLine(p, pictureBox2RW.Left, pictureBox2RW.Top + pictureBox2RW.Height, pictureBox2RW.Left + pictureBox2RW.Width, pictureBox2RW.Top + pictureBox2RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void buttonDraw3RW_Click(object sender, EventArgs e)
    {
      if (pictureBox3RW.Visible) pictureBox3RW.Visible = false;
      if (!buttonShowList3RW.Visible) buttonShowList3RW.Visible = true;

      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(b, pictureBox3RW.Left, pictureBox3RW.Top, pictureBox3RW.Width, pictureBox3RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(p, pictureBox3RW.Left, pictureBox3RW.Top, pictureBox3RW.Width, pictureBox3RW.Height);

      Array.Resize(ref evelation3RW, pictureBox3RW.Width);
      Random r = new Random();
      int height = pictureBox3RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox3RW.Width - 1; i++)
      {
        switch (r.Next(0, 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] = evelationOverlay[i] + (int)numericUpDown3RW.Value; height = height + (int)numericUpDown3RW.Value; break;
          case 2: evelationOverlay[i] = evelationOverlay[i] - (int)numericUpDown3RW.Value; height = height - (int)numericUpDown3RW.Value; break;
          default: height = height; break;
        }
        evelation3RW[i] = height;

        if (checkBoxDam3RW.Checked)
        {
          if (height <= 1) { height = 0; evelation3RW[i] = height; }
          if (height >= 100) { height = pictureBox3RW.Height - 1; evelation3RW[i] = height; }
          if (i != 0) g.DrawLine(p, pictureBox3RW.Left + i - 1, pictureBox3RW.Top + evelation3RW[i - 1], pictureBox3RW.Left + i, pictureBox3RW.Top + evelation3RW[i]);
        } else if (pictureBox3RW.Top + evelation3RW[i] - (int)numericUpDown3RW.Value > pictureBox3RW.Top && pictureBox3RW.Top + evelation3RW[i] + (int)numericUpDown3RW.Value < pictureBox3RW.Top + pictureBox3RW.Height)
        {
          if (i != 0) g.DrawLine(p, pictureBox3RW.Left + i - 1, pictureBox3RW.Top + evelation3RW[i - 1], pictureBox3RW.Left + i, pictureBox3RW.Top + evelation3RW[i]);
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox3RW.Top + evelation3RW[i] - (int)numericUpDown3RW.Value < pictureBox3RW.Top)
          {
            g.DrawLine(p, pictureBox3RW.Left, pictureBox3RW.Top, pictureBox3RW.Left + pictureBox3RW.Width, pictureBox3RW.Top);
          }
          else
          {
            g.DrawLine(p, pictureBox3RW.Left, pictureBox3RW.Top + pictureBox3RW.Height, pictureBox3RW.Left + pictureBox3RW.Width, pictureBox3RW.Top + pictureBox3RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void buttonDraw4RW_Click(object sender, EventArgs e)
    {
      if (pictureBox4RW.Visible) pictureBox4RW.Visible = false;
      if (!buttonShowList4RW.Visible) buttonShowList4RW.Visible = true;

      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(b, pictureBox4RW.Left, pictureBox4RW.Top, pictureBox4RW.Width, pictureBox4RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(p, pictureBox4RW.Left, pictureBox4RW.Top, pictureBox4RW.Width, pictureBox4RW.Height);

      Array.Resize(ref evelation4RW, pictureBox4RW.Width);
      Random r = new Random();
      int height = pictureBox4RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox4RW.Width - 1; i++)
      {
        switch (r.Next(0, 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] = evelationOverlay[i] + (int)numericUpDown4RW.Value; height = height + (int)numericUpDown4RW.Value; break;
          case 2: evelationOverlay[i] = evelationOverlay[i] - (int)numericUpDown4RW.Value; height = height - (int)numericUpDown4RW.Value; break;
          default: height = height; break;
        }
        evelation4RW[i] = height;

        if (checkBoxDam4RW.Checked)
        {
          if (height <= 1) { height = 0; evelation4RW[i] = height; }
          if (height >= 100) { height = pictureBox4RW.Height - 1; evelation4RW[i] = height; }
          if (i != 0) g.DrawLine(p, pictureBox4RW.Left + i - 1, pictureBox4RW.Top + evelation4RW[i - 1], pictureBox4RW.Left + i, pictureBox4RW.Top + evelation4RW[i]);
        } else if (pictureBox4RW.Top + evelation4RW[i] - (int)numericUpDown4RW.Value > pictureBox4RW.Top && pictureBox4RW.Top + evelation4RW[i] + (int)numericUpDown4RW.Value < pictureBox4RW.Top + pictureBox4RW.Height)
        {
          if (i != 0) g.DrawLine(p, pictureBox4RW.Left + i - 1, pictureBox4RW.Top + evelation4RW[i - 1], pictureBox4RW.Left + i, pictureBox4RW.Top + evelation4RW[i]);
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox4RW.Top + evelation4RW[i] - (int)numericUpDown4RW.Value < pictureBox4RW.Top)
          {
            g.DrawLine(p, pictureBox4RW.Left, pictureBox4RW.Top, pictureBox4RW.Left + pictureBox4RW.Width, pictureBox4RW.Top);
          }
          else
          {
            g.DrawLine(p, pictureBox4RW.Left, pictureBox4RW.Top + pictureBox4RW.Height, pictureBox4RW.Left + pictureBox4RW.Width, pictureBox4RW.Top + pictureBox4RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void buttonDrawOverlay_Click(object sender, EventArgs e)
    {
      if (pictureBoxOverlay.Visible) pictureBoxOverlay.Visible = false;

      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(b, pictureBoxOverlay.Left, pictureBoxOverlay.Top, pictureBoxOverlay.Width, pictureBoxOverlay.Height);
      p.Color = Color.Black;
      g.DrawRectangle(p, pictureBoxOverlay.Left, pictureBoxOverlay.Top, pictureBoxOverlay.Width, pictureBoxOverlay.Height);

      int height = pictureBoxOverlay.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBoxOverlay.Width - 1; i++)
      {

        if (pictureBoxOverlay.Top + evelationOverlay[i] > pictureBoxOverlay.Top && pictureBoxOverlay.Top + evelationOverlay[i] < pictureBoxOverlay.Top + pictureBoxOverlay.Height)
        {
          if (i != 0) g.DrawLine(p, pictureBoxOverlay.Left + i - 1, pictureBoxOverlay.Top + evelationOverlay[i - 1], pictureBoxOverlay.Left + i, pictureBoxOverlay.Top + evelationOverlay[i]);
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBoxOverlay.Top + evelationOverlay[i] < pictureBoxOverlay.Top)
          {
            g.DrawLine(p, pictureBoxOverlay.Left, pictureBoxOverlay.Top, pictureBoxOverlay.Left + pictureBoxOverlay.Width, pictureBoxOverlay.Top);
          }
          else
          {
            g.DrawLine(p, pictureBoxOverlay.Left, pictureBoxOverlay.Top + pictureBoxOverlay.Height, pictureBoxOverlay.Left + pictureBoxOverlay.Width, pictureBoxOverlay.Top + pictureBoxOverlay.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void buttonShowList1RW_Click(object sender, EventArgs e)
    {
    }

    private void buttonShowList2RW_Click(object sender, EventArgs e)
    {
    }

    private void buttonShowList3RW_Click(object sender, EventArgs e)
    {
    }

    private void buttonShowList4RW_Click(object sender, EventArgs e)
    {
    }

    private void OverlayRWForm_Load(object sender, EventArgs e)
    {
      Array.Resize(ref evelationOverlay, pictureBox1RW.Width);
      for (int i = 0; i < evelationOverlay.Length; i++)
      {
        evelationOverlay[i] = pictureBoxOverlay.Height / 2;
      }
    }

    private void checkBoxDrawSyncOverlay_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxDrawSyncOverlay.Checked) buttonDrawOverlay.Enabled = false; else buttonDrawOverlay.Enabled = true;
    }

  }

}