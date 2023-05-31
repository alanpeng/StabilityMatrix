﻿using System.Collections.Generic;
using StabilityMatrix.Models;
using StabilityMatrix.ViewModels;
using Wpf.Ui.Contracts;

namespace StabilityMatrix.Helper;

public class DialogFactory : IDialogFactory
{
    private readonly IContentDialogService contentDialogService;
    private readonly LaunchOptionsDialogViewModel launchOptionsDialogViewModel;
    private readonly InstallerViewModel installerViewModel;
    private readonly ISettingsManager settingsManager;

    public DialogFactory(IContentDialogService contentDialogService, LaunchOptionsDialogViewModel launchOptionsDialogViewModel, 
        ISettingsManager settingsManager, InstallerViewModel installerViewModel)
    {
        this.contentDialogService = contentDialogService;
        this.launchOptionsDialogViewModel = launchOptionsDialogViewModel;
        this.installerViewModel = installerViewModel;
        this.settingsManager = settingsManager;
    }

    public LaunchOptionsDialog CreateLaunchOptionsDialog(IEnumerable<LaunchOptionDefinition> definitions, InstalledPackage installedPackage)
    {
        launchOptionsDialogViewModel.Cards.Clear();
        // Create cards
        launchOptionsDialogViewModel.CardsFromDefinitions(definitions);
        // Load user settings
        var userLaunchArgs = settingsManager.GetLaunchArgs(installedPackage.Id);
        launchOptionsDialogViewModel.LoadFromLaunchArgs(userLaunchArgs);

        return new LaunchOptionsDialog(contentDialogService, launchOptionsDialogViewModel);
    }
    
    public InstallerWindow CreateInstallerWindow()
    {
        return new InstallerWindow(installerViewModel);
    }
}
