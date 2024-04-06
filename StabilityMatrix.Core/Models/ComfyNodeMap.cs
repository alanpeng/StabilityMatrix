﻿using System.Text.Json;
using System.Text.Json.Nodes;

namespace StabilityMatrix.Core.Models;

public class ComfyNodeMap
{
    private static Dictionary<string, string> lookup;

    public static Dictionary<string, string> Lookup
    {
        get => lookup ??= Deserialize();
    }

    public static Dictionary<string, string> Deserialize()
    {
        var json = JsonSerializer.Deserialize<Dictionary<string, JsonArray>>(Json);

        return json!
            .Select(
                pair =>
                    (
                        Name: (pair.Value[1] as JsonObject)?["title_aux"]?.ToString() ?? string.Empty,
                        Url: pair.Key
                    )
            )
            .DistinctBy(x => x.Name)
            .ToDictionary(pair => pair.Name, pair => pair.Url);
    }

    private const string Json = """
                            {
                                "https://gist.github.com/alkemann/7361b8eb966f29c8238fd323409efb68/raw/f9605be0b38d38d3e3a2988f89248ff557010076/alkemann.py": [
                                    [
                                        "Int to Text",
                                        "Save A1 Image",
                                        "Seed With Text"
                                    ],
                                    {
                                        "title_aux": "alkemann nodes"
                                    }
                                ],
                                "https://git.mmaker.moe/mmaker/sd-webui-color-enhance": [
                                    [
                                        "MMakerColorBlend",
                                        "MMakerColorEnhance"
                                    ],
                                    {
                                        "title_aux": "Color Enhance"
                                    }
                                ],
                                "https://github.com/0xbitches/ComfyUI-LCM": [
                                    [
                                        "LCM_Sampler",
                                        "LCM_Sampler_Advanced",
                                        "LCM_img2img_Sampler",
                                        "LCM_img2img_Sampler_Advanced"
                                    ],
                                    {
                                        "title_aux": "Latent Consistency Model for ComfyUI"
                                    }
                                ],
                                "https://github.com/1shadow1/hayo_comfyui_nodes/raw/main/LZCNodes.py": [
                                    [
                                        "LoadPILImages",
                                        "MergeImages",
                                        "make_transparentmask",
                                        "tensor_trans_pil",
                                        "words_generatee"
                                    ],
                                    {
                                        "title_aux": "Hayo comfyui nodes"
                                    }
                                ],
                                "https://github.com/42lux/ComfyUI-safety-checker": [
                                    [
                                        "Safety Checker"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-safety-checker"
                                    }
                                ],
                                "https://github.com/54rt1n/ComfyUI-DareMerge": [
                                    [
                                        "DM_AdvancedDareModelMerger",
                                        "DM_AdvancedModelMerger",
                                        "DM_AttentionGradient",
                                        "DM_BlockGradient",
                                        "DM_BlockModelMerger",
                                        "DM_DareClipMerger",
                                        "DM_DareModelMergerBlock",
                                        "DM_DareModelMergerElement",
                                        "DM_DareModelMergerMBW",
                                        "DM_GradientEdit",
                                        "DM_GradientOperations",
                                        "DM_GradientReporting",
                                        "DM_InjectNoise",
                                        "DM_LoRALoaderTags",
                                        "DM_LoRAReporting",
                                        "DM_MBWGradient",
                                        "DM_MagnitudeMasker",
                                        "DM_MaskEdit",
                                        "DM_MaskOperations",
                                        "DM_MaskReporting",
                                        "DM_ModelReporting",
                                        "DM_NormalizeModel",
                                        "DM_QuadMasker",
                                        "DM_ShellGradient",
                                        "DM_SimpleMasker"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-DareMerge"
                                    }
                                ],
                                "https://github.com/80sVectorz/ComfyUI-Static-Primitives": [
                                    [
                                        "FloatStaticPrimitive",
                                        "IntStaticPrimitive",
                                        "StringMlStaticPrimitive",
                                        "StringStaticPrimitive"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Static-Primitives"
                                    }
                                ],
                                "https://github.com/AInseven/ComfyUI-fastblend": [
                                    [
                                        "FillDarkMask",
                                        "InterpolateKeyFrame",
                                        "MaskListcaptoBatch",
                                        "MyOpenPoseNode",
                                        "SmoothVideo",
                                        "reBatchImage"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-fastblend"
                                    }
                                ],
                                "https://github.com/AIrjen/OneButtonPrompt": [
                                    [
                                        "AutoNegativePrompt",
                                        "CreatePromptVariant",
                                        "OneButtonPreset",
                                        "OneButtonPrompt",
                                        "SavePromptToFile"
                                    ],
                                    {
                                        "title_aux": "One Button Prompt"
                                    }
                                ],
                                "https://github.com/AbdullahAlfaraj/Comfy-Photoshop-SD": [
                                    [
                                        "APS_LatentBatch",
                                        "APS_Seed",
                                        "ContentMaskLatent",
                                        "ControlNetScript",
                                        "ControlnetUnit",
                                        "GaussianLatentImage",
                                        "GetConfig",
                                        "LoadImageBase64",
                                        "LoadImageWithMetaData",
                                        "LoadLorasFromPrompt",
                                        "MaskExpansion"
                                    ],
                                    {
                                        "title_aux": "Comfy-Photoshop-SD"
                                    }
                                ],
                                "https://github.com/AbyssYuan0/ComfyUI_BadgerTools": [
                                    [
                                        "ApplyMaskToImage-badger",
                                        "CropImageByMask-badger",
                                        "ExpandImageWithColor-badger",
                                        "FindThickLinesFromCanny-badger",
                                        "FloatToInt-badger",
                                        "FloatToString-badger",
                                        "FrameToVideo-badger",
                                        "GarbageCollect-badger",
                                        "GetColorFromBorder-badger",
                                        "GetDirName-badger",
                                        "GetUUID-badger",
                                        "IdentifyBorderColorToMask-badger",
                                        "IdentifyColorToMask-badger",
                                        "ImageNormalization-badger",
                                        "ImageOverlap-badger",
                                        "ImageScaleToSide-badger",
                                        "IntToString-badger",
                                        "SegmentToMaskByPoint-badger",
                                        "StringToFizz-badger",
                                        "TextListToString-badger",
                                        "TrimTransparentEdges-badger",
                                        "VideoCutFromDir-badger",
                                        "VideoToFrame-badger",
                                        "deleteDir-badger",
                                        "findCenterOfMask-badger",
                                        "getImageSide-badger",
                                        "getParentDir-badger",
                                        "mkdir-badger"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_BadgerTools"
                                    }
                                ],
                                "https://github.com/Acly/comfyui-inpaint-nodes": [
                                    [
                                        "INPAINT_ApplyFooocusInpaint",
                                        "INPAINT_InpaintWithModel",
                                        "INPAINT_LoadFooocusInpaint",
                                        "INPAINT_LoadInpaintModel",
                                        "INPAINT_MaskedBlur",
                                        "INPAINT_MaskedFill",
                                        "INPAINT_VAEEncodeInpaintConditioning"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Inpaint Nodes"
                                    }
                                ],
                                "https://github.com/Acly/comfyui-tooling-nodes": [
                                    [
                                        "ETN_ApplyMaskToImage",
                                        "ETN_CropImage",
                                        "ETN_LoadImageBase64",
                                        "ETN_LoadMaskBase64",
                                        "ETN_SendImageWebSocket"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Nodes for External Tooling"
                                    }
                                ],
                                "https://github.com/Amorano/Jovimetrix": [
                                    [],
                                    {
                                        "author": "amorano",
                                        "description": "Webcams, GLSL shader, Media Streaming, Tick animation, Image manipulation,",
                                        "nodename_pattern": " \\(jov\\)$",
                                        "title": "Jovimetrix",
                                        "title_aux": "Jovimetrix Composition Nodes"
                                    }
                                ],
                                "https://github.com/ArtBot2023/CharacterFaceSwap": [
                                    [
                                        "Color Blend",
                                        "Crop Face",
                                        "Exclude Facial Feature",
                                        "Generation Parameter Input",
                                        "Generation Parameter Output",
                                        "Image Full BBox",
                                        "Load BiseNet",
                                        "Load RetinaFace",
                                        "Mask Contour",
                                        "Segment Face",
                                        "Uncrop Face"
                                    ],
                                    {
                                        "title_aux": "Character Face Swap"
                                    }
                                ],
                                "https://github.com/ArtVentureX/comfyui-animatediff": [
                                    [
                                        "AnimateDiffCombine",
                                        "AnimateDiffLoraLoader",
                                        "AnimateDiffModuleLoader",
                                        "AnimateDiffSampler",
                                        "AnimateDiffSlidingWindowOptions",
                                        "ImageSizeAndBatchSize",
                                        "LoadVideo"
                                    ],
                                    {
                                        "title_aux": "AnimateDiff"
                                    }
                                ],
                                "https://github.com/AustinMroz/ComfyUI-SpliceTools": [
                                    [
                                        "LogSigmas",
                                        "RerangeSigmas",
                                        "SpliceDenoised",
                                        "SpliceLatents",
                                        "TemporalSplice"
                                    ],
                                    {
                                        "title_aux": "SpliceTools"
                                    }
                                ],
                                "https://github.com/BadCafeCode/masquerade-nodes-comfyui": [
                                    [
                                        "Blur",
                                        "Change Channel Count",
                                        "Combine Masks",
                                        "Constant Mask",
                                        "Convert Color Space",
                                        "Create QR Code",
                                        "Create Rect Mask",
                                        "Cut By Mask",
                                        "Get Image Size",
                                        "Image To Mask",
                                        "Make Image Batch",
                                        "Mask By Text",
                                        "Mask Morphology",
                                        "Mask To Region",
                                        "MasqueradeIncrementer",
                                        "Mix Color By Mask",
                                        "Mix Images By Mask",
                                        "Paste By Mask",
                                        "Prune By Mask",
                                        "Separate Mask Components",
                                        "Unary Image Op",
                                        "Unary Mask Op"
                                    ],
                                    {
                                        "title_aux": "Masquerade Nodes"
                                    }
                                ],
                                "https://github.com/Beinsezii/bsz-cui-extras": [
                                    [
                                        "BSZAbsoluteHires",
                                        "BSZAspectHires",
                                        "BSZColoredLatentImageXL",
                                        "BSZCombinedHires",
                                        "BSZHueChromaXL",
                                        "BSZInjectionKSampler",
                                        "BSZLatentDebug",
                                        "BSZLatentFill",
                                        "BSZLatentGradient",
                                        "BSZLatentHSVAImage",
                                        "BSZLatentOffsetXL",
                                        "BSZLatentRGBAImage",
                                        "BSZLatentbuster",
                                        "BSZPixelbuster",
                                        "BSZPixelbusterHelp",
                                        "BSZPrincipledConditioning",
                                        "BSZPrincipledSampler",
                                        "BSZPrincipledScale",
                                        "BSZStrangeResample"
                                    ],
                                    {
                                        "title_aux": "bsz-cui-extras"
                                    }
                                ],
                                "https://github.com/BennyKok/comfyui-deploy": [
                                    [
                                        "ComfyUIDeployExternalCheckpoint",
                                        "ComfyUIDeployExternalImage",
                                        "ComfyUIDeployExternalImageAlpha",
                                        "ComfyUIDeployExternalLora",
                                        "ComfyUIDeployExternalNumber",
                                        "ComfyUIDeployExternalNumberInt",
                                        "ComfyUIDeployExternalText"
                                    ],
                                    {
                                        "author": "BennyKok",
                                        "description": "",
                                        "nickname": "Comfy Deploy",
                                        "title": "comfyui-deploy",
                                        "title_aux": "ComfyUI Deploy"
                                    }
                                ],
                                "https://github.com/Bikecicle/ComfyUI-Waveform-Extensions/raw/main/EXT_AudioManipulation.py": [
                                    [
                                        "BatchJoinAudio",
                                        "CutAudio",
                                        "DuplicateAudio",
                                        "JoinAudio",
                                        "ResampleAudio",
                                        "ReverseAudio",
                                        "StretchAudio"
                                    ],
                                    {
                                        "title_aux": "Waveform Extensions"
                                    }
                                ],
                                "https://github.com/Billius-AI/ComfyUI-Path-Helper": [
                                    [
                                        "Add File Name Prefix",
                                        "Add File Name Prefix Advanced",
                                        "Add Folder",
                                        "Add Folder Advanced",
                                        "Create Project Root",
                                        "Join Variables",
                                        "Show Path",
                                        "Show String"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Path-Helper"
                                    }
                                ],
                                "https://github.com/BlenderNeko/ComfyUI_ADV_CLIP_emb": [
                                    [
                                        "BNK_AddCLIPSDXLParams",
                                        "BNK_AddCLIPSDXLRParams",
                                        "BNK_CLIPTextEncodeAdvanced",
                                        "BNK_CLIPTextEncodeSDXLAdvanced"
                                    ],
                                    {
                                        "title_aux": "Advanced CLIP Text Encode"
                                    }
                                ],
                                "https://github.com/BlenderNeko/ComfyUI_Cutoff": [
                                    [
                                        "BNK_CutoffBasePrompt",
                                        "BNK_CutoffRegionsToConditioning",
                                        "BNK_CutoffRegionsToConditioning_ADV",
                                        "BNK_CutoffSetRegions"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Cutoff"
                                    }
                                ],
                                "https://github.com/BlenderNeko/ComfyUI_Noise": [
                                    [
                                        "BNK_DuplicateBatchIndex",
                                        "BNK_GetSigma",
                                        "BNK_InjectNoise",
                                        "BNK_NoisyLatentImage",
                                        "BNK_SlerpLatent",
                                        "BNK_Unsampler"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Noise"
                                    }
                                ],
                                "https://github.com/BlenderNeko/ComfyUI_SeeCoder": [
                                    [
                                        "ConcatConditioning",
                                        "SEECoderImageEncode"
                                    ],
                                    {
                                        "title_aux": "SeeCoder [WIP]"
                                    }
                                ],
                                "https://github.com/BlenderNeko/ComfyUI_TiledKSampler": [
                                    [
                                        "BNK_TiledKSampler",
                                        "BNK_TiledKSamplerAdvanced"
                                    ],
                                    {
                                        "title_aux": "Tiled sampling for ComfyUI"
                                    }
                                ],
                                "https://github.com/CYBERLOOM-INC/ComfyUI-nodes-hnmr": [
                                    [
                                        "CLIPIter",
                                        "Dict2Model",
                                        "GridImage",
                                        "ImageBlend2",
                                        "KSamplerOverrided",
                                        "KSamplerSetting",
                                        "KSamplerXYZ",
                                        "LatentToHist",
                                        "LatentToImage",
                                        "ModelIter",
                                        "RandomLatentImage",
                                        "SaveStateDict",
                                        "SaveText",
                                        "StateDictLoader",
                                        "StateDictMerger",
                                        "StateDictMergerBlockWeighted",
                                        "StateDictMergerBlockWeightedMulti",
                                        "VAEDecodeBatched",
                                        "VAEEncodeBatched",
                                        "VAEIter"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-nodes-hnmr"
                                    }
                                ],
                                "https://github.com/CaptainGrock/ComfyUIInvisibleWatermark/raw/main/Invisible%20Watermark.py": [
                                    [
                                        "Apply Invisible Watermark",
                                        "Extract Watermark"
                                    ],
                                    {
                                        "title_aux": "ComfyUIInvisibleWatermark"
                                    }
                                ],
                                "https://github.com/Chan-0312/ComfyUI-IPAnimate": [
                                    [
                                        "IPAdapterAnimate"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-IPAnimate"
                                    }
                                ],
                                "https://github.com/Chaoses-Ib/ComfyUI_Ib_CustomNodes": [
                                    [
                                        "ImageToPIL",
                                        "LoadImageFromPath",
                                        "PILToImage",
                                        "PILToMask"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Ib_CustomNodes"
                                    }
                                ],
                                "https://github.com/Clybius/ComfyUI-Extra-Samplers": [
                                    [
                                        "SamplerCLYB_4M_SDE_Momentumized",
                                        "SamplerCustomModelMixtureDuo",
                                        "SamplerCustomNoise",
                                        "SamplerCustomNoiseDuo",
                                        "SamplerDPMPP_DualSDE_Momentumized",
                                        "SamplerEulerAncestralDancing_Experimental",
                                        "SamplerLCMCustom",
                                        "SamplerRES_Momentumized",
                                        "SamplerTTM"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Extra Samplers"
                                    }
                                ],
                                "https://github.com/Clybius/ComfyUI-Latent-Modifiers": [
                                    [
                                        "Latent Diffusion Mega Modifier"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Latent-Modifiers"
                                    }
                                ],
                                "https://github.com/CosmicLaca/ComfyUI_Primere_Nodes": [
                                    [
                                        "PrimereAnyDetailer",
                                        "PrimereAnyOutput",
                                        "PrimereCKPT",
                                        "PrimereCKPTLoader",
                                        "PrimereCLIPEncoder",
                                        "PrimereClearPrompt",
                                        "PrimereDynamicParser",
                                        "PrimereEmbedding",
                                        "PrimereEmbeddingHandler",
                                        "PrimereEmbeddingKeywordMerger",
                                        "PrimereHypernetwork",
                                        "PrimereImageSegments",
                                        "PrimereKSampler",
                                        "PrimereLCMSelector",
                                        "PrimereLORA",
                                        "PrimereLYCORIS",
                                        "PrimereLatentNoise",
                                        "PrimereLoraKeywordMerger",
                                        "PrimereLoraStackMerger",
                                        "PrimereLycorisKeywordMerger",
                                        "PrimereLycorisStackMerger",
                                        "PrimereMetaCollector",
                                        "PrimereMetaRead",
                                        "PrimereMetaSave",
                                        "PrimereMidjourneyStyles",
                                        "PrimereModelConceptSelector",
                                        "PrimereModelKeyword",
                                        "PrimereNetworkTagLoader",
                                        "PrimerePrompt",
                                        "PrimerePromptSwitch",
                                        "PrimereRefinerPrompt",
                                        "PrimereResolution",
                                        "PrimereResolutionMultiplier",
                                        "PrimereResolutionMultiplierMPX",
                                        "PrimereSamplers",
                                        "PrimereSamplersSteps",
                                        "PrimereSeed",
                                        "PrimereStepsCfg",
                                        "PrimereStyleLoader",
                                        "PrimereStylePile",
                                        "PrimereTextOutput",
                                        "PrimereVAE",
                                        "PrimereVAELoader",
                                        "PrimereVAESelector",
                                        "PrimereVisualCKPT",
                                        "PrimereVisualEmbedding",
                                        "PrimereVisualHypernetwork",
                                        "PrimereVisualLORA",
                                        "PrimereVisualLYCORIS",
                                        "PrimereVisualStyle"
                                    ],
                                    {
                                        "title_aux": "Primere nodes for ComfyUI"
                                    }
                                ],
                                "https://github.com/Danand/ComfyUI-ComfyCouple": [
                                    [
                                        "Attention couple",
                                        "Comfy Couple"
                                    ],
                                    {
                                        "author": "Rei D.",
                                        "description": "If you want to draw two different characters together without blending their features, so you could try to check out this custom node.",
                                        "nickname": "Danand",
                                        "title": "Comfy Couple",
                                        "title_aux": "ComfyUI-ComfyCouple"
                                    }
                                ],
                                "https://github.com/Davemane42/ComfyUI_Dave_CustomNode": [
                                    [
                                        "ABGRemover",
                                        "ConditioningStretch",
                                        "ConditioningUpscale",
                                        "MultiAreaConditioning",
                                        "MultiLatentComposite"
                                    ],
                                    {
                                        "title_aux": "Visual Area Conditioning / Latent composition"
                                    }
                                ],
                                "https://github.com/Derfuu/Derfuu_ComfyUI_ModdedNodes": [
                                    [
                                        "ABSNode_DF",
                                        "Absolute value",
                                        "Ceil",
                                        "CeilNode_DF",
                                        "Conditioning area scale by ratio",
                                        "ConditioningSetArea with tuples",
                                        "ConditioningSetAreaEXT_DF",
                                        "ConditioningSetArea_DF",
                                        "CosNode_DF",
                                        "Cosines",
                                        "Divide",
                                        "DivideNode_DF",
                                        "EmptyLatentImage_DF",
                                        "Float",
                                        "Float debug print",
                                        "Float2Tuple_DF",
                                        "FloatDebugPrint_DF",
                                        "FloatNode_DF",
                                        "Floor",
                                        "FloorNode_DF",
                                        "Get image size",
                                        "Get latent size",
                                        "GetImageSize_DF",
                                        "GetLatentSize_DF",
                                        "Image scale by ratio",
                                        "Image scale to side",
                                        "ImageScale_Ratio_DF",
                                        "ImageScale_Side_DF",
                                        "Int debug print",
                                        "Int to float",
                                        "Int to tuple",
                                        "Int2Float_DF",
                                        "IntDebugPrint_DF",
                                        "Integer",
                                        "IntegerNode_DF",
                                        "Latent Scale by ratio",
                                        "Latent Scale to side",
                                        "LatentComposite with tuples",
                                        "LatentScale_Ratio_DF",
                                        "LatentScale_Side_DF",
                                        "MultilineStringNode_DF",
                                        "Multiply",
                                        "MultiplyNode_DF",
                                        "PowNode_DF",
                                        "Power",
                                        "Random",
                                        "RandomFloat_DF",
                                        "SinNode_DF",
                                        "Sinus",
                                        "SqrtNode_DF",
                                        "Square root",
                                        "String debug print",
                                        "StringNode_DF",
                                        "Subtract",
                                        "SubtractNode_DF",
                                        "Sum",
                                        "SumNode_DF",
                                        "TanNode_DF",
                                        "Tangent",
                                        "Text",
                                        "Text box",
                                        "Tuple",
                                        "Tuple debug print",
                                        "Tuple multiply",
                                        "Tuple swap",
                                        "Tuple to floats",
                                        "Tuple to ints",
                                        "Tuple2Float_DF",
                                        "TupleDebugPrint_DF",
                                        "TupleNode_DF"
                                    ],
                                    {
                                        "title_aux": "Derfuu_ComfyUI_ModdedNodes"
                                    }
                                ],
                                "https://github.com/DonBaronFactory/ComfyUI-Cre8it-Nodes": [
                                    [
                                        "ApplySerialPrompter",
                                        "ImageSizer",
                                        "SerialPrompter"
                                    ],
                                    {
                                        "author": "CRE8IT GmbH",
                                        "description": "This extension offers various nodes.",
                                        "nickname": "cre8Nodes",
                                        "title": "cr8SerialPrompter",
                                        "title_aux": "ComfyUI-Cre8it-Nodes"
                                    }
                                ],
                                "https://github.com/Electrofried/ComfyUI-OpenAINode": [
                                    [
                                        "OpenAINode"
                                    ],
                                    {
                                        "title_aux": "OpenAINode"
                                    }
                                ],
                                "https://github.com/EllangoK/ComfyUI-post-processing-nodes": [
                                    [
                                        "ArithmeticBlend",
                                        "AsciiArt",
                                        "Blend",
                                        "Blur",
                                        "CannyEdgeMask",
                                        "ChromaticAberration",
                                        "ColorCorrect",
                                        "ColorTint",
                                        "Dissolve",
                                        "Dither",
                                        "DodgeAndBurn",
                                        "FilmGrain",
                                        "Glow",
                                        "HSVThresholdMask",
                                        "KMeansQuantize",
                                        "KuwaharaBlur",
                                        "Parabolize",
                                        "PencilSketch",
                                        "PixelSort",
                                        "Pixelize",
                                        "Quantize",
                                        "Sharpen",
                                        "SineWave",
                                        "Solarize",
                                        "Vignette"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-post-processing-nodes"
                                    }
                                ],
                                "https://github.com/Extraltodeus/ComfyUI-AutomaticCFG": [
                                    [
                                        "Automatic CFG",
                                        "Automatic CFG channels multipliers"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-AutomaticCFG"
                                    }
                                ],
                                "https://github.com/Extraltodeus/LoadLoraWithTags": [
                                    [
                                        "LoraLoaderTagsQuery"
                                    ],
                                    {
                                        "title_aux": "LoadLoraWithTags"
                                    }
                                ],
                                "https://github.com/Extraltodeus/noise_latent_perlinpinpin": [
                                    [
                                        "NoisyLatentPerlin"
                                    ],
                                    {
                                        "title_aux": "noise latent perlinpinpin"
                                    }
                                ],
                                "https://github.com/Extraltodeus/sigmas_tools_and_the_golden_scheduler": [
                                    [
                                        "Get sigmas as float",
                                        "Graph sigmas",
                                        "Manual scheduler",
                                        "Merge sigmas by average",
                                        "Merge sigmas gradually",
                                        "Multiply sigmas",
                                        "Split and concatenate sigmas",
                                        "The Golden Scheduler"
                                    ],
                                    {
                                        "title_aux": "sigmas_tools_and_the_golden_scheduler"
                                    }
                                ],
                                "https://github.com/Fannovel16/ComfyUI-Frame-Interpolation": [
                                    [
                                        "AMT VFI",
                                        "CAIN VFI",
                                        "EISAI VFI",
                                        "FILM VFI",
                                        "FLAVR VFI",
                                        "GMFSS Fortuna VFI",
                                        "IFRNet VFI",
                                        "IFUnet VFI",
                                        "KSampler Gradually Adding More Denoise (efficient)",
                                        "M2M VFI",
                                        "Make Interpolation State List",
                                        "RIFE VFI",
                                        "STMFNet VFI",
                                        "Sepconv VFI"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Frame Interpolation"
                                    }
                                ],
                                "https://github.com/Fannovel16/ComfyUI-Loopchain": [
                                    [
                                        "EmptyLatentImageLoop",
                                        "FolderToImageStorage",
                                        "ImageStorageExportLoop",
                                        "ImageStorageImport",
                                        "ImageStorageReset",
                                        "LatentStorageExportLoop",
                                        "LatentStorageImport",
                                        "LatentStorageReset"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Loopchain"
                                    }
                                ],
                                "https://github.com/Fannovel16/ComfyUI-MotionDiff": [
                                    [
                                        "EmptyMotionData",
                                        "ExportSMPLTo3DSoftware",
                                        "MotionCLIPTextEncode",
                                        "MotionDataVisualizer",
                                        "MotionDiffLoader",
                                        "MotionDiffSimpleSampler",
                                        "RenderSMPLMesh",
                                        "SMPLLoader",
                                        "SaveSMPL",
                                        "SmplifyMotionData"
                                    ],
                                    {
                                        "title_aux": "ComfyUI MotionDiff"
                                    }
                                ],
                                "https://github.com/Fannovel16/ComfyUI-Video-Matting": [
                                    [
                                        "BRIAAI Matting",
                                        "Robust Video Matting"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Video-Matting"
                                    }
                                ],
                                "https://github.com/Fannovel16/comfyui_controlnet_aux": [
                                    [
                                        "AIO_Preprocessor",
                                        "AnimalPosePreprocessor",
                                        "AnimeFace_SemSegPreprocessor",
                                        "AnimeLineArtPreprocessor",
                                        "BAE-NormalMapPreprocessor",
                                        "BinaryPreprocessor",
                                        "CannyEdgePreprocessor",
                                        "ColorPreprocessor",
                                        "DWPreprocessor",
                                        "DensePosePreprocessor",
                                        "DepthAnythingPreprocessor",
                                        "DiffusionEdge_Preprocessor",
                                        "FacialPartColoringFromPoseKps",
                                        "FakeScribblePreprocessor",
                                        "HEDPreprocessor",
                                        "HintImageEnchance",
                                        "ImageGenResolutionFromImage",
                                        "ImageGenResolutionFromLatent",
                                        "ImageIntensityDetector",
                                        "ImageLuminanceDetector",
                                        "InpaintPreprocessor",
                                        "LeReS-DepthMapPreprocessor",
                                        "LineArtPreprocessor",
                                        "LineartStandardPreprocessor",
                                        "M-LSDPreprocessor",
                                        "Manga2Anime_LineArt_Preprocessor",
                                        "MaskOptFlow",
                                        "MediaPipe-FaceMeshPreprocessor",
                                        "MeshGraphormer-DepthMapPreprocessor",
                                        "MiDaS-DepthMapPreprocessor",
                                        "MiDaS-NormalMapPreprocessor",
                                        "OneFormer-ADE20K-SemSegPreprocessor",
                                        "OneFormer-COCO-SemSegPreprocessor",
                                        "OpenposePreprocessor",
                                        "PiDiNetPreprocessor",
                                        "PixelPerfectResolution",
                                        "SAMPreprocessor",
                                        "SavePoseKpsAsJsonFile",
                                        "ScribblePreprocessor",
                                        "Scribble_XDoG_Preprocessor",
                                        "SemSegPreprocessor",
                                        "ShufflePreprocessor",
                                        "TEEDPreprocessor",
                                        "TilePreprocessor",
                                        "UniFormer-SemSegPreprocessor",
                                        "Unimatch_OptFlowPreprocessor",
                                        "Zoe-DepthMapPreprocessor",
                                        "Zoe_DepthAnythingPreprocessor"
                                    ],
                                    {
                                        "author": "tstandley",
                                        "title_aux": "ComfyUI's ControlNet Auxiliary Preprocessors"
                                    }
                                ],
                                "https://github.com/Feidorian/feidorian-ComfyNodes": [
                                    [],
                                    {
                                        "nodename_pattern": "^Feidorian_",
                                        "title_aux": "feidorian-ComfyNodes"
                                    }
                                ],
                                "https://github.com/Fictiverse/ComfyUI_Fictiverse": [
                                    [
                                        "Add Noise to Image with Mask",
                                        "Color correction",
                                        "Displace Image with Depth",
                                        "Displace Images with Mask",
                                        "Zoom Image with Depth"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Fictiverse Nodes"
                                    }
                                ],
                                "https://github.com/FizzleDorf/ComfyUI-AIT": [
                                    [
                                        "AIT_Unet_Loader",
                                        "AIT_VAE_Encode_Loader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-AIT"
                                    }
                                ],
                                "https://github.com/FizzleDorf/ComfyUI_FizzNodes": [
                                    [
                                        "AbsCosWave",
                                        "AbsSinWave",
                                        "BatchGLIGENSchedule",
                                        "BatchPromptSchedule",
                                        "BatchPromptScheduleEncodeSDXL",
                                        "BatchPromptScheduleLatentInput",
                                        "BatchPromptScheduleNodeFlowEnd",
                                        "BatchPromptScheduleSDXLLatentInput",
                                        "BatchStringSchedule",
                                        "BatchValueSchedule",
                                        "BatchValueScheduleLatentInput",
                                        "CalculateFrameOffset",
                                        "ConcatStringSingle",
                                        "CosWave",
                                        "FizzFrame",
                                        "FizzFrameConcatenate",
                                        "ImageBatchFromValueSchedule",
                                        "Init FizzFrame",
                                        "InvCosWave",
                                        "InvSinWave",
                                        "Lerp",
                                        "PromptSchedule",
                                        "PromptScheduleEncodeSDXL",
                                        "PromptScheduleNodeFlow",
                                        "PromptScheduleNodeFlowEnd",
                                        "SawtoothWave",
                                        "SinWave",
                                        "SquareWave",
                                        "StringConcatenate",
                                        "StringSchedule",
                                        "TriangleWave",
                                        "ValueSchedule",
                                        "convertKeyframeKeysToBatchKeys"
                                    ],
                                    {
                                        "title_aux": "FizzNodes"
                                    }
                                ],
                                "https://github.com/FlyingFireCo/tiled_ksampler": [
                                    [
                                        "Asymmetric Tiled KSampler",
                                        "Circular VAEDecode",
                                        "Tiled KSampler"
                                    ],
                                    {
                                        "title_aux": "tiled_ksampler"
                                    }
                                ],
                                "https://github.com/Franck-Demongin/NX_PromptStyler": [
                                    [
                                        "NX_PromptStyler"
                                    ],
                                    {
                                        "title_aux": "NX_PromptStyler"
                                    }
                                ],
                                "https://github.com/GMapeSplat/ComfyUI_ezXY": [
                                    [
                                        "ConcatenateString",
                                        "ItemFromDropdown",
                                        "IterationDriver",
                                        "JoinImages",
                                        "LineToConsole",
                                        "NumberFromList",
                                        "NumbersToList",
                                        "PlotImages",
                                        "StringFromList",
                                        "StringToLabel",
                                        "StringsToList",
                                        "ezMath",
                                        "ezXY_AssemblePlot",
                                        "ezXY_Driver"
                                    ],
                                    {
                                        "title_aux": "ezXY scripts and nodes"
                                    }
                                ],
                                "https://github.com/GTSuya-Studio/ComfyUI-Gtsuya-Nodes": [
                                    [
                                        "Danbooru (ID)",
                                        "Danbooru (Random)",
                                        "Random File From Path",
                                        "Replace Strings",
                                        "Simple Wildcards",
                                        "Simple Wildcards (Dir.)",
                                        "Wildcards Nodes"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-GTSuya-Nodes"
                                    }
                                ],
                                "https://github.com/Gourieff/comfyui-reactor-node": [
                                    [
                                        "ReActorFaceSwap",
                                        "ReActorLoadFaceModel",
                                        "ReActorRestoreFace",
                                        "ReActorSaveFaceModel"
                                    ],
                                    {
                                        "title_aux": "ReActor Node for ComfyUI"
                                    }
                                ],
                                "https://github.com/HAL41/ComfyUI-aichemy-nodes": [
                                    [
                                        "aichemyYOLOv8Segmentation"
                                    ],
                                    {
                                        "title_aux": "ComfyUI aichemy nodes"
                                    }
                                ],
                                "https://github.com/Hangover3832/ComfyUI-Hangover-Moondream": [
                                    [
                                        "Moondream Interrogator (NO COMMERCIAL USE)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Hangover-Moondream"
                                    }
                                ],
                                "https://github.com/Hangover3832/ComfyUI-Hangover-Nodes": [
                                    [
                                        "Image Scale Bounding Box",
                                        "MS kosmos-2 Interrogator",
                                        "Make Inpaint Model",
                                        "Save Image w/o Metadata"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Hangover-Nodes"
                                    }
                                ],
                                "https://github.com/Haoming02/comfyui-diffusion-cg": [
                                    [
                                        "Normalization",
                                        "NormalizationXL",
                                        "Recenter",
                                        "Recenter XL"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Diffusion Color Grading"
                                    }
                                ],
                                "https://github.com/Haoming02/comfyui-floodgate": [
                                    [
                                        "FloodGate"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Floodgate"
                                    }
                                ],
                                "https://github.com/HaydenReeve/ComfyUI-Better-Strings": [
                                    [
                                        "BetterString"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Better Strings"
                                    }
                                ],
                                "https://github.com/HebelHuber/comfyui-enhanced-save-node": [
                                    [
                                        "EnhancedSaveNode"
                                    ],
                                    {
                                        "title_aux": "comfyui-enhanced-save-node"
                                    }
                                ],
                                "https://github.com/Hiero207/ComfyUI-Hiero-Nodes": [
                                    [
                                        "Post to Discord w/ Webhook"
                                    ],
                                    {
                                        "author": "Hiero",
                                        "description": "Just some nodes that I wanted/needed, so I made them.",
                                        "nickname": "HNodes",
                                        "title": "Hiero-Nodes",
                                        "title_aux": "ComfyUI-Hiero-Nodes"
                                    }
                                ],
                                "https://github.com/IDGallagher/ComfyUI-IG-Nodes": [
                                    [
                                        "IG Analyze SSIM",
                                        "IG Cross Fade Images",
                                        "IG Explorer",
                                        "IG Float",
                                        "IG Folder",
                                        "IG Int",
                                        "IG Load Image",
                                        "IG Load Images",
                                        "IG Multiply",
                                        "IG Path Join",
                                        "IG String",
                                        "IG ZFill"
                                    ],
                                    {
                                        "author": "IDGallagher",
                                        "description": "Custom nodes to aid in the exploration of Latent Space",
                                        "nickname": "IG Interpolation Nodes",
                                        "title": "IG Interpolation Nodes",
                                        "title_aux": "IG Interpolation Nodes"
                                    }
                                ],
                                "https://github.com/Inzaniak/comfyui-ranbooru": [
                                    [
                                        "PromptBackground",
                                        "PromptLimit",
                                        "PromptMix",
                                        "PromptRandomWeight",
                                        "PromptRemove",
                                        "Ranbooru",
                                        "RanbooruURL",
                                        "RandomPicturePath"
                                    ],
                                    {
                                        "title_aux": "Ranbooru for ComfyUI"
                                    }
                                ],
                                "https://github.com/JPS-GER/ComfyUI_JPS-Nodes": [
                                    [
                                        "Conditioning Switch (JPS)",
                                        "ControlNet Switch (JPS)",
                                        "Crop Image Pipe (JPS)",
                                        "Crop Image Settings (JPS)",
                                        "Crop Image Square (JPS)",
                                        "Crop Image TargetSize (JPS)",
                                        "CtrlNet CannyEdge Pipe (JPS)",
                                        "CtrlNet CannyEdge Settings (JPS)",
                                        "CtrlNet MiDaS Pipe (JPS)",
                                        "CtrlNet MiDaS Settings (JPS)",
                                        "CtrlNet OpenPose Pipe (JPS)",
                                        "CtrlNet OpenPose Settings (JPS)",
                                        "CtrlNet ZoeDepth Pipe (JPS)",
                                        "CtrlNet ZoeDepth Settings (JPS)",
                                        "Disable Enable Switch (JPS)",
                                        "Enable Disable Switch (JPS)",
                                        "Generation TXT IMG Settings (JPS)",
                                        "Get Date Time String (JPS)",
                                        "Get Image Size (JPS)",
                                        "IP Adapter Settings (JPS)",
                                        "IP Adapter Settings Pipe (JPS)",
                                        "IP Adapter Single Settings (JPS)",
                                        "IP Adapter Single Settings Pipe (JPS)",
                                        "IPA Switch (JPS)",
                                        "Image Switch (JPS)",
                                        "ImageToImage Pipe (JPS)",
                                        "ImageToImage Settings (JPS)",
                                        "Images Masks MultiPipe (JPS)",
                                        "Integer Switch (JPS)",
                                        "Largest Int (JPS)",
                                        "Latent Switch (JPS)",
                                        "Lora Loader (JPS)",
                                        "Mask Switch (JPS)",
                                        "Model Switch (JPS)",
                                        "Multiply Float Float (JPS)",
                                        "Multiply Int Float (JPS)",
                                        "Multiply Int Int (JPS)",
                                        "Resolution Multiply (JPS)",
                                        "Revision Settings (JPS)",
                                        "Revision Settings Pipe (JPS)",
                                        "SDXL Basic Settings (JPS)",
                                        "SDXL Basic Settings Pipe (JPS)",
                                        "SDXL Fundamentals MultiPipe (JPS)",
                                        "SDXL Prompt Handling (JPS)",
                                        "SDXL Prompt Handling Plus (JPS)",
                                        "SDXL Prompt Styler (JPS)",
                                        "SDXL Recommended Resolution Calc (JPS)",
                                        "SDXL Resolutions (JPS)",
                                        "Sampler Scheduler Settings (JPS)",
                                        "Save Images Plus (JPS)",
                                        "Substract Int Int (JPS)",
                                        "Text Concatenate (JPS)",
                                        "Text Prompt (JPS)",
                                        "VAE Switch (JPS)"
                                    ],
                                    {
                                        "author": "JPS",
                                        "description": "Various nodes to handle SDXL Resolutions, SDXL Basic Settings, IP Adapter Settings, Revision Settings, SDXL Prompt Styler, Crop Image to Square, Crop Image to Target Size, Get Date-Time String, Resolution Multiply, Largest Integer, 5-to-1 Switches for Integer, Images, Latents, Conditioning, Model, VAE, ControlNet",
                                        "nickname": "JPS Custom Nodes",
                                        "title": "JPS Custom Nodes for ComfyUI",
                                        "title_aux": "JPS Custom Nodes for ComfyUI"
                                    }
                                ],
                                "https://github.com/JaredTherriault/ComfyUI-JNodes": [
                                    [
                                        "JNodes_AddOrSetMetaDataKey",
                                        "JNodes_AnyToString",
                                        "JNodes_AppendReversedFrames",
                                        "JNodes_BooleanSelectorWithString",
                                        "JNodes_CheckpointSelectorWithString",
                                        "JNodes_GetOutputDirectory",
                                        "JNodes_GetParameterFromList",
                                        "JNodes_GetParameterGlobal",
                                        "JNodes_GetTempDirectory",
                                        "JNodes_ImageFormatSelector",
                                        "JNodes_ImageSizeSelector",
                                        "JNodes_LoadVideo",
                                        "JNodes_LoraExtractor",
                                        "JNodes_OutVideoInfo",
                                        "JNodes_ParseDynamicPrompts",
                                        "JNodes_ParseParametersToGlobalList",
                                        "JNodes_ParseWildcards",
                                        "JNodes_PromptBuilderSingleSubject",
                                        "JNodes_RemoveCommentedText",
                                        "JNodes_RemoveMetaDataKey",
                                        "JNodes_RemoveParseableDataForInference",
                                        "JNodes_SamplerSelectorWithString",
                                        "JNodes_SaveImageWithOutput",
                                        "JNodes_SaveVideo",
                                        "JNodes_SchedulerSelectorWithString",
                                        "JNodes_SearchAndReplace",
                                        "JNodes_SearchAndReplaceFromFile",
                                        "JNodes_SearchAndReplaceFromList",
                                        "JNodes_SetNegativePromptInMetaData",
                                        "JNodes_SetPositivePromptInMetaData",
                                        "JNodes_SplitAndJoin",
                                        "JNodes_StringLiteral",
                                        "JNodes_SyncedStringLiteral",
                                        "JNodes_TokenCounter",
                                        "JNodes_TrimAndStrip",
                                        "JNodes_UploadVideo",
                                        "JNodes_VaeSelectorWithString"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-JNodes"
                                    }
                                ],
                                "https://github.com/JcandZero/ComfyUI_GLM4Node": [
                                    [
                                        "GLM3_turbo_CHAT",
                                        "GLM4_CHAT",
                                        "GLM4_Vsion_IMGURL"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_GLM4Node"
                                    }
                                ],
                                "https://github.com/Jcd1230/rembg-comfyui-node": [
                                    [
                                        "Image Remove Background (rembg)"
                                    ],
                                    {
                                        "title_aux": "Rembg Background Removal Node for ComfyUI"
                                    }
                                ],
                                "https://github.com/JerryOrbachJr/ComfyUI-RandomSize": [
                                    [
                                        "JOJR_RandomSize"
                                    ],
                                    {
                                        "author": "JerryOrbachJr",
                                        "description": "A ComfyUI custom node that randomly selects a height and width pair from a list in a config file",
                                        "nickname": "Random Size",
                                        "title": "Random Size",
                                        "title_aux": "ComfyUI-RandomSize"
                                    }
                                ],
                                "https://github.com/Jordach/comfy-plasma": [
                                    [
                                        "JDC_AutoContrast",
                                        "JDC_BlendImages",
                                        "JDC_BrownNoise",
                                        "JDC_Contrast",
                                        "JDC_EqualizeGrey",
                                        "JDC_GaussianBlur",
                                        "JDC_GreyNoise",
                                        "JDC_Greyscale",
                                        "JDC_ImageLoader",
                                        "JDC_ImageLoaderMeta",
                                        "JDC_PinkNoise",
                                        "JDC_Plasma",
                                        "JDC_PlasmaSampler",
                                        "JDC_PowerImage",
                                        "JDC_RandNoise",
                                        "JDC_ResizeFactor"
                                    ],
                                    {
                                        "title_aux": "comfy-plasma"
                                    }
                                ],
                                "https://github.com/Kaharos94/ComfyUI-Saveaswebp": [
                                    [
                                        "Save_as_webp"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Saveaswebp"
                                    }
                                ],
                                "https://github.com/Kangkang625/ComfyUI-paint-by-example": [
                                    [
                                        "PaintbyExamplePipeLoader",
                                        "PaintbyExampleSampler"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Paint-by-Example"
                                    }
                                ],
                                "https://github.com/Kosinkadink/ComfyUI-Advanced-ControlNet": [
                                    [
                                        "ACN_AdvancedControlNetApply",
                                        "ACN_ControlNetLoaderWithLoraAdvanced",
                                        "ACN_DefaultUniversalWeights",
                                        "ACN_SparseCtrlIndexMethodNode",
                                        "ACN_SparseCtrlLoaderAdvanced",
                                        "ACN_SparseCtrlMergedLoaderAdvanced",
                                        "ACN_SparseCtrlRGBPreprocessor",
                                        "ACN_SparseCtrlSpreadMethodNode",
                                        "ControlNetLoaderAdvanced",
                                        "CustomControlNetWeights",
                                        "CustomT2IAdapterWeights",
                                        "DiffControlNetLoaderAdvanced",
                                        "LatentKeyframe",
                                        "LatentKeyframeBatchedGroup",
                                        "LatentKeyframeGroup",
                                        "LatentKeyframeTiming",
                                        "LoadImagesFromDirectory",
                                        "ScaledSoftControlNetWeights",
                                        "ScaledSoftMaskedUniversalWeights",
                                        "SoftControlNetWeights",
                                        "SoftT2IAdapterWeights",
                                        "TimestepKeyframe"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Advanced-ControlNet"
                                    }
                                ],
                                "https://github.com/Kosinkadink/ComfyUI-AnimateDiff-Evolved": [
                                    [
                                        "ADE_AdjustPEFullStretch",
                                        "ADE_AdjustPEManual",
                                        "ADE_AdjustPESweetspotStretch",
                                        "ADE_AnimateDiffCombine",
                                        "ADE_AnimateDiffKeyframe",
                                        "ADE_AnimateDiffLoRALoader",
                                        "ADE_AnimateDiffLoaderGen1",
                                        "ADE_AnimateDiffLoaderV1Advanced",
                                        "ADE_AnimateDiffLoaderWithContext",
                                        "ADE_AnimateDiffModelSettings",
                                        "ADE_AnimateDiffModelSettingsAdvancedAttnStrengths",
                                        "ADE_AnimateDiffModelSettingsSimple",
                                        "ADE_AnimateDiffModelSettings_Release",
                                        "ADE_AnimateDiffSamplingSettings",
                                        "ADE_AnimateDiffSettings",
                                        "ADE_AnimateDiffUniformContextOptions",
                                        "ADE_AnimateDiffUnload",
                                        "ADE_ApplyAnimateDiffModel",
                                        "ADE_ApplyAnimateDiffModelSimple",
                                        "ADE_BatchedContextOptions",
                                        "ADE_CustomCFG",
                                        "ADE_CustomCFGKeyframe",
                                        "ADE_EmptyLatentImageLarge",
                                        "ADE_IterationOptsDefault",
                                        "ADE_IterationOptsFreeInit",
                                        "ADE_LoadAnimateDiffModel",
                                        "ADE_LoopedUniformContextOptions",
                                        "ADE_LoopedUniformViewOptions",
                                        "ADE_MaskedLoadLora",
                                        "ADE_MultivalDynamic",
                                        "ADE_MultivalScaledMask",
                                        "ADE_NoiseLayerAdd",
                                        "ADE_NoiseLayerAddWeighted",
                                        "ADE_NoiseLayerReplace",
                                        "ADE_RawSigmaSchedule",
                                        "ADE_SigmaSchedule",
                                        "ADE_SigmaScheduleSplitAndCombine",
                                        "ADE_SigmaScheduleWeightedAverage",
                                        "ADE_SigmaScheduleWeightedAverageInterp",
                                        "ADE_StandardStaticContextOptions",
                                        "ADE_StandardStaticViewOptions",
                                        "ADE_StandardUniformContextOptions",
                                        "ADE_StandardUniformViewOptions",
                                        "ADE_UseEvolvedSampling",
                                        "ADE_ViewsOnlyContextOptions",
                                        "AnimateDiffLoaderV1",
                                        "CheckpointLoaderSimpleWithNoiseSelect"
                                    ],
                                    {
                                        "title_aux": "AnimateDiff Evolved"
                                    }
                                ],
                                "https://github.com/Kosinkadink/ComfyUI-VideoHelperSuite": [
                                    [
                                        "VHS_BatchManager",
                                        "VHS_DuplicateImages",
                                        "VHS_DuplicateLatents",
                                        "VHS_DuplicateMasks",
                                        "VHS_GetImageCount",
                                        "VHS_GetLatentCount",
                                        "VHS_GetMaskCount",
                                        "VHS_LoadAudio",
                                        "VHS_LoadImages",
                                        "VHS_LoadImagesPath",
                                        "VHS_LoadVideo",
                                        "VHS_LoadVideoPath",
                                        "VHS_MergeImages",
                                        "VHS_MergeLatents",
                                        "VHS_MergeMasks",
                                        "VHS_PruneOutputs",
                                        "VHS_SelectEveryNthImage",
                                        "VHS_SelectEveryNthLatent",
                                        "VHS_SelectEveryNthMask",
                                        "VHS_SplitImages",
                                        "VHS_SplitLatents",
                                        "VHS_SplitMasks",
                                        "VHS_VAEDecodeBatched",
                                        "VHS_VAEEncodeBatched",
                                        "VHS_VideoCombine"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-VideoHelperSuite"
                                    }
                                ],
                                "https://github.com/LEv145/images-grid-comfy-plugin": [
                                    [
                                        "GridAnnotation",
                                        "ImageCombine",
                                        "ImagesGridByColumns",
                                        "ImagesGridByRows",
                                        "LatentCombine"
                                    ],
                                    {
                                        "title_aux": "ImagesGrid"
                                    }
                                ],
                                "https://github.com/LarryJane491/Image-Captioning-in-ComfyUI": [
                                    [
                                        "LoRA Caption Load",
                                        "LoRA Caption Save"
                                    ],
                                    {
                                        "title_aux": "Image-Captioning-in-ComfyUI"
                                    }
                                ],
                                "https://github.com/LarryJane491/Lora-Training-in-Comfy": [
                                    [
                                        "Lora Training in Comfy (Advanced)",
                                        "Lora Training in ComfyUI",
                                        "Tensorboard Access"
                                    ],
                                    {
                                        "title_aux": "Lora-Training-in-Comfy"
                                    }
                                ],
                                "https://github.com/Layer-norm/comfyui-lama-remover": [
                                    [
                                        "LamaRemover",
                                        "LamaRemoverIMG"
                                    ],
                                    {
                                        "title_aux": "Comfyui lama remover"
                                    }
                                ],
                                "https://github.com/Lerc/canvas_tab": [
                                    [
                                        "Canvas_Tab",
                                        "Send_To_Editor"
                                    ],
                                    {
                                        "author": "Lerc",
                                        "description": "This extension provides a full page image editor with mask support. There are two nodes, one to receive images from the editor and one to send images to the editor.",
                                        "nickname": "Canvas Tab",
                                        "title": "Canvas Tab",
                                        "title_aux": "Canvas Tab"
                                    }
                                ],
                                "https://github.com/Limitex/ComfyUI-Calculation": [
                                    [
                                        "CenterCalculation",
                                        "CreateQRCode"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Calculation"
                                    }
                                ],
                                "https://github.com/Limitex/ComfyUI-Diffusers": [
                                    [
                                        "CreateIntListNode",
                                        "DiffusersClipTextEncode",
                                        "DiffusersModelMakeup",
                                        "DiffusersPipelineLoader",
                                        "DiffusersSampler",
                                        "DiffusersSchedulerLoader",
                                        "DiffusersVaeLoader",
                                        "LcmLoraLoader",
                                        "StreamDiffusionCreateStream",
                                        "StreamDiffusionFastSampler",
                                        "StreamDiffusionSampler",
                                        "StreamDiffusionWarmup"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Diffusers"
                                    }
                                ],
                                "https://github.com/Loewen-Hob/rembg-comfyui-node-better": [
                                    [
                                        "Image Remove Background (rembg)"
                                    ],
                                    {
                                        "title_aux": "Rembg Background Removal Node for ComfyUI"
                                    }
                                ],
                                "https://github.com/LonicaMewinsky/ComfyUI-MakeFrame": [
                                    [
                                        "BreakFrames",
                                        "BreakGrid",
                                        "GetKeyFrames",
                                        "MakeGrid",
                                        "RandomImageFromDir"
                                    ],
                                    {
                                        "title_aux": "ComfyBreakAnim"
                                    }
                                ],
                                "https://github.com/LonicaMewinsky/ComfyUI-RawSaver": [
                                    [
                                        "SaveTifImage"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-RawSaver"
                                    }
                                ],
                                "https://github.com/LyazS/comfyui-anime-seg": [
                                    [
                                        "Anime Character Seg"
                                    ],
                                    {
                                        "title_aux": "Anime Character Segmentation node for comfyui"
                                    }
                                ],
                                "https://github.com/M1kep/ComfyLiterals": [
                                    [
                                        "Checkpoint",
                                        "Float",
                                        "Int",
                                        "KepStringLiteral",
                                        "Lora",
                                        "Operation",
                                        "String"
                                    ],
                                    {
                                        "title_aux": "ComfyLiterals"
                                    }
                                ],
                                "https://github.com/M1kep/ComfyUI-KepOpenAI": [
                                    [
                                        "KepOpenAI_ImageWithPrompt"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-KepOpenAI"
                                    }
                                ],
                                "https://github.com/M1kep/ComfyUI-OtherVAEs": [
                                    [
                                        "OtherVAE_Taesd"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-OtherVAEs"
                                    }
                                ],
                                "https://github.com/M1kep/Comfy_KepKitchenSink": [
                                    [
                                        "KepRotateImage"
                                    ],
                                    {
                                        "title_aux": "Comfy_KepKitchenSink"
                                    }
                                ],
                                "https://github.com/M1kep/Comfy_KepListStuff": [
                                    [
                                        "Empty Images",
                                        "Image Overlay",
                                        "ImageListLoader",
                                        "Join Float Lists",
                                        "Join Image Lists",
                                        "KepStringList",
                                        "KepStringListFromNewline",
                                        "Kep_JoinListAny",
                                        "Kep_RepeatList",
                                        "Kep_ReverseList",
                                        "Kep_VariableImageBuilder",
                                        "List Length",
                                        "Range(Num Steps) - Float",
                                        "Range(Num Steps) - Int",
                                        "Range(Step) - Float",
                                        "Range(Step) - Int",
                                        "Stack Images",
                                        "XYAny",
                                        "XYImage"
                                    ],
                                    {
                                        "title_aux": "Comfy_KepListStuff"
                                    }
                                ],
                                "https://github.com/M1kep/Comfy_KepMatteAnything": [
                                    [
                                        "MatteAnything_DinoBoxes",
                                        "MatteAnything_GenerateVITMatte",
                                        "MatteAnything_InitSamPredictor",
                                        "MatteAnything_LoadDINO",
                                        "MatteAnything_LoadVITMatteModel",
                                        "MatteAnything_SAMLoader",
                                        "MatteAnything_SAMMaskFromBoxes",
                                        "MatteAnything_ToTrimap"
                                    ],
                                    {
                                        "title_aux": "Comfy_KepMatteAnything"
                                    }
                                ],
                                "https://github.com/M1kep/KepPromptLang": [
                                    [
                                        "Build Gif",
                                        "Special CLIP Loader"
                                    ],
                                    {
                                        "title_aux": "KepPromptLang"
                                    }
                                ],
                                "https://github.com/MNeMoNiCuZ/ComfyUI-mnemic-nodes": [
                                    [
                                        "Save Text File_mne"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-mnemic-nodes"
                                    }
                                ],
                                "https://github.com/Mamaaaamooooo/batchImg-rembg-ComfyUI-nodes": [
                                    [
                                        "Image Remove Background (rembg)"
                                    ],
                                    {
                                        "title_aux": "Batch Rembg for ComfyUI"
                                    }
                                ],
                                "https://github.com/ManglerFTW/ComfyI2I": [
                                    [
                                        "Color Transfer",
                                        "Combine and Paste",
                                        "Inpaint Segments",
                                        "Mask Ops"
                                    ],
                                    {
                                        "author": "ManglerFTW",
                                        "title": "ComfyI2I",
                                        "title_aux": "ComfyI2I"
                                    }
                                ],
                                "https://github.com/MarkoCa1/ComfyUI_Segment_Mask": [
                                    [
                                        "AutomaticMask(segment anything)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Segment_Mask"
                                    }
                                ],
                                "https://github.com/Miosp/ComfyUI-FBCNN": [
                                    [
                                        "JPEG artifacts removal FBCNN"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-FBCNN"
                                    }
                                ],
                                "https://github.com/MitoshiroPJ/comfyui_slothful_attention": [
                                    [
                                        "NearSightedAttention",
                                        "NearSightedAttentionSimple",
                                        "NearSightedTile",
                                        "SlothfulAttention"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Slothful Attention"
                                    }
                                ],
                                "https://github.com/MrForExample/ComfyUI-3D-Pack": [
                                    [],
                                    {
                                        "nodename_pattern": "^\\[Comfy3D\\]",
                                        "title_aux": "ComfyUI-3D-Pack"
                                    }
                                ],
                                "https://github.com/MrForExample/ComfyUI-AnimateAnyone-Evolved": [
                                    [],
                                    {
                                        "nodename_pattern": "^\\[AnimateAnyone\\]",
                                        "title_aux": "ComfyUI-AnimateAnyone-Evolved"
                                    }
                                ],
                                "https://github.com/NicholasMcCarthy/ComfyUI_TravelSuite": [
                                    [
                                        "LatentTravel"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_TravelSuite"
                                    }
                                ],
                                "https://github.com/NimaNzrii/comfyui-photoshop": [
                                    [
                                        "PhotoshopToComfyUI"
                                    ],
                                    {
                                        "title_aux": "comfyui-photoshop"
                                    }
                                ],
                                "https://github.com/NimaNzrii/comfyui-popup_preview": [
                                    [
                                        "PreviewPopup"
                                    ],
                                    {
                                        "title_aux": "comfyui-popup_preview"
                                    }
                                ],
                                "https://github.com/Niutonian/ComfyUi-NoodleWebcam": [
                                    [
                                        "WebcamNode"
                                    ],
                                    {
                                        "title_aux": "ComfyUi-NoodleWebcam"
                                    }
                                ],
                                "https://github.com/Nlar/ComfyUI_CartoonSegmentation": [
                                    [
                                        "AnimeSegmentation",
                                        "KenBurnsConfigLoader",
                                        "KenBurns_Processor",
                                        "LoadImageFilename"
                                    ],
                                    {
                                        "author": "Nels Larsen",
                                        "description": "This extension offers a front end to the Cartoon Segmentation Project (https://github.com/CartoonSegmentation/CartoonSegmentation)",
                                        "nickname": "CfyCS",
                                        "title": "ComfyUI_CartoonSegmentation",
                                        "title_aux": "ComfyUI_CartoonSegmentation"
                                    }
                                ],
                                "https://github.com/NotHarroweD/Harronode": [
                                    [
                                        "Harronode"
                                    ],
                                    {
                                        "author": "HarroweD and quadmoon (https://github.com/traugdor)",
                                        "description": "This extension to ComfyUI will build a prompt for the Harrlogos LoRA for SDXL.",
                                        "nickname": "Harronode",
                                        "nodename_pattern": "Harronode",
                                        "title": "Harrlogos Prompt Builder Node",
                                        "title_aux": "Harronode"
                                    }
                                ],
                                "https://github.com/Nourepide/ComfyUI-Allor": [
                                    [
                                        "AlphaChanelAdd",
                                        "AlphaChanelAddByMask",
                                        "AlphaChanelAsMask",
                                        "AlphaChanelRemove",
                                        "AlphaChanelRestore",
                                        "ClipClamp",
                                        "ClipVisionClamp",
                                        "ClipVisionOutputClamp",
                                        "ConditioningClamp",
                                        "ControlNetClamp",
                                        "GligenClamp",
                                        "ImageBatchCopy",
                                        "ImageBatchFork",
                                        "ImageBatchGet",
                                        "ImageBatchJoin",
                                        "ImageBatchPermute",
                                        "ImageBatchRemove",
                                        "ImageClamp",
                                        "ImageCompositeAbsolute",
                                        "ImageCompositeAbsoluteByContainer",
                                        "ImageCompositeRelative",
                                        "ImageCompositeRelativeByContainer",
                                        "ImageContainer",
                                        "ImageContainerInheritanceAdd",
                                        "ImageContainerInheritanceMax",
                                        "ImageContainerInheritanceScale",
                                        "ImageContainerInheritanceSum",
                                        "ImageDrawArc",
                                        "ImageDrawArcByContainer",
                                        "ImageDrawChord",
                                        "ImageDrawChordByContainer",
                                        "ImageDrawEllipse",
                                        "ImageDrawEllipseByContainer",
                                        "ImageDrawLine",
                                        "ImageDrawLineByContainer",
                                        "ImageDrawPieslice",
                                        "ImageDrawPiesliceByContainer",
                                        "ImageDrawPolygon",
                                        "ImageDrawRectangle",
                                        "ImageDrawRectangleByContainer",
                                        "ImageDrawRectangleRounded",
                                        "ImageDrawRectangleRoundedByContainer",
                                        "ImageEffectsAdjustment",
                                        "ImageEffectsGrayscale",
                                        "ImageEffectsLensBokeh",
                                        "ImageEffectsLensChromaticAberration",
                                        "ImageEffectsLensOpticAxis",
                                        "ImageEffectsLensVignette",
                                        "ImageEffectsLensZoomBurst",
                                        "ImageEffectsNegative",
                                        "ImageEffectsSepia",
                                        "ImageFilterBilateralBlur",
                                        "ImageFilterBlur",
                                        "ImageFilterBoxBlur",
                                        "ImageFilterContour",
                                        "ImageFilterDetail",
                                        "ImageFilterEdgeEnhance",
                                        "ImageFilterEdgeEnhanceMore",
                                        "ImageFilterEmboss",
                                        "ImageFilterFindEdges",
                                        "ImageFilterGaussianBlur",
                                        "ImageFilterGaussianBlurAdvanced",
                                        "ImageFilterMax",
                                        "ImageFilterMedianBlur",
                                        "ImageFilterMin",
                                        "ImageFilterMode",
                                        "ImageFilterRank",
                                        "ImageFilterSharpen",
                                        "ImageFilterSmooth",
                                        "ImageFilterSmoothMore",
                                        "ImageFilterStackBlur",
                                        "ImageNoiseBeta",
                                        "ImageNoiseBinomial",
                                        "ImageNoiseBytes",
                                        "ImageNoiseGaussian",
                                        "ImageSegmentation",
                                        "ImageSegmentationCustom",
                                        "ImageSegmentationCustomAdvanced",
                                        "ImageText",
                                        "ImageTextMultiline",
                                        "ImageTextMultilineOutlined",
                                        "ImageTextOutlined",
                                        "ImageTransformCropAbsolute",
                                        "ImageTransformCropCorners",
                                        "ImageTransformCropRelative",
                                        "ImageTransformPaddingAbsolute",
                                        "ImageTransformPaddingRelative",
                                        "ImageTransformResizeAbsolute",
                                        "ImageTransformResizeClip",
                                        "ImageTransformResizeRelative",
                                        "ImageTransformRotate",
                                        "ImageTransformTranspose",
                                        "LatentClamp",
                                        "MaskClamp",
                                        "ModelClamp",
                                        "StyleModelClamp",
                                        "UpscaleModelClamp",
                                        "VaeClamp"
                                    ],
                                    {
                                        "title_aux": "Allor Plugin"
                                    }
                                ],
                                "https://github.com/Nuked88/ComfyUI-N-Nodes": [
                                    [
                                        "CLIPTextEncodeAdvancedNSuite [n-suite]",
                                        "DynamicPrompt [n-suite]",
                                        "Float Variable [n-suite]",
                                        "FrameInterpolator [n-suite]",
                                        "GPT Loader Simple [n-suite]",
                                        "GPT Sampler [n-suite]",
                                        "ImagePadForOutpaintAdvanced [n-suite]",
                                        "Integer Variable [n-suite]",
                                        "Llava Clip Loader [n-suite]",
                                        "LoadFramesFromFolder [n-suite]",
                                        "LoadVideo [n-suite]",
                                        "SaveVideo [n-suite]",
                                        "SetMetadataForSaveVideo [n-suite]",
                                        "String Variable [n-suite]"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-N-Nodes"
                                    }
                                ],
                                "https://github.com/Off-Live/ComfyUI-off-suite": [
                                    [
                                        "Apply CLAHE",
                                        "Cached Image Load From URL",
                                        "Crop Center wigh SEGS",
                                        "Crop Center with SEGS",
                                        "Dilate Mask for Each Face",
                                        "GW Number Formatting",
                                        "Image Crop Fit",
                                        "Image Resize Fit",
                                        "OFF SEGS to Image",
                                        "Paste Face Segment to Image",
                                        "Query Gender and Age",
                                        "SEGS to Face Crop Data",
                                        "Safe Mask to Image",
                                        "VAE Encode For Inpaint V2",
                                        "Watermarking"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-off-suite"
                                    }
                                ],
                                "https://github.com/Onierous/QRNG_Node_ComfyUI/raw/main/qrng_node.py": [
                                    [
                                        "QRNG_Node_CSV"
                                    ],
                                    {
                                        "title_aux": "QRNG_Node_ComfyUI"
                                    }
                                ],
                                "https://github.com/PCMonsterx/ComfyUI-CSV-Loader": [
                                    [
                                        "Load Artists CSV",
                                        "Load Artmovements CSV",
                                        "Load Characters CSV",
                                        "Load Colors CSV",
                                        "Load Composition CSV",
                                        "Load Lighting CSV",
                                        "Load Negative CSV",
                                        "Load Positive CSV",
                                        "Load Settings CSV",
                                        "Load Styles CSV"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-CSV-Loader"
                                    }
                                ],
                                "https://github.com/ParmanBabra/ComfyUI-Malefish-Custom-Scripts": [
                                    [
                                        "CSVPromptsLoader",
                                        "CombinePrompt",
                                        "MultiLoraLoader",
                                        "RandomPrompt"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Malefish-Custom-Scripts"
                                    }
                                ],
                                "https://github.com/Pfaeff/pfaeff-comfyui": [
                                    [
                                        "AstropulsePixelDetector",
                                        "BackgroundRemover",
                                        "ImagePadForBetterOutpaint",
                                        "Inpainting",
                                        "InpaintingPipelineLoader"
                                    ],
                                    {
                                        "title_aux": "pfaeff-comfyui"
                                    }
                                ],
                                "https://github.com/QaisMalkawi/ComfyUI-QaisHelper": [
                                    [
                                        "Bool Binary Operation",
                                        "Bool Unary Operation",
                                        "Item Debugger",
                                        "Item Switch",
                                        "Nearest SDXL Resolution",
                                        "SDXL Resolution",
                                        "Size Swapper"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Qais-Helper"
                                    }
                                ],
                                "https://github.com/RenderRift/ComfyUI-RenderRiftNodes": [
                                    [
                                        "AnalyseMetadata",
                                        "DateIntegerNode",
                                        "DisplayMetaOptions",
                                        "LoadImageWithMeta",
                                        "MetadataOverlayNode",
                                        "VideoPathMetaExtraction"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-RenderRiftNodes"
                                    }
                                ],
                                "https://github.com/Ryuukeisyou/comfyui_face_parsing": [
                                    [
                                        "BBoxListItemSelect(FaceParsing)",
                                        "BBoxResize(FaceParsing)",
                                        "ColorAdjust(FaceParsing)",
                                        "FaceBBoxDetect(FaceParsing)",
                                        "FaceBBoxDetectorLoader(FaceParsing)",
                                        "FaceParse(FaceParsing)",
                                        "FaceParsingModelLoader(FaceParsing)",
                                        "FaceParsingProcessorLoader(FaceParsing)",
                                        "FaceParsingResultsParser(FaceParsing)",
                                        "GuidedFilter(FaceParsing)",
                                        "ImageCropWithBBox(FaceParsing)",
                                        "ImageInsertWithBBox(FaceParsing)",
                                        "ImageListSelect(FaceParsing)",
                                        "ImagePadWithBBox(FaceParsing)",
                                        "ImageResizeCalculator(FaceParsing)",
                                        "ImageResizeWithBBox(FaceParsing)",
                                        "ImageSize(FaceParsing)",
                                        "LatentCropWithBBox(FaceParsing)",
                                        "LatentInsertWithBBox(FaceParsing)",
                                        "LatentSize(FaceParsing)",
                                        "MaskComposite(FaceParsing)",
                                        "MaskListComposite(FaceParsing)",
                                        "MaskListSelect(FaceParsing)",
                                        "MaskToBBox(FaceParsing)",
                                        "SkinDetectTraditional(FaceParsing)"
                                    ],
                                    {
                                        "title_aux": "comfyui_face_parsing"
                                    }
                                ],
                                "https://github.com/Ryuukeisyou/comfyui_image_io_helpers": [
                                    [
                                        "ImageLoadAsMaskByPath(ImageIOHelpers)",
                                        "ImageLoadByPath(ImageIOHelpers)",
                                        "ImageLoadFromBase64(ImageIOHelpers)",
                                        "ImageSaveAsBase64(ImageIOHelpers)",
                                        "ImageSaveToPath(ImageIOHelpers)"
                                    ],
                                    {
                                        "title_aux": "comfyui_image_io_helpers"
                                    }
                                ],
                                "https://github.com/SLAPaper/ComfyUI-Image-Selector": [
                                    [
                                        "ImageDuplicator",
                                        "ImageSelector",
                                        "LatentDuplicator",
                                        "LatentSelector"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Image-Selector"
                                    }
                                ],
                                "https://github.com/SOELexicon/ComfyUI-LexMSDBNodes": [
                                    [
                                        "MSSqlSelectNode",
                                        "MSSqlTableNode"
                                    ],
                                    {
                                        "title_aux": "LexMSDBNodes"
                                    }
                                ],
                                "https://github.com/SOELexicon/ComfyUI-LexTools": [
                                    [
                                        "AgeClassifierNode",
                                        "ArtOrHumanClassifierNode",
                                        "DocumentClassificationNode",
                                        "FoodCategoryClassifierNode",
                                        "ImageAspectPadNode",
                                        "ImageCaptioning",
                                        "ImageFilterByFloatScoreNode",
                                        "ImageFilterByIntScoreNode",
                                        "ImageQualityScoreNode",
                                        "ImageRankingNode",
                                        "ImageScaleToMin",
                                        "MD5ImageHashNode",
                                        "SamplerPropertiesNode",
                                        "ScoreConverterNode",
                                        "SeedIncrementerNode",
                                        "SegformerNode",
                                        "SegformerNodeMasks",
                                        "SegformerNodeMergeSegments",
                                        "StepCfgIncrementNode"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-LexTools"
                                    }
                                ],
                                "https://github.com/SadaleNet/CLIPTextEncodeA1111-ComfyUI/raw/master/custom_nodes/clip_text_encoder_a1111.py": [
                                    [
                                        "CLIPTextEncodeA1111",
                                        "RerouteTextForCLIPTextEncodeA1111"
                                    ],
                                    {
                                        "title_aux": "ComfyUI A1111-like Prompt Custom Node Solution"
                                    }
                                ],
                                "https://github.com/Scholar01/ComfyUI-Keyframe": [
                                    [
                                        "KeyframeApply",
                                        "KeyframeInterpolationPart",
                                        "KeyframePart"
                                    ],
                                    {
                                        "title_aux": "SComfyUI-Keyframe"
                                    }
                                ],
                                "https://github.com/SeargeDP/SeargeSDXL": [
                                    [
                                        "SeargeAdvancedParameters",
                                        "SeargeCheckpointLoader",
                                        "SeargeConditionMixing",
                                        "SeargeConditioningMuxer2",
                                        "SeargeConditioningMuxer5",
                                        "SeargeConditioningParameters",
                                        "SeargeControlnetAdapterV2",
                                        "SeargeControlnetModels",
                                        "SeargeCustomAfterUpscaling",
                                        "SeargeCustomAfterVaeDecode",
                                        "SeargeCustomPromptMode",
                                        "SeargeDebugPrinter",
                                        "SeargeEnablerInputs",
                                        "SeargeFloatConstant",
                                        "SeargeFloatMath",
                                        "SeargeFloatPair",
                                        "SeargeFreeU",
                                        "SeargeGenerated1",
                                        "SeargeGenerationParameters",
                                        "SeargeHighResolution",
                                        "SeargeImage2ImageAndInpainting",
                                        "SeargeImageAdapterV2",
                                        "SeargeImageSave",
                                        "SeargeImageSaving",
                                        "SeargeInput1",
                                        "SeargeInput2",
                                        "SeargeInput3",
                                        "SeargeInput4",
                                        "SeargeInput5",
                                        "SeargeInput6",
                                        "SeargeInput7",
                                        "SeargeIntegerConstant",
                                        "SeargeIntegerMath",
                                        "SeargeIntegerPair",
                                        "SeargeIntegerScaler",
                                        "SeargeLatentMuxer3",
                                        "SeargeLoraLoader",
                                        "SeargeLoras",
                                        "SeargeMagicBox",
                                        "SeargeModelSelector",
                                        "SeargeOperatingMode",
                                        "SeargeOutput1",
                                        "SeargeOutput2",
                                        "SeargeOutput3",
                                        "SeargeOutput4",
                                        "SeargeOutput5",
                                        "SeargeOutput6",
                                        "SeargeOutput7",
                                        "SeargeParameterProcessor",
                                        "SeargePipelineStart",
                                        "SeargePipelineTerminator",
                                        "SeargePreviewImage",
                                        "SeargePromptAdapterV2",
                                        "SeargePromptCombiner",
                                        "SeargePromptStyles",
                                        "SeargePromptText",
                                        "SeargeSDXLBasePromptEncoder",
                                        "SeargeSDXLImage2ImageSampler",
                                        "SeargeSDXLImage2ImageSampler2",
                                        "SeargeSDXLPromptEncoder",
                                        "SeargeSDXLRefinerPromptEncoder",
                                        "SeargeSDXLSampler",
                                        "SeargeSDXLSampler2",
                                        "SeargeSDXLSamplerV3",
                                        "SeargeSamplerAdvanced",
                                        "SeargeSamplerInputs",
                                        "SeargeSaveFolderInputs",
                                        "SeargeSeparator",
                                        "SeargeStylePreprocessor",
                                        "SeargeTextInputV2",
                                        "SeargeUpscaleModelLoader",
                                        "SeargeUpscaleModels",
                                        "SeargeVAELoader"
                                    ],
                                    {
                                        "title_aux": "SeargeSDXL"
                                    }
                                ],
                                "https://github.com/Ser-Hilary/SDXL_sizing/raw/main/conditioning_sizing_for_SDXL.py": [
                                    [
                                        "get_aspect_from_image",
                                        "get_aspect_from_ints",
                                        "sizing_node",
                                        "sizing_node_basic",
                                        "sizing_node_unparsed"
                                    ],
                                    {
                                        "title_aux": "SDXL_sizing"
                                    }
                                ],
                                "https://github.com/ShmuelRonen/ComfyUI-SVDResizer": [
                                    [
                                        "SVDRsizer"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SVDResizer"
                                    }
                                ],
                                "https://github.com/Shraknard/ComfyUI-Remover": [
                                    [
                                        "Remover"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Remover"
                                    }
                                ],
                                "https://github.com/Siberpone/lazy-pony-prompter": [
                                    [
                                        "LPP_Deleter",
                                        "LPP_Derpibooru",
                                        "LPP_E621",
                                        "LPP_Loader_Derpibooru",
                                        "LPP_Loader_E621",
                                        "LPP_Saver"
                                    ],
                                    {
                                        "title_aux": "Lazy Pony Prompter"
                                    }
                                ],
                                "https://github.com/Smuzzies/comfyui_chatbox_overlay/raw/main/chatbox_overlay.py": [
                                    [
                                        "Chatbox Overlay"
                                    ],
                                    {
                                        "title_aux": "Chatbox Overlay node for ComfyUI"
                                    }
                                ],
                                "https://github.com/SoftMeng/ComfyUI_Mexx_Poster": [
                                    [
                                        "ComfyUI_Mexx_Poster"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Mexx_Poster"
                                    }
                                ],
                                "https://github.com/SoftMeng/ComfyUI_Mexx_Styler": [
                                    [
                                        "MexxSDXLPromptStyler",
                                        "MexxSDXLPromptStylerAdvanced"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Mexx_Styler"
                                    }
                                ],
                                "https://github.com/SpaceKendo/ComfyUI-svd_txt2vid": [
                                    [
                                        "SVD_txt2vid_ConditioningwithLatent"
                                    ],
                                    {
                                        "title_aux": "Text to video for Stable Video Diffusion in ComfyUI"
                                    }
                                ],
                                "https://github.com/Stability-AI/stability-ComfyUI-nodes": [
                                    [
                                        "ColorBlend",
                                        "ControlLoraSave",
                                        "GetImageSize"
                                    ],
                                    {
                                        "title_aux": "stability-ComfyUI-nodes"
                                    }
                                ],
                                "https://github.com/StartHua/ComfyUI_Seg_VITON": [
                                    [
                                        "segformer_agnostic",
                                        "segformer_clothes",
                                        "segformer_remove_bg",
                                        "stabel_vition"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Seg_VITON"
                                    }
                                ],
                                "https://github.com/StartHua/Comfyui_joytag": [
                                    [
                                        "CXH_JoyTag"
                                    ],
                                    {
                                        "title_aux": "Comfyui_joytag"
                                    }
                                ],
                                "https://github.com/Suzie1/ComfyUI_Comfyroll_CustomNodes": [
                                    [
                                        "CR 8 Channel In",
                                        "CR 8 Channel Out",
                                        "CR Apply ControlNet",
                                        "CR Apply LoRA Stack",
                                        "CR Apply Model Merge",
                                        "CR Apply Multi Upscale",
                                        "CR Apply Multi-ControlNet",
                                        "CR Arabic Text RTL",
                                        "CR Aspect Ratio",
                                        "CR Aspect Ratio Banners",
                                        "CR Aspect Ratio SDXL",
                                        "CR Aspect Ratio Social Media",
                                        "CR Batch Images From List",
                                        "CR Batch Process Switch",
                                        "CR Binary Pattern",
                                        "CR Binary To Bit List",
                                        "CR Bit Schedule",
                                        "CR Central Schedule",
                                        "CR Checker Pattern",
                                        "CR Clamp Value",
                                        "CR Clip Input Switch",
                                        "CR Color Bars",
                                        "CR Color Gradient",
                                        "CR Color Panel",
                                        "CR Color Tint",
                                        "CR Combine Prompt",
                                        "CR Combine Schedules",
                                        "CR Comic Panel Templates",
                                        "CR Composite Text",
                                        "CR Conditioning Input Switch",
                                        "CR Conditioning Mixer",
                                        "CR ControlNet Input Switch",
                                        "CR Current Frame",
                                        "CR Cycle Images",
                                        "CR Cycle Images Simple",
                                        "CR Cycle LoRAs",
                                        "CR Cycle Models",
                                        "CR Cycle Text",
                                        "CR Cycle Text Simple",
                                        "CR Data Bus In",
                                        "CR Data Bus Out",
                                        "CR Debatch Frames",
                                        "CR Diamond Panel",
                                        "CR Draw Perspective Text",
                                        "CR Draw Pie",
                                        "CR Draw Shape",
                                        "CR Draw Text",
                                        "CR Encode Scheduled Prompts",
                                        "CR Feathered Border",
                                        "CR Float Range List",
                                        "CR Float To Integer",
                                        "CR Float To String",
                                        "CR Font File List",
                                        "CR Get Parameter From Prompt",
                                        "CR Gradient Float",
                                        "CR Gradient Integer",
                                        "CR Half Drop Panel",
                                        "CR Halftone Filter",
                                        "CR Halftone Grid",
                                        "CR Hires Fix Process Switch",
                                        "CR Image Border",
                                        "CR Image Grid Panel",
                                        "CR Image Input Switch",
                                        "CR Image Input Switch (4 way)",
                                        "CR Image List",
                                        "CR Image List Simple",
                                        "CR Image Output",
                                        "CR Image Panel",
                                        "CR Image Pipe Edit",
                                        "CR Image Pipe In",
                                        "CR Image Pipe Out",
                                        "CR Image Size",
                                        "CR Img2Img Process Switch",
                                        "CR Increment Float",
                                        "CR Increment Integer",
                                        "CR Index",
                                        "CR Index Increment",
                                        "CR Index Multiply",
                                        "CR Index Reset",
                                        "CR Input Text List",
                                        "CR Integer Multiple",
                                        "CR Integer Range List",
                                        "CR Integer To String",
                                        "CR Interpolate Latents",
                                        "CR Intertwine Lists",
                                        "CR Keyframe List",
                                        "CR Latent Batch Size",
                                        "CR Latent Input Switch",
                                        "CR LoRA List",
                                        "CR LoRA Stack",
                                        "CR Load Animation Frames",
                                        "CR Load Flow Frames",
                                        "CR Load GIF As List",
                                        "CR Load Image List",
                                        "CR Load Image List Plus",
                                        "CR Load LoRA",
                                        "CR Load Prompt Style",
                                        "CR Load Schedule From File",
                                        "CR Load Scheduled ControlNets",
                                        "CR Load Scheduled LoRAs",
                                        "CR Load Scheduled Models",
                                        "CR Load Text List",
                                        "CR Mask Text",
                                        "CR Math Operation",
                                        "CR Model Input Switch",
                                        "CR Model List",
                                        "CR Model Merge Stack",
                                        "CR Module Input",
                                        "CR Module Output",
                                        "CR Module Pipe Loader",
                                        "CR Multi Upscale Stack",
                                        "CR Multi-ControlNet Stack",
                                        "CR Multiline Text",
                                        "CR Output Flow Frames",
                                        "CR Output Schedule To File",
                                        "CR Overlay Text",
                                        "CR Overlay Transparent Image",
                                        "CR Page Layout",
                                        "CR Pipe Switch",
                                        "CR Polygons",
                                        "CR Prompt List",
                                        "CR Prompt List Keyframes",
                                        "CR Prompt Scheduler",
                                        "CR Prompt Text",
                                        "CR Radial Gradient",
                                        "CR Random Hex Color",
                                        "CR Random LoRA Stack",
                                        "CR Random Multiline Colors",
                                        "CR Random Multiline Values",
                                        "CR Random Panel Codes",
                                        "CR Random RGB",
                                        "CR Random RGB Gradient",
                                        "CR Random Shape Pattern",
                                        "CR Random Weight LoRA",
                                        "CR Repeater",
                                        "CR SD1.5 Aspect Ratio",
                                        "CR SDXL Aspect Ratio",
                                        "CR SDXL Base Prompt Encoder",
                                        "CR SDXL Prompt Mix Presets",
                                        "CR SDXL Prompt Mixer",
                                        "CR SDXL Style Text",
                                        "CR Save Text To File",
                                        "CR Schedule Input Switch",
                                        "CR Schedule To ScheduleList",
                                        "CR Seamless Checker",
                                        "CR Seed",
                                        "CR Seed to Int",
                                        "CR Select Font",
                                        "CR Select ISO Size",
                                        "CR Select Model",
                                        "CR Select Resize Method",
                                        "CR Set Switch From String",
                                        "CR Set Value On Binary",
                                        "CR Set Value On Boolean",
                                        "CR Set Value on String",
                                        "CR Simple Banner",
                                        "CR Simple Binary Pattern",
                                        "CR Simple Binary Pattern Simple",
                                        "CR Simple Image Compare",
                                        "CR Simple List",
                                        "CR Simple Meme Template",
                                        "CR Simple Prompt List",
                                        "CR Simple Prompt List Keyframes",
                                        "CR Simple Prompt Scheduler",
                                        "CR Simple Schedule",
                                        "CR Simple Text Panel",
                                        "CR Simple Text Scheduler",
                                        "CR Simple Text Watermark",
                                        "CR Simple Titles",
                                        "CR Simple Value Scheduler",
                                        "CR Split String",
                                        "CR Starburst Colors",
                                        "CR Starburst Lines",
                                        "CR String To Boolean",
                                        "CR String To Combo",
                                        "CR String To Number",
                                        "CR Style Bars",
                                        "CR Switch Model and CLIP",
                                        "CR Text",
                                        "CR Text Blacklist",
                                        "CR Text Concatenate",
                                        "CR Text Cycler",
                                        "CR Text Input Switch",
                                        "CR Text Input Switch (4 way)",
                                        "CR Text Length",
                                        "CR Text List",
                                        "CR Text List Simple",
                                        "CR Text List To String",
                                        "CR Text Operation",
                                        "CR Text Replace",
                                        "CR Text Scheduler",
                                        "CR Thumbnail Preview",
                                        "CR Trigger",
                                        "CR Upscale Image",
                                        "CR VAE Decode",
                                        "CR VAE Input Switch",
                                        "CR Value",
                                        "CR Value Cycler",
                                        "CR Value Scheduler",
                                        "CR Vignette Filter",
                                        "CR XY From Folder",
                                        "CR XY Index",
                                        "CR XY Interpolate",
                                        "CR XY List",
                                        "CR XY Product",
                                        "CR XY Save Grid Image",
                                        "CR XYZ Index",
                                        "CR_Aspect Ratio For Print"
                                    ],
                                    {
                                        "author": "Suzie1",
                                        "description": "175 custom nodes for artists, designers and animators.",
                                        "nickname": "Comfyroll Studio",
                                        "title": "Comfyroll Studio",
                                        "title_aux": "ComfyUI_Comfyroll_CustomNodes"
                                    }
                                ],
                                "https://github.com/Sxela/ComfyWarp": [
                                    [
                                        "ExtractOpticalFlow",
                                        "LoadFrame",
                                        "LoadFrameFromDataset",
                                        "LoadFrameFromFolder",
                                        "LoadFramePairFromDataset",
                                        "LoadFrameSequence",
                                        "MakeFrameDataset",
                                        "MixConsistencyMaps",
                                        "OffsetNumber",
                                        "ResizeToFit",
                                        "SaveFrame",
                                        "WarpFrame"
                                    ],
                                    {
                                        "title_aux": "ComfyWarp"
                                    }
                                ],
                                "https://github.com/TGu-97/ComfyUI-TGu-utils": [
                                    [
                                        "MPNReroute",
                                        "MPNSwitch",
                                        "PNSwitch"
                                    ],
                                    {
                                        "title_aux": "TGu Utilities"
                                    }
                                ],
                                "https://github.com/THtianhao/ComfyUI-FaceChain": [
                                    [
                                        "FC CropAndPaste",
                                        "FC CropBottom",
                                        "FC CropToOrigin",
                                        "FC FaceDetectCrop",
                                        "FC FaceFusion",
                                        "FC FaceSegAndReplace",
                                        "FC FaceSegment",
                                        "FC MaskOP",
                                        "FC RemoveCannyFace",
                                        "FC ReplaceByMask",
                                        "FC StyleLoraLoad"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-FaceChain"
                                    }
                                ],
                                "https://github.com/THtianhao/ComfyUI-Portrait-Maker": [
                                    [
                                        "PM_BoxCropImage",
                                        "PM_ColorTransfer",
                                        "PM_ExpandMaskBox",
                                        "PM_FaceFusion",
                                        "PM_FaceShapMatch",
                                        "PM_FaceSkin",
                                        "PM_GetImageInfo",
                                        "PM_ImageResizeTarget",
                                        "PM_ImageScaleShort",
                                        "PM_MakeUpTransfer",
                                        "PM_MaskDilateErode",
                                        "PM_MaskMerge2Image",
                                        "PM_PortraitEnhancement",
                                        "PM_RatioMerge2Image",
                                        "PM_ReplaceBoxImg",
                                        "PM_RetinaFace",
                                        "PM_Similarity",
                                        "PM_SkinRetouching",
                                        "PM_SuperColorTransfer",
                                        "PM_SuperMakeUpTransfer"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Portrait-Maker"
                                    }
                                ],
                                "https://github.com/TRI3D-LC/tri3d-comfyui-nodes": [
                                    [
                                        "tri3d-adjust-neck",
                                        "tri3d-atr-parse",
                                        "tri3d-atr-parse-batch",
                                        "tri3d-clipdrop-bgremove-api",
                                        "tri3d-dwpose",
                                        "tri3d-extract-hand",
                                        "tri3d-extract-parts-batch",
                                        "tri3d-extract-parts-batch2",
                                        "tri3d-extract-parts-mask-batch",
                                        "tri3d-face-recognise",
                                        "tri3d-float-to-image",
                                        "tri3d-fuzzification",
                                        "tri3d-image-mask-2-box",
                                        "tri3d-image-mask-box-2-image",
                                        "tri3d-interaction-canny",
                                        "tri3d-load-pose-json",
                                        "tri3d-pose-adaption",
                                        "tri3d-pose-to-image",
                                        "tri3d-position-hands",
                                        "tri3d-position-parts-batch",
                                        "tri3d-recolor-mask",
                                        "tri3d-recolor-mask-LAB_space",
                                        "tri3d-recolor-mask-LAB_space_manual",
                                        "tri3d-recolor-mask-RGB_space",
                                        "tri3d-skin-feathered-padded-mask",
                                        "tri3d-swap-pixels"
                                    ],
                                    {
                                        "title_aux": "tri3d-comfyui-nodes"
                                    }
                                ],
                                "https://github.com/Taremin/comfyui-prompt-extranetworks": [
                                    [
                                        "PromptExtraNetworks"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Prompt ExtraNetworks"
                                    }
                                ],
                                "https://github.com/Taremin/comfyui-string-tools": [
                                    [
                                        "StringToolsBalancedChoice",
                                        "StringToolsConcat",
                                        "StringToolsRandomChoice",
                                        "StringToolsString",
                                        "StringToolsText"
                                    ],
                                    {
                                        "title_aux": "ComfyUI String Tools"
                                    }
                                ],
                                "https://github.com/TeaCrab/ComfyUI-TeaNodes": [
                                    [
                                        "TC_ColorFill",
                                        "TC_EqualizeCLAHE",
                                        "TC_ImageResize",
                                        "TC_ImageScale",
                                        "TC_RandomColorFill",
                                        "TC_SizeApproximation"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TeaNodes"
                                    }
                                ],
                                "https://github.com/TemryL/ComfyS3": [
                                    [
                                        "DownloadFileS3",
                                        "LoadImageS3",
                                        "SaveImageS3",
                                        "SaveVideoFilesS3",
                                        "UploadFileS3"
                                    ],
                                    {
                                        "title_aux": "ComfyS3"
                                    }
                                ],
                                "https://github.com/TheBarret/ZSuite": [
                                    [
                                        "ZSuite: Prompter",
                                        "ZSuite: RF Noise",
                                        "ZSuite: SeedMod"
                                    ],
                                    {
                                        "title_aux": "ZSuite"
                                    }
                                ],
                                "https://github.com/TinyTerra/ComfyUI_tinyterraNodes": [
                                    [
                                        "ttN busIN",
                                        "ttN busOUT",
                                        "ttN compareInput",
                                        "ttN concat",
                                        "ttN debugInput",
                                        "ttN float",
                                        "ttN hiresfixScale",
                                        "ttN imageOutput",
                                        "ttN imageREMBG",
                                        "ttN int",
                                        "ttN multiModelMerge",
                                        "ttN pipe2BASIC",
                                        "ttN pipe2DETAILER",
                                        "ttN pipeEDIT",
                                        "ttN pipeEncodeConcat",
                                        "ttN pipeIN",
                                        "ttN pipeKSampler",
                                        "ttN pipeKSamplerAdvanced",
                                        "ttN pipeKSamplerSDXL",
                                        "ttN pipeLoader",
                                        "ttN pipeLoaderSDXL",
                                        "ttN pipeLoraStack",
                                        "ttN pipeOUT",
                                        "ttN seed",
                                        "ttN seedDebug",
                                        "ttN text",
                                        "ttN text3BOX_3WAYconcat",
                                        "ttN text7BOX_concat",
                                        "ttN textDebug",
                                        "ttN xyPlot"
                                    ],
                                    {
                                        "author": "tinyterra",
                                        "description": "This extension offers various pipe nodes, fullscreen image viewer based on node history, dynamic widgets, interface customization, and more.",
                                        "nickname": "ttNodes",
                                        "nodename_pattern": "^ttN ",
                                        "title": "tinyterraNodes",
                                        "title_aux": "tinyterraNodes"
                                    }
                                ],
                                "https://github.com/TripleHeadedMonkey/ComfyUI_MileHighStyler": [
                                    [
                                        "menus"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_MileHighStyler"
                                    }
                                ],
                                "https://github.com/Tropfchen/ComfyUI-Embedding_Picker": [
                                    [
                                        "EmbeddingPicker"
                                    ],
                                    {
                                        "title_aux": "Embedding Picker"
                                    }
                                ],
                                "https://github.com/Tropfchen/ComfyUI-yaResolutionSelector": [
                                    [
                                        "YARS",
                                        "YARSAdv"
                                    ],
                                    {
                                        "title_aux": "YARS: Yet Another Resolution Selector"
                                    }
                                ],
                                "https://github.com/Trung0246/ComfyUI-0246": [
                                    [
                                        "0246.Beautify",
                                        "0246.BoxRange",
                                        "0246.CastReroute",
                                        "0246.Cloud",
                                        "0246.Convert",
                                        "0246.Count",
                                        "0246.Highway",
                                        "0246.HighwayBatch",
                                        "0246.Hold",
                                        "0246.Hub",
                                        "0246.Junction",
                                        "0246.JunctionBatch",
                                        "0246.Loop",
                                        "0246.Merge",
                                        "0246.Meta",
                                        "0246.Pick",
                                        "0246.RandomInt",
                                        "0246.Script",
                                        "0246.ScriptNode",
                                        "0246.ScriptPile",
                                        "0246.ScriptRule",
                                        "0246.Stringify",
                                        "0246.Switch"
                                    ],
                                    {
                                        "author": "Trung0246",
                                        "description": "Random nodes for ComfyUI I made to solve my struggle with ComfyUI (ex: pipe, process). Have varying quality.",
                                        "nickname": "ComfyUI-0246",
                                        "title": "ComfyUI-0246",
                                        "title_aux": "ComfyUI-0246"
                                    }
                                ],
                                "https://github.com/Ttl/ComfyUi_NNLatentUpscale": [
                                    [
                                        "NNLatentUpscale"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Neural network latent upscale custom node"
                                    }
                                ],
                                "https://github.com/Umikaze-job/select_folder_path_easy": [
                                    [
                                        "SelectFolderPathEasy"
                                    ],
                                    {
                                        "title_aux": "select_folder_path_easy"
                                    }
                                ],
                                "https://github.com/WASasquatch/ASTERR": [
                                    [
                                        "ASTERR",
                                        "SaveASTERR"
                                    ],
                                    {
                                        "title_aux": "ASTERR"
                                    }
                                ],
                                "https://github.com/WASasquatch/ComfyUI_Preset_Merger": [
                                    [
                                        "Preset_Model_Merge"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Preset Merger"
                                    }
                                ],
                                "https://github.com/WASasquatch/FreeU_Advanced": [
                                    [
                                        "FreeU (Advanced)",
                                        "FreeU_V2 (Advanced)"
                                    ],
                                    {
                                        "title_aux": "FreeU_Advanced"
                                    }
                                ],
                                "https://github.com/WASasquatch/PPF_Noise_ComfyUI": [
                                    [
                                        "Blend Latents (PPF Noise)",
                                        "Cross-Hatch Power Fractal (PPF Noise)",
                                        "Images as Latents (PPF Noise)",
                                        "Perlin Power Fractal Latent (PPF Noise)"
                                    ],
                                    {
                                        "title_aux": "PPF_Noise_ComfyUI"
                                    }
                                ],
                                "https://github.com/WASasquatch/PowerNoiseSuite": [
                                    [
                                        "Blend Latents (PPF Noise)",
                                        "Cross-Hatch Power Fractal (PPF Noise)",
                                        "Cross-Hatch Power Fractal Settings (PPF Noise)",
                                        "Images as Latents (PPF Noise)",
                                        "Latent Adjustment (PPF Noise)",
                                        "Latents to CPU (PPF Noise)",
                                        "Linear Cross-Hatch Power Fractal (PPF Noise)",
                                        "Perlin Power Fractal Latent (PPF Noise)",
                                        "Perlin Power Fractal Settings (PPF Noise)",
                                        "Power KSampler Advanced (PPF Noise)",
                                        "Power-Law Noise (PPF Noise)"
                                    ],
                                    {
                                        "title_aux": "Power Noise Suite for ComfyUI"
                                    }
                                ],
                                "https://github.com/WASasquatch/WAS_Extras": [
                                    [
                                        "BLVAEEncode",
                                        "CLIPTextEncodeList",
                                        "CLIPTextEncodeSequence2",
                                        "ConditioningBlend",
                                        "DebugInput",
                                        "KSamplerSeq",
                                        "KSamplerSeq2",
                                        "VAEEncodeForInpaint (WAS)",
                                        "VividSharpen"
                                    ],
                                    {
                                        "title_aux": "WAS_Extras"
                                    }
                                ],
                                "https://github.com/WASasquatch/was-node-suite-comfyui": [
                                    [
                                        "BLIP Analyze Image",
                                        "BLIP Model Loader",
                                        "Blend Latents",
                                        "Boolean To Text",
                                        "Bounded Image Blend",
                                        "Bounded Image Blend with Mask",
                                        "Bounded Image Crop",
                                        "Bounded Image Crop with Mask",
                                        "Bus Node",
                                        "CLIP Input Switch",
                                        "CLIP Vision Input Switch",
                                        "CLIPSeg Batch Masking",
                                        "CLIPSeg Masking",
                                        "CLIPSeg Model Loader",
                                        "CLIPTextEncode (BlenderNeko Advanced + NSP)",
                                        "CLIPTextEncode (NSP)",
                                        "Cache Node",
                                        "Checkpoint Loader",
                                        "Checkpoint Loader (Simple)",
                                        "Conditioning Input Switch",
                                        "Constant Number",
                                        "Control Net Model Input Switch",
                                        "Convert Masks to Images",
                                        "Create Grid Image",
                                        "Create Grid Image from Batch",
                                        "Create Morph Image",
                                        "Create Morph Image from Path",
                                        "Create Video from Path",
                                        "Debug Number to Console",
                                        "Dictionary to Console",
                                        "Diffusers Hub Model Down-Loader",
                                        "Diffusers Model Loader",
                                        "Export API",
                                        "Image Analyze",
                                        "Image Aspect Ratio",
                                        "Image Batch",
                                        "Image Blank",
                                        "Image Blend",
                                        "Image Blend by Mask",
                                        "Image Blending Mode",
                                        "Image Bloom Filter",
                                        "Image Bounds",
                                        "Image Bounds to Console",
                                        "Image Canny Filter",
                                        "Image Chromatic Aberration",
                                        "Image Color Palette",
                                        "Image Crop Face",
                                        "Image Crop Location",
                                        "Image Crop Square Location",
                                        "Image Displacement Warp",
                                        "Image Dragan Photography Filter",
                                        "Image Edge Detection Filter",
                                        "Image Film Grain",
                                        "Image Filter Adjustments",
                                        "Image Flip",
                                        "Image Generate Gradient",
                                        "Image Gradient Map",
                                        "Image High Pass Filter",
                                        "Image History Loader",
                                        "Image Input Switch",
                                        "Image Levels Adjustment",
                                        "Image Load",
                                        "Image Lucy Sharpen",
                                        "Image Median Filter",
                                        "Image Mix RGB Channels",
                                        "Image Monitor Effects Filter",
                                        "Image Nova Filter",
                                        "Image Padding",
                                        "Image Paste Crop",
                                        "Image Paste Crop by Location",
                                        "Image Paste Face",
                                        "Image Perlin Noise",
                                        "Image Perlin Power Fractal",
                                        "Image Pixelate",
                                        "Image Power Noise",
                                        "Image Rembg (Remove Background)",
                                        "Image Remove Background (Alpha)",
                                        "Image Remove Color",
                                        "Image Resize",
                                        "Image Rotate",
                                        "Image Rotate Hue",
                                        "Image SSAO (Ambient Occlusion)",
                                        "Image SSDO (Direct Occlusion)",
                                        "Image Save",
                                        "Image Seamless Texture",
                                        "Image Select Channel",
                                        "Image Select Color",
                                        "Image Shadows and Highlights",
                                        "Image Size to Number",
                                        "Image Stitch",
                                        "Image Style Filter",
                                        "Image Threshold",
                                        "Image Tiled",
                                        "Image Transpose",
                                        "Image Voronoi Noise Filter",
                                        "Image fDOF Filter",
                                        "Image to Latent Mask",
                                        "Image to Noise",
                                        "Image to Seed",
                                        "Images to Linear",
                                        "Images to RGB",
                                        "Inset Image Bounds",
                                        "Integer place counter",
                                        "KSampler (WAS)",
                                        "KSampler Cycle",
                                        "Latent Batch",
                                        "Latent Input Switch",
                                        "Latent Noise Injection",
                                        "Latent Size to Number",
                                        "Latent Upscale by Factor (WAS)",
                                        "Load Cache",
                                        "Load Image Batch",
                                        "Load Lora",
                                        "Load Text File",
                                        "Logic Boolean",
                                        "Logic Boolean Primitive",
                                        "Logic Comparison AND",
                                        "Logic Comparison OR",
                                        "Logic Comparison XOR",
                                        "Logic NOT",
                                        "Lora Input Switch",
                                        "Lora Loader",
                                        "Mask Arbitrary Region",
                                        "Mask Batch",
                                        "Mask Batch to Mask",
                                        "Mask Ceiling Region",
                                        "Mask Crop Dominant Region",
                                        "Mask Crop Minority Region",
                                        "Mask Crop Region",
                                        "Mask Dilate Region",
                                        "Mask Dominant Region",
                                        "Mask Erode Region",
                                        "Mask Fill Holes",
                                        "Mask Floor Region",
                                        "Mask Gaussian Region",
                                        "Mask Invert",
                                        "Mask Minority Region",
                                        "Mask Paste Region",
                                        "Mask Smooth Region",
                                        "Mask Threshold Region",
                                        "Masks Add",
                                        "Masks Combine Batch",
                                        "Masks Combine Regions",
                                        "Masks Subtract",
                                        "MiDaS Depth Approximation",
                                        "MiDaS Mask Image",
                                        "MiDaS Model Loader",
                                        "Model Input Switch",
                                        "Number Counter",
                                        "Number Input Condition",
                                        "Number Input Switch",
                                        "Number Multiple Of",
                                        "Number Operation",
                                        "Number PI",
                                        "Number to Float",
                                        "Number to Int",
                                        "Number to Seed",
                                        "Number to String",
                                        "Number to Text",
                                        "Prompt Multiple Styles Selector",
                                        "Prompt Styles Selector",
                                        "Random Number",
                                        "SAM Image Mask",
                                        "SAM Model Loader",
                                        "SAM Parameters",
                                        "SAM Parameters Combine",
                                        "Samples Passthrough (Stat System)",
                                        "Save Text File",
                                        "Seed",
                                        "String to Text",
                                        "Tensor Batch to Image",
                                        "Text Add Token by Input",
                                        "Text Add Tokens",
                                        "Text Compare",
                                        "Text Concatenate",
                                        "Text Contains",
                                        "Text Dictionary Convert",
                                        "Text Dictionary Get",
                                        "Text Dictionary Keys",
                                        "Text Dictionary New",
                                        "Text Dictionary To Text",
                                        "Text Dictionary Update",
                                        "Text File History Loader",
                                        "Text Find and Replace",
                                        "Text Find and Replace Input",
                                        "Text Find and Replace by Dictionary",
                                        "Text Input Switch",
                                        "Text List",
                                        "Text List Concatenate",
                                        "Text List to Text",
                                        "Text Load Line From File",
                                        "Text Multiline",
                                        "Text Parse A1111 Embeddings",
                                        "Text Parse Noodle Soup Prompts",
                                        "Text Parse Tokens",
                                        "Text Random Line",
                                        "Text Random Prompt",
                                        "Text Shuffle",
                                        "Text String",
                                        "Text String Truncate",
                                        "Text to Conditioning",
                                        "Text to Console",
                                        "Text to Number",
                                        "Text to String",
                                        "True Random.org Number Generator",
                                        "Upscale Model Loader",
                                        "Upscale Model Switch",
                                        "VAE Input Switch",
                                        "Video Dump Frames",
                                        "Write to GIF",
                                        "Write to Video",
                                        "unCLIP Checkpoint Loader"
                                    ],
                                    {
                                        "title_aux": "WAS Node Suite"
                                    }
                                ],
                                "https://github.com/WebDev9000/WebDev9000-Nodes": [
                                    [
                                        "IgnoreBraces",
                                        "SettingsSwitch"
                                    ],
                                    {
                                        "title_aux": "WebDev9000-Nodes"
                                    }
                                ],
                                "https://github.com/YMC-GitHub/ymc-node-suite-comfyui": [
                                    [
                                        "canvas-util-cal-size",
                                        "conditioning-util-input-switch",
                                        "cutoff-region-util",
                                        "hks-util-cal-denoise-step",
                                        "img-util-get-image-size",
                                        "img-util-switch-input-image",
                                        "io-image-save",
                                        "io-text-save",
                                        "io-util-file-list-get",
                                        "io-util-file-list-get-text",
                                        "number-util-random-num",
                                        "pipe-util-to-basic-pipe",
                                        "region-util-get-by-center-and-size",
                                        "region-util-get-by-lt",
                                        "region-util-get-crop-location-from-center-size-text",
                                        "region-util-get-pad-out-location-by-size",
                                        "text-preset-colors",
                                        "text-util-join-text",
                                        "text-util-loop-text",
                                        "text-util-path-list",
                                        "text-util-prompt-add-prompt",
                                        "text-util-prompt-adv-dup",
                                        "text-util-prompt-adv-search",
                                        "text-util-prompt-del",
                                        "text-util-prompt-dup",
                                        "text-util-prompt-join",
                                        "text-util-prompt-search",
                                        "text-util-prompt-shuffle",
                                        "text-util-prompt-std",
                                        "text-util-prompt-unweight",
                                        "text-util-random-text",
                                        "text-util-search-text",
                                        "text-util-show-text",
                                        "text-util-switch-text",
                                        "xyz-util-txt-to-int"
                                    ],
                                    {
                                        "title_aux": "ymc-node-suite-comfyui"
                                    }
                                ],
                                "https://github.com/YOUR-WORST-TACO/ComfyUI-TacoNodes": [
                                    [
                                        "Example",
                                        "TacoAnimatedLoader",
                                        "TacoGifMaker",
                                        "TacoImg2ImgAnimatedLoader",
                                        "TacoImg2ImgAnimatedProcessor",
                                        "TacoLatent"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TacoNodes"
                                    }
                                ],
                                "https://github.com/YinBailiang/MergeBlockWeighted_fo_ComfyUI": [
                                    [
                                        "MergeBlockWeighted"
                                    ],
                                    {
                                        "title_aux": "MergeBlockWeighted_fo_ComfyUI"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-ArtGallery": [
                                    [
                                        "ArtGallery_Zho",
                                        "ArtistsImage_Zho",
                                        "CamerasImage_Zho",
                                        "FilmsImage_Zho",
                                        "MovementsImage_Zho",
                                        "StylesImage_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-ArtGallery"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-Gemini": [
                                    [
                                        "ConcatText_Zho",
                                        "DisplayText_Zho",
                                        "Gemini_API_Chat_Zho",
                                        "Gemini_API_S_Chat_Zho",
                                        "Gemini_API_S_Vsion_ImgURL_Zho",
                                        "Gemini_API_S_Zho",
                                        "Gemini_API_Vsion_ImgURL_Zho",
                                        "Gemini_API_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Gemini"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-InstantID": [
                                    [
                                        "IDBaseModelLoader_fromhub",
                                        "IDBaseModelLoader_local",
                                        "IDControlNetLoader",
                                        "IDGenerationNode",
                                        "ID_Prompt_Styler",
                                        "InsightFaceLoader_Zho",
                                        "Ipadapter_instantidLoader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-InstantID"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-PhotoMaker-ZHO": [
                                    [
                                        "BaseModel_Loader_fromhub",
                                        "BaseModel_Loader_local",
                                        "LoRALoader",
                                        "NEW_PhotoMaker_Generation",
                                        "PhotoMakerAdapter_Loader_fromhub",
                                        "PhotoMakerAdapter_Loader_local",
                                        "PhotoMaker_Generation",
                                        "Prompt_Styler",
                                        "Ref_Image_Preprocessing"
                                    ],
                                    {
                                        "title_aux": "ComfyUI PhotoMaker (ZHO)"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-Q-Align": [
                                    [
                                        "QAlign_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Q-Align"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-Qwen-VL-API": [
                                    [
                                        "QWenVL_API_S_Multi_Zho",
                                        "QWenVL_API_S_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Qwen-VL-API"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-SVD-ZHO": [
                                    [
                                        "SVD_Aspect_Ratio_Zho",
                                        "SVD_Steps_MotionStrength_Seed_Zho",
                                        "SVD_Styler_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SVD-ZHO (WIP)"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-SegMoE": [
                                    [
                                        "SMoE_Generation_Zho",
                                        "SMoE_ModelLoader_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI SegMoE"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/ComfyUI-Text_Image-Composite": [
                                    [
                                        "AlphaChanelAddByMask",
                                        "ImageCompositeBy_BG_Zho",
                                        "ImageCompositeBy_Zho",
                                        "ImageComposite_BG_Zho",
                                        "ImageComposite_Zho",
                                        "RGB_Image_Zho",
                                        "Text_Image_Frame_Zho",
                                        "Text_Image_Multiline_Zho",
                                        "Text_Image_Zho"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Text_Image-Composite [WIP]"
                                    }
                                ],
                                "https://github.com/ZHO-ZHO-ZHO/comfyui-portrait-master-zh-cn": [
                                    [
                                        "PortraitMaster_\u4e2d\u6587\u7248"
                                    ],
                                    {
                                        "title_aux": "comfyui-portrait-master-zh-cn"
                                    }
                                ],
                                "https://github.com/ZaneA/ComfyUI-ImageReward": [
                                    [
                                        "ImageRewardLoader",
                                        "ImageRewardScore"
                                    ],
                                    {
                                        "title_aux": "ImageReward"
                                    }
                                ],
                                "https://github.com/Zuellni/ComfyUI-ExLlama": [
                                    [
                                        "ZuellniExLlamaGenerator",
                                        "ZuellniExLlamaLoader",
                                        "ZuellniTextPreview",
                                        "ZuellniTextReplace"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-ExLlama"
                                    }
                                ],
                                "https://github.com/Zuellni/ComfyUI-PickScore-Nodes": [
                                    [
                                        "ZuellniPickScoreImageProcessor",
                                        "ZuellniPickScoreLoader",
                                        "ZuellniPickScoreSelector",
                                        "ZuellniPickScoreTextProcessor"
                                    ],
                                    {
                                        "title_aux": "ComfyUI PickScore Nodes"
                                    }
                                ],
                                "https://github.com/a1lazydog/ComfyUI-AudioScheduler": [
                                    [
                                        "AmplitudeToGraph",
                                        "AmplitudeToNumber",
                                        "AudioToAmplitudeGraph",
                                        "AudioToFFTs",
                                        "BatchAmplitudeSchedule",
                                        "ClipAmplitude",
                                        "GateNormalizedAmplitude",
                                        "LoadAudio",
                                        "NormalizeAmplitude",
                                        "NormalizedAmplitudeDrivenString",
                                        "NormalizedAmplitudeToGraph",
                                        "NormalizedAmplitudeToNumber",
                                        "TransientAmplitudeBasic"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-AudioScheduler"
                                    }
                                ],
                                "https://github.com/abdozmantar/ComfyUI-InstaSwap": [
                                    [
                                        "InstaSwapFaceSwap",
                                        "InstaSwapLoadFaceModel",
                                        "InstaSwapSaveFaceModel"
                                    ],
                                    {
                                        "title_aux": "InstaSwap Face Swap Node for ComfyUI"
                                    }
                                ],
                                "https://github.com/abyz22/image_control": [
                                    [
                                        "abyz22_Convertpipe",
                                        "abyz22_Editpipe",
                                        "abyz22_FirstNonNull",
                                        "abyz22_FromBasicPipe_v2",
                                        "abyz22_Frompipe",
                                        "abyz22_ImpactWildcardEncode",
                                        "abyz22_ImpactWildcardEncode_GetPrompt",
                                        "abyz22_Ksampler",
                                        "abyz22_Padding Image",
                                        "abyz22_SaveImage",
                                        "abyz22_SetQueue",
                                        "abyz22_ToBasicPipe",
                                        "abyz22_Topipe",
                                        "abyz22_blend_onecolor",
                                        "abyz22_blendimages",
                                        "abyz22_bypass",
                                        "abyz22_drawmask",
                                        "abyz22_lamaInpaint",
                                        "abyz22_lamaPreprocessor",
                                        "abyz22_makecircles",
                                        "abyz22_setimageinfo",
                                        "abyz22_smallhead"
                                    ],
                                    {
                                        "title_aux": "image_control"
                                    }
                                ],
                                "https://github.com/adbrasi/ComfyUI-TrashNodes-DownloadHuggingface": [
                                    [
                                        "DownloadLinkChecker",
                                        "ShowFileNames"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TrashNodes-DownloadHuggingface"
                                    }
                                ],
                                "https://github.com/adieyal/comfyui-dynamicprompts": [
                                    [
                                        "DPCombinatorialGenerator",
                                        "DPFeelingLucky",
                                        "DPJinja",
                                        "DPMagicPrompt",
                                        "DPOutput",
                                        "DPRandomGenerator"
                                    ],
                                    {
                                        "title_aux": "DynamicPrompts Custom Nodes"
                                    }
                                ],
                                "https://github.com/adriflex/ComfyUI_Blender_Texdiff": [
                                    [
                                        "ViewportColor",
                                        "ViewportDepth"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Blender_Texdiff"
                                    }
                                ],
                                "https://github.com/aegis72/aegisflow_utility_nodes": [
                                    [
                                        "Add Text To Image",
                                        "Aegisflow CLIP Pass",
                                        "Aegisflow Conditioning Pass",
                                        "Aegisflow Image Pass",
                                        "Aegisflow Latent Pass",
                                        "Aegisflow Mask Pass",
                                        "Aegisflow Model Pass",
                                        "Aegisflow Pos/Neg Pass",
                                        "Aegisflow SDXL Tuple Pass",
                                        "Aegisflow VAE Pass",
                                        "Aegisflow controlnet preprocessor bus",
                                        "Apply Instagram Filter",
                                        "Brightness_Contrast_Ally",
                                        "Flatten Colors",
                                        "Gaussian Blur_Ally",
                                        "GlitchThis Effect",
                                        "Hue Rotation",
                                        "Image Flip_ally",
                                        "Placeholder Tuple",
                                        "Swap Color Mode",
                                        "aegisflow Multi_Pass",
                                        "aegisflow Multi_Pass XL",
                                        "af_pipe_in_15",
                                        "af_pipe_in_xl",
                                        "af_pipe_out_15",
                                        "af_pipe_out_xl"
                                    ],
                                    {
                                        "title_aux": "AegisFlow Utility Nodes"
                                    }
                                ],
                                "https://github.com/aegis72/comfyui-styles-all": [
                                    [
                                        "menus"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-styles-all"
                                    }
                                ],
                                "https://github.com/ai-liam/comfyui_liam_util": [
                                    [
                                        "LiamLoadImage"
                                    ],
                                    {
                                        "title_aux": "LiamUtil"
                                    }
                                ],
                                "https://github.com/aianimation55/ComfyUI-FatLabels": [
                                    [
                                        "FatLabels"
                                    ],
                                    {
                                        "title_aux": "Comfy UI FatLabels"
                                    }
                                ],
                                "https://github.com/alexopus/ComfyUI-Image-Saver": [
                                    [
                                        "Cfg Literal (Image Saver)",
                                        "Checkpoint Loader with Name (Image Saver)",
                                        "Float Literal (Image Saver)",
                                        "Image Saver",
                                        "Int Literal (Image Saver)",
                                        "Sampler Selector (Image Saver)",
                                        "Scheduler Selector (Image Saver)",
                                        "Seed Generator (Image Saver)",
                                        "String Literal (Image Saver)",
                                        "Width/Height Literal (Image Saver)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Image Saver"
                                    }
                                ],
                                "https://github.com/alpertunga-bile/prompt-generator-comfyui": [
                                    [
                                        "Prompt Generator"
                                    ],
                                    {
                                        "title_aux": "prompt-generator"
                                    }
                                ],
                                "https://github.com/alsritter/asymmetric-tiling-comfyui": [
                                    [
                                        "Asymmetric_Tiling_KSampler"
                                    ],
                                    {
                                        "title_aux": "asymmetric-tiling-comfyui"
                                    }
                                ],
                                "https://github.com/alt-key-project/comfyui-dream-project": [
                                    [
                                        "Analyze Palette [Dream]",
                                        "Beat Curve [Dream]",
                                        "Big Float Switch [Dream]",
                                        "Big Image Switch [Dream]",
                                        "Big Int Switch [Dream]",
                                        "Big Latent Switch [Dream]",
                                        "Big Palette Switch [Dream]",
                                        "Big Text Switch [Dream]",
                                        "Boolean To Float [Dream]",
                                        "Boolean To Int [Dream]",
                                        "Build Prompt [Dream]",
                                        "CSV Curve [Dream]",
                                        "CSV Generator [Dream]",
                                        "Calculation [Dream]",
                                        "Common Frame Dimensions [Dream]",
                                        "Compare Palettes [Dream]",
                                        "FFMPEG Video Encoder [Dream]",
                                        "File Count [Dream]",
                                        "Finalize Prompt [Dream]",
                                        "Float Input [Dream]",
                                        "Float to Log Entry [Dream]",
                                        "Frame Count Calculator [Dream]",
                                        "Frame Counter (Directory) [Dream]",
                                        "Frame Counter (Simple) [Dream]",
                                        "Frame Counter Info [Dream]",
                                        "Frame Counter Offset [Dream]",
                                        "Frame Counter Time Offset [Dream]",
                                        "Image Brightness Adjustment [Dream]",
                                        "Image Color Shift [Dream]",
                                        "Image Contrast Adjustment [Dream]",
                                        "Image Motion [Dream]",
                                        "Image Sequence Blend [Dream]",
                                        "Image Sequence Loader [Dream]",
                                        "Image Sequence Saver [Dream]",
                                        "Image Sequence Tweening [Dream]",
                                        "Int Input [Dream]",
                                        "Int to Log Entry [Dream]",
                                        "Laboratory [Dream]",
                                        "Linear Curve [Dream]",
                                        "Log Entry Joiner [Dream]",
                                        "Log File [Dream]",
                                        "Noise from Area Palettes [Dream]",
                                        "Noise from Palette [Dream]",
                                        "Palette Color Align [Dream]",
                                        "Palette Color Shift [Dream]",
                                        "Sample Image Area as Palette [Dream]",
                                        "Sample Image as Palette [Dream]",
                                        "Saw Curve [Dream]",
                                        "Sine Curve [Dream]",
                                        "Smooth Event Curve [Dream]",
                                        "String Input [Dream]",
                                        "String Tokenizer [Dream]",
                                        "String to Log Entry [Dream]",
                                        "Text Input [Dream]",
                                        "Triangle Curve [Dream]",
                                        "Triangle Event Curve [Dream]",
                                        "WAV Curve [Dream]"
                                    ],
                                    {
                                        "title_aux": "Dream Project Animation Nodes"
                                    }
                                ],
                                "https://github.com/alt-key-project/comfyui-dream-video-batches": [
                                    [
                                        "Blended Transition [DVB]",
                                        "Calculation [DVB]",
                                        "Create Frame Set [DVB]",
                                        "Divide [DVB]",
                                        "Fade From Black [DVB]",
                                        "Fade To Black [DVB]",
                                        "Float Input [DVB]",
                                        "For Each Done [DVB]",
                                        "For Each Filename [DVB]",
                                        "Frame Set Append [DVB]",
                                        "Frame Set Frame Dimensions Scaled [DVB]",
                                        "Frame Set Index Offset [DVB]",
                                        "Frame Set Merger [DVB]",
                                        "Frame Set Reindex [DVB]",
                                        "Frame Set Repeat [DVB]",
                                        "Frame Set Reverse [DVB]",
                                        "Frame Set Split Beginning [DVB]",
                                        "Frame Set Split End [DVB]",
                                        "Frame Set Splitter [DVB]",
                                        "Generate Inbetween Frames [DVB]",
                                        "Int Input [DVB]",
                                        "Linear Camera Pan [DVB]",
                                        "Linear Camera Roll [DVB]",
                                        "Linear Camera Zoom [DVB]",
                                        "Load Image From Path [DVB]",
                                        "Multiply [DVB]",
                                        "Sine Camera Pan [DVB]",
                                        "Sine Camera Roll [DVB]",
                                        "Sine Camera Zoom [DVB]",
                                        "String Input [DVB]",
                                        "Text Input [DVB]",
                                        "Trace Memory Allocation [DVB]",
                                        "Unwrap Frame Set [DVB]"
                                    ],
                                    {
                                        "title_aux": "Dream Video Batches"
                                    }
                                ],
                                "https://github.com/an90ray/ComfyUI_RErouter_CustomNodes": [
                                    [
                                        "CLIPTextEncode (RE)",
                                        "CLIPTextEncodeSDXL (RE)",
                                        "CLIPTextEncodeSDXLRefiner (RE)",
                                        "Int (RE)",
                                        "RErouter <=",
                                        "RErouter =>",
                                        "String (RE)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_RErouter_CustomNodes"
                                    }
                                ],
                                "https://github.com/andersxa/comfyui-PromptAttention": [
                                    [
                                        "CLIPAttentionMaskEncode"
                                    ],
                                    {
                                        "title_aux": "CLIP Directional Prompt Attention"
                                    }
                                ],
                                "https://github.com/antrobot1234/antrobots-comfyUI-nodepack": [
                                    [
                                        "composite",
                                        "crop",
                                        "paste",
                                        "preview_mask",
                                        "scale"
                                    ],
                                    {
                                        "title_aux": "antrobots ComfyUI Nodepack"
                                    }
                                ],
                                "https://github.com/asagi4/ComfyUI-CADS": [
                                    [
                                        "CADS"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-CADS"
                                    }
                                ],
                                "https://github.com/asagi4/comfyui-prompt-control": [
                                    [
                                        "EditableCLIPEncode",
                                        "FilterSchedule",
                                        "LoRAScheduler",
                                        "PCApplySettings",
                                        "PCPromptFromSchedule",
                                        "PCScheduleSettings",
                                        "PCSplitSampling",
                                        "PromptControlSimple",
                                        "PromptToSchedule",
                                        "ScheduleToCond",
                                        "ScheduleToModel"
                                    ],
                                    {
                                        "title_aux": "ComfyUI prompt control"
                                    }
                                ],
                                "https://github.com/asagi4/comfyui-utility-nodes": [
                                    [
                                        "MUForceCacheClear",
                                        "MUJinjaRender",
                                        "MUSimpleWildcard"
                                    ],
                                    {
                                        "title_aux": "asagi4/comfyui-utility-nodes"
                                    }
                                ],
                                "https://github.com/aszc-dev/ComfyUI-CoreMLSuite": [
                                    [
                                        "Core ML Converter",
                                        "Core ML LCM Converter",
                                        "Core ML LoRA Loader",
                                        "CoreMLModelAdapter",
                                        "CoreMLSampler",
                                        "CoreMLSamplerAdvanced",
                                        "CoreMLUNetLoader"
                                    ],
                                    {
                                        "title_aux": "Core ML Suite for ComfyUI"
                                    }
                                ],
                                "https://github.com/avatechai/avatar-graph-comfyui": [
                                    [
                                        "ApplyMeshTransformAsShapeKey",
                                        "B_ENUM",
                                        "B_VECTOR3",
                                        "B_VECTOR4",
                                        "Combine Points",
                                        "CreateShapeFlow",
                                        "ExportBlendshapes",
                                        "ExportGLTF",
                                        "Extract Boundary Points",
                                        "Image Alpha Mask Merge",
                                        "ImageBridge",
                                        "LoadImageFromRequest",
                                        "LoadImageWithAlpha",
                                        "LoadValueFromRequest",
                                        "SAM MultiLayer",
                                        "Save Image With Workflow"
                                    ],
                                    {
                                        "author": "Avatech Limited",
                                        "description": "Include nodes for sam + bpy operation, that allows workflow creations for generative 2d character rig.",
                                        "nickname": "Avatar Graph",
                                        "title": "Avatar Graph",
                                        "title_aux": "avatar-graph-comfyui"
                                    }
                                ],
                                "https://github.com/azure-dragon-ai/ComfyUI-ClipScore-Nodes": [
                                    [
                                        "HaojihuiClipScoreFakeImageProcessor",
                                        "HaojihuiClipScoreImageProcessor",
                                        "HaojihuiClipScoreImageScore",
                                        "HaojihuiClipScoreLoader",
                                        "HaojihuiClipScoreRealImageProcessor",
                                        "HaojihuiClipScoreTextProcessor"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-ClipScore-Nodes"
                                    }
                                ],
                                "https://github.com/badjeff/comfyui_lora_tag_loader": [
                                    [
                                        "LoraTagLoader"
                                    ],
                                    {
                                        "title_aux": "LoRA Tag Loader for ComfyUI"
                                    }
                                ],
                                "https://github.com/banodoco/steerable-motion": [
                                    [
                                        "BatchCreativeInterpolation"
                                    ],
                                    {
                                        "title_aux": "Steerable Motion"
                                    }
                                ],
                                "https://github.com/bash-j/mikey_nodes": [
                                    [
                                        "AddMetaData",
                                        "Batch Crop Image",
                                        "Batch Crop Resize Inplace",
                                        "Batch Load Images",
                                        "Batch Resize Image for SDXL",
                                        "Checkpoint Loader Simple Mikey",
                                        "CinematicLook",
                                        "Empty Latent Ratio Custom SDXL",
                                        "Empty Latent Ratio Select SDXL",
                                        "EvalFloats",
                                        "FaceFixerOpenCV",
                                        "FileNamePrefix",
                                        "FileNamePrefixDateDirFirst",
                                        "Float to String",
                                        "HaldCLUT",
                                        "Image Caption",
                                        "ImageBorder",
                                        "ImageOverlay",
                                        "ImagePaste",
                                        "Int to String",
                                        "LMStudioPrompt",
                                        "Load Image Based on Number",
                                        "LoraSyntaxProcessor",
                                        "Mikey Sampler",
                                        "Mikey Sampler Base Only",
                                        "Mikey Sampler Base Only Advanced",
                                        "Mikey Sampler Tiled",
                                        "Mikey Sampler Tiled Base Only",
                                        "MikeySamplerTiledAdvanced",
                                        "MikeySamplerTiledAdvancedBaseOnly",
                                        "OobaPrompt",
                                        "PresetRatioSelector",
                                        "Prompt With SDXL",
                                        "Prompt With Style",
                                        "Prompt With Style V2",
                                        "Prompt With Style V3",
                                        "Range Float",
                                        "Range Integer",
                                        "Ratio Advanced",
                                        "Resize Image for SDXL",
                                        "Save Image If True",
                                        "Save Image With Prompt Data",
                                        "Save Images Mikey",
                                        "Save Images No Display",
                                        "SaveMetaData",
                                        "SearchAndReplace",
                                        "Seed String",
                                        "Style Conditioner",
                                        "Style Conditioner Base Only",
                                        "Text2InputOr3rdOption",
                                        "TextCombinations",
                                        "TextCombinations3",
                                        "TextConcat",
                                        "TextPreserve",
                                        "Upscale Tile Calculator",
                                        "Wildcard Processor",
                                        "WildcardAndLoraSyntaxProcessor",
                                        "WildcardOobaPrompt"
                                    ],
                                    {
                                        "title_aux": "Mikey Nodes"
                                    }
                                ],
                                "https://github.com/bedovyy/ComfyUI_NAIDGenerator": [
                                    [
                                        "GenerateNAID",
                                        "Img2ImgOptionNAID",
                                        "InpaintingOptionNAID",
                                        "MaskImageToNAID",
                                        "ModelOptionNAID",
                                        "PromptToNAID"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_NAIDGenerator"
                                    }
                                ],
                                "https://github.com/biegert/ComfyUI-CLIPSeg/raw/main/custom_nodes/clipseg.py": [
                                    [
                                        "CLIPSeg",
                                        "CombineSegMasks"
                                    ],
                                    {
                                        "title_aux": "CLIPSeg"
                                    }
                                ],
                                "https://github.com/bilal-arikan/ComfyUI_TextAssets": [
                                    [
                                        "LoadTextAsset"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_TextAssets"
                                    }
                                ],
                                "https://github.com/blepping/ComfyUI-bleh": [
                                    [
                                        "BlehDeepShrink",
                                        "BlehDiscardPenultimateSigma",
                                        "BlehHyperTile",
                                        "BlehInsaneChainSampler",
                                        "BlehModelPatchConditional"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-bleh"
                                    }
                                ],
                                "https://github.com/bmad4ever/comfyui_ab_samplercustom": [
                                    [
                                        "AB SamplerCustom (experimental)"
                                    ],
                                    {
                                        "title_aux": "comfyui_ab_sampler"
                                    }
                                ],
                                "https://github.com/bmad4ever/comfyui_bmad_nodes": [
                                    [
                                        "AdaptiveThresholding",
                                        "Add String To Many",
                                        "AddAlpha",
                                        "AdjustRect",
                                        "AnyToAny",
                                        "BoundingRect (contours)",
                                        "BuildColorRangeAdvanced (hsv)",
                                        "BuildColorRangeHSV (hsv)",
                                        "CLAHE",
                                        "CLIPEncodeMultiple",
                                        "CLIPEncodeMultipleAdvanced",
                                        "ChameleonMask",
                                        "CheckpointLoader (dirty)",
                                        "CheckpointLoaderSimple (dirty)",
                                        "Color (RGB)",
                                        "Color (hexadecimal)",
                                        "Color Clip",
                                        "Color Clip (advanced)",
                                        "Color Clip ADE20k",
                                        "ColorDictionary",
                                        "ColorDictionary (custom)",
                                        "Conditioning (combine multiple)",
                                        "Conditioning (combine selective)",
                                        "Conditioning Grid (cond)",
                                        "Conditioning Grid (string)",
                                        "Conditioning Grid (string) Advanced",
                                        "Contour To Mask",
                                        "Contours",
                                        "ControlNetHadamard",
                                        "ControlNetHadamard (manual)",
                                        "ConvertImg",
                                        "CopyMakeBorder",
                                        "CreateRequestMetadata",
                                        "DistanceTransform",
                                        "Draw Contour(s)",
                                        "EqualizeHistogram",
                                        "ExtendColorList",
                                        "ExtendCondList",
                                        "ExtendFloatList",
                                        "ExtendImageList",
                                        "ExtendIntList",
                                        "ExtendLatentList",
                                        "ExtendMaskList",
                                        "ExtendModelList",
                                        "ExtendStringList",
                                        "FadeMaskEdges",
                                        "Filter Contour",
                                        "FindComplementaryColor",
                                        "FindThreshold",
                                        "FlatLatentsIntoSingleGrid",
                                        "Framed Mask Grab Cut",
                                        "Framed Mask Grab Cut 2",
                                        "FromListGet1Color",
                                        "FromListGet1Cond",
                                        "FromListGet1Float",
                                        "FromListGet1Image",
                                        "FromListGet1Int",
                                        "FromListGet1Latent",
                                        "FromListGet1Mask",
                                        "FromListGet1Model",
                                        "FromListGet1String",
                                        "FromListGetColors",
                                        "FromListGetConds",
                                        "FromListGetFloats",
                                        "FromListGetImages",
                                        "FromListGetInts",
                                        "FromListGetLatents",
                                        "FromListGetMasks",
                                        "FromListGetModels",
                                        "FromListGetStrings",
                                        "Get Contour from list",
                                        "Get Models",
                                        "Get Prompt",
                                        "HypernetworkLoader (dirty)",
                                        "ImageBatchToList",
                                        "InRange (hsv)",
                                        "Inpaint",
                                        "Input/String to Int Array",
                                        "KMeansColor",
                                        "Load 64 Encoded Image",
                                        "LoraLoader (dirty)",
                                        "MaskGrid N KSamplers Advanced",
                                        "MaskOuterBlur",
                                        "Merge Latent Batch Gridwise",
                                        "MonoMerge",
                                        "MorphologicOperation",
                                        "MorphologicSkeletoning",
                                        "NaiveAutoKMeansColor",
                                        "OtsuThreshold",
                                        "RGB to HSV",
                                        "Rect Grab Cut",
                                        "Remap",
                                        "RemapBarrelDistortion",
                                        "RemapFromInsideParabolas",
                                        "RemapFromQuadrilateral (homography)",
                                        "RemapInsideParabolas",
                                        "RemapInsideParabolasAdvanced",
                                        "RemapPinch",
                                        "RemapReverseBarrelDistortion",
                                        "RemapStretch",
                                        "RemapToInnerCylinder",
                                        "RemapToOuterCylinder",
                                        "RemapToQuadrilateral",
                                        "RemapWarpPolar",
                                        "Repeat Into Grid (image)",
                                        "Repeat Into Grid (latent)",
                                        "RequestInputs",
                                        "SampleColorHSV",
                                        "Save Image (api)",
                                        "SeamlessClone",
                                        "SeamlessClone (simple)",
                                        "SetRequestStateToComplete",
                                        "String",
                                        "String to Float",
                                        "String to Integer",
                                        "ToColorList",
                                        "ToCondList",
                                        "ToFloatList",
                                        "ToImageList",
                                        "ToIntList",
                                        "ToLatentList",
                                        "ToMaskList",
                                        "ToModelList",
                                        "ToStringList",
                                        "UnGridify (image)",
                                        "VAEEncodeBatch"
                                    ],
                                    {
                                        "title_aux": "Bmad Nodes"
                                    }
                                ],
                                "https://github.com/bmad4ever/comfyui_lists_cartesian_product": [
                                    [
                                        "AnyListCartesianProduct"
                                    ],
                                    {
                                        "title_aux": "Lists Cartesian Product"
                                    }
                                ],
                                "https://github.com/bradsec/ComfyUI_ResolutionSelector": [
                                    [
                                        "ResolutionSelector"
                                    ],
                                    {
                                        "title_aux": "ResolutionSelector for ComfyUI"
                                    }
                                ],
                                "https://github.com/braintacles/braintacles-comfyui-nodes": [
                                    [
                                        "CLIPTextEncodeSDXL-Multi-IO",
                                        "CLIPTextEncodeSDXL-Pipe",
                                        "Empty Latent Image from Aspect-Ratio",
                                        "Random Find and Replace",
                                        "VAE Decode Pipe",
                                        "VAE Decode Tiled Pipe",
                                        "VAE Encode Pipe",
                                        "VAE Encode Tiled Pipe"
                                    ],
                                    {
                                        "title_aux": "braintacles-nodes"
                                    }
                                ],
                                "https://github.com/brianfitzgerald/style_aligned_comfy": [
                                    [
                                        "StyleAlignedBatchAlign",
                                        "StyleAlignedReferenceSampler",
                                        "StyleAlignedSampleReferenceLatents"
                                    ],
                                    {
                                        "title_aux": "StyleAligned for ComfyUI"
                                    }
                                ],
                                "https://github.com/bronkula/comfyui-fitsize": [
                                    [
                                        "FS: Crop Image Into Even Pieces",
                                        "FS: Fit Image And Resize",
                                        "FS: Fit Size From Image",
                                        "FS: Fit Size From Int",
                                        "FS: Image Region To Mask",
                                        "FS: Load Image And Resize To Fit",
                                        "FS: Pick Image From Batch",
                                        "FS: Pick Image From Batches",
                                        "FS: Pick Image From List"
                                    ],
                                    {
                                        "title_aux": "comfyui-fitsize"
                                    }
                                ],
                                "https://github.com/bruefire/ComfyUI-SeqImageLoader": [
                                    [
                                        "VFrame Loader With Mask Editor",
                                        "Video Loader With Mask Editor"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Sequential Image Loader"
                                    }
                                ],
                                "https://github.com/budihartono/comfyui_otonx_nodes": [
                                    [
                                        "OTX Integer Multiple Inputs 4",
                                        "OTX Integer Multiple Inputs 5",
                                        "OTX Integer Multiple Inputs 6",
                                        "OTX KSampler Feeder",
                                        "OTX Versatile Multiple Inputs 4",
                                        "OTX Versatile Multiple Inputs 5",
                                        "OTX Versatile Multiple Inputs 6"
                                    ],
                                    {
                                        "title_aux": "Otonx's Custom Nodes"
                                    }
                                ],
                                "https://github.com/bvhari/ComfyUI_ImageProcessing": [
                                    [
                                        "BilateralFilter",
                                        "Brightness",
                                        "Gamma",
                                        "Hue",
                                        "Saturation",
                                        "SigmoidCorrection",
                                        "UnsharpMask"
                                    ],
                                    {
                                        "title_aux": "ImageProcessing"
                                    }
                                ],
                                "https://github.com/bvhari/ComfyUI_LatentToRGB": [
                                    [
                                        "LatentToRGB"
                                    ],
                                    {
                                        "title_aux": "LatentToRGB"
                                    }
                                ],
                                "https://github.com/bvhari/ComfyUI_PerpWeight": [
                                    [
                                        "CLIPTextEncodePerpWeight"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_PerpWeight"
                                    }
                                ],
                                "https://github.com/catscandrive/comfyui-imagesubfolders/raw/main/loadImageWithSubfolders.py": [
                                    [
                                        "LoadImagewithSubfolders"
                                    ],
                                    {
                                        "title_aux": "Image loader with subfolders"
                                    }
                                ],
                                "https://github.com/ccvv804/ComfyUI-DiffusersStableCascade-LowVRAM": [
                                    [
                                        "DiffusersStableCascade"
                                    ],
                                    {
                                        "title_aux": "ComfyUI StableCascade using diffusers for Low VRAM"
                                    }
                                ],
                                "https://github.com/celsojr2013/comfyui_simpletools/raw/main/google_translator.py": [
                                    [
                                        "GoogleTranslator"
                                    ],
                                    {
                                        "title_aux": "ComfyUI SimpleTools Suit"
                                    }
                                ],
                                "https://github.com/ceruleandeep/ComfyUI-LLaVA-Captioner": [
                                    [
                                        "LlavaCaptioner"
                                    ],
                                    {
                                        "title_aux": "ComfyUI LLaVA Captioner"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-DragNUWA": [
                                    [
                                        "BrushMotion",
                                        "CompositeMotionBrush",
                                        "CompositeMotionBrushWithoutModel",
                                        "DragNUWA Run",
                                        "DragNUWA Run MotionBrush",
                                        "Get First Image",
                                        "Get Last Image",
                                        "InstantCameraMotionBrush",
                                        "InstantObjectMotionBrush",
                                        "Load CheckPoint DragNUWA",
                                        "Load MotionBrush From Optical Flow",
                                        "Load MotionBrush From Optical Flow Directory",
                                        "Load MotionBrush From Optical Flow Without Model",
                                        "Load MotionBrush From Tracking Points",
                                        "Load MotionBrush From Tracking Points Without Model",
                                        "Load Pose KeyPoints",
                                        "Loop",
                                        "LoopEnd_IMAGE",
                                        "LoopStart_IMAGE",
                                        "Split Tracking Points"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-DragNUWA"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-DynamiCrafter": [
                                    [
                                        "DynamiCrafter Simple",
                                        "DynamiCrafterLoader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-DynamiCrafter"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-I2VGEN-XL": [
                                    [
                                        "I2VGEN-XL Simple",
                                        "Modelscope Pipeline Loader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-I2VGEN-XL"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-LightGlue": [
                                    [
                                        "LightGlue Loader",
                                        "LightGlue Simple",
                                        "LightGlue Simple Multi"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-LightGlue"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-Moore-AnimateAnyone": [
                                    [
                                        "Moore-AnimateAnyone Denoising Unet",
                                        "Moore-AnimateAnyone Image Encoder",
                                        "Moore-AnimateAnyone Pipeline Loader",
                                        "Moore-AnimateAnyone Pose Guider",
                                        "Moore-AnimateAnyone Reference Unet",
                                        "Moore-AnimateAnyone Simple",
                                        "Moore-AnimateAnyone VAE"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Moore-AnimateAnyone"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-Motion-Vector-Extractor": [
                                    [
                                        "Motion Vector Extractor",
                                        "VideoCombineThenPath"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Motion-Vector-Extractor"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-MotionCtrl": [
                                    [
                                        "Load Motion Camera Preset",
                                        "Load Motion Traj Preset",
                                        "Load Motionctrl Checkpoint",
                                        "Motionctrl Cond",
                                        "Motionctrl Sample",
                                        "Motionctrl Sample Simple",
                                        "Select Image Indices"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-MotionCtrl"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-MotionCtrl-SVD": [
                                    [
                                        "Load Motionctrl-SVD Camera Preset",
                                        "Load Motionctrl-SVD Checkpoint",
                                        "Motionctrl-SVD Sample Simple"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-MotionCtrl-SVD"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-Panda3d": [
                                    [
                                        "Panda3dAmbientLight",
                                        "Panda3dAttachNewNode",
                                        "Panda3dBase",
                                        "Panda3dDirectionalLight",
                                        "Panda3dLoadDepthModel",
                                        "Panda3dLoadModel",
                                        "Panda3dLoadTexture",
                                        "Panda3dModelMerge",
                                        "Panda3dTest",
                                        "Panda3dTextureMerge"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Panda3d"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-Pymunk": [
                                    [
                                        "PygameRun",
                                        "PygameSurface",
                                        "PymunkDynamicBox",
                                        "PymunkDynamicCircle",
                                        "PymunkRun",
                                        "PymunkShapeMerge",
                                        "PymunkSpace",
                                        "PymunkStaticLine"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Pymunk"
                                    }
                                ],
                                "https://github.com/chaojie/ComfyUI-RAFT": [
                                    [
                                        "Load MotionBrush",
                                        "RAFT Run",
                                        "Save MotionBrush",
                                        "VizMotionBrush"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-RAFT"
                                    }
                                ],
                                "https://github.com/chflame163/ComfyUI_LayerStyle": [
                                    [
                                        "LayerColor: Brightness & Contrast",
                                        "LayerColor: ColorAdapter",
                                        "LayerColor: Exposure",
                                        "LayerColor: Gamma",
                                        "LayerColor: HSV",
                                        "LayerColor: LAB",
                                        "LayerColor: LUT Apply",
                                        "LayerColor: RGB",
                                        "LayerColor: YUV",
                                        "LayerFilter: ChannelShake",
                                        "LayerFilter: ColorMap",
                                        "LayerFilter: GaussianBlur",
                                        "LayerFilter: MotionBlur",
                                        "LayerFilter: Sharp & Soft",
                                        "LayerFilter: SkinBeauty",
                                        "LayerFilter: SoftLight",
                                        "LayerFilter: WaterColor",
                                        "LayerMask: CreateGradientMask",
                                        "LayerMask: MaskBoxDetect",
                                        "LayerMask: MaskByDifferent",
                                        "LayerMask: MaskEdgeShrink",
                                        "LayerMask: MaskEdgeUltraDetail",
                                        "LayerMask: MaskGradient",
                                        "LayerMask: MaskGrow",
                                        "LayerMask: MaskInvert",
                                        "LayerMask: MaskMotionBlur",
                                        "LayerMask: MaskPreview",
                                        "LayerMask: MaskStroke",
                                        "LayerMask: PixelSpread",
                                        "LayerMask: RemBgUltra",
                                        "LayerMask: SegmentAnythingUltra",
                                        "LayerStyle: ColorOverlay",
                                        "LayerStyle: DropShadow",
                                        "LayerStyle: GradientOverlay",
                                        "LayerStyle: InnerGlow",
                                        "LayerStyle: InnerShadow",
                                        "LayerStyle: OuterGlow",
                                        "LayerStyle: Stroke",
                                        "LayerUtility: ColorImage",
                                        "LayerUtility: ColorPicker",
                                        "LayerUtility: CropByMask",
                                        "LayerUtility: ExtendCanvas",
                                        "LayerUtility: GetColorTone",
                                        "LayerUtility: GetImageSize",
                                        "LayerUtility: GradientImage",
                                        "LayerUtility: ImageBlend",
                                        "LayerUtility: ImageBlendAdvance",
                                        "LayerUtility: ImageChannelMerge",
                                        "LayerUtility: ImageChannelSplit",
                                        "LayerUtility: ImageMaskScaleAs",
                                        "LayerUtility: ImageOpacity",
                                        "LayerUtility: ImageScaleRestore",
                                        "LayerUtility: ImageShift",
                                        "LayerUtility: LayerImageTransform",
                                        "LayerUtility: LayerMaskTransform",
                                        "LayerUtility: PrintInfo",
                                        "LayerUtility: RestoreCropBox",
                                        "LayerUtility: TextImage",
                                        "LayerUtility: XY to Percent"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Layer Style"
                                    }
                                ],
                                "https://github.com/chflame163/ComfyUI_MSSpeech_TTS": [
                                    [
                                        "Input Trigger",
                                        "MicrosoftSpeech_TTS",
                                        "Play Sound",
                                        "Play Sound (loop)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_MSSpeech_TTS"
                                    }
                                ],
                                "https://github.com/chflame163/ComfyUI_WordCloud": [
                                    [
                                        "ComfyWordCloud",
                                        "LoadTextFile",
                                        "RGB_Picker"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_WordCloud"
                                    }
                                ],
                                "https://github.com/chibiace/ComfyUI-Chibi-Nodes": [
                                    [
                                        "ConditionText",
                                        "ConditionTextMulti",
                                        "ImageAddText",
                                        "ImageSimpleResize",
                                        "ImageSizeInfo",
                                        "ImageTool",
                                        "Int2String",
                                        "LoadEmbedding",
                                        "LoadImageExtended",
                                        "Loader",
                                        "Prompts",
                                        "RandomResolutionLatent",
                                        "SaveImages",
                                        "SeedGenerator",
                                        "SimpleSampler",
                                        "TextSplit",
                                        "Textbox",
                                        "Wildcards"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Chibi-Nodes"
                                    }
                                ],
                                "https://github.com/chrisgoringe/cg-image-picker": [
                                    [
                                        "Preview Chooser",
                                        "Preview Chooser Fabric"
                                    ],
                                    {
                                        "author": "chrisgoringe",
                                        "description": "Custom nodes that preview images and pause the workflow to allow the user to select one or more to progress",
                                        "nickname": "Image Chooser",
                                        "title": "Image Chooser",
                                        "title_aux": "Image chooser"
                                    }
                                ],
                                "https://github.com/chrisgoringe/cg-noise": [
                                    [
                                        "Hijack",
                                        "KSampler Advanced with Variations",
                                        "KSampler with Variations",
                                        "UnHijack"
                                    ],
                                    {
                                        "title_aux": "Variation seeds"
                                    }
                                ],
                                "https://github.com/chrisgoringe/cg-use-everywhere": [
                                    [
                                        "Seed Everywhere"
                                    ],
                                    {
                                        "nodename_pattern": "(^(Prompts|Anything) Everywhere|Simple String)",
                                        "title_aux": "Use Everywhere (UE Nodes)"
                                    }
                                ],
                                "https://github.com/city96/ComfyUI_ColorMod": [
                                    [
                                        "ColorModEdges",
                                        "ColorModPivot",
                                        "LoadImageHighPrec",
                                        "PreviewImageHighPrec",
                                        "SaveImageHighPrec"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_ColorMod"
                                    }
                                ],
                                "https://github.com/city96/ComfyUI_DiT": [
                                    [
                                        "DiTCheckpointLoader",
                                        "DiTCheckpointLoaderSimple",
                                        "DiTLabelCombine",
                                        "DiTLabelSelect",
                                        "DiTSampler"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_DiT [WIP]"
                                    }
                                ],
                                "https://github.com/city96/ComfyUI_ExtraModels": [
                                    [
                                        "DiTCondLabelEmpty",
                                        "DiTCondLabelSelect",
                                        "DitCheckpointLoader",
                                        "ExtraVAELoader",
                                        "PixArtCheckpointLoader",
                                        "PixArtDPMSampler",
                                        "PixArtLoraLoader",
                                        "PixArtResolutionSelect",
                                        "PixArtT5TextEncode",
                                        "T5TextEncode",
                                        "T5v11Loader"
                                    ],
                                    {
                                        "title_aux": "Extra Models for ComfyUI"
                                    }
                                ],
                                "https://github.com/city96/ComfyUI_NetDist": [
                                    [
                                        "CombineImageBatch",
                                        "FetchRemote",
                                        "LoadCurrentWorkflowJSON",
                                        "LoadDiskWorkflowJSON",
                                        "LoadImageUrl",
                                        "LoadLatentNumpy",
                                        "LoadLatentUrl",
                                        "RemoteChainEnd",
                                        "RemoteChainStart",
                                        "RemoteQueueSimple",
                                        "RemoteQueueWorker",
                                        "SaveDiskWorkflowJSON",
                                        "SaveImageUrl",
                                        "SaveLatentNumpy"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_NetDist"
                                    }
                                ],
                                "https://github.com/city96/SD-Advanced-Noise": [
                                    [
                                        "LatentGaussianNoise",
                                        "MathEncode"
                                    ],
                                    {
                                        "title_aux": "SD-Advanced-Noise"
                                    }
                                ],
                                "https://github.com/city96/SD-Latent-Interposer": [
                                    [
                                        "LatentInterposer"
                                    ],
                                    {
                                        "title_aux": "Latent-Interposer"
                                    }
                                ],
                                "https://github.com/city96/SD-Latent-Upscaler": [
                                    [
                                        "LatentUpscaler"
                                    ],
                                    {
                                        "title_aux": "SD-Latent-Upscaler"
                                    }
                                ],
                                "https://github.com/civitai/comfy-nodes": [
                                    [
                                        "CivitAI_Checkpoint_Loader",
                                        "CivitAI_Lora_Loader"
                                    ],
                                    {
                                        "title_aux": "comfy-nodes"
                                    }
                                ],
                                "https://github.com/comfyanonymous/ComfyUI": [
                                    [
                                        "BasicScheduler",
                                        "CLIPLoader",
                                        "CLIPMergeSimple",
                                        "CLIPSave",
                                        "CLIPSetLastLayer",
                                        "CLIPTextEncode",
                                        "CLIPTextEncodeControlnet",
                                        "CLIPTextEncodeSDXL",
                                        "CLIPTextEncodeSDXLRefiner",
                                        "CLIPVisionEncode",
                                        "CLIPVisionLoader",
                                        "Canny",
                                        "CheckpointLoader",
                                        "CheckpointLoaderSimple",
                                        "CheckpointSave",
                                        "ConditioningAverage",
                                        "ConditioningCombine",
                                        "ConditioningConcat",
                                        "ConditioningSetArea",
                                        "ConditioningSetAreaPercentage",
                                        "ConditioningSetAreaStrength",
                                        "ConditioningSetMask",
                                        "ConditioningSetTimestepRange",
                                        "ConditioningZeroOut",
                                        "ControlNetApply",
                                        "ControlNetApplyAdvanced",
                                        "ControlNetLoader",
                                        "CropMask",
                                        "DiffControlNetLoader",
                                        "DiffusersLoader",
                                        "DualCLIPLoader",
                                        "EmptyImage",
                                        "EmptyLatentImage",
                                        "ExponentialScheduler",
                                        "FeatherMask",
                                        "FlipSigmas",
                                        "FreeU",
                                        "FreeU_V2",
                                        "GLIGENLoader",
                                        "GLIGENTextBoxApply",
                                        "GrowMask",
                                        "HyperTile",
                                        "HypernetworkLoader",
                                        "ImageBatch",
                                        "ImageBlend",
                                        "ImageBlur",
                                        "ImageColorToMask",
                                        "ImageCompositeMasked",
                                        "ImageCrop",
                                        "ImageFromBatch",
                                        "ImageInvert",
                                        "ImageOnlyCheckpointLoader",
                                        "ImageOnlyCheckpointSave",
                                        "ImagePadForOutpaint",
                                        "ImageQuantize",
                                        "ImageScale",
                                        "ImageScaleBy",
                                        "ImageScaleToTotalPixels",
                                        "ImageSharpen",
                                        "ImageToMask",
                                        "ImageUpscaleWithModel",
                                        "InpaintModelConditioning",
                                        "InvertMask",
                                        "JoinImageWithAlpha",
                                        "KSampler",
                                        "KSamplerAdvanced",
                                        "KSamplerSelect",
                                        "KarrasScheduler",
                                        "LatentAdd",
                                        "LatentBatch",
                                        "LatentBatchSeedBehavior",
                                        "LatentBlend",
                                        "LatentComposite",
                                        "LatentCompositeMasked",
                                        "LatentCrop",
                                        "LatentFlip",
                                        "LatentFromBatch",
                                        "LatentInterpolate",
                                        "LatentMultiply",
                                        "LatentRotate",
                                        "LatentSubtract",
                                        "LatentUpscale",
                                        "LatentUpscaleBy",
                                        "LoadImage",
                                        "LoadImageMask",
                                        "LoadLatent",
                                        "LoraLoader",
                                        "LoraLoaderModelOnly",
                                        "MaskComposite",
                                        "MaskToImage",
                                        "ModelMergeAdd",
                                        "ModelMergeBlocks",
                                        "ModelMergeSimple",
                                        "ModelMergeSubtract",
                                        "ModelSamplingContinuousEDM",
                                        "ModelSamplingDiscrete",
                                        "PatchModelAddDownscale",
                                        "PerpNeg",
                                        "PhotoMakerEncode",
                                        "PhotoMakerLoader",
                                        "PolyexponentialScheduler",
                                        "PorterDuffImageComposite",
                                        "PreviewImage",
                                        "RebatchImages",
                                        "RebatchLatents",
                                        "RepeatImageBatch",
                                        "RepeatLatentBatch",
                                        "RescaleCFG",
                                        "SDTurboScheduler",
                                        "SD_4XUpscale_Conditioning",
                                        "SVD_img2vid_Conditioning",
                                        "SamplerCustom",
                                        "SamplerDPMPP_2M_SDE",
                                        "SamplerDPMPP_SDE",
                                        "SaveAnimatedPNG",
                                        "SaveAnimatedWEBP",
                                        "SaveImage",
                                        "SaveLatent",
                                        "SelfAttentionGuidance",
                                        "SetLatentNoiseMask",
                                        "SolidMask",
                                        "SplitImageWithAlpha",
                                        "SplitSigmas",
                                        "StableCascade_EmptyLatentImage",
                                        "StableCascade_StageB_Conditioning",
                                        "StableZero123_Conditioning",
                                        "StableZero123_Conditioning_Batched",
                                        "StyleModelApply",
                                        "StyleModelLoader",
                                        "TomePatchModel",
                                        "UNETLoader",
                                        "UpscaleModelLoader",
                                        "VAEDecode",
                                        "VAEDecodeTiled",
                                        "VAEEncode",
                                        "VAEEncodeForInpaint",
                                        "VAEEncodeTiled",
                                        "VAELoader",
                                        "VAESave",
                                        "VPScheduler",
                                        "VideoLinearCFGGuidance",
                                        "unCLIPCheckpointLoader",
                                        "unCLIPConditioning"
                                    ],
                                    {
                                        "title_aux": "ComfyUI"
                                    }
                                ],
                                "https://github.com/comfyanonymous/ComfyUI_experiments": [
                                    [
                                        "ModelMergeBlockNumber",
                                        "ModelMergeSDXL",
                                        "ModelMergeSDXLDetailedTransformers",
                                        "ModelMergeSDXLTransformers",
                                        "ModelSamplerTonemapNoiseTest",
                                        "ReferenceOnlySimple",
                                        "RescaleClassifierFreeGuidanceTest",
                                        "TonemapNoiseWithRescaleCFG"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_experiments"
                                    }
                                ],
                                "https://github.com/concarne000/ConCarneNode": [
                                    [
                                        "BingImageGrabber",
                                        "Zephyr"
                                    ],
                                    {
                                        "title_aux": "ConCarneNode"
                                    }
                                ],
                                "https://github.com/coreyryanhanson/ComfyQR": [
                                    [
                                        "comfy-qr-by-image-size",
                                        "comfy-qr-by-module-size",
                                        "comfy-qr-by-module-split",
                                        "comfy-qr-mask_errors"
                                    ],
                                    {
                                        "title_aux": "ComfyQR"
                                    }
                                ],
                                "https://github.com/coreyryanhanson/ComfyQR-scanning-nodes": [
                                    [
                                        "comfy-qr-read",
                                        "comfy-qr-validate"
                                    ],
                                    {
                                        "title_aux": "ComfyQR-scanning-nodes"
                                    }
                                ],
                                "https://github.com/cubiq/ComfyUI_IPAdapter_plus": [
                                    [
                                        "IPAdapterApply",
                                        "IPAdapterApplyEncoded",
                                        "IPAdapterApplyFaceID",
                                        "IPAdapterBatchEmbeds",
                                        "IPAdapterEncoder",
                                        "IPAdapterLoadEmbeds",
                                        "IPAdapterModelLoader",
                                        "IPAdapterSaveEmbeds",
                                        "IPAdapterTilesMasked",
                                        "InsightFaceLoader",
                                        "PrepImageForClipVision",
                                        "PrepImageForInsightFace"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_IPAdapter_plus"
                                    }
                                ],
                                "https://github.com/cubiq/ComfyUI_InstantID": [
                                    [
                                        "ApplyInstantID",
                                        "FaceKeypointsPreprocessor",
                                        "InstantIDFaceAnalysis",
                                        "InstantIDModelLoader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI InstantID (Native Support)"
                                    }
                                ],
                                "https://github.com/cubiq/ComfyUI_SimpleMath": [
                                    [
                                        "SimpleMath",
                                        "SimpleMathDebug"
                                    ],
                                    {
                                        "title_aux": "Simple Math"
                                    }
                                ],
                                "https://github.com/cubiq/ComfyUI_essentials": [
                                    [
                                        "BatchCount+",
                                        "CLIPTextEncodeSDXL+",
                                        "ConsoleDebug+",
                                        "DebugTensorShape+",
                                        "DrawText+",
                                        "ExtractKeyframes+",
                                        "GetImageSize+",
                                        "ImageApplyLUT+",
                                        "ImageCASharpening+",
                                        "ImageCompositeFromMaskBatch+",
                                        "ImageCrop+",
                                        "ImageDesaturate+",
                                        "ImageEnhanceDifference+",
                                        "ImageExpandBatch+",
                                        "ImageFlip+",
                                        "ImageFromBatch+",
                                        "ImagePosterize+",
                                        "ImageRemoveBackground+",
                                        "ImageResize+",
                                        "ImageSeamCarving+",
                                        "KSamplerVariationsStochastic+",
                                        "KSamplerVariationsWithNoise+",
                                        "MaskBatch+",
                                        "MaskBlur+",
                                        "MaskExpandBatch+",
                                        "MaskFlip+",
                                        "MaskFromBatch+",
                                        "MaskFromColor+",
                                        "MaskPreview+",
                                        "ModelCompile+",
                                        "RemBGSession+",
                                        "SDXLEmptyLatentSizePicker+",
                                        "SimpleMath+",
                                        "TransitionMask+"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Essentials"
                                    }
                                ],
                                "https://github.com/dagthomas/comfyui_dagthomas": [
                                    [
                                        "CSL",
                                        "CSVPromptGenerator",
                                        "PromptGenerator"
                                    ],
                                    {
                                        "title_aux": "SDXL Auto Prompter"
                                    }
                                ],
                                "https://github.com/daniel-lewis-ab/ComfyUI-Llama": [
                                    [
                                        "Call LLM Advanced",
                                        "Call LLM Basic",
                                        "LLM_Create_Completion Advanced",
                                        "LLM_Detokenize",
                                        "LLM_Embed",
                                        "LLM_Eval",
                                        "LLM_Load_State",
                                        "LLM_Reset",
                                        "LLM_Sample",
                                        "LLM_Save_State",
                                        "LLM_Token_BOS",
                                        "LLM_Token_EOS",
                                        "LLM_Tokenize",
                                        "Load LLM Model Advanced",
                                        "Load LLM Model Basic"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Llama"
                                    }
                                ],
                                "https://github.com/daniel-lewis-ab/ComfyUI-TTS": [
                                    [
                                        "Load_Piper_Model",
                                        "Piper_Speak_Text"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TTS"
                                    }
                                ],
                                "https://github.com/darkpixel/darkprompts": [
                                    [
                                        "DarkCombine",
                                        "DarkFaceIndexShuffle",
                                        "DarkLoRALoader",
                                        "DarkPrompt"
                                    ],
                                    {
                                        "title_aux": "DarkPrompts"
                                    }
                                ],
                                "https://github.com/davask/ComfyUI-MarasIT-Nodes": [
                                    [
                                        "MarasitBusNode"
                                    ],
                                    {
                                        "title_aux": "MarasIT Nodes"
                                    }
                                ],
                                "https://github.com/dave-palt/comfyui_DSP_imagehelpers": [
                                    [
                                        "dsp-imagehelpers-concat"
                                    ],
                                    {
                                        "title_aux": "comfyui_DSP_imagehelpers"
                                    }
                                ],
                                "https://github.com/dawangraoming/ComfyUI_ksampler_gpu/raw/main/ksampler_gpu.py": [
                                    [
                                        "KSamplerAdvancedGPU",
                                        "KSamplerGPU"
                                    ],
                                    {
                                        "title_aux": "KSampler GPU"
                                    }
                                ],
                                "https://github.com/daxthin/DZ-FaceDetailer": [
                                    [
                                        "DZ_Face_Detailer"
                                    ],
                                    {
                                        "title_aux": "DZ-FaceDetailer"
                                    }
                                ],
                                "https://github.com/deroberon/StableZero123-comfyui": [
                                    [
                                        "SDZero ImageSplit",
                                        "Stablezero123",
                                        "Stablezero123WithDepth"
                                    ],
                                    {
                                        "title_aux": "StableZero123-comfyui"
                                    }
                                ],
                                "https://github.com/deroberon/demofusion-comfyui": [
                                    [
                                        "Batch Unsampler",
                                        "Demofusion",
                                        "Demofusion From Single File",
                                        "Iterative Mixing KSampler"
                                    ],
                                    {
                                        "title_aux": "demofusion-comfyui"
                                    }
                                ],
                                "https://github.com/dfl/comfyui-clip-with-break": [
                                    [
                                        "AdvancedCLIPTextEncodeWithBreak",
                                        "CLIPTextEncodeWithBreak"
                                    ],
                                    {
                                        "author": "dfl",
                                        "description": "CLIP text encoder that does BREAK prompting like A1111",
                                        "nickname": "CLIP with BREAK",
                                        "title": "CLIP with BREAK syntax",
                                        "title_aux": "comfyui-clip-with-break"
                                    }
                                ],
                                "https://github.com/digitaljohn/comfyui-propost": [
                                    [
                                        "ProPostApplyLUT",
                                        "ProPostDepthMapBlur",
                                        "ProPostFilmGrain",
                                        "ProPostRadialBlur",
                                        "ProPostVignette"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-ProPost"
                                    }
                                ],
                                "https://github.com/dimtoneff/ComfyUI-PixelArt-Detector": [
                                    [
                                        "PixelArtAddDitherPattern",
                                        "PixelArtDetectorConverter",
                                        "PixelArtDetectorSave",
                                        "PixelArtDetectorToImage",
                                        "PixelArtLoadPalettes"
                                    ],
                                    {
                                        "title_aux": "ComfyUI PixelArt Detector"
                                    }
                                ],
                                "https://github.com/diontimmer/ComfyUI-Vextra-Nodes": [
                                    [
                                        "Add Text To Image",
                                        "Apply Instagram Filter",
                                        "Create Solid Color",
                                        "Flatten Colors",
                                        "Generate Noise Image",
                                        "GlitchThis Effect",
                                        "Hue Rotation",
                                        "Load Picture Index",
                                        "Pixel Sort",
                                        "Play Sound At Execution",
                                        "Prettify Prompt Using distilgpt2",
                                        "Swap Color Mode"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Vextra-Nodes"
                                    }
                                ],
                                "https://github.com/djbielejeski/a-person-mask-generator": [
                                    [
                                        "APersonMaskGenerator"
                                    ],
                                    {
                                        "title_aux": "a-person-mask-generator"
                                    }
                                ],
                                "https://github.com/dmarx/ComfyUI-AudioReactive": [
                                    [
                                        "OpAbs",
                                        "OpBandpass",
                                        "OpClamp",
                                        "OpHarmonic",
                                        "OpModulo",
                                        "OpNormalize",
                                        "OpNovelty",
                                        "OpPercussive",
                                        "OpPow",
                                        "OpPow2",
                                        "OpPredominant_pulse",
                                        "OpQuantize",
                                        "OpRms",
                                        "OpSmoosh",
                                        "OpSmooth",
                                        "OpSqrt",
                                        "OpStretch",
                                        "OpSustain",
                                        "OpThreshold"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-AudioReactive"
                                    }
                                ],
                                "https://github.com/dmarx/ComfyUI-Keyframed": [
                                    [
                                        "Example",
                                        "KfAddCurveToPGroup",
                                        "KfAddCurveToPGroupx10",
                                        "KfApplyCurveToCond",
                                        "KfConditioningAdd",
                                        "KfConditioningAddx10",
                                        "KfCurveConstant",
                                        "KfCurveDraw",
                                        "KfCurveFromString",
                                        "KfCurveFromYAML",
                                        "KfCurveInverse",
                                        "KfCurveToAcnLatentKeyframe",
                                        "KfCurvesAdd",
                                        "KfCurvesAddx10",
                                        "KfCurvesDivide",
                                        "KfCurvesMultiply",
                                        "KfCurvesMultiplyx10",
                                        "KfCurvesSubtract",
                                        "KfDebug_Clip",
                                        "KfDebug_Cond",
                                        "KfDebug_Curve",
                                        "KfDebug_Float",
                                        "KfDebug_Image",
                                        "KfDebug_Int",
                                        "KfDebug_Latent",
                                        "KfDebug_Model",
                                        "KfDebug_Passthrough",
                                        "KfDebug_Segs",
                                        "KfDebug_String",
                                        "KfDebug_Vae",
                                        "KfDrawSchedule",
                                        "KfEvaluateCurveAtT",
                                        "KfGetCurveFromPGroup",
                                        "KfGetScheduleConditionAtTime",
                                        "KfGetScheduleConditionSlice",
                                        "KfKeyframedCondition",
                                        "KfKeyframedConditionWithText",
                                        "KfPGroupCurveAdd",
                                        "KfPGroupCurveMultiply",
                                        "KfPGroupDraw",
                                        "KfPGroupProd",
                                        "KfPGroupSum",
                                        "KfSetCurveLabel",
                                        "KfSetKeyframe",
                                        "KfSinusoidalAdjustAmplitude",
                                        "KfSinusoidalAdjustFrequency",
                                        "KfSinusoidalAdjustPhase",
                                        "KfSinusoidalAdjustWavelength",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx2",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx3",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx4",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx5",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx6",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx7",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx8",
                                        "KfSinusoidalEntangledZeroOneFromFrequencyx9",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx2",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx3",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx4",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx5",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx6",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx7",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx8",
                                        "KfSinusoidalEntangledZeroOneFromWavelengthx9",
                                        "KfSinusoidalGetAmplitude",
                                        "KfSinusoidalGetFrequency",
                                        "KfSinusoidalGetPhase",
                                        "KfSinusoidalGetWavelength",
                                        "KfSinusoidalWithFrequency",
                                        "KfSinusoidalWithWavelength"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Keyframed"
                                    }
                                ],
                                "https://github.com/drago87/ComfyUI_Dragos_Nodes": [
                                    [
                                        "file_padding",
                                        "image_info",
                                        "lora_loader",
                                        "vae_loader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Dragos_Nodes"
                                    }
                                ],
                                "https://github.com/drustan-hawk/primitive-types": [
                                    [
                                        "float",
                                        "int",
                                        "string",
                                        "string_multiline"
                                    ],
                                    {
                                        "title_aux": "primitive-types"
                                    }
                                ],
                                "https://github.com/ealkanat/comfyui_easy_padding": [
                                    [
                                        "comfyui-easy-padding"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Easy Padding"
                                    }
                                ],
                                "https://github.com/edenartlab/eden_comfy_pipelines": [
                                    [
                                        "CLIP_Interrogator",
                                        "Eden_Bool",
                                        "Eden_Compare",
                                        "Eden_DebugPrint",
                                        "Eden_Float",
                                        "Eden_Int",
                                        "Eden_String",
                                        "Filepicker",
                                        "IMG_blender",
                                        "IMG_padder",
                                        "IMG_scaler",
                                        "IMG_unpadder",
                                        "If ANY execute A else B",
                                        "LatentTypeConversion",
                                        "SaveImageAdvanced",
                                        "VAEDecode_to_folder"
                                    ],
                                    {
                                        "title_aux": "eden_comfy_pipelines"
                                    }
                                ],
                                "https://github.com/evanspearman/ComfyMath": [
                                    [
                                        "CM_BoolBinaryOperation",
                                        "CM_BoolToInt",
                                        "CM_BoolUnaryOperation",
                                        "CM_BreakoutVec2",
                                        "CM_BreakoutVec3",
                                        "CM_BreakoutVec4",
                                        "CM_ComposeVec2",
                                        "CM_ComposeVec3",
                                        "CM_ComposeVec4",
                                        "CM_FloatBinaryCondition",
                                        "CM_FloatBinaryOperation",
                                        "CM_FloatToInt",
                                        "CM_FloatToNumber",
                                        "CM_FloatUnaryCondition",
                                        "CM_FloatUnaryOperation",
                                        "CM_IntBinaryCondition",
                                        "CM_IntBinaryOperation",
                                        "CM_IntToBool",
                                        "CM_IntToFloat",
                                        "CM_IntToNumber",
                                        "CM_IntUnaryCondition",
                                        "CM_IntUnaryOperation",
                                        "CM_NearestSDXLResolution",
                                        "CM_NumberBinaryCondition",
                                        "CM_NumberBinaryOperation",
                                        "CM_NumberToFloat",
                                        "CM_NumberToInt",
                                        "CM_NumberUnaryCondition",
                                        "CM_NumberUnaryOperation",
                                        "CM_SDXLResolution",
                                        "CM_Vec2BinaryCondition",
                                        "CM_Vec2BinaryOperation",
                                        "CM_Vec2ScalarOperation",
                                        "CM_Vec2ToScalarBinaryOperation",
                                        "CM_Vec2ToScalarUnaryOperation",
                                        "CM_Vec2UnaryCondition",
                                        "CM_Vec2UnaryOperation",
                                        "CM_Vec3BinaryCondition",
                                        "CM_Vec3BinaryOperation",
                                        "CM_Vec3ScalarOperation",
                                        "CM_Vec3ToScalarBinaryOperation",
                                        "CM_Vec3ToScalarUnaryOperation",
                                        "CM_Vec3UnaryCondition",
                                        "CM_Vec3UnaryOperation",
                                        "CM_Vec4BinaryCondition",
                                        "CM_Vec4BinaryOperation",
                                        "CM_Vec4ScalarOperation",
                                        "CM_Vec4ToScalarBinaryOperation",
                                        "CM_Vec4ToScalarUnaryOperation",
                                        "CM_Vec4UnaryCondition",
                                        "CM_Vec4UnaryOperation"
                                    ],
                                    {
                                        "title_aux": "ComfyMath"
                                    }
                                ],
                                "https://github.com/fearnworks/ComfyUI_FearnworksNodes/raw/main/fw_nodes.py": [
                                    [
                                        "Count Files in Directory (FW)",
                                        "Count Tokens (FW)",
                                        "Token Count Ranker(FW)",
                                        "Trim To Tokens (FW)"
                                    ],
                                    {
                                        "title_aux": "Fearnworks Custom Nodes"
                                    }
                                ],
                                "https://github.com/fexli/fexli-util-node-comfyui": [
                                    [
                                        "FEBCPrompt",
                                        "FEBatchGenStringBCDocker",
                                        "FEColor2Image",
                                        "FEColorOut",
                                        "FEDataInsertor",
                                        "FEDataPacker",
                                        "FEDataUnpacker",
                                        "FEDeepClone",
                                        "FEDictPacker",
                                        "FEDictUnpacker",
                                        "FEEncLoraLoader",
                                        "FEExtraInfoAdd",
                                        "FEGenStringBCDocker",
                                        "FEGenStringGPT",
                                        "FEImageNoiseGenerate",
                                        "FEImagePadForOutpaint",
                                        "FEImagePadForOutpaintByImage",
                                        "FEOperatorIf",
                                        "FEPythonStrOp",
                                        "FERandomLoraSelect",
                                        "FERandomPrompt",
                                        "FERandomizedColor2Image",
                                        "FERandomizedColorOut",
                                        "FERerouteWithName",
                                        "FESaveEncryptImage",
                                        "FETextCombine",
                                        "FETextInput"
                                    ],
                                    {
                                        "title_aux": "fexli-util-node-comfyui"
                                    }
                                ],
                                "https://github.com/filipemeneses/comfy_pixelization": [
                                    [
                                        "Pixelization"
                                    ],
                                    {
                                        "title_aux": "Pixelization"
                                    }
                                ],
                                "https://github.com/filliptm/ComfyUI_Fill-Nodes": [
                                    [
                                        "FL_ImageCaptionSaver",
                                        "FL_ImageRandomizer"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Fill-Nodes"
                                    }
                                ],
                                "https://github.com/fitCorder/fcSuite/raw/main/fcSuite.py": [
                                    [
                                        "fcFloat",
                                        "fcFloatMatic",
                                        "fcHex",
                                        "fcInteger"
                                    ],
                                    {
                                        "title_aux": "fcSuite"
                                    }
                                ],
                                "https://github.com/florestefano1975/comfyui-portrait-master": [
                                    [
                                        "PortraitMaster"
                                    ],
                                    {
                                        "title_aux": "comfyui-portrait-master"
                                    }
                                ],
                                "https://github.com/florestefano1975/comfyui-prompt-composer": [
                                    [
                                        "PromptComposerCustomLists",
                                        "PromptComposerEffect",
                                        "PromptComposerGrouping",
                                        "PromptComposerMerge",
                                        "PromptComposerStyler",
                                        "PromptComposerTextSingle",
                                        "promptComposerTextMultiple"
                                    ],
                                    {
                                        "title_aux": "comfyui-prompt-composer"
                                    }
                                ],
                                "https://github.com/flowtyone/ComfyUI-Flowty-LDSR": [
                                    [
                                        "LDSRModelLoader",
                                        "LDSRUpscale",
                                        "LDSRUpscaler"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Flowty-LDSR"
                                    }
                                ],
                                "https://github.com/flyingshutter/As_ComfyUI_CustomNodes": [
                                    [
                                        "BatchIndex_AS",
                                        "CropImage_AS",
                                        "ImageMixMasked_As",
                                        "ImageToMask_AS",
                                        "Increment_AS",
                                        "Int2Any_AS",
                                        "LatentAdd_AS",
                                        "LatentMixMasked_As",
                                        "LatentMix_AS",
                                        "LatentToImages_AS",
                                        "LoadLatent_AS",
                                        "MapRange_AS",
                                        "MaskToImage_AS",
                                        "Math_AS",
                                        "NoiseImage_AS",
                                        "Number2Float_AS",
                                        "Number2Int_AS",
                                        "Number_AS",
                                        "SaveLatent_AS",
                                        "TextToImage_AS",
                                        "TextWildcardList_AS"
                                    ],
                                    {
                                        "title_aux": "As_ComfyUI_CustomNodes"
                                    }
                                ],
                                "https://github.com/foxtrot-roger/comfyui-rf-nodes": [
                                    [
                                        "LogBool",
                                        "LogFloat",
                                        "LogInt",
                                        "LogNumber",
                                        "LogString",
                                        "LogVec2",
                                        "LogVec3",
                                        "RF_AtIndexString",
                                        "RF_BoolToString",
                                        "RF_FloatToString",
                                        "RF_IntToString",
                                        "RF_JsonStyleLoader",
                                        "RF_MergeLines",
                                        "RF_NumberToString",
                                        "RF_OptionsString",
                                        "RF_RangeFloat",
                                        "RF_RangeInt",
                                        "RF_RangeNumber",
                                        "RF_SavePromptInfo",
                                        "RF_SplitLines",
                                        "RF_TextConcatenate",
                                        "RF_TextInput",
                                        "RF_TextReplace",
                                        "RF_Timestamp",
                                        "RF_ToString",
                                        "RF_Vec2ToString",
                                        "RF_Vec3ToString",
                                        "TextLine"
                                    ],
                                    {
                                        "title_aux": "RF Nodes"
                                    }
                                ],
                                "https://github.com/gemell1/ComfyUI_GMIC": [
                                    [
                                        "GmicCliWrapper"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_GMIC"
                                    }
                                ],
                                "https://github.com/giriss/comfy-image-saver": [
                                    [
                                        "Cfg Literal",
                                        "Checkpoint Selector",
                                        "Int Literal",
                                        "Sampler Selector",
                                        "Save Image w/Metadata",
                                        "Scheduler Selector",
                                        "Seed Generator",
                                        "String Literal",
                                        "Width/Height Literal"
                                    ],
                                    {
                                        "title_aux": "Save Image with Generation Metadata"
                                    }
                                ],
                                "https://github.com/glibsonoran/Plush-for-ComfyUI": [
                                    [
                                        "DalleImage",
                                        "Enhancer",
                                        "ImgTextSwitch",
                                        "Plush-Exif Wrangler",
                                        "mulTextSwitch"
                                    ],
                                    {
                                        "title_aux": "Plush-for-ComfyUI"
                                    }
                                ],
                                "https://github.com/glifxyz/ComfyUI-GlifNodes": [
                                    [
                                        "GlifConsistencyDecoder",
                                        "GlifPatchConsistencyDecoderTiled",
                                        "SDXLAspectRatio"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-GlifNodes"
                                    }
                                ],
                                "https://github.com/glowcone/comfyui-base64-to-image": [
                                    [
                                        "LoadImageFromBase64"
                                    ],
                                    {
                                        "title_aux": "Load Image From Base64 URI"
                                    }
                                ],
                                "https://github.com/godspede/ComfyUI_Substring": [
                                    [
                                        "SubstringTheory"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Substring"
                                    }
                                ],
                                "https://github.com/gokayfem/ComfyUI_VLM_nodes": [
                                    [
                                        "Joytag",
                                        "JsonToText",
                                        "KeywordExtraction",
                                        "LLMLoader",
                                        "LLMPromptGenerator",
                                        "LLMSampler",
                                        "LLava Loader Simple",
                                        "LLavaPromptGenerator",
                                        "LLavaSamplerAdvanced",
                                        "LLavaSamplerSimple",
                                        "LlavaClipLoader",
                                        "MoonDream",
                                        "PromptGenerateAPI",
                                        "SimpleText",
                                        "Suggester",
                                        "ViewText"
                                    ],
                                    {
                                        "title_aux": "VLM_nodes"
                                    }
                                ],
                                "https://github.com/guoyk93/yk-node-suite-comfyui": [
                                    [
                                        "YKImagePadForOutpaint",
                                        "YKMaskToImage"
                                    ],
                                    {
                                        "title_aux": "y.k.'s ComfyUI node suite"
                                    }
                                ],
                                "https://github.com/hhhzzyang/Comfyui_Lama": [
                                    [
                                        "LamaApply",
                                        "LamaModelLoader",
                                        "YamlConfigLoader"
                                    ],
                                    {
                                        "title_aux": "Comfyui-Lama"
                                    }
                                ],
                                "https://github.com/hinablue/ComfyUI_3dPoseEditor": [
                                    [
                                        "Hina.PoseEditor3D"
                                    ],
                                    {
                                        "title_aux": "ComfyUI 3D Pose Editor"
                                    }
                                ],
                                "https://github.com/hustille/ComfyUI_Fooocus_KSampler": [
                                    [
                                        "KSampler With Refiner (Fooocus)"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Fooocus_KSampler"
                                    }
                                ],
                                "https://github.com/hustille/ComfyUI_hus_utils": [
                                    [
                                        "3way Prompt Styler",
                                        "Batch State",
                                        "Date Time Format",
                                        "Debug Extra",
                                        "Fetch widget value",
                                        "Text Hash"
                                    ],
                                    {
                                        "title_aux": "hus' utils for ComfyUI"
                                    }
                                ],
                                "https://github.com/hylarucoder/ComfyUI-Eagle-PNGInfo": [
                                    [
                                        "EagleImageNode",
                                        "SDXLPromptStyler",
                                        "SDXLPromptStylerAdvanced",
                                        "SDXLResolutionPresets"
                                    ],
                                    {
                                        "title_aux": "Eagle PNGInfo"
                                    }
                                ],
                                "https://github.com/idrirap/ComfyUI-Lora-Auto-Trigger-Words": [
                                    [
                                        "FusionText",
                                        "LoraListNames",
                                        "LoraLoaderAdvanced",
                                        "LoraLoaderStackedAdvanced",
                                        "LoraLoaderStackedVanilla",
                                        "LoraLoaderVanilla",
                                        "LoraTagsOnly",
                                        "Randomizer",
                                        "TagsFormater",
                                        "TagsSelector",
                                        "TextInputBasic"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Lora-Auto-Trigger-Words"
                                    }
                                ],
                                "https://github.com/imb101/ComfyUI-FaceSwap": [
                                    [
                                        "FaceSwapNode"
                                    ],
                                    {
                                        "title_aux": "FaceSwap"
                                    }
                                ],
                                "https://github.com/jags111/ComfyUI_Jags_Audiotools": [
                                    [
                                        "BatchJoinAudio",
                                        "BatchToList",
                                        "BitCrushAudioFX",
                                        "BulkVariation",
                                        "ChorusAudioFX",
                                        "ClippingAudioFX",
                                        "CompressorAudioFX",
                                        "ConcatAudioList",
                                        "ConvolutionAudioFX",
                                        "CutAudio",
                                        "DelayAudioFX",
                                        "DistortionAudioFX",
                                        "DuplicateAudio",
                                        "GainAudioFX",
                                        "GenerateAudioSample",
                                        "GenerateAudioWave",
                                        "GetAudioFromFolderIndex",
                                        "GetSingle",
                                        "GetStringByIndex",
                                        "HighShelfFilter",
                                        "HighpassFilter",
                                        "ImageToSpectral",
                                        "InvertAudioFX",
                                        "JoinAudio",
                                        "LadderFilter",
                                        "LimiterAudioFX",
                                        "ListToBatch",
                                        "LoadAudioDir",
                                        "LoadAudioFile",
                                        "LoadAudioModel (DD)",
                                        "LoadVST3",
                                        "LowShelfFilter",
                                        "LowpassFilter",
                                        "MP3CompressorAudioFX",
                                        "MixAudioTensors",
                                        "NoiseGateAudioFX",
                                        "OTTAudioFX",
                                        "PeakFilter",
                                        "PhaserEffectAudioFX",
                                        "PitchShiftAudioFX",
                                        "PlotSpectrogram",
                                        "PreviewAudioFile",
                                        "PreviewAudioTensor",
                                        "ResampleAudio",
                                        "ReverbAudioFX",
                                        "ReverseAudio",
                                        "SaveAudioTensor",
                                        "SequenceVariation",
                                        "SliceAudio",
                                        "SoundPlayer",
                                        "StretchAudio",
                                        "samplerate"
                                    ],
                                    {
                                        "author": "jags111",
                                        "description": "This extension offers various audio generation tools",
                                        "nickname": "Audiotools",
                                        "title": "Jags_Audiotools",
                                        "title_aux": "ComfyUI_Jags_Audiotools"
                                    }
                                ],
                                "https://github.com/jags111/ComfyUI_Jags_VectorMagic": [
                                    [
                                        "CircularVAEDecode",
                                        "JagsCLIPSeg",
                                        "JagsClipseg",
                                        "JagsCombineMasks",
                                        "SVG",
                                        "YoloSEGdetectionNode",
                                        "YoloSegNode",
                                        "color_drop",
                                        "my unique name",
                                        "xy_Tiling_KSampler"
                                    ],
                                    {
                                        "author": "jags111",
                                        "description": "This extension offers various vector manipulation and  generation tools",
                                        "nickname": "Jags_VectorMagic",
                                        "title": "Jags_VectorMagic",
                                        "title_aux": "ComfyUI_Jags_VectorMagic"
                                    }
                                ],
                                "https://github.com/jags111/efficiency-nodes-comfyui": [
                                    [
                                        "AnimateDiff Script",
                                        "Apply ControlNet Stack",
                                        "Control Net Stacker",
                                        "Eff. Loader SDXL",
                                        "Efficient Loader",
                                        "HighRes-Fix Script",
                                        "Image Overlay",
                                        "Join XY Inputs of Same Type",
                                        "KSampler (Efficient)",
                                        "KSampler Adv. (Efficient)",
                                        "KSampler SDXL (Eff.)",
                                        "LatentUpscaler",
                                        "LoRA Stack to String converter",
                                        "LoRA Stacker",
                                        "Manual XY Entry Info",
                                        "NNLatentUpscale",
                                        "Noise Control Script",
                                        "Pack SDXL Tuple",
                                        "Tiled Upscaler Script",
                                        "Unpack SDXL Tuple",
                                        "XY Input: Add/Return Noise",
                                        "XY Input: Aesthetic Score",
                                        "XY Input: CFG Scale",
                                        "XY Input: Checkpoint",
                                        "XY Input: Clip Skip",
                                        "XY Input: Control Net",
                                        "XY Input: Control Net Plot",
                                        "XY Input: Denoise",
                                        "XY Input: LoRA",
                                        "XY Input: LoRA Plot",
                                        "XY Input: LoRA Stacks",
                                        "XY Input: Manual XY Entry",
                                        "XY Input: Prompt S/R",
                                        "XY Input: Refiner On/Off",
                                        "XY Input: Sampler/Scheduler",
                                        "XY Input: Seeds++ Batch",
                                        "XY Input: Steps",
                                        "XY Input: VAE",
                                        "XY Plot"
                                    ],
                                    {
                                        "title_aux": "Efficiency Nodes for ComfyUI Version 2.0+"
                                    }
                                ],
                                "https://github.com/jamal-alkharrat/ComfyUI_rotate_image": [
                                    [
                                        "RotateImage"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_rotate_image"
                                    }
                                ],
                                "https://github.com/jamesWalker55/comfyui-various": [
                                    [],
                                    {
                                        "nodename_pattern": "^JW",
                                        "title_aux": "Various ComfyUI Nodes by Type"
                                    }
                                ],
                                "https://github.com/jesenzhang/ComfyUI_StreamDiffusion": [
                                    [
                                        "StreamDiffusion_Loader",
                                        "StreamDiffusion_Sampler"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_StreamDiffusion"
                                    }
                                ],
                                "https://github.com/jitcoder/lora-info": [
                                    [
                                        "ImageFromURL",
                                        "LoraInfo"
                                    ],
                                    {
                                        "title_aux": "LoraInfo"
                                    }
                                ],
                                "https://github.com/jjkramhoeft/ComfyUI-Jjk-Nodes": [
                                    [
                                        "JjkConcat",
                                        "JjkShowText",
                                        "JjkText",
                                        "SDXLRecommendedImageSize"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Jjk-Nodes"
                                    }
                                ],
                                "https://github.com/jojkaart/ComfyUI-sampler-lcm-alternative": [
                                    [
                                        "LCMScheduler",
                                        "SamplerLCMAlternative",
                                        "SamplerLCMCycle"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-sampler-lcm-alternative"
                                    }
                                ],
                                "https://github.com/jordoh/ComfyUI-Deepface": [
                                    [
                                        "DeepfaceExtractFaces",
                                        "DeepfaceVerify"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Deepface"
                                    }
                                ],
                                "https://github.com/jtrue/ComfyUI-JaRue": [
                                    [
                                        "Text2Image_jru",
                                        "YouTube2Prompt_jru"
                                    ],
                                    {
                                        "nodename_pattern": "_jru$",
                                        "title_aux": "ComfyUI-JaRue"
                                    }
                                ],
                                "https://github.com/ka-puna/comfyui-yanc": [
                                    [
                                        "YANC.ConcatStrings",
                                        "YANC.FormatDatetimeString",
                                        "YANC.GetWidgetValueString",
                                        "YANC.IntegerCaster",
                                        "YANC.MultilineString",
                                        "YANC.TruncateString"
                                    ],
                                    {
                                        "title_aux": "comfyui-yanc"
                                    }
                                ],
                                "https://github.com/kadirnar/ComfyUI-Transformers": [
                                    [
                                        "DepthEstimationPipeline",
                                        "ImageClassificationPipeline",
                                        "ImageSegmentationPipeline",
                                        "ObjectDetectionPipeline"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Transformers"
                                    }
                                ],
                                "https://github.com/kenjiqq/qq-nodes-comfyui": [
                                    [
                                        "Any List",
                                        "Axis Pack",
                                        "Axis Unpack",
                                        "Image Accumulator End",
                                        "Image Accumulator Start",
                                        "Load Lines From Text File",
                                        "Slice List",
                                        "Text Splitter",
                                        "XY Grid Helper"
                                    ],
                                    {
                                        "title_aux": "qq-nodes-comfyui"
                                    }
                                ],
                                "https://github.com/kft334/Knodes": [
                                    [
                                        "Image(s) To Websocket (Base64)",
                                        "ImageOutput",
                                        "Load Image (Base64)",
                                        "Load Images (Base64)"
                                    ],
                                    {
                                        "title_aux": "Knodes"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-CCSR": [
                                    [
                                        "CCSR_Model_Select",
                                        "CCSR_Upscale"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-CCSR"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-DDColor": [
                                    [
                                        "DDColor_Colorize"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-DDColor"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-DiffusersStableCascade": [
                                    [
                                        "DiffusersStableCascade"
                                    ],
                                    {
                                        "title_aux": "ComfyUI StableCascade using diffusers"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-KJNodes": [
                                    [
                                        "AddLabel",
                                        "BatchCLIPSeg",
                                        "BatchCropFromMask",
                                        "BatchCropFromMaskAdvanced",
                                        "BatchUncrop",
                                        "BatchUncropAdvanced",
                                        "BboxToInt",
                                        "ColorMatch",
                                        "ColorToMask",
                                        "CondPassThrough",
                                        "ConditioningMultiCombine",
                                        "ConditioningSetMaskAndCombine",
                                        "ConditioningSetMaskAndCombine3",
                                        "ConditioningSetMaskAndCombine4",
                                        "ConditioningSetMaskAndCombine5",
                                        "CreateAudioMask",
                                        "CreateFadeMask",
                                        "CreateFadeMaskAdvanced",
                                        "CreateFluidMask",
                                        "CreateGradientMask",
                                        "CreateMagicMask",
                                        "CreateShapeMask",
                                        "CreateTextMask",
                                        "CreateVoronoiMask",
                                        "CrossFadeImages",
                                        "DummyLatentOut",
                                        "EmptyLatentImagePresets",
                                        "FilterZeroMasksAndCorrespondingImages",
                                        "FlipSigmasAdjusted",
                                        "FloatConstant",
                                        "GLIGENTextBoxApplyBatch",
                                        "GenerateNoise",
                                        "GetImageRangeFromBatch",
                                        "GetImagesFromBatchIndexed",
                                        "GetLatentsFromBatchIndexed",
                                        "GrowMaskWithBlur",
                                        "INTConstant",
                                        "ImageBatchRepeatInterleaving",
                                        "ImageBatchTestPattern",
                                        "ImageConcanate",
                                        "ImageGrabPIL",
                                        "ImageGridComposite2x2",
                                        "ImageGridComposite3x3",
                                        "ImageTransformByNormalizedAmplitude",
                                        "ImageUpscaleWithModelBatched",
                                        "InjectNoiseToLatent",
                                        "InsertImageBatchByIndexes",
                                        "NormalizeLatent",
                                        "NormalizedAmplitudeToMask",
                                        "OffsetMask",
                                        "OffsetMaskByNormalizedAmplitude",
                                        "ReferenceOnlySimple3",
                                        "ReplaceImagesInBatch",
                                        "ResizeMask",
                                        "ReverseImageBatch",
                                        "RoundMask",
                                        "SaveImageWithAlpha",
                                        "ScaleBatchPromptSchedule",
                                        "SomethingToString",
                                        "SoundReactive",
                                        "SplitBboxes",
                                        "StableZero123_BatchSchedule",
                                        "StringConstant",
                                        "VRAM_Debug",
                                        "WidgetToString"
                                    ],
                                    {
                                        "title_aux": "KJNodes for ComfyUI"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-Marigold": [
                                    [
                                        "ColorizeDepthmap",
                                        "MarigoldDepthEstimation",
                                        "RemapDepth",
                                        "SaveImageOpenEXR"
                                    ],
                                    {
                                        "title_aux": "Marigold depth estimation in ComfyUI"
                                    }
                                ],
                                "https://github.com/kijai/ComfyUI-SVD": [
                                    [
                                        "SVDimg2vid"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SVD"
                                    }
                                ],
                                "https://github.com/kinfolk0117/ComfyUI_GradientDeepShrink": [
                                    [
                                        "GradientPatchModelAddDownscale",
                                        "GradientPatchModelAddDownscaleAdvanced"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_GradientDeepShrink"
                                    }
                                ],
                                "https://github.com/kinfolk0117/ComfyUI_Pilgram": [
                                    [
                                        "Pilgram"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Pilgram"
                                    }
                                ],
                                "https://github.com/kinfolk0117/ComfyUI_SimpleTiles": [
                                    [
                                        "DynamicTileMerge",
                                        "DynamicTileSplit",
                                        "TileCalc",
                                        "TileMerge",
                                        "TileSplit"
                                    ],
                                    {
                                        "title_aux": "SimpleTiles"
                                    }
                                ],
                                "https://github.com/kinfolk0117/ComfyUI_TiledIPAdapter": [
                                    [
                                        "TiledIPAdapter"
                                    ],
                                    {
                                        "title_aux": "TiledIPAdapter"
                                    }
                                ],
                                "https://github.com/knuknX/ComfyUI-Image-Tools": [
                                    [
                                        "BatchImagePathLoader",
                                        "ImageBgRemoveProcessor",
                                        "ImageCheveretoUploader",
                                        "ImageStandardResizeProcessor",
                                        "JSONMessageNotifyTool",
                                        "PreviewJSONNode",
                                        "SingleImagePathLoader",
                                        "SingleImageUrlLoader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Image-Tools"
                                    }
                                ],
                                "https://github.com/kohya-ss/ControlNet-LLLite-ComfyUI": [
                                    [
                                        "LLLiteLoader"
                                    ],
                                    {
                                        "title_aux": "ControlNet-LLLite-ComfyUI"
                                    }
                                ],
                                "https://github.com/komojini/ComfyUI_SDXL_DreamBooth_LoRA_CustomNodes": [
                                    [
                                        "S3 Bucket LoRA",
                                        "S3Bucket_Load_LoRA",
                                        "XL DreamBooth LoRA",
                                        "XLDB_LoRA"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_SDXL_DreamBooth_LoRA_CustomNodes"
                                    }
                                ],
                                "https://github.com/komojini/komojini-comfyui-nodes": [
                                    [
                                        "BatchCreativeInterpolationNodeDynamicSettings",
                                        "CachedGetter",
                                        "DragNUWAImageCanvas",
                                        "FlowBuilder",
                                        "FlowBuilder (adv)",
                                        "FlowBuilder (advanced)",
                                        "FlowBuilder (advanced) Setter",
                                        "FlowBuilderSetter",
                                        "FlowBuilderSetter (adv)",
                                        "Getter",
                                        "ImageCropByRatio",
                                        "ImageCropByRatioAndResize",
                                        "ImageGetter",
                                        "ImageMerger",
                                        "ImagesCropByRatioAndResizeBatch",
                                        "KSamplerAdvancedCacheable",
                                        "KSamplerCacheable",
                                        "Setter",
                                        "UltimateVideoLoader",
                                        "UltimateVideoLoader (simple)",
                                        "YouTubeVideoLoader"
                                    ],
                                    {
                                        "title_aux": "komojini-comfyui-nodes"
                                    }
                                ],
                                "https://github.com/kwaroran/abg-comfyui": [
                                    [
                                        "Remove Image Background (abg)"
                                    ],
                                    {
                                        "title_aux": "abg-comfyui"
                                    }
                                ],
                                "https://github.com/laksjdjf/LCMSampler-ComfyUI": [
                                    [
                                        "SamplerLCM",
                                        "TAESDLoader"
                                    ],
                                    {
                                        "title_aux": "LCMSampler-ComfyUI"
                                    }
                                ],
                                "https://github.com/laksjdjf/LoRA-Merger-ComfyUI": [
                                    [
                                        "LoraLoaderFromWeight",
                                        "LoraLoaderWeightOnly",
                                        "LoraMerge",
                                        "LoraSave"
                                    ],
                                    {
                                        "title_aux": "LoRA-Merger-ComfyUI"
                                    }
                                ],
                                "https://github.com/laksjdjf/attention-couple-ComfyUI": [
                                    [
                                        "Attention couple"
                                    ],
                                    {
                                        "title_aux": "attention-couple-ComfyUI"
                                    }
                                ],
                                "https://github.com/laksjdjf/cd-tuner_negpip-ComfyUI": [
                                    [
                                        "CDTuner",
                                        "Negapip",
                                        "Negpip"
                                    ],
                                    {
                                        "title_aux": "cd-tuner_negpip-ComfyUI"
                                    }
                                ],
                                "https://github.com/laksjdjf/pfg-ComfyUI": [
                                    [
                                        "PFG"
                                    ],
                                    {
                                        "title_aux": "pfg-ComfyUI"
                                    }
                                ],
                                "https://github.com/lilly1987/ComfyUI_node_Lilly": [
                                    [
                                        "CheckpointLoaderSimpleText",
                                        "LoraLoaderText",
                                        "LoraLoaderTextRandom",
                                        "Random_Sampler",
                                        "VAELoaderDecode"
                                    ],
                                    {
                                        "title_aux": "simple wildcard for ComfyUI"
                                    }
                                ],
                                "https://github.com/lldacing/comfyui-easyapi-nodes": [
                                    [
                                        "Base64ToImage",
                                        "Base64ToMask",
                                        "ImageToBase64",
                                        "ImageToBase64Advanced",
                                        "LoadImageFromURL",
                                        "LoadImageToBase64",
                                        "LoadMaskFromURL",
                                        "MaskImageToBase64",
                                        "MaskToBase64",
                                        "MaskToBase64Image",
                                        "SamAutoMaskSEGS"
                                    ],
                                    {
                                        "title_aux": "comfyui-easyapi-nodes"
                                    }
                                ],
                                "https://github.com/longgui0318/comfyui-mask-util": [
                                    [
                                        "Mask Region Info",
                                        "Mask Selection Of Masks",
                                        "Split Masks"
                                    ],
                                    {
                                        "title_aux": "comfyui-mask-util"
                                    }
                                ],
                                "https://github.com/lordgasmic/ComfyUI-Wildcards/raw/master/wildcards.py": [
                                    [
                                        "CLIPTextEncodeWithWildcards"
                                    ],
                                    {
                                        "title_aux": "Wildcards"
                                    }
                                ],
                                "https://github.com/lrzjason/ComfyUIJasonNode/raw/main/SDXLMixSampler.py": [
                                    [
                                        "SDXLMixSampler"
                                    ],
                                    {
                                        "title_aux": "ComfyUIJasonNode"
                                    }
                                ],
                                "https://github.com/ltdrdata/ComfyUI-Impact-Pack": [
                                    [
                                        "AddMask",
                                        "BasicPipeToDetailerPipe",
                                        "BasicPipeToDetailerPipeSDXL",
                                        "BboxDetectorCombined",
                                        "BboxDetectorCombined_v2",
                                        "BboxDetectorForEach",
                                        "BboxDetectorSEGS",
                                        "BitwiseAndMask",
                                        "BitwiseAndMaskForEach",
                                        "CLIPSegDetectorProvider",
                                        "CfgScheduleHookProvider",
                                        "CombineRegionalPrompts",
                                        "CoreMLDetailerHookProvider",
                                        "DenoiseScheduleHookProvider",
                                        "DenoiseSchedulerDetailerHookProvider",
                                        "DetailerForEach",
                                        "DetailerForEachDebug",
                                        "DetailerForEachDebugPipe",
                                        "DetailerForEachPipe",
                                        "DetailerForEachPipeForAnimateDiff",
                                        "DetailerHookCombine",
                                        "DetailerPipeToBasicPipe",
                                        "EditBasicPipe",
                                        "EditDetailerPipe",
                                        "EditDetailerPipeSDXL",
                                        "EmptySegs",
                                        "FaceDetailer",
                                        "FaceDetailerPipe",
                                        "FromBasicPipe",
                                        "FromBasicPipe_v2",
                                        "FromDetailerPipe",
                                        "FromDetailerPipeSDXL",
                                        "FromDetailerPipe_v2",
                                        "ImageListToImageBatch",
                                        "ImageMaskSwitch",
                                        "ImageReceiver",
                                        "ImageSender",
                                        "ImpactAssembleSEGS",
                                        "ImpactCombineConditionings",
                                        "ImpactCompare",
                                        "ImpactConcatConditionings",
                                        "ImpactConditionalBranch",
                                        "ImpactConditionalBranchSelMode",
                                        "ImpactConditionalStopIteration",
                                        "ImpactControlBridge",
                                        "ImpactControlNetApplyAdvancedSEGS",
                                        "ImpactControlNetApplySEGS",
                                        "ImpactControlNetClearSEGS",
                                        "ImpactConvertDataType",
                                        "ImpactDecomposeSEGS",
                                        "ImpactDilateMask",
                                        "ImpactDilateMaskInSEGS",
                                        "ImpactDilate_Mask_SEG_ELT",
                                        "ImpactDummyInput",
                                        "ImpactEdit_SEG_ELT",
                                        "ImpactFloat",
                                        "ImpactFrom_SEG_ELT",
                                        "ImpactGaussianBlurMask",
                                        "ImpactGaussianBlurMaskInSEGS",
                                        "ImpactHFTransformersClassifierProvider",
                                        "ImpactIfNone",
                                        "ImpactImageBatchToImageList",
                                        "ImpactImageInfo",
                                        "ImpactInt",
                                        "ImpactInversedSwitch",
                                        "ImpactIsNotEmptySEGS",
                                        "ImpactKSamplerAdvancedBasicPipe",
                                        "ImpactKSamplerBasicPipe",
                                        "ImpactLatentInfo",
                                        "ImpactLogger",
                                        "ImpactLogicalOperators",
                                        "ImpactMakeImageBatch",
                                        "ImpactMakeImageList",
                                        "ImpactMakeTileSEGS",
                                        "ImpactMinMax",
                                        "ImpactNeg",
                                        "ImpactNodeSetMuteState",
                                        "ImpactQueueTrigger",
                                        "ImpactQueueTriggerCountdown",
                                        "ImpactRemoteBoolean",
                                        "ImpactRemoteInt",
                                        "ImpactSEGSClassify",
                                        "ImpactSEGSConcat",
                                        "ImpactSEGSLabelFilter",
                                        "ImpactSEGSOrderedFilter",
                                        "ImpactSEGSPicker",
                                        "ImpactSEGSRangeFilter",
                                        "ImpactSEGSToMaskBatch",
                                        "ImpactSEGSToMaskList",
                                        "ImpactScaleBy_BBOX_SEG_ELT",
                                        "ImpactSegsAndMask",
                                        "ImpactSegsAndMaskForEach",
                                        "ImpactSetWidgetValue",
                                        "ImpactSimpleDetectorSEGS",
                                        "ImpactSimpleDetectorSEGSPipe",
                                        "ImpactSimpleDetectorSEGS_for_AD",
                                        "ImpactSleep",
                                        "ImpactStringSelector",
                                        "ImpactSwitch",
                                        "ImpactValueReceiver",
                                        "ImpactValueSender",
                                        "ImpactWildcardEncode",
                                        "ImpactWildcardProcessor",
                                        "IterativeImageUpscale",
                                        "IterativeLatentUpscale",
                                        "KSamplerAdvancedProvider",
                                        "KSamplerProvider",
                                        "LatentPixelScale",
                                        "LatentReceiver",
                                        "LatentSender",
                                        "LatentSwitch",
                                        "MMDetDetectorProvider",
                                        "MMDetLoader",
                                        "MaskDetailerPipe",
                                        "MaskListToMaskBatch",
                                        "MaskPainter",
                                        "MaskToSEGS",
                                        "MaskToSEGS_for_AnimateDiff",
                                        "MasksToMaskList",
                                        "MediaPipeFaceMeshToSEGS",
                                        "NoiseInjectionDetailerHookProvider",
                                        "NoiseInjectionHookProvider",
                                        "ONNXDetectorProvider",
                                        "ONNXDetectorSEGS",
                                        "PixelKSampleHookCombine",
                                        "PixelKSampleUpscalerProvider",
                                        "PixelKSampleUpscalerProviderPipe",
                                        "PixelTiledKSampleUpscalerProvider",
                                        "PixelTiledKSampleUpscalerProviderPipe",
                                        "PreviewBridge",
                                        "PreviewBridgeLatent",
                                        "PreviewDetailerHookProvider",
                                        "ReencodeLatent",
                                        "ReencodeLatentPipe",
                                        "RegionalPrompt",
                                        "RegionalSampler",
                                        "RegionalSamplerAdvanced",
                                        "RemoveImageFromSEGS",
                                        "RemoveNoiseMask",
                                        "SAMDetectorCombined",
                                        "SAMDetectorSegmented",
                                        "SAMLoader",
                                        "SEGSDetailer",
                                        "SEGSDetailerForAnimateDiff",
                                        "SEGSLabelFilterDetailerHookProvider",
                                        "SEGSOrderedFilterDetailerHookProvider",
                                        "SEGSPaste",
                                        "SEGSPreview",
                                        "SEGSPreviewCNet",
                                        "SEGSRangeFilterDetailerHookProvider",
                                        "SEGSSwitch",
                                        "SEGSToImageList",
                                        "SegmDetectorCombined",
                                        "SegmDetectorCombined_v2",
                                        "SegmDetectorForEach",
                                        "SegmDetectorSEGS",
                                        "Segs  Mask",
                                        "Segs  Mask ForEach",
                                        "SegsMaskCombine",
                                        "SegsToCombinedMask",
                                        "SetDefaultImageForSEGS",
                                        "StepsScheduleHookProvider",
                                        "SubtractMask",
                                        "SubtractMaskForEach",
                                        "TiledKSamplerProvider",
                                        "ToBasicPipe",
                                        "ToBinaryMask",
                                        "ToDetailerPipe",
                                        "ToDetailerPipeSDXL",
                                        "TwoAdvancedSamplersForMask",
                                        "TwoSamplersForMask",
                                        "TwoSamplersForMaskUpscalerProvider",
                                        "TwoSamplersForMaskUpscalerProviderPipe",
                                        "UltralyticsDetectorProvider",
                                        "UnsamplerDetailerHookProvider",
                                        "UnsamplerHookProvider"
                                    ],
                                    {
                                        "author": "Dr.Lt.Data",
                                        "description": "This extension offers various detector nodes and detailer nodes that allow you to configure a workflow that automatically enhances facial details. And provide iterative upscaler.",
                                        "nickname": "Impact Pack",
                                        "title": "Impact Pack",
                                        "title_aux": "ComfyUI Impact Pack"
                                    }
                                ],
                                "https://github.com/ltdrdata/ComfyUI-Inspire-Pack": [
                                    [
                                        "AnimeLineArt_Preprocessor_Provider_for_SEGS //Inspire",
                                        "ApplyRegionalIPAdapters //Inspire",
                                        "BindImageListPromptList //Inspire",
                                        "CLIPTextEncodeWithWeight //Inspire",
                                        "CacheBackendData //Inspire",
                                        "CacheBackendDataList //Inspire",
                                        "CacheBackendDataNumberKey //Inspire",
                                        "CacheBackendDataNumberKeyList //Inspire",
                                        "Canny_Preprocessor_Provider_for_SEGS //Inspire",
                                        "ChangeImageBatchSize //Inspire",
                                        "CheckpointLoaderSimpleShared //Inspire",
                                        "Color_Preprocessor_Provider_for_SEGS //Inspire",
                                        "ConcatConditioningsWithMultiplier //Inspire",
                                        "DWPreprocessor_Provider_for_SEGS //Inspire",
                                        "FakeScribblePreprocessor_Provider_for_SEGS //Inspire",
                                        "FloatRange //Inspire",
                                        "FromIPAdapterPipe //Inspire",
                                        "GlobalSampler //Inspire",
                                        "GlobalSeed //Inspire",
                                        "HEDPreprocessor_Provider_for_SEGS //Inspire",
                                        "HyperTile //Inspire",
                                        "IPAdapterModelHelper //Inspire",
                                        "ImageBatchSplitter //Inspire",
                                        "InpaintPreprocessor_Provider_for_SEGS //Inspire",
                                        "KSampler //Inspire",
                                        "KSamplerAdvanced //Inspire",
                                        "KSamplerAdvancedPipe //Inspire",
                                        "KSamplerAdvancedProgress //Inspire",
                                        "KSamplerPipe //Inspire",
                                        "KSamplerProgress //Inspire",
                                        "LatentBatchSplitter //Inspire",
                                        "LeRes_DepthMap_Preprocessor_Provider_for_SEGS //Inspire",
                                        "LineArt_Preprocessor_Provider_for_SEGS //Inspire",
                                        "ListCounter //Inspire",
                                        "LoadImage //Inspire",
                                        "LoadImageListFromDir //Inspire",
                                        "LoadImagesFromDir //Inspire",
                                        "LoadPromptsFromDir //Inspire",
                                        "LoadPromptsFromFile //Inspire",
                                        "LoadSinglePromptFromFile //Inspire",
                                        "LoraBlockInfo //Inspire",
                                        "LoraLoaderBlockWeight //Inspire",
                                        "MakeBasicPipe //Inspire",
                                        "Manga2Anime_LineArt_Preprocessor_Provider_for_SEGS //Inspire",
                                        "MediaPipeFaceMeshDetectorProvider //Inspire",
                                        "MediaPipe_FaceMesh_Preprocessor_Provider_for_SEGS //Inspire",
                                        "MeshGraphormerDepthMapPreprocessorProvider_for_SEGS //Inspire",
                                        "MiDaS_DepthMap_Preprocessor_Provider_for_SEGS //Inspire",
                                        "OpenPose_Preprocessor_Provider_for_SEGS //Inspire",
                                        "PromptBuilder //Inspire",
                                        "PromptExtractor //Inspire",
                                        "RandomGeneratorForList //Inspire",
                                        "RegionalConditioningColorMask //Inspire",
                                        "RegionalConditioningSimple //Inspire",
                                        "RegionalIPAdapterColorMask //Inspire",
                                        "RegionalIPAdapterEncodedColorMask //Inspire",
                                        "RegionalIPAdapterEncodedMask //Inspire",
                                        "RegionalIPAdapterMask //Inspire",
                                        "RegionalPromptColorMask //Inspire",
                                        "RegionalPromptSimple //Inspire",
                                        "RegionalSeedExplorerColorMask //Inspire",
                                        "RegionalSeedExplorerMask //Inspire",
                                        "RemoveBackendData //Inspire",
                                        "RemoveBackendDataNumberKey //Inspire",
                                        "RemoveControlNet //Inspire",
                                        "RemoveControlNetFromRegionalPrompts //Inspire",
                                        "RetrieveBackendData //Inspire",
                                        "RetrieveBackendDataNumberKey //Inspire",
                                        "SeedExplorer //Inspire",
                                        "ShowCachedInfo //Inspire",
                                        "TilePreprocessor_Provider_for_SEGS //Inspire",
                                        "ToIPAdapterPipe //Inspire",
                                        "UnzipPrompt //Inspire",
                                        "WildcardEncode //Inspire",
                                        "XY Input: Lora Block Weight //Inspire",
                                        "ZipPrompt //Inspire",
                                        "Zoe_DepthMap_Preprocessor_Provider_for_SEGS //Inspire"
                                    ],
                                    {
                                        "author": "Dr.Lt.Data",
                                        "description": "This extension provides various nodes to support Lora Block Weight and the Impact Pack.",
                                        "nickname": "Inspire Pack",
                                        "nodename_pattern": "Inspire$",
                                        "title": "Inspire Pack",
                                        "title_aux": "ComfyUI Inspire Pack"
                                    }
                                ],
                                "https://github.com/m-sokes/ComfyUI-Sokes-Nodes": [
                                    [
                                        "Custom Date Format | sokes \ud83e\uddac",
                                        "Latent Switch x9 | sokes \ud83e\uddac"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Sokes Nodes"
                                    }
                                ],
                                "https://github.com/m957ymj75urz/ComfyUI-Custom-Nodes/raw/main/clip-text-encode-split/clip_text_encode_split.py": [
                                    [
                                        "RawText",
                                        "RawTextCombine",
                                        "RawTextEncode",
                                        "RawTextReplace"
                                    ],
                                    {
                                        "title_aux": "m957ymj75urz/ComfyUI-Custom-Nodes"
                                    }
                                ],
                                "https://github.com/mape/ComfyUI-mape-Helpers": [
                                    [
                                        "mape Variable"
                                    ],
                                    {
                                        "author": "mape",
                                        "description": "Various QoL improvements like prompt tweaking, variable assignment, image preview, fuzzy search, error reporting, organizing and node navigation.",
                                        "nickname": "\ud83d\udfe1 mape's helpers",
                                        "title": "mape's helpers",
                                        "title_aux": "mape's ComfyUI Helpers"
                                    }
                                ],
                                "https://github.com/marhensa/sdxl-recommended-res-calc": [
                                    [
                                        "RecommendedResCalc"
                                    ],
                                    {
                                        "title_aux": "Recommended Resolution Calculator"
                                    }
                                ],
                                "https://github.com/martijnat/comfyui-previewlatent": [
                                    [
                                        "PreviewLatent",
                                        "PreviewLatentAdvanced",
                                        "PreviewLatentXL"
                                    ],
                                    {
                                        "title_aux": "comfyui-previewlatent"
                                    }
                                ],
                                "https://github.com/massao000/ComfyUI_aspect_ratios": [
                                    [
                                        "Aspect Ratios Node"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_aspect_ratios"
                                    }
                                ],
                                "https://github.com/matan1905/ComfyUI-Serving-Toolkit": [
                                    [
                                        "DiscordServing",
                                        "ServingInputNumber",
                                        "ServingInputText",
                                        "ServingOutput",
                                        "WebSocketServing"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Serving toolkit"
                                    }
                                ],
                                "https://github.com/mav-rik/facerestore_cf": [
                                    [
                                        "CropFace",
                                        "FaceRestoreCFWithModel",
                                        "FaceRestoreModelLoader"
                                    ],
                                    {
                                        "title_aux": "Facerestore CF (Code Former)"
                                    }
                                ],
                                "https://github.com/mbrostami/ComfyUI-HF": [
                                    [
                                        "GPT2Node"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-HF"
                                    }
                                ],
                                "https://github.com/mcmonkeyprojects/sd-dynamic-thresholding": [
                                    [
                                        "DynamicThresholdingFull",
                                        "DynamicThresholdingSimple"
                                    ],
                                    {
                                        "title_aux": "Stable Diffusion Dynamic Thresholding (CFG Scale Fix)"
                                    }
                                ],
                                "https://github.com/meap158/ComfyUI-Background-Replacement": [
                                    [
                                        "BackgroundReplacement",
                                        "ImageComposite"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Background-Replacement"
                                    }
                                ],
                                "https://github.com/meap158/ComfyUI-GPU-temperature-protection": [
                                    [
                                        "GPUTemperatureProtection"
                                    ],
                                    {
                                        "title_aux": "GPU temperature protection"
                                    }
                                ],
                                "https://github.com/meap158/ComfyUI-Prompt-Expansion": [
                                    [
                                        "PromptExpansion"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Prompt-Expansion"
                                    }
                                ],
                                "https://github.com/melMass/comfy_mtb": [
                                    [
                                        "Animation Builder (mtb)",
                                        "Any To String (mtb)",
                                        "Batch Float (mtb)",
                                        "Batch Float Assemble (mtb)",
                                        "Batch Float Fill (mtb)",
                                        "Batch Make (mtb)",
                                        "Batch Merge (mtb)",
                                        "Batch Shake (mtb)",
                                        "Batch Shape (mtb)",
                                        "Batch Transform (mtb)",
                                        "Bbox (mtb)",
                                        "Bbox From Mask (mtb)",
                                        "Blur (mtb)",
                                        "Color Correct (mtb)",
                                        "Colored Image (mtb)",
                                        "Concat Images (mtb)",
                                        "Crop (mtb)",
                                        "Debug (mtb)",
                                        "Deep Bump (mtb)",
                                        "Export With Ffmpeg (mtb)",
                                        "Face Swap (mtb)",
                                        "Film Interpolation (mtb)",
                                        "Fit Number (mtb)",
                                        "Float To Number (mtb)",
                                        "Get Batch From History (mtb)",
                                        "Image Compare (mtb)",
                                        "Image Premultiply (mtb)",
                                        "Image Remove Background Rembg (mtb)",
                                        "Image Resize Factor (mtb)",
                                        "Image Tile Offset (mtb)",
                                        "Int To Bool (mtb)",
                                        "Int To Number (mtb)",
                                        "Interpolate Clip Sequential (mtb)",
                                        "Latent Lerp (mtb)",
                                        "Load Face Analysis Model (mtb)",
                                        "Load Face Enhance Model (mtb)",
                                        "Load Face Swap Model (mtb)",
                                        "Load Film Model (mtb)",
                                        "Load Image From Url (mtb)",
                                        "Load Image Sequence (mtb)",
                                        "Mask To Image (mtb)",
                                        "Math Expression (mtb)",
                                        "Model Patch Seamless (mtb)",
                                        "Pick From Batch (mtb)",
                                        "Qr Code (mtb)",
                                        "Restore Face (mtb)",
                                        "Save Gif (mtb)",
                                        "Save Image Grid (mtb)",
                                        "Save Image Sequence (mtb)",
                                        "Save Tensors (mtb)",
                                        "Sharpen (mtb)",
                                        "Smart Step (mtb)",
                                        "Stack Images (mtb)",
                                        "String Replace (mtb)",
                                        "Styles Loader (mtb)",
                                        "Text To Image (mtb)",
                                        "Transform Image (mtb)",
                                        "Uncrop (mtb)",
                                        "Unsplash Image (mtb)",
                                        "Vae Decode (mtb)"
                                    ],
                                    {
                                        "nodename_pattern": "\\(mtb\\)$",
                                        "title_aux": "MTB Nodes"
                                    }
                                ],
                                "https://github.com/mihaiiancu/ComfyUI_Inpaint": [
                                    [
                                        "InpaintMediapipe"
                                    ],
                                    {
                                        "title_aux": "mihaiiancu/Inpaint"
                                    }
                                ],
                                "https://github.com/mikkel/ComfyUI-text-overlay": [
                                    [
                                        "Image Text Overlay"
                                    ],
                                    {
                                        "title_aux": "ComfyUI - Text Overlay Plugin"
                                    }
                                ],
                                "https://github.com/mikkel/comfyui-mask-boundingbox": [
                                    [
                                        "Mask Bounding Box"
                                    ],
                                    {
                                        "title_aux": "ComfyUI - Mask Bounding Box"
                                    }
                                ],
                                "https://github.com/mlinmg/ComfyUI-LaMA-Preprocessor": [
                                    [
                                        "LaMaPreprocessor",
                                        "lamaPreprocessor"
                                    ],
                                    {
                                        "title_aux": "LaMa Preprocessor [WIP]"
                                    }
                                ],
                                "https://github.com/modusCell/ComfyUI-dimension-node-modusCell": [
                                    [
                                        "DimensionProviderFree modusCell",
                                        "DimensionProviderRatio modusCell",
                                        "String Concat modusCell"
                                    ],
                                    {
                                        "title_aux": "Preset Dimensions"
                                    }
                                ],
                                "https://github.com/mpiquero7164/ComfyUI-SaveImgPrompt": [
                                    [
                                        "Save IMG Prompt"
                                    ],
                                    {
                                        "title_aux": "SaveImgPrompt"
                                    }
                                ],
                                "https://github.com/nagolinc/ComfyUI_FastVAEDecorder_SDXL": [
                                    [
                                        "FastLatentToImage"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_FastVAEDecorder_SDXL"
                                    }
                                ],
                                "https://github.com/natto-maki/ComfyUI-NegiTools": [
                                    [
                                        "NegiTools_CompositeImages",
                                        "NegiTools_DepthEstimationByMarigold",
                                        "NegiTools_DetectFaceRotationForInpainting",
                                        "NegiTools_ImageProperties",
                                        "NegiTools_LatentProperties",
                                        "NegiTools_NoiseImageGenerator",
                                        "NegiTools_OpenAiDalle3",
                                        "NegiTools_OpenAiGpt",
                                        "NegiTools_OpenAiGpt4v",
                                        "NegiTools_OpenAiTranslate",
                                        "NegiTools_OpenPoseToPointList",
                                        "NegiTools_PointListToMask",
                                        "NegiTools_RandomImageLoader",
                                        "NegiTools_SaveImageToDirectory",
                                        "NegiTools_SeedGenerator",
                                        "NegiTools_StereoImageGenerator",
                                        "NegiTools_StringFunction"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-NegiTools"
                                    }
                                ],
                                "https://github.com/nicolai256/comfyUI_Nodes_nicolai256/raw/main/yugioh-presets.py": [
                                    [
                                        "yugioh_Presets"
                                    ],
                                    {
                                        "title_aux": "comfyUI_Nodes_nicolai256"
                                    }
                                ],
                                "https://github.com/ningxiaoxiao/comfyui-NDI": [
                                    [
                                        "NDI_LoadImage",
                                        "NDI_SendImage"
                                    ],
                                    {
                                        "title_aux": "comfyui-NDI"
                                    }
                                ],
                                "https://github.com/nkchocoai/ComfyUI-PromptUtilities": [
                                    [
                                        "PromptUtilitiesConstString",
                                        "PromptUtilitiesConstStringMultiLine",
                                        "PromptUtilitiesFormatString",
                                        "PromptUtilitiesJoinStringList",
                                        "PromptUtilitiesLoadPreset",
                                        "PromptUtilitiesLoadPresetAdvanced",
                                        "PromptUtilitiesRandomPreset",
                                        "PromptUtilitiesRandomPresetAdvanced"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-PromptUtilities"
                                    }
                                ],
                                "https://github.com/nkchocoai/ComfyUI-SizeFromPresets": [
                                    [
                                        "EmptyLatentImageFromPresetsSD15",
                                        "EmptyLatentImageFromPresetsSDXL",
                                        "RandomEmptyLatentImageFromPresetsSD15",
                                        "RandomEmptyLatentImageFromPresetsSDXL",
                                        "RandomSizeFromPresetsSD15",
                                        "RandomSizeFromPresetsSDXL",
                                        "SizeFromPresetsSD15",
                                        "SizeFromPresetsSDXL"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SizeFromPresets"
                                    }
                                ],
                                "https://github.com/nkchocoai/ComfyUI-TextOnSegs": [
                                    [
                                        "CalcMaxFontSize",
                                        "ExtractDominantColor",
                                        "GetComplementaryColor",
                                        "SegsToRegion",
                                        "TextOnSegsFloodFill"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TextOnSegs"
                                    }
                                ],
                                "https://github.com/noembryo/ComfyUI-noEmbryo": [
                                    [
                                        "PromptTermList1",
                                        "PromptTermList2",
                                        "PromptTermList3",
                                        "PromptTermList4",
                                        "PromptTermList5",
                                        "PromptTermList6"
                                    ],
                                    {
                                        "author": "noEmbryo",
                                        "description": "Some useful nodes for ComfyUI",
                                        "nickname": "noEmbryo",
                                        "title": "noEmbryo nodes for ComfyUI",
                                        "title_aux": "noEmbryo nodes"
                                    }
                                ],
                                "https://github.com/nosiu/comfyui-instantId-faceswap": [
                                    [
                                        "FaceEmbed",
                                        "FaceSwapGenerationInpaint",
                                        "FaceSwapSetupPipeline",
                                        "LCMLora"
                                    ],
                                    {
                                        "title_aux": "ComfyUI InstantID Faceswapper"
                                    }
                                ],
                                "https://github.com/noxinias/ComfyUI_NoxinNodes": [
                                    [
                                        "NoxinChime",
                                        "NoxinPromptLoad",
                                        "NoxinPromptSave",
                                        "NoxinScaledResolution",
                                        "NoxinSimpleMath",
                                        "NoxinSplitPrompt"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_NoxinNodes"
                                    }
                                ],
                                "https://github.com/ntc-ai/ComfyUI-DARE-LoRA-Merge": [
                                    [
                                        "Apply LoRA",
                                        "DARE Merge LoRA Stack",
                                        "Save LoRA"
                                    ],
                                    {
                                        "title_aux": "ComfyUI - Apply LoRA Stacker with DARE"
                                    }
                                ],
                                "https://github.com/ntdviet/comfyui-ext/raw/main/custom_nodes/gcLatentTunnel/gcLatentTunnel.py": [
                                    [
                                        "gcLatentTunnel"
                                    ],
                                    {
                                        "title_aux": "ntdviet/comfyui-ext"
                                    }
                                ],
                                "https://github.com/omar92/ComfyUI-QualityOfLifeSuit_Omar92": [
                                    [
                                        "CLIPStringEncode _O",
                                        "Chat completion _O",
                                        "ChatGPT Simple _O",
                                        "ChatGPT _O",
                                        "ChatGPT compact _O",
                                        "Chat_Completion _O",
                                        "Chat_Message _O",
                                        "Chat_Message_fromString _O",
                                        "Concat Text _O",
                                        "ConcatRandomNSP_O",
                                        "Debug String _O",
                                        "Debug Text _O",
                                        "Debug Text route _O",
                                        "Edit_image _O",
                                        "Equation1param _O",
                                        "Equation2params _O",
                                        "GetImage_(Width&Height) _O",
                                        "GetLatent_(Width&Height) _O",
                                        "ImageScaleFactor _O",
                                        "ImageScaleFactorSimple _O",
                                        "LatentUpscaleFactor _O",
                                        "LatentUpscaleFactorSimple _O",
                                        "LatentUpscaleMultiply",
                                        "Note _O",
                                        "RandomNSP _O",
                                        "Replace Text _O",
                                        "String _O",
                                        "Text _O",
                                        "Text2Image _O",
                                        "Trim Text _O",
                                        "VAEDecodeParallel _O",
                                        "combine_chat_messages _O",
                                        "compine_chat_messages _O",
                                        "concat Strings _O",
                                        "create image _O",
                                        "create_image _O",
                                        "debug Completeion _O",
                                        "debug messages_O",
                                        "float _O",
                                        "floatToInt _O",
                                        "floatToText _O",
                                        "int _O",
                                        "intToFloat _O",
                                        "load_openAI _O",
                                        "replace String _O",
                                        "replace String advanced _O",
                                        "saveTextToFile _O",
                                        "seed _O",
                                        "selectLatentFromBatch _O",
                                        "string2Image _O",
                                        "trim String _O",
                                        "variation_image _O"
                                    ],
                                    {
                                        "title_aux": "Quality of life Suit:V2"
                                    }
                                ],
                                "https://github.com/ostris/ostris_nodes_comfyui": [
                                    [
                                        "LLM Pipe Loader - Ostris",
                                        "LLM Prompt Upsampling - Ostris",
                                        "One Seed - Ostris",
                                        "Text Box - Ostris"
                                    ],
                                    {
                                        "nodename_pattern": "- Ostris$",
                                        "title_aux": "Ostris Nodes ComfyUI"
                                    }
                                ],
                                "https://github.com/ownimage/ComfyUI-ownimage": [
                                    [
                                        "Caching Image Loader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-ownimage"
                                    }
                                ],
                                "https://github.com/oyvindg/ComfyUI-TrollSuite": [
                                    [
                                        "BinaryImageMask",
                                        "ImagePadding",
                                        "LoadLastImage",
                                        "RandomMask",
                                        "TransparentImage"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TrollSuite"
                                    }
                                ],
                                "https://github.com/palant/extended-saveimage-comfyui": [
                                    [
                                        "SaveImageExtended"
                                    ],
                                    {
                                        "title_aux": "Extended Save Image for ComfyUI"
                                    }
                                ],
                                "https://github.com/palant/image-resize-comfyui": [
                                    [
                                        "ImageResize"
                                    ],
                                    {
                                        "title_aux": "Image Resize for ComfyUI"
                                    }
                                ],
                                "https://github.com/pants007/comfy-pants": [
                                    [
                                        "CLIPTextEncodeAIO",
                                        "Image Make Square"
                                    ],
                                    {
                                        "title_aux": "pants"
                                    }
                                ],
                                "https://github.com/paulo-coronado/comfy_clip_blip_node": [
                                    [
                                        "CLIPTextEncodeBLIP",
                                        "CLIPTextEncodeBLIP-2",
                                        "Example"
                                    ],
                                    {
                                        "title_aux": "comfy_clip_blip_node"
                                    }
                                ],
                                "https://github.com/picturesonpictures/comfy_PoP": [
                                    [
                                        "AdaptiveCannyDetector_PoP",
                                        "AnyAspectRatio",
                                        "ConditioningMultiplier_PoP",
                                        "ConditioningNormalizer_PoP",
                                        "DallE3_PoP",
                                        "LoadImageResizer_PoP",
                                        "LoraStackLoader10_PoP",
                                        "LoraStackLoader_PoP",
                                        "VAEDecoderPoP",
                                        "VAEEncoderPoP"
                                    ],
                                    {
                                        "title_aux": "comfy_PoP"
                                    }
                                ],
                                "https://github.com/pkpkTech/ComfyUI-SaveAVIF": [
                                    [
                                        "SaveAvif"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SaveAVIF"
                                    }
                                ],
                                "https://github.com/pkpkTech/ComfyUI-TemporaryLoader": [
                                    [
                                        "LoadTempCheckpoint",
                                        "LoadTempLoRA",
                                        "LoadTempMultiLoRA"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TemporaryLoader"
                                    }
                                ],
                                "https://github.com/pythongosssss/ComfyUI-Custom-Scripts": [
                                    [
                                        "CheckpointLoader|pysssss",
                                        "ConstrainImageforVideo|pysssss",
                                        "ConstrainImage|pysssss",
                                        "LoadText|pysssss",
                                        "LoraLoader|pysssss",
                                        "MathExpression|pysssss",
                                        "MultiPrimitive|pysssss",
                                        "PlaySound|pysssss",
                                        "Repeater|pysssss",
                                        "ReroutePrimitive|pysssss",
                                        "SaveText|pysssss",
                                        "ShowText|pysssss",
                                        "StringFunction|pysssss"
                                    ],
                                    {
                                        "title_aux": "pythongosssss/ComfyUI-Custom-Scripts"
                                    }
                                ],
                                "https://github.com/pythongosssss/ComfyUI-WD14-Tagger": [
                                    [
                                        "WD14Tagger|pysssss"
                                    ],
                                    {
                                        "title_aux": "ComfyUI WD 1.4 Tagger"
                                    }
                                ],
                                "https://github.com/ramyma/A8R8_ComfyUI_nodes": [
                                    [
                                        "Base64ImageInput",
                                        "Base64ImageOutput"
                                    ],
                                    {
                                        "title_aux": "A8R8 ComfyUI Nodes"
                                    }
                                ],
                                "https://github.com/rcfcu2000/zhihuige-nodes-comfyui": [
                                    [
                                        "Combine ZHGMasks",
                                        "Cover ZHGMasks",
                                        "From ZHG pip",
                                        "GroundingDinoModelLoader (zhihuige)",
                                        "GroundingDinoPIPESegment (zhihuige)",
                                        "GroundingDinoSAMSegment (zhihuige)",
                                        "InvertMask (zhihuige)",
                                        "SAMModelLoader (zhihuige)",
                                        "To ZHG pip",
                                        "ZHG FaceIndex",
                                        "ZHG GetMaskArea",
                                        "ZHG Image Levels",
                                        "ZHG SaveImage",
                                        "ZHG SmoothEdge",
                                        "ZHG UltimateSDUpscale"
                                    ],
                                    {
                                        "title_aux": "zhihuige-nodes-comfyui"
                                    }
                                ],
                                "https://github.com/rcsaquino/comfyui-custom-nodes": [
                                    [
                                        "BackgroundRemover | rcsaquino",
                                        "VAELoader | rcsaquino",
                                        "VAEProcessor | rcsaquino"
                                    ],
                                    {
                                        "title_aux": "rcsaquino/comfyui-custom-nodes"
                                    }
                                ],
                                "https://github.com/receyuki/comfyui-prompt-reader-node": [
                                    [
                                        "SDBatchLoader",
                                        "SDLoraLoader",
                                        "SDLoraSelector",
                                        "SDParameterExtractor",
                                        "SDParameterGenerator",
                                        "SDPromptMerger",
                                        "SDPromptReader",
                                        "SDPromptSaver",
                                        "SDTypeConverter"
                                    ],
                                    {
                                        "author": "receyuki",
                                        "description": "ComfyUI node version of the SD Prompt Reader",
                                        "nickname": "SD Prompt Reader",
                                        "title": "SD Prompt Reader",
                                        "title_aux": "comfyui-prompt-reader-node"
                                    }
                                ],
                                "https://github.com/redhottensors/ComfyUI-Prediction": [
                                    [
                                        "SamplerCustomPrediction"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Prediction"
                                    }
                                ],
                                "https://github.com/rgthree/rgthree-comfy": [
                                    [],
                                    {
                                        "author": "rgthree",
                                        "description": "A bunch of nodes I created that I also find useful.",
                                        "nickname": "rgthree",
                                        "nodename_pattern": " \\(rgthree\\)$",
                                        "title": "Comfy Nodes",
                                        "title_aux": "rgthree's ComfyUI Nodes"
                                    }
                                ],
                                "https://github.com/richinsley/Comfy-LFO": [
                                    [
                                        "LFO_Pulse",
                                        "LFO_Sawtooth",
                                        "LFO_Sine",
                                        "LFO_Square",
                                        "LFO_Triangle"
                                    ],
                                    {
                                        "title_aux": "Comfy-LFO"
                                    }
                                ],
                                "https://github.com/ricklove/comfyui-ricklove": [
                                    [
                                        "RL_Crop_Resize",
                                        "RL_Crop_Resize_Batch",
                                        "RL_Depth16",
                                        "RL_Finetune_Analyze",
                                        "RL_Finetune_Analyze_Batch",
                                        "RL_Finetune_Variable",
                                        "RL_Image_Shadow",
                                        "RL_Image_Threshold_Channels",
                                        "RL_Internet_Search",
                                        "RL_LoadImageSequence",
                                        "RL_Optical_Flow_Dip",
                                        "RL_SaveImageSequence",
                                        "RL_Uncrop",
                                        "RL_Warp_Image",
                                        "RL_Zoe_Depth_Map_Preprocessor",
                                        "RL_Zoe_Depth_Map_Preprocessor_Raw_Infer",
                                        "RL_Zoe_Depth_Map_Preprocessor_Raw_Process"
                                    ],
                                    {
                                        "title_aux": "comfyui-ricklove"
                                    }
                                ],
                                "https://github.com/rklaffehn/rk-comfy-nodes": [
                                    [
                                        "RK_CivitAIAddHashes",
                                        "RK_CivitAIMetaChecker"
                                    ],
                                    {
                                        "title_aux": "rk-comfy-nodes"
                                    }
                                ],
                                "https://github.com/romeobuilderotti/ComfyUI-PNG-Metadata": [
                                    [
                                        "SetMetadataAll",
                                        "SetMetadataString"
                                    ],
                                    {
                                        "title_aux": "ComfyUI PNG Metadata"
                                    }
                                ],
                                "https://github.com/rui40000/RUI-Nodes": [
                                    [
                                        "ABCondition",
                                        "CharacterCount"
                                    ],
                                    {
                                        "title_aux": "RUI-Nodes"
                                    }
                                ],
                                "https://github.com/s1dlx/comfy_meh/raw/main/meh.py": [
                                    [
                                        "MergingExecutionHelper"
                                    ],
                                    {
                                        "title_aux": "comfy_meh"
                                    }
                                ],
                                "https://github.com/seanlynch/comfyui-optical-flow": [
                                    [
                                        "Apply optical flow",
                                        "Compute optical flow",
                                        "Visualize optical flow"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Optical Flow"
                                    }
                                ],
                                "https://github.com/seanlynch/srl-nodes": [
                                    [
                                        "SRL Conditional Interrrupt",
                                        "SRL Eval",
                                        "SRL Filter Image List",
                                        "SRL Format String"
                                    ],
                                    {
                                        "title_aux": "SRL's nodes"
                                    }
                                ],
                                "https://github.com/sergekatzmann/ComfyUI_Nimbus-Pack": [
                                    [
                                        "ImageResizeAndCropNode",
                                        "ImageSquareAdapterNode"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Nimbus-Pack"
                                    }
                                ],
                                "https://github.com/shadowcz007/comfyui-consistency-decoder": [
                                    [
                                        "VAEDecodeConsistencyDecoder",
                                        "VAELoaderConsistencyDecoder"
                                    ],
                                    {
                                        "title_aux": "Consistency Decoder"
                                    }
                                ],
                                "https://github.com/shadowcz007/comfyui-mixlab-nodes": [
                                    [
                                        "3DImage",
                                        "AppInfo",
                                        "AreaToMask",
                                        "CenterImage",
                                        "CharacterInText",
                                        "ChatGPTOpenAI",
                                        "CkptNames_",
                                        "Color",
                                        "DynamicDelayProcessor",
                                        "EmbeddingPrompt",
                                        "EnhanceImage",
                                        "FaceToMask",
                                        "FeatheredMask",
                                        "FloatSlider",
                                        "FloatingVideo",
                                        "Font",
                                        "GamePal",
                                        "GetImageSize_",
                                        "GradientImage",
                                        "GridOutput",
                                        "ImageColorTransfer",
                                        "ImageCropByAlpha",
                                        "IntNumber",
                                        "JoinWithDelimiter",
                                        "LaMaInpainting",
                                        "LimitNumber",
                                        "LoadImagesFromPath",
                                        "LoadImagesFromURL",
                                        "LoraNames_",
                                        "MergeLayers",
                                        "MirroredImage",
                                        "MultiplicationNode",
                                        "NewLayer",
                                        "NoiseImage",
                                        "OutlineMask",
                                        "PromptImage",
                                        "PromptSimplification",
                                        "PromptSlide",
                                        "RandomPrompt",
                                        "ResizeImageMixlab",
                                        "SamplerNames_",
                                        "SaveImageToLocal",
                                        "ScreenShare",
                                        "Seed_",
                                        "ShowLayer",
                                        "ShowTextForGPT",
                                        "SmoothMask",
                                        "SpeechRecognition",
                                        "SpeechSynthesis",
                                        "SplitImage",
                                        "SplitLongMask",
                                        "SvgImage",
                                        "SwitchByIndex",
                                        "TESTNODE_",
                                        "TESTNODE_TOKEN",
                                        "TextImage",
                                        "TextInput_",
                                        "TextToNumber",
                                        "TransparentImage",
                                        "VAEDecodeConsistencyDecoder",
                                        "VAELoaderConsistencyDecoder"
                                    ],
                                    {
                                        "title_aux": "comfyui-mixlab-nodes"
                                    }
                                ],
                                "https://github.com/shadowcz007/comfyui-ultralytics-yolo": [
                                    [
                                        "DetectByLabel"
                                    ],
                                    {
                                        "title_aux": "comfyui-ultralytics-yolo"
                                    }
                                ],
                                "https://github.com/shiimizu/ComfyUI-PhotoMaker-Plus": [
                                    [
                                        "PhotoMakerEncodePlus",
                                        "PhotoMakerStyles",
                                        "PrepImagesForClipVisionFromPath"
                                    ],
                                    {
                                        "title_aux": "ComfyUI PhotoMaker Plus"
                                    }
                                ],
                                "https://github.com/shiimizu/ComfyUI-TiledDiffusion": [
                                    [
                                        "NoiseInversion",
                                        "TiledDiffusion",
                                        "VAEDecodeTiled_TiledDiffusion",
                                        "VAEEncodeTiled_TiledDiffusion"
                                    ],
                                    {
                                        "title_aux": "Tiled Diffusion & VAE for ComfyUI"
                                    }
                                ],
                                "https://github.com/shiimizu/ComfyUI_smZNodes": [
                                    [
                                        "smZ CLIPTextEncode",
                                        "smZ Settings"
                                    ],
                                    {
                                        "title_aux": "smZNodes"
                                    }
                                ],
                                "https://github.com/shingo1228/ComfyUI-SDXL-EmptyLatentImage": [
                                    [
                                        "SDXL Empty Latent Image"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-SDXL-EmptyLatentImage"
                                    }
                                ],
                                "https://github.com/shingo1228/ComfyUI-send-eagle-slim": [
                                    [
                                        "Send Eagle with text",
                                        "Send Webp Image to Eagle"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-send-Eagle(slim)"
                                    }
                                ],
                                "https://github.com/shockz0rz/ComfyUI_InterpolateEverything": [
                                    [
                                        "OpenposePreprocessorInterpolate"
                                    ],
                                    {
                                        "title_aux": "InterpolateEverything"
                                    }
                                ],
                                "https://github.com/shockz0rz/comfy-easy-grids": [
                                    [
                                        "FloatToText",
                                        "GridFloatList",
                                        "GridFloats",
                                        "GridIntList",
                                        "GridInts",
                                        "GridLoras",
                                        "GridStringList",
                                        "GridStrings",
                                        "ImageGridCommander",
                                        "IntToText",
                                        "SaveImageGrid",
                                        "TextConcatenator"
                                    ],
                                    {
                                        "title_aux": "comfy-easy-grids"
                                    }
                                ],
                                "https://github.com/siliconflow/onediff_comfy_nodes": [
                                    [
                                        "CompareModel",
                                        "ControlNetGraphLoader",
                                        "ControlNetGraphSaver",
                                        "ControlNetSpeedup",
                                        "ModelGraphLoader",
                                        "ModelGraphSaver",
                                        "ModelSpeedup",
                                        "ModuleDeepCacheSpeedup",
                                        "OneDiffCheckpointLoaderSimple",
                                        "SVDSpeedup",
                                        "ShowImageDiff",
                                        "VaeGraphLoader",
                                        "VaeGraphSaver",
                                        "VaeSpeedup"
                                    ],
                                    {
                                        "title_aux": "OneDiff Nodes"
                                    }
                                ],
                                "https://github.com/sipherxyz/comfyui-art-venture": [
                                    [
                                        "AV_CheckpointMerge",
                                        "AV_CheckpointModelsToParametersPipe",
                                        "AV_CheckpointSave",
                                        "AV_ControlNetEfficientLoader",
                                        "AV_ControlNetEfficientLoaderAdvanced",
                                        "AV_ControlNetEfficientStacker",
                                        "AV_ControlNetEfficientStackerSimple",
                                        "AV_ControlNetLoader",
                                        "AV_ControlNetPreprocessor",
                                        "AV_LoraListLoader",
                                        "AV_LoraListStacker",
                                        "AV_LoraLoader",
                                        "AV_ParametersPipeToCheckpointModels",
                                        "AV_ParametersPipeToPrompts",
                                        "AV_PromptsToParametersPipe",
                                        "AV_SAMLoader",
                                        "AV_VAELoader",
                                        "AspectRatioSelector",
                                        "BLIPCaption",
                                        "BLIPLoader",
                                        "BooleanPrimitive",
                                        "ColorBlend",
                                        "ColorCorrect",
                                        "DeepDanbooruCaption",
                                        "DependenciesEdit",
                                        "Fooocus_KSampler",
                                        "Fooocus_KSamplerAdvanced",
                                        "GetBoolFromJson",
                                        "GetFloatFromJson",
                                        "GetIntFromJson",
                                        "GetObjectFromJson",
                                        "GetSAMEmbedding",
                                        "GetTextFromJson",
                                        "ISNetLoader",
                                        "ISNetSegment",
                                        "ImageAlphaComposite",
                                        "ImageApplyChannel",
                                        "ImageExtractChannel",
                                        "ImageGaussianBlur",
                                        "ImageMuxer",
                                        "ImageRepeat",
                                        "ImageScaleDown",
                                        "ImageScaleDownBy",
                                        "ImageScaleDownToSize",
                                        "ImageScaleToMegapixels",
                                        "LaMaInpaint",
                                        "LoadImageAsMaskFromUrl",
                                        "LoadImageFromUrl",
                                        "LoadJsonFromUrl",
                                        "MergeModels",
                                        "NumberScaler",
                                        "OverlayInpaintedImage",
                                        "OverlayInpaintedLatent",
                                        "PrepareImageAndMaskForInpaint",
                                        "QRCodeGenerator",
                                        "RandomFloat",
                                        "RandomInt",
                                        "SAMEmbeddingToImage",
                                        "SDXLAspectRatioSelector",
                                        "SDXLPromptStyler",
                                        "SeedSelector",
                                        "StringToInt",
                                        "StringToNumber"
                                    ],
                                    {
                                        "title_aux": "comfyui-art-venture"
                                    }
                                ],
                                "https://github.com/skfoo/ComfyUI-Coziness": [
                                    [
                                        "LoraTextExtractor-b1f83aa2",
                                        "MultiLoraLoader-70bf3d77"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Coziness"
                                    }
                                ],
                                "https://github.com/smagnetize/kb-comfyui-nodes": [
                                    [
                                        "SingleImageDataUrlLoader"
                                    ],
                                    {
                                        "title_aux": "kb-comfyui-nodes"
                                    }
                                ],
                                "https://github.com/space-nuko/ComfyUI-Disco-Diffusion": [
                                    [
                                        "DiscoDiffusion_DiscoDiffusion",
                                        "DiscoDiffusion_DiscoDiffusionExtraSettings",
                                        "DiscoDiffusion_GuidedDiffusionLoader",
                                        "DiscoDiffusion_OpenAICLIPLoader"
                                    ],
                                    {
                                        "title_aux": "Disco Diffusion"
                                    }
                                ],
                                "https://github.com/space-nuko/ComfyUI-OpenPose-Editor": [
                                    [
                                        "Nui.OpenPoseEditor"
                                    ],
                                    {
                                        "title_aux": "OpenPose Editor"
                                    }
                                ],
                                "https://github.com/space-nuko/nui-suite": [
                                    [
                                        "Nui.DynamicPromptsTextGen",
                                        "Nui.FeelingLuckyTextGen",
                                        "Nui.OutputString"
                                    ],
                                    {
                                        "title_aux": "nui suite"
                                    }
                                ],
                                "https://github.com/spacepxl/ComfyUI-HQ-Image-Save": [
                                    [
                                        "LoadEXR",
                                        "LoadLatentEXR",
                                        "SaveEXR",
                                        "SaveLatentEXR",
                                        "SaveTiff"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-HQ-Image-Save"
                                    }
                                ],
                                "https://github.com/spacepxl/ComfyUI-Image-Filters": [
                                    [
                                        "AdainImage",
                                        "AdainLatent",
                                        "AlphaClean",
                                        "AlphaMatte",
                                        "BatchAverageImage",
                                        "BatchAverageUnJittered",
                                        "BatchNormalizeImage",
                                        "BatchNormalizeLatent",
                                        "BlurImageFast",
                                        "BlurMaskFast",
                                        "ClampOutliers",
                                        "ConvertNormals",
                                        "DifferenceChecker",
                                        "DilateErodeMask",
                                        "EnhanceDetail",
                                        "ExposureAdjust",
                                        "GuidedFilterAlpha",
                                        "ImageConstant",
                                        "ImageConstantHSV",
                                        "JitterImage",
                                        "Keyer",
                                        "LatentStats",
                                        "NormalMapSimple",
                                        "OffsetLatentImage",
                                        "RemapRange",
                                        "Tonemap",
                                        "UnJitterImage",
                                        "UnTonemap"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Image-Filters"
                                    }
                                ],
                                "https://github.com/spacepxl/ComfyUI-RAVE": [
                                    [
                                        "ConditioningDebug",
                                        "ImageGridCompose",
                                        "ImageGridDecompose",
                                        "KSamplerRAVE",
                                        "LatentGridCompose",
                                        "LatentGridDecompose"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-RAVE"
                                    }
                                ],
                                "https://github.com/spinagon/ComfyUI-seam-carving": [
                                    [
                                        "SeamCarving"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-seam-carving"
                                    }
                                ],
                                "https://github.com/spinagon/ComfyUI-seamless-tiling": [
                                    [
                                        "CircularVAEDecode",
                                        "MakeCircularVAE",
                                        "OffsetImage",
                                        "SeamlessTile"
                                    ],
                                    {
                                        "title_aux": "Seamless tiling Node for ComfyUI"
                                    }
                                ],
                                "https://github.com/spro/comfyui-mirror": [
                                    [
                                        "LatentMirror"
                                    ],
                                    {
                                        "title_aux": "Latent Mirror node for ComfyUI"
                                    }
                                ],
                                "https://github.com/ssitu/ComfyUI_UltimateSDUpscale": [
                                    [
                                        "UltimateSDUpscale",
                                        "UltimateSDUpscaleNoUpscale"
                                    ],
                                    {
                                        "title_aux": "UltimateSDUpscale"
                                    }
                                ],
                                "https://github.com/ssitu/ComfyUI_fabric": [
                                    [
                                        "FABRICPatchModel",
                                        "FABRICPatchModelAdv",
                                        "KSamplerAdvFABRICAdv",
                                        "KSamplerFABRIC",
                                        "KSamplerFABRICAdv"
                                    ],
                                    {
                                        "title_aux": "ComfyUI fabric"
                                    }
                                ],
                                "https://github.com/ssitu/ComfyUI_restart_sampling": [
                                    [
                                        "KRestartSampler",
                                        "KRestartSamplerAdv",
                                        "KRestartSamplerSimple"
                                    ],
                                    {
                                        "title_aux": "Restart Sampling"
                                    }
                                ],
                                "https://github.com/ssitu/ComfyUI_roop": [
                                    [
                                        "RoopImproved",
                                        "roop"
                                    ],
                                    {
                                        "title_aux": "ComfyUI roop"
                                    }
                                ],
                                "https://github.com/storyicon/comfyui_segment_anything": [
                                    [
                                        "GroundingDinoModelLoader (segment anything)",
                                        "GroundingDinoSAMSegment (segment anything)",
                                        "InvertMask (segment anything)",
                                        "IsMaskEmpty",
                                        "SAMModelLoader (segment anything)"
                                    ],
                                    {
                                        "title_aux": "segment anything"
                                    }
                                ],
                                "https://github.com/strimmlarn/ComfyUI_Strimmlarns_aesthetic_score": [
                                    [
                                        "AesthetlcScoreSorter",
                                        "CalculateAestheticScore",
                                        "LoadAesteticModel",
                                        "ScoreToNumber"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_Strimmlarns_aesthetic_score"
                                    }
                                ],
                                "https://github.com/styler00dollar/ComfyUI-deepcache": [
                                    [
                                        "DeepCache"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-deepcache"
                                    }
                                ],
                                "https://github.com/styler00dollar/ComfyUI-sudo-latent-upscale": [
                                    [
                                        "SudoLatentUpscale"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-sudo-latent-upscale"
                                    }
                                ],
                                "https://github.com/syllebra/bilbox-comfyui": [
                                    [
                                        "BilboXLut",
                                        "BilboXPhotoPrompt",
                                        "BilboXVignette"
                                    ],
                                    {
                                        "title_aux": "BilboX's ComfyUI Custom Nodes"
                                    }
                                ],
                                "https://github.com/sylym/comfy_vid2vid": [
                                    [
                                        "CheckpointLoaderSimpleSequence",
                                        "DdimInversionSequence",
                                        "KSamplerSequence",
                                        "LoadImageMaskSequence",
                                        "LoadImageSequence",
                                        "LoraLoaderSequence",
                                        "SetLatentNoiseSequence",
                                        "TrainUnetSequence",
                                        "VAEEncodeForInpaintSequence"
                                    ],
                                    {
                                        "title_aux": "Vid2vid"
                                    }
                                ],
                                "https://github.com/szhublox/ambw_comfyui": [
                                    [
                                        "Auto Merge Block Weighted",
                                        "CLIPMergeSimple",
                                        "CheckpointSave",
                                        "ModelMergeBlocks",
                                        "ModelMergeSimple"
                                    ],
                                    {
                                        "title_aux": "Auto-MBW"
                                    }
                                ],
                                "https://github.com/taabata/Comfy_Syrian_Falcon_Nodes/raw/main/SyrianFalconNodes.py": [
                                    [
                                        "CompositeImage",
                                        "KSamplerAlternate",
                                        "KSamplerPromptEdit",
                                        "KSamplerPromptEditAndAlternate",
                                        "LoopBack",
                                        "QRGenerate",
                                        "WordAsImage"
                                    ],
                                    {
                                        "title_aux": "Syrian Falcon Nodes"
                                    }
                                ],
                                "https://github.com/taabata/LCM_Inpaint-Outpaint_Comfy": [
                                    [
                                        "ComfyNodesToSaveCanvas",
                                        "FloatNumber",
                                        "FreeU_LCM",
                                        "ImageOutputToComfyNodes",
                                        "ImageShuffle",
                                        "ImageSwitch",
                                        "LCMGenerate",
                                        "LCMGenerate_ReferenceOnly",
                                        "LCMGenerate_SDTurbo",
                                        "LCMGenerate_img2img",
                                        "LCMGenerate_img2img_IPAdapter",
                                        "LCMGenerate_img2img_controlnet",
                                        "LCMGenerate_inpaintv2",
                                        "LCMGenerate_inpaintv3",
                                        "LCMLoader",
                                        "LCMLoader_RefInpaint",
                                        "LCMLoader_ReferenceOnly",
                                        "LCMLoader_SDTurbo",
                                        "LCMLoader_controlnet",
                                        "LCMLoader_controlnet_inpaint",
                                        "LCMLoader_img2img",
                                        "LCMLoraLoader_inpaint",
                                        "LCMLoraLoader_ipadapter",
                                        "LCMLora_inpaint",
                                        "LCMLora_ipadapter",
                                        "LCMT2IAdapter",
                                        "LCM_IPAdapter",
                                        "LCM_IPAdapter_inpaint",
                                        "LCM_outpaint_prep",
                                        "LoadImageNode_LCM",
                                        "Loader_SegmindVega",
                                        "OutpaintCanvasTool",
                                        "SaveImage_Canvas",
                                        "SaveImage_LCM",
                                        "SaveImage_Puzzle",
                                        "SaveImage_PuzzleV2",
                                        "SegmindVega",
                                        "SettingsSwitch",
                                        "stitch"
                                    ],
                                    {
                                        "title_aux": "LCM_Inpaint-Outpaint_Comfy"
                                    }
                                ],
                                "https://github.com/talesofai/comfyui-browser": [
                                    [
                                        "DifyTextGenerator //Browser",
                                        "LoadImageByUrl //Browser",
                                        "SelectInputs //Browser",
                                        "UploadToRemote //Browser",
                                        "XyzPlot //Browser"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Browser"
                                    }
                                ],
                                "https://github.com/theUpsider/ComfyUI-Logic": [
                                    [
                                        "Bool",
                                        "Compare",
                                        "DebugPrint",
                                        "Float",
                                        "If ANY execute A else B",
                                        "Int",
                                        "String"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Logic"
                                    }
                                ],
                                "https://github.com/theUpsider/ComfyUI-Styles_CSV_Loader": [
                                    [
                                        "Load Styles CSV"
                                    ],
                                    {
                                        "title_aux": "Styles CSV Loader Extension for ComfyUI"
                                    }
                                ],
                                "https://github.com/thecooltechguy/ComfyUI-MagicAnimate": [
                                    [
                                        "MagicAnimate",
                                        "MagicAnimateModelLoader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-MagicAnimate"
                                    }
                                ],
                                "https://github.com/thecooltechguy/ComfyUI-Stable-Video-Diffusion": [
                                    [
                                        "SVDDecoder",
                                        "SVDModelLoader",
                                        "SVDSampler",
                                        "SVDSimpleImg2Vid"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Stable Video Diffusion"
                                    }
                                ],
                                "https://github.com/thedyze/save-image-extended-comfyui": [
                                    [
                                        "SaveImageExtended"
                                    ],
                                    {
                                        "title_aux": "Save Image Extended for ComfyUI"
                                    }
                                ],
                                "https://github.com/tocubed/ComfyUI-AudioReactor": [
                                    [
                                        "AudioFrameTransformBeats",
                                        "AudioFrameTransformShadertoy",
                                        "AudioLoadPath",
                                        "Shadertoy"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-AudioReactor"
                                    }
                                ],
                                "https://github.com/toyxyz/ComfyUI_toyxyz_test_nodes": [
                                    [
                                        "CaptureWebcam",
                                        "LatentDelay",
                                        "LoadWebcamImage",
                                        "SaveImagetoPath"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_toyxyz_test_nodes"
                                    }
                                ],
                                "https://github.com/trojblue/trNodes": [
                                    [
                                        "JpgConvertNode",
                                        "trColorCorrection",
                                        "trLayering",
                                        "trRouter",
                                        "trRouterLonger"
                                    ],
                                    {
                                        "title_aux": "trNodes"
                                    }
                                ],
                                "https://github.com/trumanwong/ComfyUI-NSFW-Detection": [
                                    [
                                        "NSFWDetection"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-NSFW-Detection"
                                    }
                                ],
                                "https://github.com/ttulttul/ComfyUI-Iterative-Mixer": [
                                    [
                                        "Batch Unsampler",
                                        "Iterative Mixing KSampler",
                                        "Iterative Mixing KSampler Advanced",
                                        "IterativeMixingSampler",
                                        "IterativeMixingScheduler",
                                        "IterativeMixingSchedulerAdvanced",
                                        "Latent Batch Comparison Plot",
                                        "Latent Batch Statistics Plot",
                                        "MixingMaskGenerator"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Iterative Mixing Nodes"
                                    }
                                ],
                                "https://github.com/ttulttul/ComfyUI-Tensor-Operations": [
                                    [
                                        "Image Match Normalize",
                                        "Latent Match Normalize"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Tensor-Operations"
                                    }
                                ],
                                "https://github.com/tudal/Hakkun-ComfyUI-nodes/raw/main/hakkun_nodes.py": [
                                    [
                                        "Any Converter",
                                        "Calculate Upscale",
                                        "Image Resize To Height",
                                        "Image Resize To Width",
                                        "Image size to string",
                                        "Load Random Image",
                                        "Load Text",
                                        "Multi Text Merge",
                                        "Prompt Parser",
                                        "Random Line",
                                        "Random Line 4"
                                    ],
                                    {
                                        "title_aux": "Hakkun-ComfyUI-nodes"
                                    }
                                ],
                                "https://github.com/tusharbhutt/Endless-Nodes": [
                                    [
                                        "ESS Aesthetic Scoring",
                                        "ESS Aesthetic Scoring Auto",
                                        "ESS Combo Parameterizer",
                                        "ESS Combo Parameterizer & Prompts",
                                        "ESS Eight Input Random",
                                        "ESS Eight Input Text Switch",
                                        "ESS Float to Integer",
                                        "ESS Float to Number",
                                        "ESS Float to String",
                                        "ESS Float to X",
                                        "ESS Global Envoy",
                                        "ESS Image Reward",
                                        "ESS Image Reward Auto",
                                        "ESS Image Saver with JSON",
                                        "ESS Integer to Float",
                                        "ESS Integer to Number",
                                        "ESS Integer to String",
                                        "ESS Integer to X",
                                        "ESS Number to Float",
                                        "ESS Number to Integer",
                                        "ESS Number to String",
                                        "ESS Number to X",
                                        "ESS Parameterizer",
                                        "ESS Parameterizer & Prompts",
                                        "ESS Six Float Output",
                                        "ESS Six Input Random",
                                        "ESS Six Input Text Switch",
                                        "ESS Six Integer IO Switch",
                                        "ESS Six Integer IO Widget",
                                        "ESS String to Float",
                                        "ESS String to Integer",
                                        "ESS String to Num",
                                        "ESS String to X",
                                        "\u267e\ufe0f\ud83c\udf0a\u2728 Image Saver with JSON"
                                    ],
                                    {
                                        "author": "BiffMunky",
                                        "description": "A small set of nodes I created for various numerical and text inputs.  Features image saver with ability to have JSON saved to separate folder, parameter collection nodes, two aesthetic scoring models, switches for text and numbers, and conversion of string to numeric and vice versa.",
                                        "nickname": "\u267e\ufe0f\ud83c\udf0a\u2728",
                                        "title": "Endless \ufe0f\ud83c\udf0a\u2728 Nodes",
                                        "title_aux": "Endless \ufe0f\ud83c\udf0a\u2728 Nodes"
                                    }
                                ],
                                "https://github.com/twri/sdxl_prompt_styler": [
                                    [
                                        "SDXLPromptStyler",
                                        "SDXLPromptStylerAdvanced"
                                    ],
                                    {
                                        "title_aux": "SDXL Prompt Styler"
                                    }
                                ],
                                "https://github.com/uarefans/ComfyUI-Fans": [
                                    [
                                        "Fans Prompt Styler Negative",
                                        "Fans Prompt Styler Positive",
                                        "Fans Styler",
                                        "Fans Text Concatenate"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Fans"
                                    }
                                ],
                                "https://github.com/vanillacode314/SimpleWildcardsComfyUI": [
                                    [
                                        "SimpleConcat",
                                        "SimpleWildcard"
                                    ],
                                    {
                                        "author": "VanillaCode314",
                                        "description": "A simple wildcard node for ComfyUI. Can also be used a style prompt node.",
                                        "nickname": "Simple Wildcard",
                                        "title": "Simple Wildcard",
                                        "title_aux": "Simple Wildcard"
                                    }
                                ],
                                "https://github.com/vienteck/ComfyUI-Chat-GPT-Integration": [
                                    [
                                        "ChatGptPrompt"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Chat-GPT-Integration"
                                    }
                                ],
                                "https://github.com/violet-chen/comfyui-psd2png": [
                                    [
                                        "Psd2Png"
                                    ],
                                    {
                                        "title_aux": "comfyui-psd2png"
                                    }
                                ],
                                "https://github.com/wallish77/wlsh_nodes": [
                                    [
                                        "Alternating KSampler (WLSH)",
                                        "Build Filename String (WLSH)",
                                        "CLIP +/- w/Text Unified (WLSH)",
                                        "CLIP Positive-Negative (WLSH)",
                                        "CLIP Positive-Negative XL (WLSH)",
                                        "CLIP Positive-Negative XL w/Text (WLSH)",
                                        "CLIP Positive-Negative w/Text (WLSH)",
                                        "Checkpoint Loader w/Name (WLSH)",
                                        "Empty Latent by Pixels (WLSH)",
                                        "Empty Latent by Ratio (WLSH)",
                                        "Empty Latent by Size (WLSH)",
                                        "Generate Border Mask (WLSH)",
                                        "Grayscale Image (WLSH)",
                                        "Image Load with Metadata (WLSH)",
                                        "Image Save with Prompt (WLSH)",
                                        "Image Save with Prompt File (WLSH)",
                                        "Image Save with Prompt/Info (WLSH)",
                                        "Image Save with Prompt/Info File (WLSH)",
                                        "Image Scale By Factor (WLSH)",
                                        "Image Scale by Shortside (WLSH)",
                                        "KSamplerAdvanced (WLSH)",
                                        "Multiply Integer (WLSH)",
                                        "Outpaint to Image (WLSH)",
                                        "Prompt Weight (WLSH)",
                                        "Quick Resolution Multiply (WLSH)",
                                        "Resolutions by Ratio (WLSH)",
                                        "SDXL Quick Empty Latent (WLSH)",
                                        "SDXL Quick Image Scale (WLSH)",
                                        "SDXL Resolutions (WLSH)",
                                        "SDXL Steps (WLSH)",
                                        "Save Positive Prompt(WLSH)",
                                        "Save Prompt (WLSH)",
                                        "Save Prompt/Info (WLSH)",
                                        "Seed and Int (WLSH)",
                                        "Seed to Number (WLSH)",
                                        "Simple Pattern Replace (WLSH)",
                                        "Simple String Combine (WLSH)",
                                        "Time String (WLSH)",
                                        "Upscale by Factor with Model (WLSH)",
                                        "VAE Encode for Inpaint w/Padding (WLSH)"
                                    ],
                                    {
                                        "title_aux": "wlsh_nodes"
                                    }
                                ],
                                "https://github.com/whatbirdisthat/cyberdolphin": [
                                    [
                                        "\ud83d\udc2c Gradio ChatInterface",
                                        "\ud83d\udc2c OpenAI Advanced",
                                        "\ud83d\udc2c OpenAI Compatible",
                                        "\ud83d\udc2c OpenAI DALL\u00b7E",
                                        "\ud83d\udc2c OpenAI Simple"
                                    ],
                                    {
                                        "title_aux": "cyberdolphin"
                                    }
                                ],
                                "https://github.com/whmc76/ComfyUI-Openpose-Editor-Plus": [
                                    [
                                        "CDL.OpenPoseEditorPlus"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Openpose-Editor-Plus"
                                    }
                                ],
                                "https://github.com/wmatson/easy-comfy-nodes": [
                                    [
                                        "EZAssocDictNode",
                                        "EZAssocImgNode",
                                        "EZAssocStrNode",
                                        "EZEmptyDictNode",
                                        "EZHttpPostNode",
                                        "EZLoadImgBatchFromUrlsNode",
                                        "EZLoadImgFromUrlNode",
                                        "EZRemoveImgBackground",
                                        "EZS3Uploader",
                                        "EZVideoCombiner"
                                    ],
                                    {
                                        "title_aux": "easy-comfy-nodes"
                                    }
                                ],
                                "https://github.com/wolfden/ComfyUi_PromptStylers": [
                                    [
                                        "SDXLPromptStylerAll",
                                        "SDXLPromptStylerHorror",
                                        "SDXLPromptStylerMisc",
                                        "SDXLPromptStylerbyArtist",
                                        "SDXLPromptStylerbyCamera",
                                        "SDXLPromptStylerbyComposition",
                                        "SDXLPromptStylerbyCyberpunkSurrealism",
                                        "SDXLPromptStylerbyDepth",
                                        "SDXLPromptStylerbyEnvironment",
                                        "SDXLPromptStylerbyFantasySetting",
                                        "SDXLPromptStylerbyFilter",
                                        "SDXLPromptStylerbyFocus",
                                        "SDXLPromptStylerbyImpressionism",
                                        "SDXLPromptStylerbyLighting",
                                        "SDXLPromptStylerbyMileHigh",
                                        "SDXLPromptStylerbyMood",
                                        "SDXLPromptStylerbyMythicalCreature",
                                        "SDXLPromptStylerbyOriginal",
                                        "SDXLPromptStylerbyQuantumRealism",
                                        "SDXLPromptStylerbySteamPunkRealism",
                                        "SDXLPromptStylerbySubject",
                                        "SDXLPromptStylerbySurrealism",
                                        "SDXLPromptStylerbyTheme",
                                        "SDXLPromptStylerbyTimeofDay",
                                        "SDXLPromptStylerbyWyvern",
                                        "SDXLPromptbyCelticArt",
                                        "SDXLPromptbyContemporaryNordicArt",
                                        "SDXLPromptbyFashionArt",
                                        "SDXLPromptbyGothicRevival",
                                        "SDXLPromptbyIrishFolkArt",
                                        "SDXLPromptbyRomanticNationalismArt",
                                        "SDXLPromptbySportsArt",
                                        "SDXLPromptbyStreetArt",
                                        "SDXLPromptbyVikingArt",
                                        "SDXLPromptbyWildlifeArt"
                                    ],
                                    {
                                        "title_aux": "SDXL Prompt Styler (customized version by wolfden)"
                                    }
                                ],
                                "https://github.com/wolfden/ComfyUi_String_Function_Tree": [
                                    [
                                        "StringFunction"
                                    ],
                                    {
                                        "title_aux": "ComfyUi_String_Function_Tree"
                                    }
                                ],
                                "https://github.com/wsippel/comfyui_ws/raw/main/sdxl_utility.py": [
                                    [
                                        "SDXLResolutionPresets"
                                    ],
                                    {
                                        "title_aux": "SDXLResolutionPresets"
                                    }
                                ],
                                "https://github.com/wutipong/ComfyUI-TextUtils": [
                                    [
                                        "Text Utils - Join N-Elements of String List",
                                        "Text Utils - Join String List",
                                        "Text Utils - Join Strings",
                                        "Text Utils - Split String to List"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-TextUtils"
                                    }
                                ],
                                "https://github.com/wwwins/ComfyUI-Simple-Aspect-Ratio": [
                                    [
                                        "SimpleAspectRatio"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Simple-Aspect-Ratio"
                                    }
                                ],
                                "https://github.com/xXAdonesXx/NodeGPT": [
                                    [
                                        "AppendAgent",
                                        "Assistant",
                                        "Chat",
                                        "ChatGPT",
                                        "CombineInput",
                                        "Conditioning",
                                        "CostumeAgent_1",
                                        "CostumeAgent_2",
                                        "CostumeMaster_1",
                                        "Critic",
                                        "DisplayString",
                                        "DisplayTextAsImage",
                                        "EVAL",
                                        "Engineer",
                                        "Executor",
                                        "GroupChat",
                                        "Image_generation_Conditioning",
                                        "LM_Studio",
                                        "LoadAPIconfig",
                                        "LoadTXT",
                                        "MemGPT",
                                        "Memory_Excel",
                                        "Model_1",
                                        "Ollama",
                                        "Output2String",
                                        "Planner",
                                        "Scientist",
                                        "TextCombine",
                                        "TextGeneration",
                                        "TextGenerator",
                                        "TextInput",
                                        "TextOutput",
                                        "UserProxy",
                                        "llama-cpp",
                                        "llava",
                                        "oobaboogaOpenAI"
                                    ],
                                    {
                                        "title_aux": "NodeGPT"
                                    }
                                ],
                                "https://github.com/xiaoxiaodesha/hd_node": [
                                    [
                                        "Combine HDMasks",
                                        "Cover HDMasks",
                                        "HD FaceIndex",
                                        "HD GetMaskArea",
                                        "HD Image Levels",
                                        "HD SmoothEdge",
                                        "HD UltimateSDUpscale"
                                    ],
                                    {
                                        "title_aux": "hd-nodes-comfyui"
                                    }
                                ],
                                "https://github.com/yffyhk/comfyui_auto_danbooru": [
                                    [
                                        "GetDanbooru",
                                        "TagEncode"
                                    ],
                                    {
                                        "title_aux": "comfyui_auto_danbooru"
                                    }
                                ],
                                "https://github.com/yolain/ComfyUI-Easy-Use": [
                                    [
                                        "dynamicThresholdingFull",
                                        "easy LLLiteLoader",
                                        "easy XYInputs: CFG Scale",
                                        "easy XYInputs: Checkpoint",
                                        "easy XYInputs: ControlNet",
                                        "easy XYInputs: Denoise",
                                        "easy XYInputs: Lora",
                                        "easy XYInputs: ModelMergeBlocks",
                                        "easy XYInputs: NegativeCond",
                                        "easy XYInputs: NegativeCondList",
                                        "easy XYInputs: PositiveCond",
                                        "easy XYInputs: PositiveCondList",
                                        "easy XYInputs: PromptSR",
                                        "easy XYInputs: Sampler/Scheduler",
                                        "easy XYInputs: Seeds++ Batch",
                                        "easy XYInputs: Steps",
                                        "easy XYPlot",
                                        "easy XYPlotAdvanced",
                                        "easy a1111Loader",
                                        "easy boolean",
                                        "easy cleanGpuUsed",
                                        "easy comfyLoader",
                                        "easy compare",
                                        "easy controlnetLoader",
                                        "easy controlnetLoaderADV",
                                        "easy convertAnything",
                                        "easy detailerFix",
                                        "easy float",
                                        "easy fooocusInpaintLoader",
                                        "easy fullLoader",
                                        "easy fullkSampler",
                                        "easy globalSeed",
                                        "easy hiresFix",
                                        "easy if",
                                        "easy imageInsetCrop",
                                        "easy imagePixelPerfect",
                                        "easy imageRemoveBG",
                                        "easy imageSave",
                                        "easy imageScaleDown",
                                        "easy imageScaleDownBy",
                                        "easy imageScaleDownToSize",
                                        "easy imageSize",
                                        "easy imageSizeByLongerSide",
                                        "easy imageSizeBySide",
                                        "easy imageSwitch",
                                        "easy imageToMask",
                                        "easy int",
                                        "easy isSDXL",
                                        "easy joinImageBatch",
                                        "easy kSampler",
                                        "easy kSamplerDownscaleUnet",
                                        "easy kSamplerInpainting",
                                        "easy kSamplerSDTurbo",
                                        "easy kSamplerTiled",
                                        "easy latentCompositeMaskedWithCond",
                                        "easy latentNoisy",
                                        "easy loraStack",
                                        "easy negative",
                                        "easy pipeIn",
                                        "easy pipeOut",
                                        "easy pipeToBasicPipe",
                                        "easy portraitMaster",
                                        "easy poseEditor",
                                        "easy positive",
                                        "easy preDetailerFix",
                                        "easy preSampling",
                                        "easy preSamplingAdvanced",
                                        "easy preSamplingDynamicCFG",
                                        "easy preSamplingSdTurbo",
                                        "easy promptList",
                                        "easy rangeFloat",
                                        "easy rangeInt",
                                        "easy samLoaderPipe",
                                        "easy seed",
                                        "easy showAnything",
                                        "easy showLoaderSettingsNames",
                                        "easy showSpentTime",
                                        "easy string",
                                        "easy stylesSelector",
                                        "easy svdLoader",
                                        "easy ultralyticsDetectorPipe",
                                        "easy unSampler",
                                        "easy wildcards",
                                        "easy xyAny",
                                        "easy zero123Loader"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Easy Use"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIComfyImageSubmit": [
                                    [
                                        "DTSimpleSubmitImage",
                                        "DTSubmitImage"
                                    ],
                                    {
                                        "title_aux": "Comfy AI DoubTech.ai Image Sumission Node"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIComfyLoaders": [
                                    [
                                        "DTCLIPLoader",
                                        "DTCLIPVisionLoader",
                                        "DTCheckpointLoader",
                                        "DTCheckpointLoaderSimple",
                                        "DTControlNetLoader",
                                        "DTDiffControlNetLoader",
                                        "DTDiffusersLoader",
                                        "DTGLIGENLoader",
                                        "DTLoadImage",
                                        "DTLoadImageMask",
                                        "DTLoadLatent",
                                        "DTLoraLoader",
                                        "DTLorasLoader",
                                        "DTStyleModelLoader",
                                        "DTUpscaleModelLoader",
                                        "DTVAELoader",
                                        "DTunCLIPCheckpointLoader"
                                    ],
                                    {
                                        "title_aux": "Comfy UI Online Loaders"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIComfyPromptAgent": [
                                    [
                                        "DTPromptAgent",
                                        "DTPromptAgentString"
                                    ],
                                    {
                                        "title_aux": "Comfy UI Prompt Agent"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIComfyQRCodes": [
                                    [
                                        "QRCode"
                                    ],
                                    {
                                        "title_aux": "Comfy UI QR Codes"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIComfyVariables": [
                                    [
                                        "DTCLIPTextEncode",
                                        "DTSingleLineStringVariable",
                                        "DTSingleLineStringVariableNoClip",
                                        "FloatVariable",
                                        "IntVariable",
                                        "StringFormat",
                                        "StringFormatSingleLine",
                                        "StringVariable"
                                    ],
                                    {
                                        "title_aux": "Variables for Comfy UI"
                                    }
                                ],
                                "https://github.com/yolanother/DTAIImageToTextNode": [
                                    [
                                        "DTAIImageToTextNode",
                                        "DTAIImageUrlToTextNode"
                                    ],
                                    {
                                        "title_aux": "Image to Text Node"
                                    }
                                ],
                                "https://github.com/youyegit/tdxh_node_comfyui": [
                                    [
                                        "TdxhBoolNumber",
                                        "TdxhClipVison",
                                        "TdxhControlNetApply",
                                        "TdxhControlNetProcessor",
                                        "TdxhFloatInput",
                                        "TdxhImageToSize",
                                        "TdxhImageToSizeAdvanced",
                                        "TdxhImg2ImgLatent",
                                        "TdxhIntInput",
                                        "TdxhLoraLoader",
                                        "TdxhOnOrOff",
                                        "TdxhReference",
                                        "TdxhStringInput",
                                        "TdxhStringInputTranslator"
                                    ],
                                    {
                                        "title_aux": "tdxh_node_comfyui"
                                    }
                                ],
                                "https://github.com/yuvraj108c/ComfyUI-Pronodes": [
                                    [
                                        "LoadYoutubeVideoNode"
                                    ],
                                    {
                                        "title_aux": "ComfyUI-Pronodes"
                                    }
                                ],
                                "https://github.com/yuvraj108c/ComfyUI-Whisper": [
                                    [
                                        "Add Subtitles To Background",
                                        "Add Subtitles To Frames",
                                        "Apply Whisper",
                                        "Resize Cropped Subtitles"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Whisper"
                                    }
                                ],
                                "https://github.com/zcfrank1st/Comfyui-Toolbox": [
                                    [
                                        "PreviewJson",
                                        "PreviewVideo",
                                        "SaveJson",
                                        "TestJsonPreview"
                                    ],
                                    {
                                        "title_aux": "Comfyui-Toolbox"
                                    }
                                ],
                                "https://github.com/zcfrank1st/Comfyui-Yolov8": [
                                    [
                                        "Yolov8Detection",
                                        "Yolov8Segmentation"
                                    ],
                                    {
                                        "title_aux": "ComfyUI Yolov8"
                                    }
                                ],
                                "https://github.com/zcfrank1st/comfyui_visual_anagrams": [
                                    [
                                        "VisualAnagramsAnimate",
                                        "VisualAnagramsSample"
                                    ],
                                    {
                                        "title_aux": "comfyui_visual_anagram"
                                    }
                                ],
                                "https://github.com/zer0TF/cute-comfy": [
                                    [
                                        "Cute.Placeholder"
                                    ],
                                    {
                                        "title_aux": "Cute Comfy"
                                    }
                                ],
                                "https://github.com/zfkun/ComfyUI_zfkun": [
                                    [
                                        "ZFLoadImagePath",
                                        "ZFPreviewText",
                                        "ZFPreviewTextMultiline",
                                        "ZFShareScreen",
                                        "ZFTextTranslation"
                                    ],
                                    {
                                        "title_aux": "ComfyUI_zfkun"
                                    }
                                ],
                                "https://github.com/zhongpei/ComfyUI-InstructIR": [
                                    [
                                        "InstructIRProcess",
                                        "LoadInstructIRModel"
                                    ],
                                    {
                                        "title_aux": "ComfyUI for InstructIR"
                                    }
                                ],
                                "https://github.com/zhongpei/Comfyui_image2prompt": [
                                    [
                                        "Image2Text",
                                        "LoadImage2TextModel"
                                    ],
                                    {
                                        "title_aux": "Comfyui_image2prompt"
                                    }
                                ],
                                "https://github.com/zhuanqianfish/ComfyUI-EasyNode": [
                                    [
                                        "EasyCaptureNode",
                                        "EasyVideoOutputNode",
                                        "SendImageWebSocket"
                                    ],
                                    {
                                        "title_aux": "EasyCaptureNode for ComfyUI"
                                    }
                                ],
                                "https://raw.githubusercontent.com/throttlekitty/SDXLCustomAspectRatio/main/SDXLAspectRatio.py": [
                                    [
                                        "SDXLAspectRatio"
                                    ],
                                    {
                                        "title_aux": "SDXLCustomAspectRatio"
                                    }
                                ]
                            }
                            """;
}
