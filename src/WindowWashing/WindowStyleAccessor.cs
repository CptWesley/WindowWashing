using System.Runtime.CompilerServices;

namespace WindowWashing;

/// <summary>
/// Style setter used for changing the style of a <see cref="WindowHandle"/>.
/// </summary>
public unsafe readonly struct WindowStyleAccessor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowStyleAccessor"/> struct.
    /// </summary>
    /// <param name="window">The window.</param>
    public WindowStyleAccessor(WindowHandle window)
        => Window = window;

    /// <summary>
    /// Gets the related window.
    /// </summary>
    public WindowHandle Window { get; }

    /// <summary>
    /// Gets or sets the regular window styles of the window.
    /// </summary>
    public WindowStyles Styles
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetStyles(Window.HWndPtr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetStyles(Window.HWndPtr, value, true);
    }

    /// <summary>
    /// Gets or sets the extended window styles of the window.
    /// </summary>
    public ExtendedWindowStyles ExtendedStyles
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetExtendedStyles(Window.HWndPtr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetExtendedStyles(Window.HWndPtr, value, true);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Border"/> flag is set.
    /// The window has a thin-line border.
    /// </summary>
    public bool Border
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Border);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Border, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Caption"/> flag is set.
    /// The window has a title bar (includes the <see cref="Border"/> style).
    /// </summary>
    public bool Caption
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Caption);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Caption, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Child"/> flag is set.
    /// The window is a child window.
    /// A window with this style cannot have a menu bar.
    /// This style cannot be used with the <see cref="Popup"/> style.
    /// </summary>
    public bool Child
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Child);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Child, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.ChildWindow"/> flag is set.
    /// Same as the <see cref="Child"/> style.
    /// </summary>
    public bool ChildWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.ChildWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.ChildWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.ClipChildren"/> flag is set.
    /// Excludes the area occupied by child windows when drawing occurs within the parent window.
    /// This style is used when creating the parent window.
    /// </summary>
    public bool ClipChildren
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.ClipChildren);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.ClipChildren, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.ClipSiblings"/> flag is set.
    /// Clips child windows relative to each other; that is, when a particular child window
    /// receives a <c>WM_PAINT</c> message, the <see cref="ClipSiblings"/> style clips
    /// all other overlapping child windows out of the region of the child window to be updated.
    /// If <see cref="ClipSiblings"/> is not specified and child windows overlap, it is possible,
    /// when drawing within the client area of a child window, to draw within the client area
    /// of a neighboring child window.
    /// </summary>
    public bool ClipSiblings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.ClipSiblings);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.ClipSiblings, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Disabled"/> flag is set.
    /// The window is initially disabled.
    /// A disabled window cannot receive input from the user.
    /// To change this after a window has been created, use the <c>EnableWindow</c> function.
    /// </summary>
    public bool Disabled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Disabled);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Disabled, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.DialogFrame"/> flag is set.
    /// The window has a border of a style typically used with dialog boxes.
    /// A window with this style cannot have a title bar.
    /// </summary>
    public bool DialogFrame
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.DialogFrame);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.DialogFrame, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Group"/> flag is set.
    /// The window is the first control of a group of controls.
    /// The group consists of this first control and all controls defined after it,
    /// up to the next control with the <see cref="Group"/> style.
    /// The first control in each group usually has the <see cref="TabStop"/> style so that
    /// the user can move from group to group.
    /// The user can subsequently change the keyboard focus from one control
    /// in the group to the next control in the group by using the direction keys.
    /// You can turn this style on and off to change dialog box navigation.
    /// </summary>
    public bool Group
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Group);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Group, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.HorizontalScroll"/> flag is set.
    /// The window has a horizontal scroll bar.
    /// </summary>
    public bool HorizontalScroll
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.HorizontalScroll);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.HorizontalScroll, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Iconic"/> flag is set.
    /// The window is initially minimized. Same as the <see cref="Minimize"/> style.
    /// </summary>
    public bool Iconic
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Iconic);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Iconic, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Maximize"/> flag is set.
    /// The window is initially maximized.
    /// </summary>
    public bool Maximize
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Maximize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Maximize, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.MaximizeBox"/> flag is set.
    /// The window has a maximize button.
    /// Cannot be combined with the <see cref="ExtendedWindowStyles.ContextHelp"/> style.
    /// The <see cref="SystemMenu"/> style must also be specified.
    /// </summary>
    public bool MaximizeBox
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.MaximizeBox);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.MaximizeBox, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Minimize"/> flag is set.
    /// The window is initially minimized. Same as the <see cref="Iconic"/> style.
    /// </summary>
    public bool Minimize
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Minimize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Minimize, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.MinimizeBox"/> flag is set.
    /// The window has a minimize button.
    /// Cannot be combined with the <see cref="ExtendedWindowStyles.ContextHelp"/> style.
    /// The <see cref="SystemMenu"/> style must also be specified.
    /// </summary>
    public bool MinimizeBox
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.MinimizeBox);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.MinimizeBox, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Overlapped"/> flag is set.
    /// The window is an overlapped window.
    /// An overlapped window has a title bar and a border.
    /// Same as the <see cref="Tiled"/> style.
    /// </summary>
    public bool Overlapped
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Overlapped);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Overlapped, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.OverlappedWindow"/> flag is set.
    /// The window is an overlapped window.
    /// Same as the <see cref="TiledWindow"/> style.
    /// </summary>
    public bool OverlappedWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.OverlappedWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.OverlappedWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Popup"/> flag is set.
    /// The window is a pop-up window.
    /// This style cannot be used with the <see cref="Child"/> style.
    /// </summary>
    public bool Popup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Popup);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Popup, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.PopupWindow"/> flag is set.
    /// The window is a pop-up window.
    /// The <see cref="Caption"/> and <see cref="PopupWindow"/> styles must be combined to make the window menu visible.
    /// </summary>
    public bool PopupWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.PopupWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.PopupWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.SizeBox"/> flag is set.
    /// The window has a sizing border.
    /// Same as the <see cref="ThickFrame"/> style.
    /// </summary>
    public bool SizeBox
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.SizeBox);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.SizeBox, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.SystemMenu"/> flag is set.
    /// The window has a window menu on its title bar.
    /// The <see cref="Caption"/> style must also be specified.
    /// </summary>
    public bool SystemMenu
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.SystemMenu);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.SystemMenu, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.TabStop"/> flag is set.
    /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
    /// Pressing the TAB key changes the keyboard focus to the next control with the <see cref="TabStop"/> style.
    /// You can turn this style on and off to change dialog box navigation.
    /// </summary>
    public bool TabStop
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.TabStop);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.TabStop, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.ThickFrame"/> flag is set.
    /// The window has a sizing border.
    /// Same as the <see cref="SizeBox"/> style.
    /// </summary>
    public bool ThickFrame
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.ThickFrame);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.ThickFrame, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Tiled"/> flag is set.
    /// The window is an overlapped window.
    /// An overlapped window has a title bar and a border.
    /// Same as the <see cref="Overlapped"/> style.
    /// </summary>
    public bool Tiled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Tiled);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Tiled, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.TiledWindow"/> flag is set.
    /// The window is an overlapped window.
    /// Same as the <see cref="OverlappedWindow"/> style.
    /// </summary>
    public bool TiledWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.TiledWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.TiledWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.Visible"/> flag is set.
    /// The window is initially visible.
    /// This style can be turned on and off by using the <c>ShowWindow</c> or <c>SetWindowPos</c> function.
    /// </summary>
    public bool Visible
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.Visible);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.Visible, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="WindowStyles.VerticalScroll"/> flag is set.
    /// The window has a vertical scroll bar.
    /// </summary>
    public bool VerticalScroll
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(WindowStyles.VerticalScroll);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(WindowStyles.VerticalScroll, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.AcceptFiles"/> flag is set.
    /// The window accepts drag-drop files.
    /// </summary>
    public bool AcceptFiles
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.AcceptFiles);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.AcceptFiles, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.AppWindow"/> flag is set.
    /// Forces a top-level window onto the taskbar when the window is visible.
    /// </summary>
    public bool AppWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.AppWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.AppWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.ClientEdge"/> flag is set.
    /// The window has a border with a sunken edge.
    /// </summary>
    public bool ClientEdge
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.ClientEdge);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.ClientEdge, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.Composited"/> flag is set.
    /// Paints all descendants of a window in bottom-to-top painting order using double-buffering.
    /// Bottom-to-top painting order allows a descendent window to have translucency (alpha)
    /// and transparency (color-key) effects, but only if the descendent window also has the <c>WS_EX_TRANSPARENT</c>
    /// bit set. Double-buffering allows the window and its descendents to be painted without flicker.
    /// This cannot be used if the window has a class style of either <c>CS_OWNDC</c> or <c>CS_CLASSDC</c>.
    /// </summary>
    public bool Composited
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.Composited);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.Composited, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.ContextHelp"/> flag is set.
    /// The title bar of the window includes a question mark.
    /// When the user clicks the question mark, the cursor changes to a question mark with a pointer.
    /// If the user then clicks a child window, the child receives a <c>WM_HELP</c> message.
    /// The child window should pass the message to the parent window procedure,
    /// which should call the WinHelp function using the <c>HELP_WM_HELP</c> command.
    /// The Help application displays a pop-up window that typically contains help for the child window.
    /// <see cref="ContextHelp"/> cannot be used with the <see cref="MaximizeBox"/>
    /// or <see cref="MinimizeBox"/> styles.
    /// </summary>
    public bool ContextHelp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.ContextHelp);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.ContextHelp, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.ControlParent"/> flag is set.
    /// The window itself contains child windows that should take part in dialog box navigation.
    /// If this style is specified, the dialog manager recurses into children of this window
    /// when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
    /// </summary>
    public bool ControlParent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.ControlParent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.ControlParent, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.DialogModalFrame"/> flag is set.
    /// The window has a double border; the window can, optionally, be created with a title bar by
    /// specifying the <see cref="WindowStyles.Caption"/> style in the dwStyle parameter.
    /// </summary>
    public bool DialogModalFrame
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.DialogModalFrame);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.DialogModalFrame, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.Layered"/> flag is set.
    /// The window is a layered window.
    /// This style cannot be used if the window has a class style of either <c>CS_OWNDC</c> or <c>CS_CLASSDC</c>.
    /// Windows 8: The <see cref="Layered"/> style is supported for top-level windows and child windows.
    /// Previous Windows versions support <see cref="Layered"/> only for top-level windows.
    /// </summary>
    public bool Layered
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.Layered);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.Layered, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.LayoutRightToLeft"/> flag is set.
    /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment,
    /// the horizontal origin of the window is on the right edge.
    /// Increasing horizontal values advance to the left.
    /// </summary>
    public bool LayoutRightToLeft
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.LayoutRightToLeft);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.LayoutRightToLeft, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.Left"/> flag is set.
    /// The window has generic left-aligned properties. This is the default.
    /// </summary>
    public bool Left
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.Left);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.Left, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.LeftScrollBar"/> flag is set.
    /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment,
    /// the vertical scroll bar (if present) is to the left of the client area.
    /// For other languages, the style is ignored.
    /// </summary>
    public bool LeftScrollBar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.LeftScrollBar);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.LeftScrollBar, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.LeftToRightReading"/> flag is set.
    /// The window text is displayed using left-to-right reading-order properties.
    /// This is the default.
    /// </summary>
    public bool LeftToRightReading
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.LeftToRightReading);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.LeftToRightReading, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.MDIChild"/> flag is set.
    /// The window is a MDI child window.
    /// </summary>
    public bool MDIChild
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.MDIChild);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.MDIChild, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.NoActivate"/> flag is set.
    /// A top-level window created with this style does not become the foreground
    /// window when the user clicks it.
    /// The system does not bring this window to the foreground when the user
    /// minimizes or closes the foreground window.
    /// The window should not be activated through programmatic access or via
    /// keyboard navigation by accessible technology, such as Narrator.
    /// To activate the window, use the <c>SetActiveWindow</c> or <c>SetForegroundWindow</c> function.
    /// The window does not appear on the taskbar by default.
    /// To force the window to appear on the taskbar, use the <see cref="AppWindow"/> style.
    /// </summary>
    public bool NoActivate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.NoActivate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.NoActivate, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.NoInheritLayout"/> flag is set.
    /// The window does not pass its window layout to its child windows.
    /// </summary>
    public bool NoInheritLayout
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.NoInheritLayout);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.NoInheritLayout, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.NoParentNotify"/> flag is set.
    /// The child window created with this style does not send the <c>WM_PARENTNOTIFY</c> message to
    /// its parent window when it is created or destroyed.
    /// </summary>
    public bool NoParentNotify
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.NoParentNotify);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.NoParentNotify, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.NoRedirectionBitmap"/> flag is set.
    /// The window does not render to a redirection surface.
    /// This is for windows that do not have visible content
    /// or that use mechanisms other than surfaces to provide their visual.
    /// </summary>
    public bool NoRedirectionBitmap
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.NoRedirectionBitmap);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.NoRedirectionBitmap, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.OverlappedWindow"/> flag is set.
    /// The window is an overlapped window.
    /// </summary>
    public bool ExtendedOverlappedWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.OverlappedWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.OverlappedWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.PaletteWindow"/> flag is set.
    /// The window is palette window, which is a modeless dialog box that presents an array of commands.
    /// </summary>
    public bool PaletteWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.PaletteWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.PaletteWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.Right"/> flag is set.
    /// The window has generic "right-aligned" properties.
    /// This depends on the window class.
    /// This style has an effect only if the shell language is Hebrew, Arabic,
    /// or another language that supports reading-order alignment; otherwise, the style is ignored.
    /// Using the <see cref="Right"/> style for static or edit controls has the same effect as
    /// using the <c>SS_RIGHT</c> or <c>ES_RIGHT</c> style, respectively.
    /// Using this style with button controls has the same effect as using <c>BS_RIGHT</c> and <c>BS_RIGHTBUTTON</c> styles.
    /// </summary>
    public bool Right
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.Right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.Right, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.RightScrollBar"/> flag is set.
    /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
    /// </summary>
    public bool RightScrollBar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.RightScrollBar);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.RightScrollBar, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.RightToLeftReading"/> flag is set.
    /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment,
    /// the window text is displayed using right-to-left reading-order properties.
    /// For other languages, the style is ignored.
    /// </summary>
    public bool RightToLeftReading
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.RightToLeftReading);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.RightToLeftReading, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.StaticEdge"/> flag is set.
    /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
    /// </summary>
    public bool StaticEdge
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.StaticEdge);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.StaticEdge, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.ToolWindow"/> flag is set.
    /// The window is intended to be used as a floating toolbar.
    /// A tool window has a title bar that is shorter than a normal title bar,
    /// and the window title is drawn using a smaller font.
    /// A tool window does not appear in the taskbar or in the dialog
    /// that appears when the user presses ALT+TAB.
    /// If a tool window has a system menu, its icon is not displayed on the title bar.
    /// However, you can display the system menu by right-clicking or by typing ALT+SPACE.
    /// </summary>
    public bool ToolWindow
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.ToolWindow);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.ToolWindow, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.TopMost"/> flag is set.
    /// The window should be placed above all non-topmost windows and should stay above them,
    /// even when the window is deactivated. To add or remove this style, use the <c>SetWindowPos</c> function.
    /// </summary>
    public bool TopMost
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.TopMost);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.TopMost, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.Transparent"/> flag is set.
    /// The window should not be painted until siblings beneath the window
    /// (that were created by the same thread) have been painted.
    /// The window appears transparent because the bits of underlying
    /// sibling windows have already been painted.
    /// To achieve transparency without these restrictions,
    /// use the SetWindowRgn function.
    /// </summary>
    public bool Transparent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.Transparent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.Transparent, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether or not the <see cref="ExtendedWindowStyles.WindowEdge"/> flag is set.
    /// The window has a border with a raised edge.
    /// </summary>
    public bool WindowEdge
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsSet(ExtendedWindowStyles.WindowEdge);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Set(ExtendedWindowStyles.WindowEdge, value);
    }

    /// <summary>
    /// Sets a certain set of styles.
    /// </summary>
    /// <param name="styles">The styles to set.</param>
    /// <param name="value">Their value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(WindowStyles styles, bool value)
    {
        WindowStyles resultStyles = Styles;

        if (value)
        {
            resultStyles |= styles;
        }
        else
        {
            resultStyles &= ~styles;
        }

        Styles = resultStyles;
    }

    /// <summary>
    /// Sets a certain set of styles.
    /// </summary>
    /// <param name="styles">The styles to set.</param>
    /// <param name="value">Their value.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(ExtendedWindowStyles styles, bool value)
    {
        ExtendedWindowStyles resultStyles = ExtendedStyles;

        if (value)
        {
            resultStyles |= styles;
        }
        else
        {
            resultStyles &= ~styles;
        }

        ExtendedStyles = resultStyles;
    }

    /// <summary>
    /// Gets a value indicating whether or not the given style flags are set on the window.
    /// </summary>
    /// <param name="styles">The styles to check for.</param>
    /// <returns>A value indicating whether or not the given style flags are set on the window.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSet(WindowStyles styles)
        => Styles.HasFlag(styles);

    /// <summary>
    /// Gets a value indicating whether or not the given style flags are set on the window.
    /// </summary>
    /// <param name="styles">The styles to check for.</param>
    /// <returns>A value indicating whether or not the given style flags are set on the window.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSet(ExtendedWindowStyles styles)
        => ExtendedStyles.HasFlag(styles);
}
