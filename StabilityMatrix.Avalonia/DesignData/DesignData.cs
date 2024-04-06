﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using AvaloniaEdit.Utils;
using DynamicData;
using DynamicData.Binding;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Semver;
using StabilityMatrix.Avalonia.Controls.CodeCompletion;
using StabilityMatrix.Avalonia.Models;
using StabilityMatrix.Avalonia.Models.TagCompletion;
using StabilityMatrix.Avalonia.Services;
using StabilityMatrix.Avalonia.ViewModels;
using StabilityMatrix.Avalonia.ViewModels.Base;
using StabilityMatrix.Avalonia.ViewModels.CheckpointBrowser;
using StabilityMatrix.Avalonia.ViewModels.CheckpointManager;
using StabilityMatrix.Avalonia.ViewModels.Dialogs;
using StabilityMatrix.Avalonia.ViewModels.Inference;
using StabilityMatrix.Avalonia.ViewModels.Inference.Video;
using StabilityMatrix.Avalonia.ViewModels.OutputsPage;
using StabilityMatrix.Avalonia.ViewModels.PackageManager;
using StabilityMatrix.Avalonia.ViewModels.Progress;
using StabilityMatrix.Avalonia.ViewModels.Settings;
using StabilityMatrix.Core.Api;
using StabilityMatrix.Core.Database;
using StabilityMatrix.Core.Helper;
using StabilityMatrix.Core.Helper.Cache;
using StabilityMatrix.Core.Helper.Factory;
using StabilityMatrix.Core.Models;
using StabilityMatrix.Core.Models.Api;
using StabilityMatrix.Core.Models.Api.Comfy;
using StabilityMatrix.Core.Models.Api.OpenArt;
using StabilityMatrix.Core.Models.Database;
using StabilityMatrix.Core.Models.FileInterfaces;
using StabilityMatrix.Core.Models.PackageModification;
using StabilityMatrix.Core.Models.Packages;
using StabilityMatrix.Core.Models.Packages.Extensions;
using StabilityMatrix.Core.Models.Progress;
using StabilityMatrix.Core.Models.Update;
using StabilityMatrix.Core.Python;
using StabilityMatrix.Core.Services;
using StabilityMatrix.Core.Updater;
using CivitAiBrowserViewModel = StabilityMatrix.Avalonia.ViewModels.CheckpointBrowser.CivitAiBrowserViewModel;
using HuggingFacePageViewModel = StabilityMatrix.Avalonia.ViewModels.CheckpointBrowser.HuggingFacePageViewModel;

namespace StabilityMatrix.Avalonia.DesignData;

