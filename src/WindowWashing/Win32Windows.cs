using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace WindowWashing;

/// <summary>
/// Provides a thin wrapper over the native function calls.
/// </summary>
public static unsafe class Win32Windows
{
    private const string WindowsOS = "windows";

    /// <summary>
    /// Callback function for enumerating windows.
    /// </summary>
    /// <param name="hWnd">The handle of the window being enumerated.</param>
    /// <returns>A value indicating whether or not we should continue the enumeration or terminate early.</returns>
    public delegate bool EnumWindowsPtrFunc(void* hWnd);

    private delegate bool EnumWindowsInternalDelegate(void* hWnd, void* data);

    /// <summary>
    /// Checks if the last native call threw an error. If so, throw an exception.
    /// </summary>
    /// <exception cref="Win32Exception">The exception caused by the native call.</exception>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfError()
    {
        int error = Marshal.GetLastWin32Error();

        if (error == 0)
        {
            return;
        }

        if (error != 0)
        {
            throw new Win32Exception(error);
        }
    }

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The window handle of the old window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* SetParent(void* hWndChild, void* hWndNewParent, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        void* result = NativeMethods.SetParent(hWndChild, hWndNewParent);

        if (throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The window handle of the old window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint SetParent(nint hWndChild, nint hWndNewParent, bool throwOnError = false)
        => (nint)SetParent((void*)hWndChild, (void*)hWndNewParent, throwOnError);

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <param name="hWndOldParent">The window handle of the old window. A nullpointer if the operation was unsuccesful.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetParent(void* hWndChild, void* hWndNewParent, out void* hWndOldParent)
    {
        hWndOldParent = NativeMethods.SetParent(hWndChild, hWndNewParent);
        return hWndOldParent != null;
    }

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <param name="hWndOldParent">The window handle of the old window. A nullpointer if the operation was unsuccesful.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetParent(nint hWndChild, nint hWndNewParent, out nint hWndOldParent)
    {
        bool result = TrySetParent((void*)hWndChild, (void*)hWndNewParent, out void* hWndOldParentPtr);
        hWndOldParent = (nint)hWndOldParentPtr;
        return result;
    }

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetParent(void* hWndChild, void* hWndNewParent)
        => TrySetParent(hWndChild, hWndNewParent, out void* old);

    /// <summary>
    /// Sets a window to be the child of another window.
    /// </summary>
    /// <param name="hWndChild">The window handle of the window that will become the child.</param>
    /// <param name="hWndNewParent">The window handle of the window that will become the parent.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetParent(nint hWndChild, nint hWndNewParent)
        => TrySetParent((void*)hWndChild, (void*)hWndNewParent);

    /// <summary>
    /// Moves a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="x">The new x coordinate relative to the parent or desktop.</param>
    /// <param name="y">The new y coordinate relative to the parent or desktop.</param>
    /// <param name="width">The new width of the window.</param>
    /// <param name="height">The new height of the window.</param>
    /// <param name="repaint">Indicates whether or not the window needs to be repainted.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool MoveWindow(void* hWnd, int x, int y, int width, int height, bool repaint, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        bool result = NativeMethods.MoveWindow(hWnd, x, y, width, height, repaint);
        if (throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Moves a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="x">The new x coordinate relative to the parent or desktop.</param>
    /// <param name="y">The new y coordinate relative to the parent or desktop.</param>
    /// <param name="width">The new width of the window.</param>
    /// <param name="height">The new height of the window.</param>
    /// <param name="repaint">Indicates whether or not the window needs to be repainted.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool MoveWindow(nint hWnd, int x, int y, int width, int height, bool repaint, bool throwOnError = false)
        => MoveWindow((void*)hWnd, x, y, width, height, repaint, throwOnError);

    /// <summary>
    /// Retrieves a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window long to retrieve.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The retrieved window long.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long GetWindowLong(void* hWnd, WindowLong index, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        long result = NativeMethods.GetWindowLong(hWnd, (int)index);
        if (throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Retrieves a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window long to retrieve.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The retrieved window long.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long GetWindowLong(nint hWnd, WindowLong index, bool throwOnError = false)
        => GetWindowLong((void*)hWnd, index, throwOnError);

    /// <summary>
    /// Retrieve the <see cref="WindowStyles"/> flags of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The <see cref="WindowStyles"/> flags of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WindowStyles GetStyles(void* hWnd, bool throwOnError = false)
        => (WindowStyles)GetWindowLong(hWnd, WindowLong.Style, throwOnError);

    /// <summary>
    /// Retrieve the <see cref="WindowStyles"/> flags of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The <see cref="WindowStyles"/> flags of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WindowStyles GetStyles(nint hWnd, bool throwOnError = false)
        => GetStyles((void*)hWnd, throwOnError);

    /// <summary>
    /// Retrieve the <see cref="ExtendedWindowStyles"/> flags of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The <see cref="ExtendedWindowStyles"/> flags of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ExtendedWindowStyles GetExtendedStyles(void* hWnd, bool throwOnError = false)
        => (ExtendedWindowStyles)GetWindowLong(hWnd, WindowLong.ExtendedStyle, throwOnError);

    /// <summary>
    /// Retrieve the <see cref="WindowStyles"/> flags of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The <see cref="ExtendedWindowStyles"/> flags of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ExtendedWindowStyles GetExtendedStyles(nint hWnd, bool throwOnError = false)
        => GetExtendedStyles((void*)hWnd, throwOnError);

    /// <summary>
    /// Retrieve the application instance (<c>HINSTANCE</c>).
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The application instance (<c>HINSTANCE</c>) of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GetHInstance(void* hWnd, bool throwOnError = false)
        => (void*)GetWindowLong(hWnd, WindowLong.HInstance, throwOnError);

    /// <summary>
    /// Retrieve the application instance (<c>HINSTANCE</c>).
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The application instance (<c>HINSTANCE</c>) of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetHInstance(nint hWnd, bool throwOnError = false)
        => (nint)GetHInstance((void*)hWnd, throwOnError);

    /// <summary>
    /// Retrieve the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The identifier of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GetIdentifier(void* hWnd, bool throwOnError = false)
        => (void*)GetWindowLong(hWnd, WindowLong.Id, throwOnError);

    /// <summary>
    /// Retrieve the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The identifier of the window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetIdentifier(nint hWnd, bool throwOnError = false)
        => (nint)GetIdentifier((void*)hWnd, throwOnError);

    /// <summary>
    /// Tries to set a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <param name="oldLong">The old window long value.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWindowLong(void* hWnd, WindowLong index, long dwNewLong, out long oldLong)
        => TrySetWindowLongInternal(hWnd, index, dwNewLong, out oldLong) == 0;

    /// <summary>
    /// Tries to set a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <param name="oldLong">The old window long value.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWindowLong(nint hWnd, WindowLong index, long dwNewLong, out long oldLong)
        => TrySetWindowLong((void*)hWnd, index, dwNewLong, out oldLong);

    /// <summary>
    /// Tries to set a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWindowLong(void* hWnd, WindowLong index, long dwNewLong)
        => TrySetWindowLongInternal(hWnd, index, dwNewLong, out long oldLong) == 0;

    /// <summary>
    /// Tries to set a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWindowLong(nint hWnd, WindowLong index, long dwNewLong)
        => TrySetWindowLong((void*)hWnd, index, dwNewLong);

    /// <summary>
    /// Sets a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old window long value.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long SetWindowLong(void* hWnd, WindowLong index, long dwNewLong, bool throwOnError = false)
    {
        int errorCode = TrySetWindowLongInternal(hWnd, index, dwNewLong, out long oldLong);
        if (errorCode != 0 && throwOnError)
        {
            throw new Win32Exception(errorCode);
        }

        return oldLong;
    }

    /// <summary>
    /// Sets a window long.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="index">The type of window handle to set.</param>
    /// <param name="dwNewLong">The new window long value.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old window long value.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long SetWindowLong(nint hWnd, WindowLong index, long dwNewLong, bool throwOnError = false)
        => SetWindowLong((void*)hWnd, index, dwNewLong, throwOnError);

    /// <summary>
    /// Tries to set the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="oldStyles">The old styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetStyles(void* hWnd, WindowStyles newStyles, out WindowStyles oldStyles)
    {
        bool result = TrySetWindowLong(hWnd, WindowLong.Style, (long)newStyles, out long oldStylesLong);
        oldStyles = (WindowStyles)oldStylesLong;
        return result;
    }

    /// <summary>
    /// Tries to set the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="oldStyles">The old styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetStyles(nint hWnd, WindowStyles newStyles, out WindowStyles oldStyles)
        => TrySetStyles((void*)hWnd, newStyles, out oldStyles);

    /// <summary>
    /// Tries to set the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetStyles(void* hWnd, WindowStyles newStyles)
        => TrySetStyles(hWnd, newStyles, out WindowStyles oldStyles);

    /// <summary>
    /// Tries to set the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetStyles(nint hWnd, WindowStyles newStyles)
        => TrySetStyles((void*)hWnd, newStyles);

    /// <summary>
    /// Sets the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old window styles.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WindowStyles SetStyles(void* hWnd, WindowStyles newStyles, bool throwOnError = false)
        => (WindowStyles)SetWindowLong(hWnd, WindowLong.Style, (long)newStyles, throwOnError);

    /// <summary>
    /// Sets the window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old window styles.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WindowStyles SetStyles(nint hWnd, WindowStyles newStyles, bool throwOnError = false)
        => SetStyles((void*)hWnd, newStyles, throwOnError);

    /// <summary>
    /// Tries to set the extended window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="oldStyles">The old styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetExtendedStyles(void* hWnd, ExtendedWindowStyles newStyles, out ExtendedWindowStyles oldStyles)
    {
        bool result = TrySetWindowLong(hWnd, WindowLong.ExtendedStyle, (long)newStyles, out long oldStylesLong);
        oldStyles = (ExtendedWindowStyles)oldStylesLong;
        return result;
    }

    /// <summary>
    /// Tries to set the extended window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="oldStyles">The old styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetExtendedStyles(nint hWnd, ExtendedWindowStyles newStyles, out ExtendedWindowStyles oldStyles)
        => TrySetExtendedStyles((void*)hWnd, newStyles, out oldStyles);

    /// <summary>
    /// Tries to set the extended window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetExtendedStyles(void* hWnd, ExtendedWindowStyles newStyles)
        => TrySetExtendedStyles(hWnd, newStyles, out ExtendedWindowStyles oldStyles);

    /// <summary>
    /// Tries to set the extended window styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetExtendedStyles(nint hWnd, ExtendedWindowStyles newStyles)
        => TrySetExtendedStyles((void*)hWnd, newStyles);

    /// <summary>
    /// Sets the window extended styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old extended window styles.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ExtendedWindowStyles SetExtendedStyles(void* hWnd, ExtendedWindowStyles newStyles, bool throwOnError = false)
        => (ExtendedWindowStyles)SetWindowLong(hWnd, WindowLong.ExtendedStyle, (long)newStyles, throwOnError);

    /// <summary>
    /// Sets the window extended styles of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newStyles">The new styles.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The old extended window styles.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ExtendedWindowStyles SetExtendedStyles(nint hWnd, ExtendedWindowStyles newStyles, bool throwOnError = false)
        => SetExtendedStyles((void*)hWnd, newStyles, throwOnError);

    /// <summary>
    /// Tries to set the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <param name="oldId">The old identifier.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetIdentifier(void* hWnd, void* newId, out void* oldId)
    {
        bool result = TrySetWindowLong(hWnd, WindowLong.Id, (long)newId, out long oldIdLong);
        oldId = (void*)oldIdLong;
        return result;
    }

    /// <summary>
    /// Tries to set the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <param name="oldId">The old identifier.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetIdentifier(nint hWnd, nint newId, out nint oldId)
    {
        bool result = TrySetIdentifier((void*)hWnd, (void*)newId, out void* oldStylesPtr);
        oldId = (nint)oldStylesPtr;
        return result;
    }

    /// <summary>
    /// Tries to set the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetIdentifier(void* hWnd, void* newId)
        => TrySetIdentifier(hWnd, newId, out void* oldId);

    /// <summary>
    /// Tries to set the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetIdentifier(nint hWnd, nint newId)
        => TrySetIdentifier((void*)hWnd, (void*)newId);

    /// <summary>
    /// Sets the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns the old identifier.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* SetIdentifier(void* hWnd, void* newId, bool throwOnError = false)
        => (void*)SetWindowLong(hWnd, WindowLong.Id, (long)newId, throwOnError);

    /// <summary>
    /// Sets the window identifier.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new identifier.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns the old identifier.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint SetIdentifier(nint hWnd, nint newId, bool throwOnError = false)
        => (nint)SetIdentifier((void*)hWnd, (void*)newId, throwOnError);

    /// <summary>
    /// Tries to set the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new HINSTANCE.</param>
    /// <param name="oldId">The old HINSTANCE.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetHInstance(void* hWnd, void* newId, out void* oldId)
    {
        bool result = TrySetWindowLong(hWnd, WindowLong.HInstance, (long)newId, out long oldIdLong);
        oldId = (void*)oldIdLong;
        return result;
    }

    /// <summary>
    /// Tries to set the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new HINSTANCE.</param>
    /// <param name="oldId">The old HINSTANCE.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetHInstance(nint hWnd, nint newId, out nint oldId)
    {
        bool result = TrySetHInstance((void*)hWnd, (void*)newId, out void* oldStylesPtr);
        oldId = (nint)oldStylesPtr;
        return result;
    }

    /// <summary>
    /// Tries to set the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new HINSTANCE.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetHInstance(void* hWnd, void* newId)
        => TrySetHInstance(hWnd, newId, out void* oldId);

    /// <summary>
    /// Tries to set the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new styles.</param>
    /// <returns>Returns <c>true</c> if the operation was succesful, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetHInstance(nint hWnd, nint newId)
        => TrySetHInstance((void*)hWnd, (void*)newId);

    /// <summary>
    /// Sets the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new HINSTANCE.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns the old HINSTANCE.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* SetHInstance(void* hWnd, void* newId, bool throwOnError = false)
        => (void*)SetWindowLong(hWnd, WindowLong.HInstance, (long)newId, throwOnError);

    /// <summary>
    /// Sets the window HINSTANCE.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="newId">The new HINSTANCE.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>Returns the old HINSTANCE.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint SetHInstance(nint hWnd, nint newId, bool throwOnError = false)
        => (nint)SetHInstance((void*)hWnd, (void*)newId, throwOnError);

    /// <summary>
    /// Gets the hWnd of the desktop window.
    /// </summary>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GetDesktopWindowPtr()
        => NativeMethods.GetDesktopWindow();

    /// <summary>
    /// Gets the hWnd of the desktop window.
    /// </summary>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetDesktopWindow()
        => (nint)GetDesktopWindowPtr();

    /// <summary>
    /// Gets the hWnd of the currently active window.
    /// </summary>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GetForegroundWindowPtr()
        => NativeMethods.GetForegroundWindow();

    /// <summary>
    /// Gets the hWnd of the currently active window.
    /// </summary>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetForegroundWindow()
        => (nint)GetForegroundWindowPtr();

    /// <summary>
    /// Gets the hWnd of the parent window of the given window.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GetParent(void* hWnd)
        => NativeMethods.GetParent(hWnd);

    /// <summary>
    /// Gets the hWnd of the parent window of the given window.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <returns>The hWnd of the desktop window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetParent(nint hWnd)
        => (nint)GetParent((void*)hWnd);

    /// <summary>
    /// Checks if the given hWnd refers to an existing window.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <returns>Returns <c>true</c> if the given window exists, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWindow(void* hWnd)
        => NativeMethods.IsWindow(hWnd);

    /// <summary>
    /// Checks if the given hWnd refers to an existing window.
    /// </summary>
    /// <param name="hWnd">The handle of the window.</param>
    /// <returns>Returns <c>true</c> if the given window exists, <c>false</c> otherwise.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWindow(nint hWnd)
        => IsWindow((void*)hWnd);

    /// <summary>
    /// Changes the show mode of the window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="cmd">The show command to apply.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>
    /// If the window was previously visible, the return value is <c>true</c>.
    /// If the window was previously hidden, the return value is <c>false</c>.
    /// </returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ShowWindow(void* hWnd, ShowWindow cmd, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        bool result = NativeMethods.ShowWindow(hWnd, (int)cmd);

        if (throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Changes the show mode of the window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="cmd">The show command to apply.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>
    /// If the window was previously visible, the return value is <c>true</c>.
    /// If the window was previously hidden, the return value is <c>false</c>.
    /// </returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ShowWindow(nint hWnd, ShowWindow cmd, bool throwOnError = false)
        => ShowWindow((void*)hWnd, cmd, throwOnError);

    /// <summary>
    /// Gets the length of the window title.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The number of characters in the window title.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWindowTextLength(void* hWnd, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        int result = NativeMethods.GetWindowTextLength(hWnd);

        if (throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Gets the length of the window title.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The number of characters in the window title.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWindowTextLength(nint hWnd, bool throwOnError = false)
        => GetWindowTextLength((void*)hWnd, throwOnError);

    /// <summary>
    /// Gets the title of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The window title.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetWindowText(void* hWnd, bool throwOnError = false)
    {
        int length = GetWindowTextLength(hWnd, throwOnError);
        StringBuilder sb = new StringBuilder(length + 1);
        NativeMethods.SetLastError(0);
        int read = NativeMethods.GetWindowText(hWnd, sb, sb.Capacity);

        if (throwOnError)
        {
            ThrowIfError();
        }

        return sb.ToString();
    }

    /// <summary>
    /// Gets the title of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The window title.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetWindowText(nint hWnd, bool throwOnError = false)
        => GetWindowText((void*)hWnd, throwOnError);

    /// <summary>
    /// Sets the title of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="text">The new title.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SetWindowText(void* hWnd, string text, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        NativeMethods.SetWindowText(hWnd, text);
        int errorCode = Marshal.GetLastWin32Error();

        if (throwOnError && errorCode != 0)
        {
            throw new Win32Exception(errorCode);
        }

        return errorCode == 0;
    }

    /// <summary>
    /// Sets the title of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="text">The new title.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SetWindowText(nint hWnd, string text, bool throwOnError = false)
        => SetWindowText((void*)hWnd, text, throwOnError);

    /// <summary>
    /// Enumerates over all top-level windows.
    /// </summary>
    /// <param name="cb">The callback function.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EnumWindows(EnumWindowsPtrFunc cb, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        bool result = NativeMethods.EnumWindows((w, d) => cb(w), null);
        if (!result && throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Enumerates over all top-level windows.
    /// </summary>
    /// <param name="cb">The callback function.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EnumWindows(Func<nint, bool> cb, bool throwOnError = false)
        => EnumWindows((void* w) => cb((nint)w), throwOnError);

    /// <summary>
    /// Enumerates over all top-level windows.
    /// </summary>
    /// <returns>All top-level windows.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<nint> EnumWindows()
    {
        List<nint> result = new List<nint>();
        EnumWindows(
            (nint hwnd) =>
            {
                result.Add(hwnd);
                return true;
            },
            false);
        return result;
    }

    /// <summary>
    /// Enumerates over all child windows of the given window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="cb">The callback function.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EnumChildWindows(void* hWnd, EnumWindowsPtrFunc cb, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        bool result = NativeMethods.EnumChildWindows(hWnd, (w, d) => cb(w), null);
        if (!result && throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Enumerates over all child windows of the given window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="cb">The callback function.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EnumChildWindows(nint hWnd, Func<nint, bool> cb, bool throwOnError = false)
        => EnumChildWindows((void*)hWnd, (void* w) => cb((nint)w), throwOnError);

    /// <summary>
    /// Enumerates over all child windows of the given window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <returns>All top-level windows.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<nint> EnumChildWindows(nint hWnd)
    {
        List<nint> result = new List<nint>();
        EnumChildWindows(
            hWnd,
            (nint hwnd) =>
            {
                result.Add(hwnd);
                return true;
            },
            false);
        return result;
    }

    /// <summary>
    /// Enumerates over all child windows of the given window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <returns>All top-level windows.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<nint> EnumChildWindows(void* hWnd)
        => EnumChildWindows((nint)hWnd);

    /// <summary>
    /// Gets the class name of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The class name of the given window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetClassName(void* hWnd, bool throwOnError = false)
    {
        StringBuilder sb = new StringBuilder(256);
        NativeMethods.SetLastError(0);
        int read = NativeMethods.GetClassName(hWnd, sb, sb.Capacity);
        int errorCode = Marshal.GetLastWin32Error();

        if (read == 0 && errorCode != 0 && throwOnError)
        {
            throw new Win32Exception(errorCode);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Gets the class name of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>The class name of the given window.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetClassName(nint hWnd, bool throwOnError = false)
        => GetClassName((void*)hWnd, throwOnError);

    /// <summary>
    /// Send a message to request the closing of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DestroyWindow(void* hWnd, bool throwOnError = false)
    {
        NativeMethods.SetLastError(0);
        bool result = NativeMethods.DestroyWindow(hWnd);

        if (!result && throwOnError)
        {
            ThrowIfError();
        }

        return result;
    }

    /// <summary>
    /// Send a message to request the closing of a window.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    /// <param name="throwOnError">Indicates whether or not an exception should be thrown when an error occured.</param>
    /// <returns>A value indicating whether or not the operation was succesful.</returns>
    [SupportedOSPlatform(WindowsOS)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DestroyWindow(nint hWnd, bool throwOnError = false)
        => DestroyWindow((void*)hWnd, throwOnError);

    private static int TrySetWindowLongInternal(void* hWnd, WindowLong index, long dwNewLong, out long oldLong)
    {
        NativeMethods.SetLastError(0);
        oldLong = NativeMethods.SetWindowLong(hWnd, (int)index, dwNewLong);
        if (oldLong == 0)
        {
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 0)
            {
                return errorCode;
            }
        }

        return 0;
    }

    private static class NativeMethods
    {
        private const string User32 = "user32";
        private const string Kernel32 = "kernel32";

        [DllImport(Kernel32, SetLastError = true)]
        public static extern void SetLastError(uint dwErrorCode);

        [DllImport(User32, SetLastError = true)]
        public static extern void* SetParent(void* hWndChild, void* hWndNewParent);

        [DllImport(User32, SetLastError = true)]
        public static extern bool MoveWindow(void* hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport(User32, SetLastError = true)]
        public static extern long GetWindowLong(void* hWnd, int nIndex);

        [DllImport(User32, SetLastError = true)]
        public static extern long SetWindowLong(void* hWnd, int nIndex, long dwNewLong);

        [DllImport(User32, SetLastError = true)]
        public static extern void* GetDesktopWindow();

        [DllImport(User32, SetLastError = true)]
        public static extern void* GetForegroundWindow();

        [DllImport(User32, SetLastError = true)]
        public static extern void* GetParent(void* hWnd);

        [DllImport(User32, SetLastError = true)]
        public static extern bool IsWindow(void* hWnd);

        [DllImport(User32, SetLastError = true)]
        public static extern bool ShowWindow(void* hWnd, int nCmdShow);

        [DllImport(User32, SetLastError = true)]
        public static extern int GetWindowTextLength(void* hWnd);

        [DllImport(User32, SetLastError = true)]
        public static extern int GetWindowText(void* hWnd, StringBuilder lpString, int maxCount);

        [DllImport(User32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(void* hWnd, string lpString);

        [DllImport(User32, SetLastError = true)]
        public static extern bool EnumWindows(EnumWindowsInternalDelegate lpEnumFunc, void* lParam);

        [DllImport(User32, SetLastError = true)]
        public static extern bool EnumChildWindows(void* hWnd, EnumWindowsInternalDelegate lpEnumFunc, void* lParam);

        [DllImport(User32, SetLastError = true)]
        public static extern int GetClassName(void* hWnd, StringBuilder lpString, int maxCount);

        [DllImport(User32, SetLastError = true)]
        public static extern bool DestroyWindow(void* hWnd);
    }
}