using System;
using System.Collections.Generic;
namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, (string Name, Dictionary<EtwEventDescriptor, string> Events)> s_knownProviders = new()
        {

            { 
                MicrosoftApplicationInsightsCoreProvider.Id,
                (
                    MicrosoftApplicationInsightsCoreProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { MicrosoftApplicationInsightsCoreProvider.EventSourceMessageEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.EventSourceMessageEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.LogVerboseEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.LogVerboseEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.TelemetryClientConstructorWithNoTelemetryConfigurationEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.TelemetryClientConstructorWithNoTelemetryConfigurationEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.PopulateRequiredStringWithValueEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.PopulateRequiredStringWithValueEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.RequestTelemetryIncorrectDurationEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.RequestTelemetryIncorrectDurationEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.TrackingWasDisabledEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.TrackingWasDisabledEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.TrackingWasEnabledEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.TrackingWasEnabledEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.LogErrorEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.LogErrorEvent.Name },
                        { MicrosoftApplicationInsightsCoreProvider.BuildInfoConfigBrokenXmlErrorEvent.Descriptor, MicrosoftApplicationInsightsCoreProvider.BuildInfoConfigBrokenXmlErrorEvent.Name },
                    }
                )
            },

            { 
                MicrosoftVisualStudioCpsCoreProvider.Id,
                (
                    MicrosoftVisualStudioCpsCoreProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { MicrosoftVisualStudioCpsCoreProvider.EventSourceMessageEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.EventSourceMessageEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.CreateItemSchemaStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.CreateItemSchemaStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.CreateItemSchemaStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.CreateItemSchemaStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.PublishingProjectCapabilitiesEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.PublishingProjectCapabilitiesEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ConfiguredProjectVersionChangedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ConfiguredProjectVersionChangedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ReportPrioritySchedulerGapEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ReportPrioritySchedulerGapEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ReportProjectDataSourceVersionChangedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ReportProjectDataSourceVersionChangedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadSchemaFileStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadSchemaFileStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.PhysicalTreeLoadingStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.PhysicalTreeLoadingStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.BatchBuildStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.BatchBuildStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.BatchBuildStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.BatchBuildStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildSnapshotStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildSnapshotStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildSnapshotStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildSnapshotStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectSnapshotStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectSnapshotStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectSnapshotStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectSnapshotStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.SubscribeRuleStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.SubscribeRuleStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.SubscribeRuleStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.SubscribeRuleStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectConfigurationActivatedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectConfigurationActivatedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectConfigurationDeactivatedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectConfigurationDeactivatedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadSchemaFileStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadSchemaFileStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.CreatePropertyCatalogsStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.CreatePropertyCatalogsStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.CreatePropertyCatalogsStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.CreatePropertyCatalogsStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.HintSubmissionStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.HintSubmissionStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.HintSubmissionStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.HintSubmissionStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.HintProcessStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.HintProcessStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.HintProcessStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.HintProcessStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.AddSourceItemsStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.AddSourceItemsStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.AddSourceItemsStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.AddSourceItemsStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.RemoveSourceItemsStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.RemoveSourceItemsStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.RemoveSourceItemsStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.RemoveSourceItemsStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadConfiguredProjectStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadConfiguredProjectStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.LoadConfiguredProjectStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.LoadConfiguredProjectStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.PhysicalTreeLoadingStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.PhysicalTreeLoadingStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.DirectoryTreeLoadingStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.DirectoryTreeLoadingStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.DirectoryTreeLoadingStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.DirectoryTreeLoadingStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.SetActiveTreeProviderStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.SetActiveTreeProviderStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.SetActiveTreeProviderStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.SetActiveTreeProviderStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.InitializeActiveTreeProviderStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.InitializeActiveTreeProviderStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.InitializeActiveTreeProviderStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.InitializeActiveTreeProviderStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.CapabilitiesTriggersProjectReloadEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.CapabilitiesTriggersProjectReloadEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectGlobbingWatchingServiceInitializedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectGlobbingWatchingServiceInitializedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeDisposedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeDisposedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeAddSubscriptionEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeAddSubscriptionEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeReleaseSubscriptionEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectDirectoryTreeReleaseSubscriptionEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectEvaluationStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ProjectMarkDirtiedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ProjectMarkDirtiedEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildFallbackToLegacyEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.DesignTimeBuildFallbackToLegacyEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ReportOutputDataSourceStartEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ReportOutputDataSourceStartEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ReportOutputDataSourceStopEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ReportOutputDataSourceStopEvent.Name },
                        { MicrosoftVisualStudioCpsCoreProvider.ReportCoreDirectoryTreeHintFileChangedEvent.Descriptor, MicrosoftVisualStudioCpsCoreProvider.ReportCoreDirectoryTreeHintFileChangedEvent.Name },
                    }
                )
            },

            { 
                MicrosoftVisualStudioCpsVsProvider.Id,
                (
                    MicrosoftVisualStudioCpsVsProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { MicrosoftVisualStudioCpsVsProvider.EventSourceMessageEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.EventSourceMessageEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateProjectStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateProjectStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.SetInitialProjectConfigurationStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.SetInitialProjectConfigurationStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.InitializeProjectNodeStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.InitializeProjectNodeStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.InitializeProjectNodeStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.InitializeProjectNodeStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateProjectStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateProjectStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreeLoadingStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreeLoadingStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsNotifyTaskStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsNotifyTaskStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateUnconfiguredProjectStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateUnconfiguredProjectStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateUnconfiguredProjectStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateUnconfiguredProjectStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.SetInitialProjectConfigurationStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.SetInitialProjectConfigurationStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreePublishingStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreePublishingStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreePublishingStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreePublishingStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingLatestReferencesStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingLatestReferencesStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingLatestReferencesStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingLatestReferencesStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateProjectAsyncStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateProjectAsyncStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadInitialProjectTreeStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadInitialProjectTreeStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadInitialProjectTreeStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadInitialProjectTreeStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeCoreStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeCoreStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeCoreStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeCoreStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.TransferToBestProjectOwnerStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.TransferToBestProjectOwnerStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.TransferToBestProjectOwnerStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.TransferToBestProjectOwnerStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.SwitchToMainThreadToPublishTreeFailedEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.SwitchToMainThreadToPublishTreeFailedEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.NotifyBeforeSolutionClosingEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.NotifyBeforeSolutionClosingEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.NotifyQueryStatusDelayEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.NotifyQueryStatusDelayEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreeLoadingStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.WaitingProjectTreeLoadingStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllConfiguredProjectsStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllConfiguredProjectsStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllConfiguredProjectsStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllConfiguredProjectsStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllProjectNodesStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllProjectNodesStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadAllProjectNodesStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadAllProjectNodesStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadProjectsAndTreesStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadProjectsAndTreesStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.LoadProjectsAndTreesStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.LoadProjectsAndTreesStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.ResetDesignTimeBuilderEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.ResetDesignTimeBuilderEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsNotifyTaskStopEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsNotifyTaskStopEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsUpdateSubTypeStartEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsUpdateSubTypeStartEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.CpsUpdateSubTypeEndEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.CpsUpdateSubTypeEndEvent.Name },
                        { MicrosoftVisualStudioCpsVsProvider.ProjectReloadedInBackgroundEvent.Descriptor, MicrosoftVisualStudioCpsVsProvider.ProjectReloadedInBackgroundEvent.Name },
                    }
                )
            },

            { 
                MicrosoftVisualStudioThreadingProvider.Id,
                (
                    MicrosoftVisualStudioThreadingProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { MicrosoftVisualStudioThreadingProvider.EventSourceMessageEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.EventSourceMessageEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.CompleteOnCurrentThreadStopEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.CompleteOnCurrentThreadStopEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.WaitSynchronouslyStartEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.WaitSynchronouslyStartEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.WaitSynchronouslyStopEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.WaitSynchronouslyStopEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.PostExecutionStopEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.PostExecutionStopEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.CircularJoinableTaskDependencyDetectedEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.CircularJoinableTaskDependencyDetectedEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.ReaderWriterLockIssuedEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.ReaderWriterLockIssuedEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.WaitReaderWriterLockStartEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.WaitReaderWriterLockStartEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.WaitReaderWriterLockStopEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.WaitReaderWriterLockStopEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.CompleteOnCurrentThreadStartEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.CompleteOnCurrentThreadStartEvent.Name },
                        { MicrosoftVisualStudioThreadingProvider.PostExecutionStartEvent.Descriptor, MicrosoftVisualStudioThreadingProvider.PostExecutionStartEvent.Name },
                    }
                )
            },

            { 
                RoslynEventSourceProvider.Id,
                (
                    RoslynEventSourceProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { RoslynEventSourceProvider.EventSourceMessageEvent.Descriptor, RoslynEventSourceProvider.EventSourceMessageEvent.Name },
                        { RoslynEventSourceProvider.LogEvent.Descriptor, RoslynEventSourceProvider.LogEvent.Name },
                        { RoslynEventSourceProvider.BlockStartEvent.Descriptor, RoslynEventSourceProvider.BlockStartEvent.Name },
                        { RoslynEventSourceProvider.BlockStopEvent.Descriptor, RoslynEventSourceProvider.BlockStopEvent.Name },
                        { RoslynEventSourceProvider.SendFunctionDefinitionsEvent.Descriptor, RoslynEventSourceProvider.SendFunctionDefinitionsEvent.Name },
                        { RoslynEventSourceProvider.BlockCanceledEvent.Descriptor, RoslynEventSourceProvider.BlockCanceledEvent.Name },
                        { RoslynEventSourceProvider.OnEventCommandEvent.Descriptor, RoslynEventSourceProvider.OnEventCommandEvent.Name },
                    }
                )
            },

            { 
                StreamJsonRpcProvider.Id,
                (
                    StreamJsonRpcProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { StreamJsonRpcProvider.EventSourceMessageEvent.Descriptor, StreamJsonRpcProvider.EventSourceMessageEvent.Name },
                        { StreamJsonRpcProvider.SendingNotificationEvent.Descriptor, StreamJsonRpcProvider.SendingNotificationEvent.Name },
                        { StreamJsonRpcProvider.ReceivedResultEvent.Descriptor, StreamJsonRpcProvider.ReceivedResultEvent.Name },
                        { StreamJsonRpcProvider.ReceivedErrorEvent.Descriptor, StreamJsonRpcProvider.ReceivedErrorEvent.Name },
                        { StreamJsonRpcProvider.ReceivedNoResponseEvent.Descriptor, StreamJsonRpcProvider.ReceivedNoResponseEvent.Name },
                        { StreamJsonRpcProvider.SendingCancellationRequestEvent.Descriptor, StreamJsonRpcProvider.SendingCancellationRequestEvent.Name },
                        { StreamJsonRpcProvider.ReceivedNotificationEvent.Descriptor, StreamJsonRpcProvider.ReceivedNotificationEvent.Name },
                        { StreamJsonRpcProvider.SendingResultEvent.Descriptor, StreamJsonRpcProvider.SendingResultEvent.Name },
                        { StreamJsonRpcProvider.SendingErrorEvent.Descriptor, StreamJsonRpcProvider.SendingErrorEvent.Name },
                        { StreamJsonRpcProvider.ReceivedCancellationRequestEvent.Descriptor, StreamJsonRpcProvider.ReceivedCancellationRequestEvent.Name },
                        { StreamJsonRpcProvider.TransmissionQueuedEvent.Descriptor, StreamJsonRpcProvider.TransmissionQueuedEvent.Name },
                        { StreamJsonRpcProvider.TransmissionCompletedEvent.Descriptor, StreamJsonRpcProvider.TransmissionCompletedEvent.Name },
                        { StreamJsonRpcProvider.HandlerTransmittedEvent.Descriptor, StreamJsonRpcProvider.HandlerTransmittedEvent.Name },
                        { StreamJsonRpcProvider.HandlerReceivedEvent.Descriptor, StreamJsonRpcProvider.HandlerReceivedEvent.Name },
                        { StreamJsonRpcProvider.SendingRequestEvent.Descriptor, StreamJsonRpcProvider.SendingRequestEvent.Name },
                        { StreamJsonRpcProvider.ReceivedRequestEvent.Descriptor, StreamJsonRpcProvider.ReceivedRequestEvent.Name },
                    }
                )
            },

            { 
                System_Diagnostics_Eventing_FrameworkEventSourceProvider.Id,
                (
                    System_Diagnostics_Eventing_FrameworkEventSourceProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.EventSourceMessageEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.EventSourceMessageEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookupStartedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookupStartedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookingForResourceSetEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookingForResourceSetEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheUnexpectedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheUnexpectedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerStreamFoundEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerStreamFoundEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerStreamNotFoundEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerStreamNotFoundEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblySucceededEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblySucceededEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblyFailedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblyFailedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerManifestResourceAccessDeniedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerManifestResourceAccessDeniedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesSufficientEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesSufficientEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourceAttributeMissingEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourceAttributeMissingEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCreatingResourceSetEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCreatingResourceSetEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNotCreatingResourceSetEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNotCreatingResourceSetEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookupFailedEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerLookupFailedEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerReleasingResourcesEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerReleasingResourcesEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesNotFoundEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesNotFoundEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesFoundEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerNeutralResourcesFoundEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerAddingCultureFromConfigFileEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerAddingCultureFromConfigFileEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCultureNotFoundInConfigFileEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCultureNotFoundInConfigFileEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCultureFoundInConfigFileEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ResourceManagerCultureFoundInConfigFileEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadPoolEnqueueWorkEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadPoolEnqueueWorkEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadPoolDequeueWorkEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadPoolDequeueWorkEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetResponseStartEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetResponseStartEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetResponseStopEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetResponseStopEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetRequestStreamStartEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetRequestStreamStartEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetRequestStreamStopEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.GetRequestStreamStopEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferSendEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferSendEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferReceiveEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferReceiveEvent.Name },
                        { System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferReceiveHandledEvent.Descriptor, System_Diagnostics_Eventing_FrameworkEventSourceProvider.ThreadTransferReceiveHandledEvent.Name },
                    }
                )
            },

            { 
                System_Threading_Tasks_TplEventSourceProvider.Id,
                (
                    System_Threading_Tasks_TplEventSourceProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { System_Threading_Tasks_TplEventSourceProvider.EventSourceMessageEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.EventSourceMessageEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelLoopBeginEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelLoopBeginEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelLoopEndEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelLoopEndEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelInvokeBeginEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelInvokeBeginEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelInvokeEndEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelInvokeEndEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelForkEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelForkEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.ParallelJoinEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.ParallelJoinEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskScheduledEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskScheduledEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskStartedEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskStartedEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskCompletedEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskCompletedEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskWaitBeginEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskWaitBeginEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskWaitEndEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskWaitEndEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskWaitContinuationCompleteEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskWaitContinuationCompleteEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TaskWaitContinuationStartedEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TaskWaitContinuationStartedEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.AwaitTaskContinuationScheduledEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.AwaitTaskContinuationScheduledEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TraceOperationBeginEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TraceOperationBeginEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TraceOperationRelationEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TraceOperationRelationEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TraceOperationEndEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TraceOperationEndEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TraceSynchronousWorkBeginEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TraceSynchronousWorkBeginEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.TraceSynchronousWorkEndEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.TraceSynchronousWorkEndEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.RunningContinuationEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.RunningContinuationEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.RunningContinuationListEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.RunningContinuationListEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.DebugMessageEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.DebugMessageEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.DebugFacilityMessageEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.DebugFacilityMessageEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.DebugFacilityMessage1Event.Descriptor, System_Threading_Tasks_TplEventSourceProvider.DebugFacilityMessage1Event.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.SetActivityIdEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.SetActivityIdEvent.Name },
                        { System_Threading_Tasks_TplEventSourceProvider.NewIDEvent.Descriptor, System_Threading_Tasks_TplEventSourceProvider.NewIDEvent.Name },
                    }
                )
            },
        };
    }
}