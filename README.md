This is a mouse tracker that displays your mouse movements as a green dot in a box, which loops when it reaches the edges of the box. It will register mouse movements successfully even when the movement is blocked by the edge of the screen, or when a first-person game locks it into first-person, because it isn't using the cursor position; it is using raw movement data from the input device.

Operating system and hardware stuff is not exactly my expertise, but I am pretty confident that this will not harm the computer because the code seems right and I have been using it all the time with no consequences. I even leave it running when I'm not using it, for like weeks. But if it destroys everything then don't sue me pls I tried

# Picture example:

<img width="1456" height="763" alt="image" src="https://github.com/user-attachments/assets/ba6a41a8-34de-4bac-87ed-7e1229389720" />

# Video example

https://youtu.be/F3uwYt35K8o?t=2h33m47s

# How to make the background transparent in OBS

You can make OBS display it as a transparent background with an opaque green dot (although it will only be transparent in OBS. the tracker itself will still have an opaque background). To do this:

1. While the mouse detector is running, in OBS in the Sources tab add a Window Capture and set its Window as MouseDetector.exe.
2. In the Sources tab, right click that Window Capture and click Filters, then add an Effect Filter and choose Color Key.
3. Click the Color Key and change its settings to Key Color Type: Custom Color, Key Color: #f0f0f0, Similarity: 50, Smoothness: 50, Opacity: 1.0000, Contrast: 0.00, Brightness: 0.0000, Gamma: 0.00.
4. Add another Effect Filter and choose Chroma Key. Click it and change its settings to Key Color Type: Magenta, Similarity: 400, Smoothness: 80, Key Color Spill Reduction: 100, Opacity: 1.0000, Contrast: 0.00, Brightness: 0.0000, Gamma: 0.00
5. Exit the filters panel, and in the Sources tab, add another Window Capture and set its Window as MouseDetector.exe. 
6. In the Sources tab, right click this Window Capture and click Filters, then add an Effect Filter and choose Chroma Key. Click it and change its settings to Key Color Type: Magenta, Similarity: 400, Smoothness: 80, Key Color Spill Reduction: 100, Opacity: 0.0050, Contrast: 0.00, Brightness: 0.0000, Gamma: 0.00.
7. Exit the filters panel, and in the Sources tab, shift click both Window Captures and right click the selection and click Group Selected Items
8. In the OBS display, drag the mouse detector around as needed.

If you want a different amount of transparency, change step 6's Opacity: 0.0050 to a different number.

# Tips

I am using Visual Studio to run this program. OBS can't display the mouse tracker if it's minimized, but putting it behind other windows/tabs or dragging it partially offscreen is fine. Sometimes I have noticed that the background of the tracker looks like a glitchy copy of another part of the screen, but that can be fixed by minimizing and unminimizing the tracker. I'm pretty sure I have fixed this bug but sometimes the dot will somehow reach a NaN position which makes the dot disappear. If it still happens, you have to close the tracker and reopen it.

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
