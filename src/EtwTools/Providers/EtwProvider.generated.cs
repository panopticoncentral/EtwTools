using System;
using System.Collections.Generic;
namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, (string Name, Dictionary<EtwEventDescriptor, string> Events)> s_knownProviders = new()
        {
            { 
                DotnetProvider.Id,
                (
                    DotnetProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { DotnetProvider.AssemblyInfoEvent.Descriptor, DotnetProvider.AssemblyInfoEvent.Name },
                    }
                )
            },

            { 
                ApplicationInsightsCoreProvider.Id,
                (
                    ApplicationInsightsCoreProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { ApplicationInsightsCoreProvider.EventSourceMessageEvent.Descriptor, ApplicationInsightsCoreProvider.EventSourceMessageEvent.Name },
                        { ApplicationInsightsCoreProvider.LogVerboseEvent.Descriptor, ApplicationInsightsCoreProvider.LogVerboseEvent.Name },
                        { ApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.Descriptor, ApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.Name },
                        { ApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.Descriptor, ApplicationInsightsCoreProvider.DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.Name },
                        { ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.Descriptor, ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.Name },
                        { ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.Descriptor, ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.Name },
                        { ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.Descriptor, ApplicationInsightsCoreProvider.DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.Name },
                        { ApplicationInsightsCoreProvider.TelemetryClientConstructorWithNoTelemetryConfigurationEvent.Descriptor, ApplicationInsightsCoreProvider.TelemetryClientConstructorWithNoTelemetryConfigurationEvent.Name },
                        { ApplicationInsightsCoreProvider.PopulateRequiredStringWithValueEvent.Descriptor, ApplicationInsightsCoreProvider.PopulateRequiredStringWithValueEvent.Name },
                        { ApplicationInsightsCoreProvider.RequestTelemetryIncorrectDurationEvent.Descriptor, ApplicationInsightsCoreProvider.RequestTelemetryIncorrectDurationEvent.Name },
                        { ApplicationInsightsCoreProvider.TrackingWasDisabledEvent.Descriptor, ApplicationInsightsCoreProvider.TrackingWasDisabledEvent.Name },
                        { ApplicationInsightsCoreProvider.TrackingWasEnabledEvent.Descriptor, ApplicationInsightsCoreProvider.TrackingWasEnabledEvent.Name },
                        { ApplicationInsightsCoreProvider.LogErrorEvent.Descriptor, ApplicationInsightsCoreProvider.LogErrorEvent.Name },
                        { ApplicationInsightsCoreProvider.BuildInfoConfigBrokenXmlErrorEvent.Descriptor, ApplicationInsightsCoreProvider.BuildInfoConfigBrokenXmlErrorEvent.Name },
                    }
                )
            },

            { 
                VisualStudioCpsCoreProvider.Id,
                (
                    VisualStudioCpsCoreProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { VisualStudioCpsCoreProvider.EventSourceMessageEvent.Descriptor, VisualStudioCpsCoreProvider.EventSourceMessageEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildStopEvent.Name },
                        { VisualStudioCpsCoreProvider.CreateItemSchemaStartEvent.Descriptor, VisualStudioCpsCoreProvider.CreateItemSchemaStartEvent.Name },
                        { VisualStudioCpsCoreProvider.CreateItemSchemaStopEvent.Descriptor, VisualStudioCpsCoreProvider.CreateItemSchemaStopEvent.Name },
                        { VisualStudioCpsCoreProvider.PublishingProjectCapabilitiesEvent.Descriptor, VisualStudioCpsCoreProvider.PublishingProjectCapabilitiesEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStartEvent.Descriptor, VisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ConfiguredProjectVersionChangedEvent.Descriptor, VisualStudioCpsCoreProvider.ConfiguredProjectVersionChangedEvent.Name },
                        { VisualStudioCpsCoreProvider.ReportPrioritySchedulerGapEvent.Descriptor, VisualStudioCpsCoreProvider.ReportPrioritySchedulerGapEvent.Name },
                        { VisualStudioCpsCoreProvider.ReportProjectDataSourceVersionChangedEvent.Descriptor, VisualStudioCpsCoreProvider.ReportProjectDataSourceVersionChangedEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectEvaluationRuleSnapshotStopEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadSchemaFileStopEvent.Descriptor, VisualStudioCpsCoreProvider.LoadSchemaFileStopEvent.Name },
                        { VisualStudioCpsCoreProvider.PhysicalTreeLoadingStopEvent.Descriptor, VisualStudioCpsCoreProvider.PhysicalTreeLoadingStopEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStopEvent.Descriptor, VisualStudioCpsCoreProvider.LoadDynamicLoadComponentsStopEvent.Name },
                        { VisualStudioCpsCoreProvider.BatchBuildStartEvent.Descriptor, VisualStudioCpsCoreProvider.BatchBuildStartEvent.Name },
                        { VisualStudioCpsCoreProvider.BatchBuildStopEvent.Descriptor, VisualStudioCpsCoreProvider.BatchBuildStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildSnapshotStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildSnapshotStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildSnapshotStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildSnapshotStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectSnapshotStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectSnapshotStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectSnapshotStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectSnapshotStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectBuildRuleSnapshotStopEvent.Name },
                        { VisualStudioCpsCoreProvider.SubscribeRuleStartEvent.Descriptor, VisualStudioCpsCoreProvider.SubscribeRuleStartEvent.Name },
                        { VisualStudioCpsCoreProvider.SubscribeRuleStopEvent.Descriptor, VisualStudioCpsCoreProvider.SubscribeRuleStopEvent.Name },
                        { VisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStartEvent.Descriptor, VisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStartEvent.Name },
                        { VisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStopEvent.Descriptor, VisualStudioCpsCoreProvider.UpdateProjectRuleSnapshotStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectConfigurationActivatedEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectConfigurationActivatedEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectConfigurationDeactivatedEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectConfigurationDeactivatedEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectTreeProviderInitializationStopEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadSchemaFileStartEvent.Descriptor, VisualStudioCpsCoreProvider.LoadSchemaFileStartEvent.Name },
                        { VisualStudioCpsCoreProvider.CreatePropertyCatalogsStartEvent.Descriptor, VisualStudioCpsCoreProvider.CreatePropertyCatalogsStartEvent.Name },
                        { VisualStudioCpsCoreProvider.CreatePropertyCatalogsStopEvent.Descriptor, VisualStudioCpsCoreProvider.CreatePropertyCatalogsStopEvent.Name },
                        { VisualStudioCpsCoreProvider.HintSubmissionStartEvent.Descriptor, VisualStudioCpsCoreProvider.HintSubmissionStartEvent.Name },
                        { VisualStudioCpsCoreProvider.HintSubmissionStopEvent.Descriptor, VisualStudioCpsCoreProvider.HintSubmissionStopEvent.Name },
                        { VisualStudioCpsCoreProvider.HintProcessStartEvent.Descriptor, VisualStudioCpsCoreProvider.HintProcessStartEvent.Name },
                        { VisualStudioCpsCoreProvider.HintProcessStopEvent.Descriptor, VisualStudioCpsCoreProvider.HintProcessStopEvent.Name },
                        { VisualStudioCpsCoreProvider.AddSourceItemsStartEvent.Descriptor, VisualStudioCpsCoreProvider.AddSourceItemsStartEvent.Name },
                        { VisualStudioCpsCoreProvider.AddSourceItemsStopEvent.Descriptor, VisualStudioCpsCoreProvider.AddSourceItemsStopEvent.Name },
                        { VisualStudioCpsCoreProvider.RemoveSourceItemsStartEvent.Descriptor, VisualStudioCpsCoreProvider.RemoveSourceItemsStartEvent.Name },
                        { VisualStudioCpsCoreProvider.RemoveSourceItemsStopEvent.Descriptor, VisualStudioCpsCoreProvider.RemoveSourceItemsStopEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadConfiguredProjectStartEvent.Descriptor, VisualStudioCpsCoreProvider.LoadConfiguredProjectStartEvent.Name },
                        { VisualStudioCpsCoreProvider.LoadConfiguredProjectStopEvent.Descriptor, VisualStudioCpsCoreProvider.LoadConfiguredProjectStopEvent.Name },
                        { VisualStudioCpsCoreProvider.PhysicalTreeLoadingStartEvent.Descriptor, VisualStudioCpsCoreProvider.PhysicalTreeLoadingStartEvent.Name },
                        { VisualStudioCpsCoreProvider.DirectoryTreeLoadingStartEvent.Descriptor, VisualStudioCpsCoreProvider.DirectoryTreeLoadingStartEvent.Name },
                        { VisualStudioCpsCoreProvider.DirectoryTreeLoadingStopEvent.Descriptor, VisualStudioCpsCoreProvider.DirectoryTreeLoadingStopEvent.Name },
                        { VisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStartEvent.Descriptor, VisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStartEvent.Name },
                        { VisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStopEvent.Descriptor, VisualStudioCpsCoreProvider.WaitAutoLoadMethodsToFinishStopEvent.Name },
                        { VisualStudioCpsCoreProvider.SetActiveTreeProviderStartEvent.Descriptor, VisualStudioCpsCoreProvider.SetActiveTreeProviderStartEvent.Name },
                        { VisualStudioCpsCoreProvider.SetActiveTreeProviderStopEvent.Descriptor, VisualStudioCpsCoreProvider.SetActiveTreeProviderStopEvent.Name },
                        { VisualStudioCpsCoreProvider.InitializeActiveTreeProviderStartEvent.Descriptor, VisualStudioCpsCoreProvider.InitializeActiveTreeProviderStartEvent.Name },
                        { VisualStudioCpsCoreProvider.InitializeActiveTreeProviderStopEvent.Descriptor, VisualStudioCpsCoreProvider.InitializeActiveTreeProviderStopEvent.Name },
                        { VisualStudioCpsCoreProvider.CapabilitiesTriggersProjectReloadEvent.Descriptor, VisualStudioCpsCoreProvider.CapabilitiesTriggersProjectReloadEvent.Name },
                        { VisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStartEvent.Descriptor, VisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStartEvent.Name },
                        { VisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStopEvent.Descriptor, VisualStudioCpsCoreProvider.UnloadDynamicLoadComponentsStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectGlobbingWatchingServiceInitializedEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectGlobbingWatchingServiceInitializedEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStartEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStartEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStopEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingConsistentCheckStopEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStartEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStartEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStopEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectDirectoryTreeDisposedEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectDirectoryTreeDisposedEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectDirectoryTreeAddSubscriptionEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectDirectoryTreeAddSubscriptionEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectDirectoryTreeReleaseSubscriptionEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectDirectoryTreeReleaseSubscriptionEvent.Name },
                        { VisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStartEvent.Descriptor, VisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStartEvent.Name },
                        { VisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStopEvent.Descriptor, VisualStudioCpsCoreProvider.GetEvaluatedPropertyValueStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectEvaluationStartEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectEvaluationStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectEvaluationStopEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectEvaluationStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ProjectMarkDirtiedEvent.Descriptor, VisualStudioCpsCoreProvider.ProjectMarkDirtiedEvent.Name },
                        { VisualStudioCpsCoreProvider.DesignTimeBuildStartEvent.Descriptor, VisualStudioCpsCoreProvider.DesignTimeBuildStartEvent.Name },
                        { VisualStudioCpsCoreProvider.DesignTimeBuildStopEvent.Descriptor, VisualStudioCpsCoreProvider.DesignTimeBuildStopEvent.Name },
                        { VisualStudioCpsCoreProvider.DesignTimeBuildFallbackToLegacyEvent.Descriptor, VisualStudioCpsCoreProvider.DesignTimeBuildFallbackToLegacyEvent.Name },
                        { VisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStartEvent.Descriptor, VisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStartEvent.Name },
                        { VisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStopEvent.Descriptor, VisualStudioCpsCoreProvider.UpToDateCheckCalculateHashStopEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent.Name },
                        { VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent.Descriptor, VisualStudioCpsCoreProvider.GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent.Name },
                        { VisualStudioCpsCoreProvider.ReportOutputDataSourceStartEvent.Descriptor, VisualStudioCpsCoreProvider.ReportOutputDataSourceStartEvent.Name },
                        { VisualStudioCpsCoreProvider.ReportOutputDataSourceStopEvent.Descriptor, VisualStudioCpsCoreProvider.ReportOutputDataSourceStopEvent.Name },
                        { VisualStudioCpsCoreProvider.ReportCoreDirectoryTreeHintFileChangedEvent.Descriptor, VisualStudioCpsCoreProvider.ReportCoreDirectoryTreeHintFileChangedEvent.Name },
                    }
                )
            },

            { 
                VisualStudioCpsVsProvider.Id,
                (
                    VisualStudioCpsVsProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { VisualStudioCpsVsProvider.EventSourceMessageEvent.Descriptor, VisualStudioCpsVsProvider.EventSourceMessageEvent.Name },
                        { VisualStudioCpsVsProvider.CreateProjectStartEvent.Descriptor, VisualStudioCpsVsProvider.CreateProjectStartEvent.Name },
                        { VisualStudioCpsVsProvider.SetInitialProjectConfigurationStopEvent.Descriptor, VisualStudioCpsVsProvider.SetInitialProjectConfigurationStopEvent.Name },
                        { VisualStudioCpsVsProvider.InitializeProjectNodeStartEvent.Descriptor, VisualStudioCpsVsProvider.InitializeProjectNodeStartEvent.Name },
                        { VisualStudioCpsVsProvider.InitializeProjectNodeStopEvent.Descriptor, VisualStudioCpsVsProvider.InitializeProjectNodeStopEvent.Name },
                        { VisualStudioCpsVsProvider.CreateProjectStopEvent.Descriptor, VisualStudioCpsVsProvider.CreateProjectStopEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingProjectTreeLoadingStopEvent.Descriptor, VisualStudioCpsVsProvider.WaitingProjectTreeLoadingStopEvent.Name },
                        { VisualStudioCpsVsProvider.CpsNotifyTaskStartEvent.Descriptor, VisualStudioCpsVsProvider.CpsNotifyTaskStartEvent.Name },
                        { VisualStudioCpsVsProvider.CreateUnconfiguredProjectStartEvent.Descriptor, VisualStudioCpsVsProvider.CreateUnconfiguredProjectStartEvent.Name },
                        { VisualStudioCpsVsProvider.CreateUnconfiguredProjectStopEvent.Descriptor, VisualStudioCpsVsProvider.CreateUnconfiguredProjectStopEvent.Name },
                        { VisualStudioCpsVsProvider.SetInitialProjectConfigurationStartEvent.Descriptor, VisualStudioCpsVsProvider.SetInitialProjectConfigurationStartEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingProjectTreePublishingStartEvent.Descriptor, VisualStudioCpsVsProvider.WaitingProjectTreePublishingStartEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingProjectTreePublishingStopEvent.Descriptor, VisualStudioCpsVsProvider.WaitingProjectTreePublishingStopEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingLatestReferencesStartEvent.Descriptor, VisualStudioCpsVsProvider.WaitingLatestReferencesStartEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingLatestReferencesStopEvent.Descriptor, VisualStudioCpsVsProvider.WaitingLatestReferencesStopEvent.Name },
                        { VisualStudioCpsVsProvider.CreateProjectAsyncStartEvent.Descriptor, VisualStudioCpsVsProvider.CreateProjectAsyncStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadInitialProjectTreeStartEvent.Descriptor, VisualStudioCpsVsProvider.LoadInitialProjectTreeStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadInitialProjectTreeStopEvent.Descriptor, VisualStudioCpsVsProvider.LoadInitialProjectTreeStopEvent.Name },
                        { VisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStartEvent.Descriptor, VisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStartEvent.Name },
                        { VisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStopEvent.Descriptor, VisualStudioCpsVsProvider.CreateDynamicTypeFromRuleStopEvent.Name },
                        { VisualStudioCpsVsProvider.PublishProjectTreeCoreStartEvent.Descriptor, VisualStudioCpsVsProvider.PublishProjectTreeCoreStartEvent.Name },
                        { VisualStudioCpsVsProvider.PublishProjectTreeCoreStopEvent.Descriptor, VisualStudioCpsVsProvider.PublishProjectTreeCoreStopEvent.Name },
                        { VisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStartEvent.Descriptor, VisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStartEvent.Name },
                        { VisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStopEvent.Descriptor, VisualStudioCpsVsProvider.PublishProjectTreeAcquiringLockStopEvent.Name },
                        { VisualStudioCpsVsProvider.TransferToBestProjectOwnerStartEvent.Descriptor, VisualStudioCpsVsProvider.TransferToBestProjectOwnerStartEvent.Name },
                        { VisualStudioCpsVsProvider.TransferToBestProjectOwnerStopEvent.Descriptor, VisualStudioCpsVsProvider.TransferToBestProjectOwnerStopEvent.Name },
                        { VisualStudioCpsVsProvider.SwitchToMainThreadToPublishTreeFailedEvent.Descriptor, VisualStudioCpsVsProvider.SwitchToMainThreadToPublishTreeFailedEvent.Name },
                        { VisualStudioCpsVsProvider.NotifyBeforeSolutionClosingEvent.Descriptor, VisualStudioCpsVsProvider.NotifyBeforeSolutionClosingEvent.Name },
                        { VisualStudioCpsVsProvider.NotifyQueryStatusDelayEvent.Descriptor, VisualStudioCpsVsProvider.NotifyQueryStatusDelayEvent.Name },
                        { VisualStudioCpsVsProvider.WaitingProjectTreeLoadingStartEvent.Descriptor, VisualStudioCpsVsProvider.WaitingProjectTreeLoadingStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStartEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStopEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllUnconfiguredProjectsStopEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllConfiguredProjectsStartEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllConfiguredProjectsStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllConfiguredProjectsStopEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllConfiguredProjectsStopEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllProjectNodesStartEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllProjectNodesStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadAllProjectNodesStopEvent.Descriptor, VisualStudioCpsVsProvider.LoadAllProjectNodesStopEvent.Name },
                        { VisualStudioCpsVsProvider.LoadProjectsAndTreesStartEvent.Descriptor, VisualStudioCpsVsProvider.LoadProjectsAndTreesStartEvent.Name },
                        { VisualStudioCpsVsProvider.LoadProjectsAndTreesStopEvent.Descriptor, VisualStudioCpsVsProvider.LoadProjectsAndTreesStopEvent.Name },
                        { VisualStudioCpsVsProvider.ResetDesignTimeBuilderEvent.Descriptor, VisualStudioCpsVsProvider.ResetDesignTimeBuilderEvent.Name },
                        { VisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStartEvent.Descriptor, VisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStartEvent.Name },
                        { VisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStopEvent.Descriptor, VisualStudioCpsVsProvider.CpsHandlersBeforeCloseSolutionStopEvent.Name },
                        { VisualStudioCpsVsProvider.CpsNotifyTaskStopEvent.Descriptor, VisualStudioCpsVsProvider.CpsNotifyTaskStopEvent.Name },
                        { VisualStudioCpsVsProvider.CpsUpdateSubTypeStartEvent.Descriptor, VisualStudioCpsVsProvider.CpsUpdateSubTypeStartEvent.Name },
                        { VisualStudioCpsVsProvider.CpsUpdateSubTypeEndEvent.Descriptor, VisualStudioCpsVsProvider.CpsUpdateSubTypeEndEvent.Name },
                        { VisualStudioCpsVsProvider.ProjectReloadedInBackgroundEvent.Descriptor, VisualStudioCpsVsProvider.ProjectReloadedInBackgroundEvent.Name },
                    }
                )
            },

            { 
                VisualStudioThreadingProvider.Id,
                (
                    VisualStudioThreadingProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { VisualStudioThreadingProvider.EventSourceMessageEvent.Descriptor, VisualStudioThreadingProvider.EventSourceMessageEvent.Name },
                        { VisualStudioThreadingProvider.CompleteOnCurrentThreadStopEvent.Descriptor, VisualStudioThreadingProvider.CompleteOnCurrentThreadStopEvent.Name },
                        { VisualStudioThreadingProvider.WaitSynchronouslyStartEvent.Descriptor, VisualStudioThreadingProvider.WaitSynchronouslyStartEvent.Name },
                        { VisualStudioThreadingProvider.WaitSynchronouslyStopEvent.Descriptor, VisualStudioThreadingProvider.WaitSynchronouslyStopEvent.Name },
                        { VisualStudioThreadingProvider.PostExecutionStopEvent.Descriptor, VisualStudioThreadingProvider.PostExecutionStopEvent.Name },
                        { VisualStudioThreadingProvider.CircularJoinableTaskDependencyDetectedEvent.Descriptor, VisualStudioThreadingProvider.CircularJoinableTaskDependencyDetectedEvent.Name },
                        { VisualStudioThreadingProvider.ReaderWriterLockIssuedEvent.Descriptor, VisualStudioThreadingProvider.ReaderWriterLockIssuedEvent.Name },
                        { VisualStudioThreadingProvider.WaitReaderWriterLockStartEvent.Descriptor, VisualStudioThreadingProvider.WaitReaderWriterLockStartEvent.Name },
                        { VisualStudioThreadingProvider.WaitReaderWriterLockStopEvent.Descriptor, VisualStudioThreadingProvider.WaitReaderWriterLockStopEvent.Name },
                        { VisualStudioThreadingProvider.CompleteOnCurrentThreadStartEvent.Descriptor, VisualStudioThreadingProvider.CompleteOnCurrentThreadStartEvent.Name },
                        { VisualStudioThreadingProvider.PostExecutionStartEvent.Descriptor, VisualStudioThreadingProvider.PostExecutionStartEvent.Name },
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
                FrameworkEventSourceProvider.Id,
                (
                    FrameworkEventSourceProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { FrameworkEventSourceProvider.EventSourceMessageEvent.Descriptor, FrameworkEventSourceProvider.EventSourceMessageEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerLookupStartedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerLookupStartedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerLookingForResourceSetEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerLookingForResourceSetEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheUnexpectedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerFoundResourceSetInCacheUnexpectedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerStreamFoundEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerStreamFoundEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerStreamNotFoundEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerStreamNotFoundEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblySucceededEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblySucceededEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblyFailedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerGetSatelliteAssemblyFailedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerManifestResourceAccessDeniedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerManifestResourceAccessDeniedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerNeutralResourcesSufficientEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerNeutralResourcesSufficientEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerNeutralResourceAttributeMissingEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerNeutralResourceAttributeMissingEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerCreatingResourceSetEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerCreatingResourceSetEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerNotCreatingResourceSetEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerNotCreatingResourceSetEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerLookupFailedEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerLookupFailedEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerReleasingResourcesEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerReleasingResourcesEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerNeutralResourcesNotFoundEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerNeutralResourcesNotFoundEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerNeutralResourcesFoundEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerNeutralResourcesFoundEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerAddingCultureFromConfigFileEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerAddingCultureFromConfigFileEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerCultureNotFoundInConfigFileEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerCultureNotFoundInConfigFileEvent.Name },
                        { FrameworkEventSourceProvider.ResourceManagerCultureFoundInConfigFileEvent.Descriptor, FrameworkEventSourceProvider.ResourceManagerCultureFoundInConfigFileEvent.Name },
                        { FrameworkEventSourceProvider.ThreadPoolEnqueueWorkEvent.Descriptor, FrameworkEventSourceProvider.ThreadPoolEnqueueWorkEvent.Name },
                        { FrameworkEventSourceProvider.ThreadPoolDequeueWorkEvent.Descriptor, FrameworkEventSourceProvider.ThreadPoolDequeueWorkEvent.Name },
                        { FrameworkEventSourceProvider.GetResponseStartEvent.Descriptor, FrameworkEventSourceProvider.GetResponseStartEvent.Name },
                        { FrameworkEventSourceProvider.GetResponseStopEvent.Descriptor, FrameworkEventSourceProvider.GetResponseStopEvent.Name },
                        { FrameworkEventSourceProvider.GetRequestStreamStartEvent.Descriptor, FrameworkEventSourceProvider.GetRequestStreamStartEvent.Name },
                        { FrameworkEventSourceProvider.GetRequestStreamStopEvent.Descriptor, FrameworkEventSourceProvider.GetRequestStreamStopEvent.Name },
                        { FrameworkEventSourceProvider.ThreadTransferSendEvent.Descriptor, FrameworkEventSourceProvider.ThreadTransferSendEvent.Name },
                        { FrameworkEventSourceProvider.ThreadTransferReceiveEvent.Descriptor, FrameworkEventSourceProvider.ThreadTransferReceiveEvent.Name },
                        { FrameworkEventSourceProvider.ThreadTransferReceiveHandledEvent.Descriptor, FrameworkEventSourceProvider.ThreadTransferReceiveHandledEvent.Name },
                    }
                )
            },

            { 
                TplEventSourceProvider.Id,
                (
                    TplEventSourceProvider.Name, new Dictionary<EtwEventDescriptor, string>
                    {
                        { TplEventSourceProvider.EventSourceMessageEvent.Descriptor, TplEventSourceProvider.EventSourceMessageEvent.Name },
                        { TplEventSourceProvider.ParallelLoopBeginEvent.Descriptor, TplEventSourceProvider.ParallelLoopBeginEvent.Name },
                        { TplEventSourceProvider.ParallelLoopEndEvent.Descriptor, TplEventSourceProvider.ParallelLoopEndEvent.Name },
                        { TplEventSourceProvider.ParallelInvokeBeginEvent.Descriptor, TplEventSourceProvider.ParallelInvokeBeginEvent.Name },
                        { TplEventSourceProvider.ParallelInvokeEndEvent.Descriptor, TplEventSourceProvider.ParallelInvokeEndEvent.Name },
                        { TplEventSourceProvider.ParallelForkEvent.Descriptor, TplEventSourceProvider.ParallelForkEvent.Name },
                        { TplEventSourceProvider.ParallelJoinEvent.Descriptor, TplEventSourceProvider.ParallelJoinEvent.Name },
                        { TplEventSourceProvider.TaskScheduledEvent.Descriptor, TplEventSourceProvider.TaskScheduledEvent.Name },
                        { TplEventSourceProvider.TaskStartedEvent.Descriptor, TplEventSourceProvider.TaskStartedEvent.Name },
                        { TplEventSourceProvider.TaskCompletedEvent.Descriptor, TplEventSourceProvider.TaskCompletedEvent.Name },
                        { TplEventSourceProvider.TaskWaitBeginEvent.Descriptor, TplEventSourceProvider.TaskWaitBeginEvent.Name },
                        { TplEventSourceProvider.TaskWaitEndEvent.Descriptor, TplEventSourceProvider.TaskWaitEndEvent.Name },
                        { TplEventSourceProvider.TaskWaitContinuationCompleteEvent.Descriptor, TplEventSourceProvider.TaskWaitContinuationCompleteEvent.Name },
                        { TplEventSourceProvider.TaskWaitContinuationStartedEvent.Descriptor, TplEventSourceProvider.TaskWaitContinuationStartedEvent.Name },
                        { TplEventSourceProvider.AwaitTaskContinuationScheduledEvent.Descriptor, TplEventSourceProvider.AwaitTaskContinuationScheduledEvent.Name },
                        { TplEventSourceProvider.TraceOperationBeginEvent.Descriptor, TplEventSourceProvider.TraceOperationBeginEvent.Name },
                        { TplEventSourceProvider.TraceOperationRelationEvent.Descriptor, TplEventSourceProvider.TraceOperationRelationEvent.Name },
                        { TplEventSourceProvider.TraceOperationEndEvent.Descriptor, TplEventSourceProvider.TraceOperationEndEvent.Name },
                        { TplEventSourceProvider.TraceSynchronousWorkBeginEvent.Descriptor, TplEventSourceProvider.TraceSynchronousWorkBeginEvent.Name },
                        { TplEventSourceProvider.TraceSynchronousWorkEndEvent.Descriptor, TplEventSourceProvider.TraceSynchronousWorkEndEvent.Name },
                        { TplEventSourceProvider.RunningContinuationEvent.Descriptor, TplEventSourceProvider.RunningContinuationEvent.Name },
                        { TplEventSourceProvider.RunningContinuationListEvent.Descriptor, TplEventSourceProvider.RunningContinuationListEvent.Name },
                        { TplEventSourceProvider.DebugMessageEvent.Descriptor, TplEventSourceProvider.DebugMessageEvent.Name },
                        { TplEventSourceProvider.DebugFacilityMessageEvent.Descriptor, TplEventSourceProvider.DebugFacilityMessageEvent.Name },
                        { TplEventSourceProvider.DebugFacilityMessage1Event.Descriptor, TplEventSourceProvider.DebugFacilityMessage1Event.Name },
                        { TplEventSourceProvider.SetActivityIdEvent.Descriptor, TplEventSourceProvider.SetActivityIdEvent.Name },
                        { TplEventSourceProvider.NewIDEvent.Descriptor, TplEventSourceProvider.NewIDEvent.Name },
                    }
                )
            },
        };
    }
}