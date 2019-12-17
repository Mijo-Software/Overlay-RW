using System;
using System.Drawing;
using System.Windows.Forms;

namespace OverlayRW
{
  public partial class OverlayRWForm : Form
  {
    private Graphics g;
    private readonly Pen p = new Pen(Color.Black);
    private readonly SolidBrush b = new SolidBrush(Color.Black);

    private int[]
      evelation1RW = new int[0],
      evelation2RW = new int[0],
      evelation3RW = new int[0],
      evelation4RW = new int[0],
      evelationOverlay = new int[0];

    public OverlayRWForm() => InitializeComponent();

    private void ButtonDraw1RW_Click(object sender, EventArgs e)
    {
      if (pictureBox1RW.Visible)
      {
        pictureBox1RW.Visible = false;
      }
      if (!buttonShowList1RW.Visible)
      {
        buttonShowList1RW.Visible = true;
      }
      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(brush: b, x: pictureBox1RW.Left, y: pictureBox1RW.Top, width: pictureBox1RW.Width, height: pictureBox1RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(pen: p, x: pictureBox1RW.Left, y: pictureBox1RW.Top, width: pictureBox1RW.Width, height: pictureBox1RW.Height);
      Array.Resize(array: ref evelation1RW, newSize: pictureBox1RW.Width);
      Random r = new Random();
      int height = pictureBox1RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox1RW.Width - 1; i++)
      {
        switch (r.Next(minValue: 0, maxValue: 3))
        {
          case 0: height = height; break;
          case 1: height += (int)numericUpDown1RW.Value; evelationOverlay[i] = height; break;
          case 2: height -= (int)numericUpDown1RW.Value; evelationOverlay[i] = height; break;
          default: height = height; break;
        }
        evelation1RW[i] = height;

        if (checkBoxDam1RW.Checked)
        {
          if (height <= 1) { height = 0; evelation1RW[i] = height; }
          if (height >= 100) { height = pictureBox1RW.Height - 1; evelation1RW[i] = height; }
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox1RW.Left + i - 1, y1: pictureBox1RW.Top + evelation1RW[i - 1], x2: pictureBox1RW.Left + i, y2: pictureBox1RW.Top + evelation1RW[i]);
          }
        }
        else if (pictureBox1RW.Top + evelation1RW[i] - (int)numericUpDown1RW.Value > pictureBox1RW.Top && pictureBox1RW.Top + evelation1RW[i] + (int)numericUpDown1RW.Value < pictureBox1RW.Top + pictureBox1RW.Height)
        {
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox1RW.Left + i - 1, y1: pictureBox1RW.Top + evelation1RW[i - 1], x2: pictureBox1RW.Left + i, y2: pictureBox1RW.Top + evelation1RW[i]);
          }
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox1RW.Top + evelation1RW[i] - (int)numericUpDown1RW.Value < pictureBox1RW.Top)
          {
            g.DrawLine(pen: p, x1: pictureBox1RW.Left, y1: pictureBox1RW.Top, x2: pictureBox1RW.Left + pictureBox1RW.Width, y2: pictureBox1RW.Top);
          }
          else
          {
            g.DrawLine(pen: p, x1: pictureBox1RW.Left, y1: pictureBox1RW.Top + pictureBox1RW.Height, x2: pictureBox1RW.Left + pictureBox1RW.Width, y2: pictureBox1RW.Top + pictureBox1RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void ButtonDraw2RW_Click(object sender, EventArgs e)
    {
      if (pictureBox2RW.Visible)
      {
        pictureBox2RW.Visible = false;
      }
      if (!buttonShowList2RW.Visible)
      {
        buttonShowList2RW.Visible = true;
      }
      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(brush: b, x: pictureBox2RW.Left, y: pictureBox2RW.Top, width: pictureBox2RW.Width, height: pictureBox2RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(pen: p, x: pictureBox2RW.Left, y: pictureBox2RW.Top, width: pictureBox2RW.Width, height: pictureBox2RW.Height);
      Array.Resize(array: ref evelation2RW, newSize: pictureBox2RW.Width);
      Random r = new Random();
      int height = pictureBox2RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox2RW.Width - 1; i++)
      {
        switch (r.Next(minValue: 0, maxValue: 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] += (int)numericUpDown2RW.Value; height += (int)numericUpDown2RW.Value; break;
          case 2: evelationOverlay[i] -= (int)numericUpDown2RW.Value; height -= (int)numericUpDown2RW.Value; break;
          default: height = height; break;
        }
        evelation2RW[i] = height;
        if (checkBoxDam2RW.Checked)
        {
          if (height <= 1) { height = 0; evelation2RW[i] = height; }
          if (height >= 100) { height = pictureBox2RW.Height - 1; evelation2RW[i] = height; }
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox2RW.Left + i - 1, y1: pictureBox2RW.Top + evelation2RW[i - 1], x2: pictureBox2RW.Left + i, y2: pictureBox2RW.Top + evelation2RW[i]);
          }
        }
        else if (pictureBox2RW.Top + evelation2RW[i] - (int)numericUpDown2RW.Value > pictureBox2RW.Top && pictureBox2RW.Top + evelation2RW[i] + (int)numericUpDown2RW.Value < pictureBox2RW.Top + pictureBox2RW.Height)
        {
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox2RW.Left + i - 1, y1: pictureBox2RW.Top + evelation2RW[i - 1], x2: pictureBox2RW.Left + i, y2: pictureBox2RW.Top + evelation2RW[i]);
          }
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox2RW.Top + evelation2RW[i] - (int)numericUpDown2RW.Value < pictureBox2RW.Top)
          {
            g.DrawLine(pen: p, x1: pictureBox2RW.Left, y1: pictureBox2RW.Top, x2: pictureBox2RW.Left + pictureBox2RW.Width, y2: pictureBox2RW.Top);
          }
          else
          {
            g.DrawLine(pen: p, x1: pictureBox2RW.Left, y1: pictureBox2RW.Top + pictureBox2RW.Height, x2: pictureBox2RW.Left + pictureBox2RW.Width, y2: pictureBox2RW.Top + pictureBox2RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void ButtonDraw3RW_Click(object sender, EventArgs e)
    {
      if (pictureBox3RW.Visible)
      {
        pictureBox3RW.Visible = false;
      }
      if (!buttonShowList3RW.Visible)
      {
        buttonShowList3RW.Visible = true;
      }
      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(brush: b, x: pictureBox3RW.Left, y: pictureBox3RW.Top, width: pictureBox3RW.Width, height: pictureBox3RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(pen: p, x: pictureBox3RW.Left, y: pictureBox3RW.Top, width: pictureBox3RW.Width, height: pictureBox3RW.Height);
      Array.Resize(array: ref evelation3RW, newSize: pictureBox3RW.Width);
      Random r = new Random();
      int height = pictureBox3RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox3RW.Width - 1; i++)
      {
        switch (r.Next(minValue: 0, maxValue: 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] += (int)numericUpDown3RW.Value; height += (int)numericUpDown3RW.Value; break;
          case 2: evelationOverlay[i] -= (int)numericUpDown3RW.Value; height -= (int)numericUpDown3RW.Value; break;
          default: height = height; break;
        }
        evelation3RW[i] = height;
        if (checkBoxDam3RW.Checked)
        {
          if (height <= 1) { height = 0; evelation3RW[i] = height; }
          if (height >= 100) { height = pictureBox3RW.Height - 1; evelation3RW[i] = height; }
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox3RW.Left + i - 1, y1: pictureBox3RW.Top + evelation3RW[i - 1], x2: pictureBox3RW.Left + i, y2: pictureBox3RW.Top + evelation3RW[i]);
          }
        }
        else if (pictureBox3RW.Top + evelation3RW[i] - (int)numericUpDown3RW.Value > pictureBox3RW.Top && pictureBox3RW.Top + evelation3RW[i] + (int)numericUpDown3RW.Value < pictureBox3RW.Top + pictureBox3RW.Height)
        {
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox3RW.Left + i - 1, y1: pictureBox3RW.Top + evelation3RW[i - 1], x2: pictureBox3RW.Left + i, y2: pictureBox3RW.Top + evelation3RW[i]);
          }
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox3RW.Top + evelation3RW[i] - (int)numericUpDown3RW.Value < pictureBox3RW.Top)
          {
            g.DrawLine(pen: p, x1: pictureBox3RW.Left, y1: pictureBox3RW.Top, x2: pictureBox3RW.Left + pictureBox3RW.Width, y2: pictureBox3RW.Top);
          }
          else
          {
            g.DrawLine(pen: p, x1: pictureBox3RW.Left, y1: pictureBox3RW.Top + pictureBox3RW.Height, x2: pictureBox3RW.Left + pictureBox3RW.Width, y2: pictureBox3RW.Top + pictureBox3RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void ButtonDraw4RW_Click(object sender, EventArgs e)
    {
      if (pictureBox4RW.Visible)
      {
        pictureBox4RW.Visible = false;
      }
      if (!buttonShowList4RW.Visible)
      {
        buttonShowList4RW.Visible = true;
      }
      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(brush: b, x: pictureBox4RW.Left, y: pictureBox4RW.Top, width: pictureBox4RW.Width, height: pictureBox4RW.Height);
      p.Color = Color.Black;
      g.DrawRectangle(pen: p, x: pictureBox4RW.Left, y: pictureBox4RW.Top, width: pictureBox4RW.Width, height: pictureBox4RW.Height);

      Array.Resize(array: ref evelation4RW, newSize: pictureBox4RW.Width);
      Random r = new Random();
      int height = pictureBox4RW.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBox4RW.Width - 1; i++)
      {
        switch (r.Next(minValue: 0, maxValue: 3))
        {
          case 0: height = height; break;
          case 1: evelationOverlay[i] += (int)numericUpDown4RW.Value; height += (int)numericUpDown4RW.Value; break;
          case 2: evelationOverlay[i] -= (int)numericUpDown4RW.Value; height -= (int)numericUpDown4RW.Value; break;
          default: height = height; break;
        }
        evelation4RW[i] = height;
        if (checkBoxDam4RW.Checked)
        {
          if (height <= 1) { height = 0; evelation4RW[i] = height; }
          if (height >= 100) { height = pictureBox4RW.Height - 1; evelation4RW[i] = height; }
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox4RW.Left + i - 1, y1: pictureBox4RW.Top + evelation4RW[i - 1], x2: pictureBox4RW.Left + i, y2: pictureBox4RW.Top + evelation4RW[i]);
          }
        }
        else if (pictureBox4RW.Top + evelation4RW[i] - (int)numericUpDown4RW.Value > pictureBox4RW.Top && pictureBox4RW.Top + evelation4RW[i] + (int)numericUpDown4RW.Value < pictureBox4RW.Top + pictureBox4RW.Height)
        {
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBox4RW.Left + i - 1, y1: pictureBox4RW.Top + evelation4RW[i - 1], x2: pictureBox4RW.Left + i, y2: pictureBox4RW.Top + evelation4RW[i]);
          }
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBox4RW.Top + evelation4RW[i] - (int)numericUpDown4RW.Value < pictureBox4RW.Top)
          {
            g.DrawLine(pen: p, x1: pictureBox4RW.Left, y1: pictureBox4RW.Top, x2: pictureBox4RW.Left + pictureBox4RW.Width, y2: pictureBox4RW.Top);
          }
          else
          {
            g.DrawLine(pen: p, x1: pictureBox4RW.Left, y1: pictureBox4RW.Top + pictureBox4RW.Height, x2: pictureBox4RW.Left + pictureBox4RW.Width, y2: pictureBox4RW.Top + pictureBox4RW.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void ButtonDrawOverlay_Click(object sender, EventArgs e)
    {
      if (pictureBoxOverlay.Visible)
      {
        pictureBoxOverlay.Visible = false;
      }
      g = CreateGraphics();
      b.Color = Color.White;
      g.FillRectangle(brush: b, x: pictureBoxOverlay.Left, y: pictureBoxOverlay.Top, width: pictureBoxOverlay.Width, height: pictureBoxOverlay.Height);
      p.Color = Color.Black;
      g.DrawRectangle(pen: p, x: pictureBoxOverlay.Left, y: pictureBoxOverlay.Top, width: pictureBoxOverlay.Width, height: pictureBoxOverlay.Height);
      int height = pictureBoxOverlay.Height / 2;
      p.Color = Color.Blue;
      for (int i = 0; i < pictureBoxOverlay.Width - 1; i++)
      {
        if (pictureBoxOverlay.Top + evelationOverlay[i] > pictureBoxOverlay.Top && pictureBoxOverlay.Top + evelationOverlay[i] < pictureBoxOverlay.Top + pictureBoxOverlay.Height)
        {
          if (i != 0)
          {
            g.DrawLine(pen: p, x1: pictureBoxOverlay.Left + i - 1, y1: pictureBoxOverlay.Top + evelationOverlay[i - 1], x2: pictureBoxOverlay.Left + i, y2: pictureBoxOverlay.Top + evelationOverlay[i]);
          }
        }
        else
        {
          p.Color = Color.Red;
          if (pictureBoxOverlay.Top + evelationOverlay[i] < pictureBoxOverlay.Top)
          {
            g.DrawLine(pen: p, x1: pictureBoxOverlay.Left, y1: pictureBoxOverlay.Top, x2: pictureBoxOverlay.Left + pictureBoxOverlay.Width, y2: pictureBoxOverlay.Top);
          }
          else
          {
            g.DrawLine(pen: p, x1: pictureBoxOverlay.Left, y1: pictureBoxOverlay.Top + pictureBoxOverlay.Height, x2: pictureBoxOverlay.Left + pictureBoxOverlay.Width, y2: pictureBoxOverlay.Top + pictureBoxOverlay.Height);
          }
          p.Color = Color.Blue;
        }
      }
    }

    private void ButtonShowList1RW_Click(object sender, EventArgs e)
    {
    }

    private void ButtonShowList2RW_Click(object sender, EventArgs e)
    {
    }

    private void ButtonShowList3RW_Click(object sender, EventArgs e)
    {
    }

    private void ButtonShowList4RW_Click(object sender, EventArgs e)
    {
    }

    private void OverlayRWForm_Load(object sender, EventArgs e)
    {
      Array.Resize(array: ref evelationOverlay, newSize: pictureBox1RW.Width);
      for (int i = 0; i < evelationOverlay.Length; i++)
      {
        evelationOverlay[i] = pictureBoxOverlay.Height / 2;
      }
    }

    private void CheckBoxDrawSyncOverlay_CheckedChanged(object sender, EventArgs e) => buttonDrawOverlay.Enabled = !checkBoxDrawSyncOverlay.Checked;
  }
}