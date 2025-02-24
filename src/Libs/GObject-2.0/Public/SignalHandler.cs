using System;

namespace GObject;

/// <summary>
/// SignalHandler for signals without any extra data.
/// </summary>
/// <param name="sender">The sender of this signal.</param>
/// <param name="args">Event args. Will always have the value of <see cref="EventArgs.Empty"/>.</param>
public delegate void SignalHandler<in TSender>(TSender sender, EventArgs args)
    where TSender : Object;

/// <summary>
/// SignalHandler for signals with extra data.
/// </summary>
/// <param name="sender">The sender of this signal.</param>
/// <param name="args"><see cref="SignalArgs"/> with additional data.</param>
public delegate void SignalHandler<in TSender, in TSignalArgs>(TSender sender, TSignalArgs args)
    where TSender : Object
    where TSignalArgs : SignalArgs;
