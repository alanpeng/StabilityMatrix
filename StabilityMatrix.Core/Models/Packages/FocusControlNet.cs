﻿using StabilityMatrix.Core.Attributes;
using StabilityMatrix.Core.Helper;
using StabilityMatrix.Core.Helper.Cache;
using StabilityMatrix.Core.Services;

namespace StabilityMatrix.Core.Models.Packages;

[Singleton(typeof(BasePackage))]
public class FocusControlNet(
    IGithubApiCache githubApi,
    ISettingsManager settingsManager,
    IDownloadService downloadService,
    IPrerequisiteHelper prerequisiteHelper
) : Fooocus(githubApi, settingsManager, downloadService, prerequisiteHelper)
{
    public override string Name => "Fooocus-ControlNet-SDXL";
    public override string DisplayName { get; set; } = "Fooocus-ControlNet";
    public override string Author => "fenneishi";
    public override string Blurb => "Fooocus-ControlNet adds more control to the original Fooocus software.";
    public override string Disclaimer =>
        "This package has not been updated in over 8 months and may be abandoned.";

    public override string LicenseUrl =>
        "https://github.com/fenneishi/Fooocus-ControlNet-SDXL/blob/main/LICENSE";
    public override Uri PreviewImageUri =>
        new("https://github.com/fenneishi/Fooocus-ControlNet-SDXL/raw/main/asset/canny/snip.png");
    public override PackageDifficulty InstallerSortOrder => PackageDifficulty.Impossible;
    public override bool OfferInOneClickInstaller => false;

    public override SharedFolderLayout SharedFolderLayout =>
        base.SharedFolderLayout with
        {
            RelativeConfigPath = "user_path_config.txt"
        };
}
