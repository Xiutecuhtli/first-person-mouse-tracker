This is a mouse tracker that displays your mouse movements as a green dot in a box, which loops when it reaches the edges of the box. It will register mouse movements successfully even when the movement is blocked by the edge of the screen, or when a first-person game locks it into first-person, because it isn't using the cursor position; it is using raw movement data from the input device.

Operating system and hardware stuff is not exactly my expertise, but I am pretty confident that this will not harm the computer because the code seems right and I have been using it all the time with no consequences. I even leave it running when I'm not using it, for like weeks. But if it destroys everything then don't sue me pls I tried

# Picture example:

<img width="1448" height="762" alt="image" src="https://github.com/user-attachments/assets/b6c04f9e-ade7-4b80-8a84-ce34f10ba65c" />

# Video example

https://youtu.be/F3uwYt35K8o?t=2h33m47s

# How to make the background transparent in OBS

The tracker's background is opaque. But you can make it display in OBS as having a transparent background and opaque green dot instead. To do this:

1. Have the mouse detector running and unminimized, and OBS open.
2. In the Sources tab of OBS, add a new source, choose Window Capture and set its Window as MouseDetector.exe.
3. In the Sources tab, rightclick that Window Capture and click Filters, then add an Effect Filter and choose Chroma Key.
4. Click the Chroma Key and change its settings to Key Color Type: Magenta, Similarity: 400, Smoothness: 80, Key Color Spill Reduction: 100, Opacity: 1.0000, Contrast: 0.00, Brightness: 0.0000, Gamma: 0.00.
5. Add another Effect Filter and now choose Color Key. Click it and change its settings to Key Color Type: Custom Color, Key Color: #f0f0f0, Similarity: 50, Smoothness: 50, Opacity: 1.0000, Contrast: 0.00, Brightness: 0.0000, Gamma: 0.00.
6. Exit the filters panel, and repeat steps 2-4, except with Opacity: 0.0050. You could change this number to make the background more or less transparent.
7. Exit the filters panel, and in the Sources tab, shift click both of the Window Captures. Right click one of them and click Group Selected Items.
8. In the OBS display, you can now click and drag the mouse detector box around or resize it as needed.

# Tips

I am using Visual Studio to run this program. OBS can't display the mouse tracker if it's minimized, but putting it behind other windows/tabs or dragging it partially offscreen is fine. Sometimes I have noticed that the background of the tracker looks like a glitchy copy of another part of the screen, but that can be fixed by minimizing and unminimizing the tracker. Sometimes the dot used to somehow get a NaN position which made the dot disappear. I think I fixed that but if it still happens, you have to close the tracker and reopen it. You can resize and recolor things in OBS or by changing numbers in the Program.cs file.

# License

MIT License

Copyright (c) 2026 - Xiutecuhtli

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
