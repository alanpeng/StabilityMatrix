﻿using StabilityMatrix.Avalonia.Models.Inference;
using StabilityMatrix.Avalonia.Services;
using StabilityMatrix.Avalonia.ViewModels.Base;
using StabilityMatrix.Core.Attributes;

namespace StabilityMatrix.Avalonia.ViewModels.Inference.Modules;

[ManagedService]
[Transient]
public class LayerDiffuseModule : ModuleBase
{
    /// <inheritdoc />
    public LayerDiffuseModule(ServiceManager<ViewModelBase> vmFactory)
        : base(vmFactory)
    {
        Title = "Layer Diffuse";
        AddCards(vmFactory.Get<LayerDiffuseCardViewModel>());
    }

    /// <inheritdoc />
    protected override void OnApplyStep(ModuleApplyStepEventArgs e)
    {
        var card = GetCard<LayerDiffuseCardViewModel>();
        card.ApplyStep(e);
    }
}
