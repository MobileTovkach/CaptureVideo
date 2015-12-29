using System;
using System.Windows.Forms;
using DirectX.Capture;
using VideoTC.src.extensions;
using static System.Diagnostics.Debug;
using GalaSoft.MvvmLight;

namespace VideoTC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Filters _filters;
        private Capture _capture;


        private void button1_Click(object sender, EventArgs e)
        {
            Assert(comboBox4 != null, "comboBox4 != null");
            if (comboBox4.Items.Count <= 0) return;
            Assert(_capture != null, "_capture != null");
            Assert(pictureBox1 != null, "pictureBox1 != null");
            _capture.PreviewWindow = pictureBox1; //вывод видеозахвата в пикчербокс на форме
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _filters = new Filters();
            Assert(condition: _filters.VideoInputDevices != null, message: "_filters.VideoInputDevices != null");
            Assert(_filters.AudioInputDevices != null, "_filters.AudioInputDevices != null");
            _capture = new Capture(videoDevice: _filters.VideoInputDevices[0], audioDevice: _filters.AudioInputDevices[0]);
            //поиск устройств видеозахвата
            if (comboBox2 != null)
            {
                TEnumerableExtensions.ForEach(_filters.VideoInputDevices, x => comboBox2.Items.Add(x)); //добавление в комбоббокс
            }
            if (comboBox2 != null && comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox3 != null)
            {
                TEnumerableExtensions.ForEach(_filters.AudioInputDevices, x => comboBox3.Items.Add(x)); //устройства для ввода аудио, добавление в комбобокс
            }
            Assert(comboBox3 != null, "comboBox3 != null");
            if (comboBox3.Items.Count <= 0) return;
            TEnumerableExtensions.ForEach(_capture.VideoSources, x => comboBox4.Items.Add(x));//поиск источников видео
        }
    }
}
