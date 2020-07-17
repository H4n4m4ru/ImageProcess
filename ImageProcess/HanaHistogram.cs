using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class HanaHistogram : UserControl
    {
        //Member Variables
        private int
            _i_max_height = 0,
            _i_max_length = 0,
            _i_bar_width = 1,
            _i_bar_height = 100,
            _i_bar_space = 1,
            _i_interval = 0,
            _i_line_size = 2,
            _i_left_space = 2,
            _i_right_space = 2,
            _i_top_space = 2,
            _i_bottom_space = 12;
        private double _d_enhance = 2.5;
        private Font _textfont = new Font("Arial", 8);
        private Color
            _color_line = Color.White,
            _color_text = Color.White,
            _color_bar = Color.Violet;
        private int[] _data_array = new int[1000];
        private Bitmap BackGround = new Bitmap(100, 100);

        public int Bar_Width
        {
            get { return this._i_bar_width; }
            set
            {
                if ((value > 0) && (value + _i_interval <= _i_bar_space)) this._i_bar_width = value;
            }
        }
        public int Bar_Height
        {
            get { return this._i_bar_height; }
            set
            {
                if (value > 0) this._i_bar_height = value;
            }
        }
        public int Bar_Space
        {
            get { return this._i_bar_space; }
            set
            {
                if (value >= (_i_interval + _i_bar_width)) this._i_bar_space = value;
            }
        }
        public int Interval {
            get { return this._i_interval; }
            set {
                if ((value >= 0) && (value + _i_bar_width <= _i_bar_space)) this._i_interval = value; 
            }
        }
        public int LineSize {
            get { return this._i_line_size; }
            set {
                if (value > 0) this._i_line_size = value;
            }
        }
        public int LeftSpace {
            get { return this._i_left_space; }
            set { if (value >= 0)this._i_left_space = value ;}
        }
        public int RightSpace
        {
            get { return this._i_right_space; }
            set { if (value >= 0)this._i_right_space = value; }
        }
        public int TopSpace
        {
            get { return this._i_top_space; }
            set { if (value >= 0)this._i_top_space = value; }
        }
        public int BottomSpace
        {
            get { return this._i_bottom_space; }
            set { if (value >= 0)this._i_bottom_space = value; }
        }
        public double Enhance {
            get { return this._d_enhance; }
            set { if (value > 0)this._d_enhance = value; }
        }

        public Font TextFont {
            get { return this._textfont; }
            set { this._textfont = value; }
        }

        public Color Line_Color {
            get { return this._color_line; }
            set {
                Color _color_temp = this._color_line;
                try
                {
                    this._color_line = value;
                }
                catch {
                    this._color_line = _color_temp;
                }
            }
        }
        public Color Text_Color
        {
            get { return this._color_text; }
            set
            {
                Color _color_temp = this._color_text;
                try
                {
                    this._color_text = value;
                }
                catch
                {
                    this._color_text = _color_temp;
                }
            }
        }
        public Color Bar_Color
        {
            get { return this._color_bar; }
            set
            {
                Color _color_temp = this._color_bar;
                try
                {
                    this._color_bar = value;
                }
                catch
                {
                    this._color_bar = _color_temp;
                }
            }
        }

        //Constructor
        public HanaHistogram()
        {
            InitializeComponent();
        }

        //Member Functions
        public void LoadData(Bitmap _bmp,char _channel) {
            unsafe
            {
                _data_array = new int[256];
                BitmapData _bd_bmp = _bmp.LockBits(new Rectangle(0, 0, _bmp.Width, _bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                byte* _ptr_pointer0 = (byte*)_bd_bmp.Scan0;
                int _i_height = _bd_bmp.Height,
                    _i_width = _bd_bmp.Width,
                    _i_stride = _bd_bmp.Stride,
                    _i_channel = 0;

                switch (_channel) { 
                    case 'A':
                        _i_channel = 3;break;
                    case 'a':
                        _i_channel = 3; break;
                    case 'R':
                        _i_channel = 2; break;
                    case 'r':
                        _i_channel = 2; break;
                    case 'G':
                        _i_channel = 1; break;
                    case 'g':
                        _i_channel = 1; break;
                    case 'B':
                        _i_channel = 0; break;
                    case 'b':
                        _i_channel = 0; break;
                    default:
                        _i_channel = 2;break;
                }

                for (int y = 0; y < _i_height; y++) {
                    for (int x = 0; x < _i_width; x++)
                        _data_array[_ptr_pointer0[y * _i_stride + x * 4 + _i_channel]]++;
                }

                _i_max_height = _data_array.Max();
                _i_max_length = 256;

                _bmp.UnlockBits(_bd_bmp);
            }
        }
        public void LoadData(int[] _input_data)
        {
            if (_input_data.Length == 0||_input_data.Max()<=0) return;

            _data_array = new int[_input_data.Length];
            _input_data.CopyTo(_data_array, 0);

            _i_max_length = _data_array.Length;
            _i_max_height = _data_array.Max();
        }

        public void ShowData(){
            if (_i_max_length == 0) return;

            this.Width = _i_left_space + _i_line_size + _i_max_length * _i_bar_space + _i_right_space;
            this.Height = _i_top_space + _i_line_size + _i_bar_height + _i_bottom_space;
            BackGround = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(BackGround)) {
                g.Clear(this.BackColor);
                SolidBrush Bruh_line = new SolidBrush(_color_line);
                SolidBrush Bruh_bar = new SolidBrush(_color_bar);

                g.FillRectangle(Bruh_line, _i_left_space, _i_top_space, _i_line_size, _i_bar_height + _i_line_size);
                g.FillRectangle(Bruh_line, _i_left_space, _i_top_space + _i_bar_height, this.Width - _i_left_space - _i_right_space, _i_line_size);
                //   
                int x_axis_current = _i_left_space + _i_line_size,
                    y_axis_current = _i_top_space + _i_bar_height;

                for (int i = 0; i < _i_max_length; i++, x_axis_current += _i_bar_space){
                    int i_height_transed = (int)(_d_enhance * (double)_data_array[i] / (double)_i_max_height * (double)_i_bar_height);
                    g.FillRectangle(Bruh_bar, x_axis_current + _i_interval, y_axis_current - i_height_transed, _i_bar_width, i_height_transed);
                }
            }
            this.BackgroundImage = BackGround;
        }
        public void ShowData(int[] _input_data) { ;}
    }
}
