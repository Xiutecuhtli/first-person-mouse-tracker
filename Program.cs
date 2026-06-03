using System.Runtime.InteropServices;

class TestClass
{
    private delegate int HOOKPROC(int code, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint numDevices, uint size);

    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetRawInputData(IntPtr hRawInput, uint uiCommand, out RAWINPUT pData, ref int pcbSize, int cbSizeHeader);

    [STAThread]
    static void Main()
    {
        Application.Run(new MouseMoveDetector());
    }

    public class MouseMoveDetector : Form
    {
        static readonly int numRows = 3;
        static readonly int dotSize = 5;
        static readonly Color dotColor = Color.LimeGreen;

        readonly Panel[,] dots = new Panel[numRows, numRows];
        readonly System.Windows.Forms.Timer updateTimer = new();
        double x = 0;
        double y = 0;

        public MouseMoveDetector()
        {
            // There are actually 9 dots that get teleported to create a seamless looping effect.
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numRows; j++)
                {
                    this.dots[i, j] = new Panel
                    {
                        Size = new Size(dotSize, dotSize),
                        BackColor = dotColor,
                    };
                    this.Controls.Add(this.dots[i, j]);
                };

            // Update icons on an interval
            updateTimer.Interval = 2;
            updateTimer.Tick += UpdateDotsVisually;
            updateTimer.Start();


            // Register listening to mouse

            RAWINPUTDEVICE[] devices = {
                new()
                {
                    UsagePage=0x01,
                    Usage=0x02,
                    RawInputDeviceFlags=0x00000100,
                    Target=this.Handle,
                }
            };
            if (!RegisterRawInputDevices(devices, (uint)devices.Length, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICE))))
                Console.WriteLine("FAIL");
            else
                Console.WriteLine("SUCCESS");


        }

        protected override void WndProc(ref Message m)
        {
            int outSize;
            int size = Marshal.SizeOf(typeof(RAWINPUT));
            outSize = GetRawInputData(m.LParam, 0x10000003, out RAWINPUT input, ref size, Marshal.SizeOf(typeof(RAWINPUTHEADER)));
            if (outSize != -1 && input.header.dwType == 0)
                UpdateDotsInternally(input.data.lLastX, input.data.lLastY);
            base.WndProc(ref m);
        }
        
        // Internal floating point values for x and y, looped to be within the small numerical range
        void UpdateDotsInternally(int deltaX, int deltaY)
        {
            double lengthMultiplier = 0.06;

            this.x += deltaX * lengthMultiplier;
            this.y += deltaY * lengthMultiplier;
            if (this.ClientSize.Width != 0.0)
                this.x %= this.ClientSize.Width;
            if (this.ClientSize.Height != 0.0)
                this.y %= this.ClientSize.Height;
            if (this.x < 0) this.x += this.ClientSize.Width;
            if (this.y < 0) this.y += this.ClientSize.Height;
        }
        
        // Visual integer values for x and y, applied to all 9 copies.
        void UpdateDotsVisually(object? _sender, EventArgs _e)
        {
            for (var i = 0; i < numRows; i++)
                for (var j = 0; j < numRows; j++)
                {
                    Panel dot = dots[i, j];

                    int dotX = (int)this.x;
                    int dotY = (int)this.y;

                    if (i == 0)
                        dotY -= this.ClientSize.Height;
                    if (i == 2)
                        dotY += this.ClientSize.Height;
                    if (j == 0)
                        dotX -= this.ClientSize.Width;
                    if (j == 2)
                        dotX += this.ClientSize.Width;

                    dot.Location = new Point(dotX, dotY);
                }
        }
    }
}