[Localizable(false)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class DesignData
{
    [NotNull]
    public static IServiceProvider? Services { get; set; }

    private static bool isInitialized;

    // This needs to be static method instead of static constructor
    // or else Avalonia analyzers won't work.
    public static void Initialize()
    {
        if (isInitialized)
            throw new InvalidOperationException("DesignData is already initialized.");

        var services = App.ConfigureServices();

        var activePackageId = Guid.NewGuid();
        services.AddSingleton<ISettingsManager, MockSettingsManager>(
            _ =>
                new MockSettingsManager
                {
                    Settings =
                    {
                        InstalledPackages = new List<InstalledPackage>
                        {
                            new()
                            {
                                Id = activePackageId,
                                DisplayName = "My Installed Package",
                                PackageName = "stable-diffusion-webui",
                                Version = new InstalledPackageVersion { InstalledReleaseVersion = "v1.0.0" },
                                LibraryPath = $"Packages{Path.DirectorySeparatorChar}example-webui",
                                LastUpdateCheck = DateTimeOffset.Now
                            },
                            new()
                            {
                                Id = Guid.NewGuid(),
                                DisplayName = "Comfy Diffusion WebUI Dev Branch Long Name",
                                PackageName = "ComfyUI",
                                Version = new InstalledPackageVersion
                                {
                                    InstalledBranch = "master",
                                    InstalledCommitSha = "abc12uwu345568972abaedf7g7e679a98879e879f87ga8"
                                },
                                LibraryPath = $"Packages{Path.DirectorySeparatorChar}example-webui",
                                LastUpdateCheck = DateTimeOffset.Now
                            },
                            new()
                            {
                                Id = Guid.NewGuid(),
                                DisplayName = "Running Comfy",
                                PackageName = "ComfyUI",
                                Version = new InstalledPackageVersion
                                {
                                    InstalledBranch = "master",
                                    InstalledCommitSha = "abc12uwu345568972abaedf7g7e679a98879e879f87ga8"
                                },
                                LibraryPath = $"Packages{Path.DirectorySeparatorChar}example-webui",
                                LastUpdateCheck = DateTimeOffset.Now
                            }
                        },
                        ActiveInstalledPackageId = activePackageId
                    }
                }
        );

        // General services
        services
            .AddLogging()
            .AddSingleton<IPackageFactory, PackageFactory>()
            .AddSingleton<IUpdateHelper, UpdateHelper>()
            .AddSingleton<ModelFinder>()
            .AddSingleton<SharedState>();

        // Mock services
        services
            .AddSingleton(Substitute.For<INotificationService>())
            .AddSingleton(Substitute.For<ISharedFolders>())
            .AddSingleton(Substitute.For<IDownloadService>())
            .AddSingleton(Substitute.For<IHttpClientFactory>())
            .AddSingleton(Substitute.For<IApiFactory>())
            .AddSingleton(Substitute.For<IDiscordRichPresenceService>())
            .AddSingleton(Substitute.For<ITrackedDownloadService>())
            .AddSingleton(Substitute.For<ILiteDbContext>())
            .AddSingleton(Substitute.For<IAccountsService>())
            .AddSingleton<IInferenceClientManager, MockInferenceClientManager>()
            .AddSingleton<ICompletionProvider, MockCompletionProvider>()
            .AddSingleton<IModelIndexService, MockModelIndexService>()
            .AddSingleton<IImageIndexService, MockImageIndexService>()
            .AddSingleton<IMetadataImportService, MetadataImportService>();

        // Placeholder services that nobody should need during design time
        services
            .AddSingleton<IPyRunner>(_ => null!)
            .AddSingleton<ILiteDbContext>(_ => null!)
            .AddSingleton<ICivitApi>(_ => null!)
            .AddSingleton<IGithubApiCache>(_ => null!)
            .AddSingleton<ITokenizerProvider>(_ => null!)
            .AddSingleton<IPrerequisiteHelper>(_ => null!);

        // Override Launch page with mock
        services.Remove(ServiceDescriptor.Singleton<LaunchPageViewModel, LaunchPageViewModel>());
        services.AddSingleton<LaunchPageViewModel, MockLaunchPageViewModel>();

        Services = services.BuildServiceProvider();

        var dialogFactory = Services.GetRequiredService<ServiceManager<ViewModelBase>>();
        var settingsManager = Services.GetRequiredService<ISettingsManager>();
        var downloadService = Services.GetRequiredService<IDownloadService>();
        var modelFinder = Services.GetRequiredService<ModelFinder>();
        var packageFactory = Services.GetRequiredService<IPackageFactory>();
        var notificationService = Services.GetRequiredService<INotificationService>();
        var modelImportService = Services.GetRequiredService<IMetadataImportService>();

        LaunchOptionsViewModel = Services.GetRequiredService<LaunchOptionsViewModel>();
        LaunchOptionsViewModel.Cards = new[]
        {
            LaunchOptionCard.FromDefinition(
                new LaunchOptionDefinition
                {
                    Name = "Host",
                    Type = LaunchOptionType.String,
                    Description = "The host name for the Web UI",
                    DefaultValue = "localhost",
                    Options = { "--host" }
                }
            ),
            LaunchOptionCard.FromDefinition(
                new LaunchOptionDefinition
                {
                    Name = "API",
                    Type = LaunchOptionType.Bool,
                    Options = { "--api" }
                }
            )
        };
        LaunchOptionsViewModel.UpdateFilterCards();

        NewInstallerDialogViewModel = Services.GetRequiredService<PackageInstallBrowserViewModel>();
        // NewInstallerDialogViewModel.InferencePackages = new ObservableCollectionExtended<BasePackage>(
        //     packageFactory.GetPackagesByType(PackageType.SdInference).OrderBy(p => p.InstallerSortOrder)
        // );
        // NewInstallerDialogViewModel.TrainingPackages = new ObservableCollection<BasePackage>(
        //     packageFactory.GetPackagesByType(PackageType.SdTraining).OrderBy(p => p.InstallerSortOrder)
        // );

        PackageInstallDetailViewModel = new PackageInstallDetailViewModel(
            packageFactory.GetAllAvailablePackages().FirstOrDefault() as BaseGitPackage,
            settingsManager,
            notificationService,
            null,
            null,
            null,
            null,
            packageFactory
        );

        ObservableCacheEx.AddOrUpdate(
            CheckpointsPageViewModel.CheckpointFoldersCache,
            new CheckpointFolder[]
            {
                new(settingsManager, downloadService, modelFinder, notificationService, modelImportService)
                {
                    DirectoryPath = "Models/StableDiffusion",
                    DisplayedCheckpointFiles = new ObservableCollectionExtended<CheckpointFile>()
                    {
                        new()
                        {
                            FilePath = "~/Models/StableDiffusion/electricity-light.safetensors",
                            Title = "Auroral Background",
                            PreviewImagePath =
                                "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/"
                                + "78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg",
                            UpdateAvailable = true,
                            ConnectedModel = new ConnectedModelInfo
                            {
                                VersionName = "Lightning Auroral",
                                BaseModel = "SD 1.5",
                                ModelName = "Auroral Background",
                                ModelType = CivitModelType.Model,
                                FileMetadata = new CivitFileMetadata
                                {
                                    Format = CivitModelFormat.SafeTensor,
                                    Fp = CivitModelFpType.fp16,
                                    Size = CivitModelSize.pruned,
                                },
                                TrainedWords = ["aurora", "lightning"]
                            }
                        },
                        new() { FilePath = "~/Models/Lora/model.safetensors", Title = "Some model" },
                    },
                },
                new(settingsManager, downloadService, modelFinder, notificationService, modelImportService)
                {
                    Title = "Lora",
                    DirectoryPath = "Packages/Lora",
                    DisplayedCheckpointFiles = new ObservableCollectionExtended<CheckpointFile>
                    {
                        new() { FilePath = "~/Models/Lora/lora_v2.pt", Title = "Best Lora v2", }
                    }
                }
            }
        );

        /*// Checkpoints page
        CheckpointsPageViewModel.CheckpointFolders =
            new CheckpointFolder[]
            {
                new(settingsManager, downloadService, modelFinder, notificationService)
                {
                    Title = "StableDiffusion",
                    DirectoryPath = "Models/StableDiffusion",
                    CheckpointFiles = CheckpointFile[]
                    {
                        new()
                        {
                            FilePath = "~/Models/StableDiffusion/electricity-light.safetensors",
                            Title = "Auroral Background",
                            PreviewImagePath =
                                "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/"
                                + "78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg",
                            ConnectedModel = new ConnectedModelInfo
                            {
                                VersionName = "Lightning Auroral",
                                BaseModel = "SD 1.5",
                                ModelName = "Auroral Background",
                                ModelType = CivitModelType.Model,
                                FileMetadata = new CivitFileMetadata
                                {
                                    Format = CivitModelFormat.SafeTensor,
                                    Fp = CivitModelFpType.fp16,
                                    Size = CivitModelSize.pruned,
                                }
                            }
                        },
                        new()
                        {
                            FilePath = "~/Models/Lora/model.safetensors",
                            Title = "Some model"
                        },
                    },
                },
                new(settingsManager, downloadService, modelFinder, notificationService)
                {
                    Title = "Lora",
                    DirectoryPath = "Packages/Lora",
                    SubFolders = CheckpointFolder[]
                    {
                        new(settingsManager, downloadService, modelFinder, notificationService)
                        {
                            Title = "StableDiffusion",
                            DirectoryPath = "Packages/Lora/Subfolder",
                        },
                        new(settingsManager, downloadService, modelFinder, notificationService)
                        {
                            Title = "Lora",
                            DirectoryPath = "Packages/StableDiffusion/Subfolder",
                        }
                    },
                    CheckpointFiles = new AdvancedObservableList<CheckpointFile>
                    {
                        new() { FilePath = "~/Models/Lora/lora_v2.pt", Title = "Best Lora v2", }
                    }
                }
            };

        foreach (var folder in CheckpointsPageViewModel.CheckpointFolders)
        {
            folder.DisplayedCheckpointFiles = new AdvancedObservableList<CheckpointFile>(
                folder.CheckpointFiles
            );
        }*/

        CivitAiBrowserViewModel.ModelCards = new ObservableCollectionExtended<CheckpointBrowserCardViewModel>
        {
            dialogFactory.Get<CheckpointBrowserCardViewModel>(vm =>
            {
                vm.CivitModel = new CivitModel
                {
                    Name = "BB95 Furry Mix",
                    Description = "A furry mix of BB95",
                    Stats = new CivitModelStats { Rating = 3.5, RatingCount = 24 },
                    ModelVersions = [new() { Name = "v1.2.2-Inpainting" }],
                    Creator = new CivitCreator
                    {
                        Image = "https://gravatar.com/avatar/fe74084ae8a081dc2283f5bde4736756ad?f=y&d=retro",
                        Username = "creator-1"
                    }
                };
            }),
            dialogFactory.Get<CheckpointBrowserCardViewModel>(vm =>
            {
                vm.CivitModel = new CivitModel
                {
                    Name = "Another Model",
                    Description = "A mix of example",
                    Stats = new CivitModelStats { Rating = 5, RatingCount = 3500 },
                    ModelVersions =
                    [
                        new()
                        {
                            Name = "v1.2.2-Inpainting",
                            Images = new List<CivitImage>
                            {
                                new()
                                {
                                    NsfwLevel = 1,
                                    Url =
                                        "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/"
                                        + "78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg"
                                }
                            }
                        }
                    ],
                    Creator = new CivitCreator
                    {
                        Image = "https://gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50?f=y&d=retro",
                        Username = "creator-2"
                    }
                };
            })
        };

        NewCheckpointsPageViewModel.AllCheckpoints = new ObservableCollection<CheckpointFile>
        {
            new()
            {
                FilePath = "~/Models/StableDiffusion/electricity-light.safetensors",
                Title = "Auroral Background",
                PreviewImagePath =
                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/"
                    + "78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg",
                ConnectedModel = new ConnectedModelInfo
                {
                    VersionName = "Lightning Auroral",
                    BaseModel = "SD 1.5",
                    ModelName = "Auroral Background",
                    ModelType = CivitModelType.Model,
                    FileMetadata = new CivitFileMetadata
                    {
                        Format = CivitModelFormat.SafeTensor,
                        Fp = CivitModelFpType.fp16,
                        Size = CivitModelSize.pruned,
                    }
                }
            },
            new() { FilePath = "~/Models/Lora/model.safetensors", Title = "Some model" }
        };

        ProgressManagerViewModel.ProgressItems.AddRange(
            new ProgressItemViewModelBase[]
            {
                new ProgressItemViewModel(
                    new ProgressItem(
                        Guid.NewGuid(),
                        "Test File.exe",
                        new ProgressReport(0.5f, "Downloading...")
                    )
                ),
                new MockDownloadProgressItemViewModel(
                    "Very Long Test File Name Need Even More Longness Thanks That's pRobably good 2.exe"
                ),
                new PackageInstallProgressItemViewModel(
                    new PackageModificationRunner
                    {
                        CurrentProgress = new ProgressReport(0.5f, "Installing package..."),
                        ModificationCompleteMessage = "Package installed successfully"
                    }
                )
            }
        );

        UpdateViewModel = Services.GetRequiredService<UpdateViewModel>();
        UpdateViewModel.CurrentVersionText = "v2.0.0";
        UpdateViewModel.NewVersionText = "v2.0.1";
        UpdateViewModel.ReleaseNotes = "## v2.0.1\n- Fixed a bug\n- Added a feature\n- Removed a feature";

        isInitialized = true;
    }

    [NotNull]
    public static PackageInstallBrowserViewModel? NewInstallerDialogViewModel { get; private set; }

    [NotNull]
    public static PackageInstallDetailViewModel? PackageInstallDetailViewModel { get; private set; }

    [NotNull]
    public static LaunchOptionsViewModel? LaunchOptionsViewModel { get; private set; }

    [NotNull]
    public static UpdateViewModel? UpdateViewModel { get; private set; }

    public static ServiceManager<ViewModelBase> DialogFactory =>
        Services.GetRequiredService<ServiceManager<ViewModelBase>>();

    public static MainWindowViewModel MainWindowViewModel =>
        Services.GetRequiredService<MainWindowViewModel>();

    public static FirstLaunchSetupViewModel FirstLaunchSetupViewModel =>
        Services.GetRequiredService<FirstLaunchSetupViewModel>();

    public static LaunchPageViewModel LaunchPageViewModel =>
        Services.GetRequiredService<LaunchPageViewModel>();

    public static HuggingFacePageViewModel HuggingFacePageViewModel =>
        Services.GetRequiredService<HuggingFacePageViewModel>();

    public static NewOneClickInstallViewModel NewOneClickInstallViewModel =>
        Services.GetRequiredService<NewOneClickInstallViewModel>();

    public static RecommendedModelsViewModel RecommendedModelsViewModel =>
        DialogFactory.Get<RecommendedModelsViewModel>(vm =>
        {
            vm.Sd15Models = new ObservableCollectionExtended<RecommendedModelItemViewModel>()
            {
                new()
                {
                    ModelVersion = new CivitModelVersion
                    {
                        Name = "BB95 Furry Mix",
                        Description = "A furry mix of BB95",
                        Stats = new CivitModelStats { Rating = 3.5, RatingCount = 24 },
                        Images =
                        [
                            new CivitImage
                            {
                                Url =
                                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg"
                            }
                        ],
                    },
                    Author = "bb95"
                },
                new()
                {
                    ModelVersion = new CivitModelVersion
                    {
                        Name = "BB95 Furry Mix",
                        Description = "A furry mix of BB95",
                        Stats = new CivitModelStats { Rating = 3.5, RatingCount = 24 },
                        Images =
                        [
                            new CivitImage
                            {
                                Url =
                                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg"
                            }
                        ],
                    },
                    Author = "bb95"
                }
            };
        });
    public static OutputsPageViewModel OutputsPageViewModel
    {
        get
        {
            var vm = Services.GetRequiredService<OutputsPageViewModel>();
            vm.Outputs = new ObservableCollectionExtended<OutputImageViewModel>
            {
                new(
                    new LocalImageFile
                    {
                        AbsolutePath =
                            "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/78fd2a0a-42b6-42b0-9815-81cb11bb3d05/00009-2423234823.jpeg",
                        ImageType = LocalImageFileType.TextToImage
                    }
                )
            };
            vm.Categories = new ObservableCollectionExtended<PackageOutputCategory>
            {
                new()
                {
                    Name = "Category 1",
                    Path = "path1",
                    SubDirectories = [new PackageOutputCategory { Name = "SubCategory 1", Path = "path3" }]
                },
                new() { Name = "Category 2", Path = "path2" }
            };
            return vm;
        }
    }

    public static PackageManagerViewModel PackageManagerViewModel
    {
        get
        {
            var settings = Services.GetRequiredService<ISettingsManager>();
            var vm = Services.GetRequiredService<PackageManagerViewModel>();

            vm.SetPackages(settings.Settings.InstalledPackages);
            vm.SetUnknownPackages(
                new InstalledPackage[]
                {
                    UnknownInstalledPackage.FromDirectoryName("sd-unknown-with-long-name"),
                }
            );

            vm.PackageCards[0].IsUpdateAvailable = true;

            return vm;
        }
    }

    public static PackageExtensionBrowserViewModel PackageExtensionBrowserViewModel =>
        DialogFactory.Get<PackageExtensionBrowserViewModel>(vm =>
        {
            vm.AddExtensions(
                [
                    new PackageExtension
                    {
                        Author = "123",
                        Title = "Cool Extension",
                        Description = "This is an interesting extension",
                        Reference = new Uri("https://github.com/LykosAI/StabilityMatrix"),
                        Files = [new Uri("https://github.com/LykosAI/StabilityMatrix")]
                    },
                    new PackageExtension
                    {
                        Author = "123",
                        Title = "Cool Extension",
                        Description = "This is an interesting extension",
                        Reference = new Uri("https://github.com/LykosAI/StabilityMatrix"),
                        Files = [new Uri("https://github.com/LykosAI/StabilityMatrix")]
                    }
                ],
                [
                    new InstalledPackageExtension
                    {
                        GitRepositoryUrl = "https://github.com/LykosAI/StabilityMatrix",
                        Paths = [new DirectoryPath("example-dir")]
                    },
                    new InstalledPackageExtension { Paths = [new DirectoryPath("example-dir-2")] }
                ]
            );
        });

    public static CheckpointsPageViewModel CheckpointsPageViewModel =>
        Services.GetRequiredService<CheckpointsPageViewModel>();

    public static NewCheckpointsPageViewModel NewCheckpointsPageViewModel =>
        Services.GetRequiredService<NewCheckpointsPageViewModel>();

    public static SettingsViewModel SettingsViewModel => Services.GetRequiredService<SettingsViewModel>();

    public static NewPackageManagerViewModel NewPackageManagerViewModel =>
        Services.GetRequiredService<NewPackageManagerViewModel>();

    public static InferenceSettingsViewModel InferenceSettingsViewModel =>
        Services.GetRequiredService<InferenceSettingsViewModel>();

    public static MainSettingsViewModel MainSettingsViewModel =>
        Services.GetRequiredService<MainSettingsViewModel>();

    public static AccountSettingsViewModel AccountSettingsViewModel =>
        Services.GetRequiredService<AccountSettingsViewModel>();

    public static NotificationSettingsViewModel NotificationSettingsViewModel =>
        Services.GetRequiredService<NotificationSettingsViewModel>();

    public static UpdateSettingsViewModel UpdateSettingsViewModel
    {
        get
        {
            var vm = Services.GetRequiredService<UpdateSettingsViewModel>();

            var update = new UpdateInfo
            {
                Version = SemVersion.Parse("2.0.1"),
                ReleaseDate = DateTimeOffset.Now,
                Url = new Uri("https://example.org"),
                Changelog = new Uri("https://example.org"),
                HashBlake3 = "",
                Signature = "",
            };

            vm.UpdateStatus = new UpdateStatusChangedEventArgs
            {
                LatestUpdate = update,
                UpdateChannels = new Dictionary<UpdateChannel, UpdateInfo>
                {
                    [UpdateChannel.Stable] = update,
                    [UpdateChannel.Preview] = update,
                    [UpdateChannel.Development] = update
                },
                CheckedAt = DateTimeOffset.UtcNow
            };
            return vm;
        }
    }

    public static CivitAiBrowserViewModel CivitAiBrowserViewModel =>
        Services.GetRequiredService<CivitAiBrowserViewModel>();

    public static CheckpointBrowserViewModel CheckpointBrowserViewModel =>
        Services.GetRequiredService<CheckpointBrowserViewModel>();

    public static SelectModelVersionViewModel SelectModelVersionViewModel =>
        DialogFactory.Get<SelectModelVersionViewModel>(vm =>
        {
            // Sample data
            var sampleCivitVersions = new List<CivitModelVersion>
            {
                new()
                {
                    Name = "BB95 Furry Mix",
                    Description =
                        @"Introducing SnoutMix
A Mix of non-Furry and Furry models such as Furtastic and BB95Furry to create a great variety of anthro AI generation options, but bringing out more detail, still giving a lot of freedom to customise the human aspects, and having great backgrounds, with a focus on something more realistic. Works well with realistic character loras.
The gallery images are often inpainted, but you will get something very similar if copying their data directly. They are inpainted using the same model, therefore all results are possible without anything custom/hidden-away. Controlnet Tiled is applied to enhance them further afterwards. Gallery images were made with same model but before it was renamed",
                    BaseModel = "SD 1.5",
                    Files = new List<CivitFile>
                    {
                        new()
                        {
                            Name = "bb95-v100-uwu-reallylongfilename-v1234576802.safetensors",
                            Type = CivitFileType.Model,
                            Metadata = new CivitFileMetadata
                            {
                                Format = CivitModelFormat.SafeTensor,
                                Fp = CivitModelFpType.fp16,
                                Size = CivitModelSize.pruned
                            }
                        },
                        new()
                        {
                            Name = "bb95-v100-uwu-reallylongfilename-v1234576802-fp32.safetensors",
                            Type = CivitFileType.Model,
                            Metadata = new CivitFileMetadata
                            {
                                Format = CivitModelFormat.SafeTensor,
                                Fp = CivitModelFpType.fp32,
                                Size = CivitModelSize.full
                            },
                            Hashes = new CivitFileHashes { BLAKE3 = "ABCD" }
                        }
                    }
                }
            };
            var sampleViewModel = new ModelVersionViewModel(
                new HashSet<string> { "ABCD" },
                sampleCivitVersions[0]
            );

            // Sample data for dialogs
            vm.Versions = new List<ModelVersionViewModel> { sampleViewModel };
            vm.Title = sampleCivitVersions[0].Name;
            vm.Description = sampleCivitVersions[0].Description;
            vm.SelectedVersionViewModel = sampleViewModel;
        });

    public static OneClickInstallViewModel OneClickInstallViewModel =>
        Services.GetRequiredService<OneClickInstallViewModel>();

    public static InferenceViewModel InferenceViewModel => Services.GetRequiredService<InferenceViewModel>();

    public static SelectDataDirectoryViewModel SelectDataDirectoryViewModel =>
        Services.GetRequiredService<SelectDataDirectoryViewModel>();

    public static ProgressManagerViewModel ProgressManagerViewModel =>
        Services.GetRequiredService<ProgressManagerViewModel>();

    public static ExceptionViewModel ExceptionViewModel =>
        DialogFactory.Get<ExceptionViewModel>(viewModel =>
        {
            // Use try-catch to generate traceback information
            try
            {
                try
                {
                    throw new OperationCanceledException("Example");
                }
                catch (OperationCanceledException e)
                {
                    throw new AggregateException(e);
                }
            }
            catch (AggregateException e)
            {
                viewModel.Exception = e;
            }
        });

    public static EnvVarsViewModel EnvVarsViewModel =>
        DialogFactory.Get<EnvVarsViewModel>(viewModel =>
        {
            viewModel.EnvVars = new ObservableCollection<EnvVarKeyPair> { new("UWU", "TRUE"), };
        });

    public static PythonPackagesViewModel PythonPackagesViewModel =>
        DialogFactory.Get<PythonPackagesViewModel>(vm =>
        {
            vm.AddPackages(new PipPackageInfo("pip", "1.0.0"), new PipPackageInfo("torch", "2.1.0+cu121"));
        });

    public static LykosLoginViewModel LykosLoginViewModel => DialogFactory.Get<LykosLoginViewModel>();

    public static OAuthConnectViewModel OAuthConnectViewModel =>
        DialogFactory.Get<OAuthConnectViewModel>(vm =>
        {
            vm.Url =
                "https://www.example.org/oauth2/authorize?"
                + "client_id=66ad566552679cb6e650be01ed6f8d2ae9a0f803c0369850a5c9ee82a2396062&"
                + "scope=identity%20identity.memberships&"
                + "response_type=code&state=test%40example.org&"
                + "redirect_uri=http://localhost:5022/api/oauth/patreon/callback";
        });

    public static MaskEditorViewModel MaskEditorViewModel => DialogFactory.Get<MaskEditorViewModel>();

    public static InferenceTextToImageViewModel InferenceTextToImageViewModel =>
        DialogFactory.Get<InferenceTextToImageViewModel>(vm =>
        {
            vm.OutputProgress.Value = 10;
            vm.OutputProgress.Maximum = 30;
            vm.OutputProgress.Text = "Sampler 10/30";
        });

    public static InferenceImageToVideoViewModel InferenceImageToVideoViewModel =>
        DialogFactory.Get<InferenceImageToVideoViewModel>(vm =>
        {
            vm.OutputProgress.Value = 10;
            vm.OutputProgress.Maximum = 30;
            vm.OutputProgress.Text = "Sampler 10/30";
        });

    public static InferenceImageToImageViewModel InferenceImageToImageViewModel =>
        DialogFactory.Get<InferenceImageToImageViewModel>();

    public static InferenceImageUpscaleViewModel InferenceImageUpscaleViewModel =>
        DialogFactory.Get<InferenceImageUpscaleViewModel>();

    public static PackageImportViewModel PackageImportViewModel =>
        DialogFactory.Get<PackageImportViewModel>();

    public static RefreshBadgeViewModel RefreshBadgeViewModel => new() { State = ProgressState.Success };

    public static PropertyGridViewModel PropertyGridViewModel =>
        DialogFactory.Get<PropertyGridViewModel>(vm =>
        {
            vm.SelectedObject = new INotifyPropertyChanged[]
            {
                new MockPropertyGridObject(),
                new MockPropertyGridObjectAlt()
            };
            vm.ExcludeCategories = ["Excluded Category"];
        });

    public static SeedCardViewModel SeedCardViewModel => new();
    public static SvdImgToVidConditioningViewModel SvdImgToVidConditioningViewModel => new();
    public static VideoOutputSettingsCardViewModel VideoOutputSettingsCardViewModel => new();

    public static SamplerCardViewModel SamplerCardViewModel =>
        DialogFactory.Get<SamplerCardViewModel>(vm =>
        {
            vm.Steps = 20;
            vm.CfgScale = 7;
            vm.IsCfgScaleEnabled = true;
            vm.IsSamplerSelectionEnabled = true;
            vm.IsDimensionsEnabled = true;
            vm.SelectedSampler = new ComfySampler("euler");
        });

    public static SamplerCardViewModel SamplerCardViewModelScaleMode =>
        DialogFactory.Get<SamplerCardViewModel>(vm =>
        {
            vm.IsDenoiseStrengthEnabled = true;
        });

    public static SamplerCardViewModel SamplerCardViewModelRefinerMode =>
        DialogFactory.Get<SamplerCardViewModel>(vm =>
        {
            vm.IsCfgScaleEnabled = true;
            vm.IsSamplerSelectionEnabled = true;
            vm.IsDimensionsEnabled = true;
            vm.IsRefinerStepsEnabled = true;
        });

    public static ModelCardViewModel ModelCardViewModel => DialogFactory.Get<ModelCardViewModel>();

    public static ImgToVidModelCardViewModel ImgToVidModelCardViewModel =>
        DialogFactory.Get<ImgToVidModelCardViewModel>();

    public static ImageGalleryCardViewModel ImageGalleryCardViewModel =>
        DialogFactory.Get<ImageGalleryCardViewModel>(vm =>
        {
            vm.ImageSources.AddRange(
                new ImageSource[]
                {
                    new(
                        new Uri(
                            "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/4a7e00a7-6f18-42d4-87c0-10e792df2640/width=1152"
                        )
                    ),
                    new(
                        new Uri(
                            "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/a318ac1f-3ad0-48ac-98cc-79126febcc17/width=1024"
                        )
                    ),
                    new(
                        new Uri(
                            "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/16588c94-6595-4be9-8806-d7e6e22d198c/width=1152"
                        )
                    ),
                }
            );
        });

    public static ImageFolderCardViewModel ImageFolderCardViewModel =>
        DialogFactory.Get<ImageFolderCardViewModel>();

    public static FreeUCardViewModel FreeUCardViewModel => DialogFactory.Get<FreeUCardViewModel>();

    public static PromptCardViewModel PromptCardViewModel =>
        DialogFactory.Get<PromptCardViewModel>(vm =>
        {
            var builder = new StringBuilder();
            builder.AppendLine("house, (high quality), [example], BREAK");
            builder.AppendLine("# this is a comment");
            builder.AppendLine(
                "(detailed), [purple and orange lighting], looking pleased, (cinematic, god rays:0.8), "
                    + "(8k, 4k, high res:1), (intricate), (unreal engine:1.2), (shaded:1.1), "
                    + "(soft focus, detailed background), (horizontal lens flare), "
                    + "(clear eyes)"
            );
            builder.AppendLine("<lora:details:0.8>, <lyco:some_model>");

            vm.PromptDocument.Text = builder.ToString();
            vm.NegativePromptDocument.Text = "embedding:EasyNegative, blurry, jpeg artifacts";
        });

    public static StackCardViewModel StackCardViewModel =>
        DialogFactory.Get<StackCardViewModel>(vm =>
        {
            vm.AddCards(SamplerCardViewModel, SeedCardViewModel);
        });

    public static StackEditableCardViewModel StackEditableCardViewModel =>
        DialogFactory.Get<StackEditableCardViewModel>(vm =>
        {
            vm.AddCards(StackExpanderViewModel, StackExpanderViewModel2);
        });

    public static StackExpanderViewModel StackExpanderViewModel =>
        DialogFactory.Get<StackExpanderViewModel>(vm =>
        {
            vm.Title = "Hires Fix";
            vm.AddCards(UpscalerCardViewModel, SamplerCardViewModel);
            vm.OnContainerIndexChanged(0);
        });

    public static StackExpanderViewModel StackExpanderViewModel2 =>
        DialogFactory.Get<StackExpanderViewModel>(vm =>
        {
            vm.Title = "Hires Fix";
            vm.IsSettingsEnabled = true;
            vm.AddCards(UpscalerCardViewModel, SamplerCardViewModel);
            vm.OnContainerIndexChanged(1);
        });

    public static UpscalerCardViewModel UpscalerCardViewModel => DialogFactory.Get<UpscalerCardViewModel>();

    public static BatchSizeCardViewModel BatchSizeCardViewModel =>
        DialogFactory.Get<BatchSizeCardViewModel>();

    public static BatchSizeCardViewModel BatchSizeCardViewModelWithIndexOption =>
        DialogFactory.Get<BatchSizeCardViewModel>(vm =>
        {
            vm.IsBatchIndexEnabled = true;
        });

    public static LayerDiffuseCardViewModel LayerDiffuseCardViewModel =>
        DialogFactory.Get<LayerDiffuseCardViewModel>();
  
    public static InstalledWorkflowsViewModel InstalledWorkflowsViewModel
    {
        get
        {
            var vm = Services.GetRequiredService<InstalledWorkflowsViewModel>();
            vm.DisplayedWorkflows = new ObservableCollectionExtended<OpenArtMetadata>
            {
                new()
                {
                    Workflow = new()
                    {
                        Name = "Test Workflow",
                        Creator = new OpenArtCreator { Name = "Test Creator" },
                        Thumbnails =
                        [
                            new OpenArtThumbnail
                            {
                                Url = new Uri(
                                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/dd9b038c-bd15-43ab-86ab-66e145ad7ff2/width=512"
                                )
                            }
                        ]
                    }
                }
            };

            return vm;
        }
    }

    public static IList<ICompletionData> SampleCompletionData =>
        new List<ICompletionData>
        {
            new TagCompletionData("test1", TagType.General),
            new TagCompletionData("test2", TagType.Artist),
            new TagCompletionData("test3", TagType.Character),
            new TagCompletionData("test4", TagType.Copyright),
            new TagCompletionData("test5", TagType.Species),
            new TagCompletionData("test_unknown", TagType.Invalid),
        };

    public static CompletionList SampleCompletionList
    {
        get
        {
            var list = new CompletionList { IsFiltering = true };
            ExtensionMethods.AddRange(list.CompletionData, SampleCompletionData);
            ExtensionMethods.AddRange(list.FilteredCompletionData, list.CompletionData);
            list.SelectItem("te", true);
            return list;
        }
    }

    public static IEnumerable<HybridModelFile> SampleHybridModels { get; } =
        [
            HybridModelFile.FromLocal(
                new LocalModelFile
                {
                    SharedFolderType = SharedFolderType.StableDiffusion,
                    RelativePath = "art_shaper_v8.safetensors",
                    PreviewImageFullPath =
                        "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/dd9b038c-bd15-43ab-86ab-66e145ad7ff2/width=512",
                    ConnectedModelInfo = new ConnectedModelInfo
                    {
                        ModelName = "Art Shaper (very long name example)",
                        VersionName = "Style v8 (very long name)"
                    }
                }
            ),
            HybridModelFile.FromLocal(
                new LocalModelFile
                {
                    SharedFolderType = SharedFolderType.StableDiffusion,
                    RelativePath = "background_arts.safetensors",
                    PreviewImageFullPath =
                        "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/71c81ddf-d8c3-46b4-843d-9f8f20a9254a/width=512",
                    ConnectedModelInfo = new ConnectedModelInfo
                    {
                        ModelName = "Background Arts",
                        VersionName = "Anime Style v10"
                    }
                }
            ),
            HybridModelFile.FromRemote("v1-5-pruned-emaonly.safetensors"),
            HybridModelFile.FromRemote("sample-model.pt"),
        ];

    public static HybridModelFile SampleHybridModel => SampleHybridModels.First();

    public static ImageViewerViewModel ImageViewerViewModel =>
        DialogFactory.Get<ImageViewerViewModel>(vm =>
        {
            vm.ImageSource = new ImageSource(
                new Uri(
                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/a318ac1f-3ad0-48ac-98cc-79126febcc17/width=1500"
                )
            );
            vm.FileNameText = "TextToImage_00041.png";
            vm.FileSizeText = "2.4 MB";
            vm.ImageSizeText = "1280 x 1792";
        });

    public static DownloadResourceViewModel DownloadResourceViewModel =>
        DialogFactory.Get<DownloadResourceViewModel>(vm =>
        {
            vm.FileName = ComfyUpscaler.DefaultDownloadableModels[0].Name;
            vm.FileSize = Convert.ToInt64(2 * Size.GiB);
            vm.Resource = ComfyUpscaler.DefaultDownloadableModels[0].DownloadableResource!.Value;
        });

    public static SharpenCardViewModel SharpenCardViewModel => DialogFactory.Get<SharpenCardViewModel>();

    public static InferenceConnectionHelpViewModel InferenceConnectionHelpViewModel =>
        DialogFactory.Get<InferenceConnectionHelpViewModel>();

    public static SelectImageCardViewModel SelectImageCardViewModel =>
        DialogFactory.Get<SelectImageCardViewModel>();

    public static SelectImageCardViewModel SelectImageCardViewModel_WithImage =>
        DialogFactory.Get<SelectImageCardViewModel>(vm =>
        {
            vm.ImageSource = new ImageSource(
                new Uri(
                    "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/a318ac1f-3ad0-48ac-98cc-79126febcc17/width=1500"
                )
            );
        });

    public static ImageSource SampleImageSource =>
        new(
            new Uri(
                "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/a318ac1f-3ad0-48ac-98cc-79126febcc17/width=1500"
            )
        )
        {
            Label = "Test Image"
        };

    public static ControlNetCardViewModel ControlNetCardViewModel =>
        DialogFactory.Get<ControlNetCardViewModel>();

    public static OpenArtWorkflowViewModel OpenArtWorkflowViewModel =>
        new(Services.GetRequiredService<ISettingsManager>(), Services.GetRequiredService<IPackageFactory>())
        {
            Workflow = new OpenArtSearchResult
            {
                Name = "Test Workflow",
                Creator = new OpenArtCreator
                {
                    Name = "Test Creator Name",
                    Username = "Test Creator Username"
                },
                Thumbnails =
                [
                    new OpenArtThumbnail
                    {
                        Url = new Uri(
                            "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/a318ac1f-3ad0-48ac-98cc-79126febcc17/width=1500"
                        )
                    }
                ],
                NodesIndex =
                [
                    "Anything Everywhere",
                    "Reroute",
                    "Note",
                    ".",
                    "ComfyUI's ControlNet Auxiliary Preprocessors",
                    "DWPreprocessor",
                    "PixelPerfectResolution",
                    "AIO_Preprocessor",
                    ",",
                    "ComfyUI",
                    "PreviewImage",
                    "CLIPTextEncode",
                    "EmptyLatentImage",
                    "SplitImageWithAlpha",
                    "ControlNetApplyAdvanced",
                    "JoinImageWithAlpha",
                    "LatentUpscaleBy",
                    "VAEEncode",
                    "LoadImage",
                    "ControlNetLoader",
                    "CLIPVisionLoader",
                    "SaveImage",
                    ",",
                    "ComfyUI Impact Pack",
                    "SAMLoader",
                    "UltralyticsDetectorProvider",
                    "FaceDetailer",
                    ","
                ]
            }
        };

    public static string CurrentDirectory => Directory.GetCurrentDirectory();

    public static Indexer Types { get; } = new();

    public class Indexer
    {
        public object? this[string typeName]
        {
            get
            {
                var type =
                    Type.GetType(typeName) ?? throw new ArgumentException($"Type {typeName} not found");
                try
                {
                    return Services.GetService(type);
                }
                catch (InvalidOperationException)
                {
                    return Activator.CreateInstance(type);
                }
            }
        }
    }
}
