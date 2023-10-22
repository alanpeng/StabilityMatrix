﻿using Avalonia.Markup.Xaml;
using StabilityMatrix.Avalonia.Controls;
using StabilityMatrix.Core.Attributes;

namespace StabilityMatrix.Avalonia.Views.Dialogs;

[Transient]
public partial class EnvVarsDialog : UserControlBase
{
    public EnvVarsDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
