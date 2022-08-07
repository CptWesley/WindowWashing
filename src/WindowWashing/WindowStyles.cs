using System;

namespace WindowWashing;

/// <summary>
/// Represent different window styles.
/// Descriptions retrieved from: <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/window-styles"/>.
/// </summary>
/// <seealso cref="ExtendedWindowStyles"/>
[Flags]
public enum WindowStyles : long
{
    /// <summary>
    /// The window has a thin-line border.
    /// </summary>
    Border = 0x00800000L,

    /// <summary>
    /// The window has a title bar (includes the <see cref="Border"/> style).
    /// </summary>
    Caption = 0x00C00000L,

    /// <summary>
    /// The window is a child window.
    /// A window with this style cannot have a menu bar.
    /// This style cannot be used with the <see cref="Popup"/> style.
    /// </summary>
    Child = 0x40000000L,

    /// <summary>
    /// Same as the <see cref="Child"/> style.
    /// </summary>
    ChildWindow = 0x40000000L,

    /// <summary>
    /// Excludes the area occupied by child windows when drawing occurs within the parent window.
    /// This style is used when creating the parent window.
    /// </summary>
    ClipChildren = 0x02000000L,

    /// <summary>
    /// Clips child windows relative to each other; that is, when a particular child window
    /// receives a <c>WM_PAINT</c> message, the <see cref="ClipSiblings"/> style clips
    /// all other overlapping child windows out of the region of the child window to be updated.
    /// If <see cref="ClipSiblings"/> is not specified and child windows overlap, it is possible,
    /// when drawing within the client area of a child window, to draw within the client area
    /// of a neighboring child window.
    /// </summary>
    ClipSiblings = 0x04000000L,

    /// <summary>
    /// The window is initially disabled.
    /// A disabled window cannot receive input from the user.
    /// To change this after a window has been created, use the <c>EnableWindow</c> function.
    /// </summary>
    Disabled = 0x08000000L,

    /// <summary>
    /// The window has a border of a style typically used with dialog boxes.
    /// A window with this style cannot have a title bar.
    /// </summary>
    DialogFrame = 0x00400000L,

    /// <summary>
    /// The window is the first control of a group of controls.
    /// The group consists of this first control and all controls defined after it,
    /// up to the next control with the <see cref="Group"/> style.
    /// The first control in each group usually has the <see cref="TabStop"/> style so that
    /// the user can move from group to group.
    /// The user can subsequently change the keyboard focus from one control
    /// in the group to the next control in the group by using the direction keys.
    /// You can turn this style on and off to change dialog box navigation.
    /// To change this style after a window has been created, use the <see cref="Win32Windows.SetWindowLong(nint, WindowLong, long, bool)"/> function.
    /// </summary>
    Group = 0x00020000L,

    /// <summary>
    /// The window has a horizontal scroll bar.
    /// </summary>
    HorizontalScroll = 0x00100000L,

    /// <summary>
    /// The window is initially minimized. Same as the <see cref="Minimize"/> style.
    /// </summary>
    Iconic = 0x20000000L,

    /// <summary>
    /// The window is initially maximized.
    /// </summary>
    Maximize = 0x01000000L,

    /// <summary>
    /// The window has a maximize button.
    /// Cannot be combined with the <see cref="ExtendedWindowStyles.ContextHelp"/> style.
    /// The <see cref="SystemMenu"/> style must also be specified.
    /// </summary>
    MaximizeBox = 0x00010000L,

    /// <summary>
    /// The window is initially minimized. Same as the <see cref="Iconic"/> style.
    /// </summary>
    Minimize = 0x20000000L,

    /// <summary>
    /// The window has a minimize button.
    /// Cannot be combined with the <see cref="ExtendedWindowStyles.ContextHelp"/> style.
    /// The <see cref="SystemMenu"/> style must also be specified.
    /// </summary>
    MinimizeBox = 0x00020000L,

    /// <summary>
    /// The window is an overlapped window.
    /// An overlapped window has a title bar and a border.
    /// Same as the <see cref="Tiled"/> style.
    /// </summary>
    Overlapped = 0x00000000L,

    /// <summary>
    /// The window is an overlapped window.
    /// Same as the <see cref="TiledWindow"/> style.
    /// </summary>
    OverLappedWindow = Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox,

    /// <summary>
    /// The window is a pop-up window.
    /// This style cannot be used with the <see cref="Child"/> style.
    /// </summary>
    Popup = 0x80000000L,

    /// <summary>
    /// The window is a pop-up window.
    /// The <see cref="Caption"/> and <see cref="PopupWindow"/> styles must be combined to make the window menu visible.
    /// </summary>
    PopupWindow = Popup | Border | SystemMenu,

    /// <summary>
    /// The window has a sizing border.
    /// Same as the <see cref="ThickFrame"/> style.
    /// </summary>
    SizeBox = 0x00040000L,

    /// <summary>
    /// The window has a window menu on its title bar.
    /// The <see cref="Caption"/> style must also be specified.
    /// </summary>
    SystemMenu = 0x00080000L,

    /// <summary>
    /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
    /// Pressing the TAB key changes the keyboard focus to the next control with the <see cref="TabStop"/> style.
    /// You can turn this style on and off to change dialog box navigation.
    /// To change this style after a window has been created, use the <see cref="Win32Windows.SetWindowLong(nint, WindowLong, long, bool)"/> function.
    /// For user-created windows and modeless dialogs to work with tab stops,
    /// alter the message loop to call the <c>IsDialogMessage</c> function.
    /// </summary>
    TabStop = 0x00010000L,

    /// <summary>
    /// The window has a sizing border.
    /// Same as the <see cref="SizeBox"/> style.
    /// </summary>
    ThickFrame = 0x00040000L,

    /// <summary>
    /// The window is an overlapped window.
    /// An overlapped window has a title bar and a border.
    /// Same as the <see cref="Overlapped"/> style.
    /// </summary>
    Tiled = 0x00000000L,

    /// <summary>
    /// The window is an overlapped window.
    /// Same as the <see cref="OverLappedWindow"/> style.
    /// </summary>
    TiledWindow = OverLappedWindow,

    /// <summary>
    /// The window is initially visible.
    /// This style can be turned on and off by using the <c>ShowWindow</c> or <c>SetWindowPos</c> function.
    /// </summary>
    Visible = 0x10000000L,

    /// <summary>
    /// The window has a vertical scroll bar.
    /// </summary>
    VerticalScroll = 0x00200000L,
}
